using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    public abstract class ObjectKernel<TSpriteState, TMotionState> : IObject
        where TSpriteState : ISpriteState
        where TMotionState : IMotionState
    {
        private bool PrepareToUnload;
        private int UnloadCounter;
        private int TotalIterationsUntilUnload;

        protected TSpriteState SpriteState { get; set; }
        protected TMotionState MotionState { get; set; }
        protected ICommandHandler CommandHandler { get; set; }
        protected ICollisionHandler CollisionHandler { get; set; }

        public WorldManager World { get; private set; }

        public bool Solid { get; protected set; }

        public bool Active { get; set; }

        public Rectangle PositionRectangle
        {
            get { return SpriteState.Sprite.GetDestination(MotionState.Position); }
        }

        public Vector2 PositionPoint
        {
            get { return MotionState.Position; }
        }

        protected ObjectKernel(WorldManager world)
        {
            World = world;
            Solid = true;
            Active = true;
            Initialize();
            Reset();
        }

        protected abstract void Initialize();

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

        public void Unload(int unloadTimer)
        {
            this.PrepareToUnload = true;
            this.TotalIterationsUntilUnload = unloadTimer;
            this.UnloadCounter = 0;
        }

        public void Update()
        {
            if (World.ObjectList.Contains(this) && PrepareToUnload)
            {
                UnloadCounter++;
                if (UnloadCounter >= TotalIterationsUntilUnload)
                {
                    World.ObjectList.Remove(this);
                }
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
            SpriteState.Sprite.Draw(spriteBatch, MotionState.Position);
        }

        public void PassCommand(ICommand command)
        {
            CommandHandler.ReadCommand(command);
        }
    }
}