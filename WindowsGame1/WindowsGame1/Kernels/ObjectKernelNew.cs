using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    public abstract class ObjectKernelNew<TSpriteState, TMotionState> : IObject
        where TSpriteState : SpriteStateKernelNew
        where TMotionState : MotionStateKernelNew
    {
        private bool PrepareToUnload;
        private int UnloadCounter;
        private TSpriteState spriteState;
        private TMotionState motionState;

        protected State<TSpriteState, TMotionState> State { get; private set; }

        // temporarily made for test cases
        public State<TSpriteState, TMotionState> StateGetter
        {
            get { return State; }
        }

        protected TSpriteState SpriteState
        {
            get { return spriteState; }
            set
            {
                spriteState = value;
                State.SpriteState = value;
            }
        }

        protected TMotionState MotionState
        {
            get { return motionState; }
            set
            {
                motionState = value;
                State.MotionState = value;
            }
        }

        protected ICommandHandler CommandHandler { get; set; }
        protected ICollisionHandlerNew CollisionHandler { get; set; }

        public WorldManager World { get; private set; }

        public virtual bool Solid
        {
            get { return true; }
        }

        public Rectangle PositionRectangle
        {
            get { return SpriteState.Sprite.GetDestination(MotionState.Position); }
        }

        public Vector2 PositionPoint
        {
            get { return MotionState.Position; }
        }

        protected ObjectKernelNew(WorldManager world)
        {
            World = world;
            State = new State<TSpriteState, TMotionState> { Object = this };
        }

        protected abstract void SyncState();

        public virtual void Reset()
        {
            SpriteState.Reset();
            MotionState.Reset();
        }

        public void Load(ContentManager content, Vector2 location)
        {
            SpriteState.Load(content);
            MotionState.Position = location;
        }

        public void Unload(int counter = 0)
        {
            PrepareToUnload = true;
            UnloadCounter = counter;
        }

        public void Update()
        {
            if (World.ObjectList.Contains(this) && PrepareToUnload)
            {
                UnloadCounter--;
                if (UnloadCounter == 0) World.ObjectList.Remove(this);
            }
            if (CommandHandler != null) CommandHandler.Handle();
            if (CollisionHandler != null) CollisionHandler.Handle();
            SyncState();
            SpriteState.Update();
            MotionState.Update();
            if (CollisionHandler != null) CollisionHandler.DetectBarrier();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (SpriteState.Left)
                SpriteState.Sprite.DrawLeft(spriteBatch, MotionState.Position, SpriteState.Color);
            else if (SpriteState.Right)
                SpriteState.Sprite.DrawRight(spriteBatch, MotionState.Position, SpriteState.Color);
            else
                SpriteState.Sprite.DrawDefault(spriteBatch, MotionState.Position, SpriteState.Color);
        }

        public void PassCommand(ICommand command)
        {
            CommandHandler.ReadCommand(command);
        }
    }
}