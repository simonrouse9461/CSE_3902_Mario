using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    public abstract class ObjectKernel<TSpriteState, TMotionState> : IObject
        where TSpriteState : ISpriteState
        where TMotionState : IMotionState
    {
        protected TSpriteState SpriteState { get; set; }
        protected TMotionState MotionState { get; set; }
        protected ICommandHandler CommandHandler { get; set; }
        protected ICollisionHandler CollisionHandler { get; set; }

        public WorldManager World { get; private set; }

        public bool Solid { get; private set; }

        public bool Effective { get; private set; }

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
            Effective = true;
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

        public void Unload()
        {
            if (World.ObjectList.Contains(this))
            {
                World.ObjectList.Remove(this);
            }
            
        }

        public void Update()
        {
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