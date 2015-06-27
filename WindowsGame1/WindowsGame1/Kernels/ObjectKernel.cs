using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    public abstract class ObjectKernel<TSpriteState, TMotionState> : IObject
        where TSpriteState : SpriteStateKernel
        where TMotionState : MotionStateKernel
    {
        private TSpriteState spriteState;
        private TMotionState motionState;
        private BarrierDetector barrierDetector;

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
                barrierDetector.MotionState = value;
            }
        }

        protected ICommandHandler CommandHandler { get; set; }
        protected ICollisionHandler CollisionHandler { get; set; }

        public virtual bool Solid
        {
            get { return true; }
        }

        public virtual bool Stealth
        {
            get { return false; }
        }

        public Rectangle PositionRectangle
        {
            get { return SpriteState.Sprite.GetDestination(MotionState.Position); }
        }

        public Vector2 PositionPoint
        {
            get { return MotionState.Position; }
        }

        protected ObjectKernel()
        {
            barrierDetector = new BarrierDetector(this, MotionState);
            State = new State<TSpriteState, TMotionState>
            {
                Object = this,
                BarrierDetector = barrierDetector
            };
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

        public void Unload()
        {
            State.DelayCommand(state => WorldManager.Instance.ObjectList.Remove(this));
        }

        public void Update()
        {
            State.Update();
            if (CommandHandler != null) CommandHandler.Handle();
            SyncState();
            if (CollisionHandler != null) CollisionHandler.Handle();
            SyncState();
            SpriteState.Update();
            MotionState.Update();
            barrierDetector.Detect();
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