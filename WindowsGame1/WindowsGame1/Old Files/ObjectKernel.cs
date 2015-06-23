using System;
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

        protected TSpriteState SpriteState { get; set; }
        protected TMotionState MotionState { get; set; }
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

        protected ObjectKernel(WorldManager world)
        {
            World = world;
            CollisionHandler = new NullCollisionHandler(SpriteState, MotionState, this);
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
            CollisionHandler.Handle();
            SyncState();
            SpriteState.Update();
            MotionState.Update();
            if (CollisionHandler != null) CollisionHandler.DetectBarrier();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            SpriteState.Sprite.Draw(spriteBatch, MotionState.Position, SpriteState.Color);
        }

        public void PassCommand(ICommand command)
        {
            CommandHandler.ReadCommand(command);
        }
    }
}