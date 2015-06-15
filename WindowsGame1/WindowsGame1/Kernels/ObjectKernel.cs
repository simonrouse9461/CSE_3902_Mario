using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    public abstract class ObjectKernel<TSpriteState, TMotionState> : IObject
        where TSpriteState : ISpriteState 
        where TMotionState : IMotionState 
    {
        public WorldManager World { get; set; }

        protected TSpriteState SpriteState;

        protected TMotionState MotionState;

        protected ICollisionHandler CollisionHandler;

        protected ObjectKernel(Vector2 location)
        {
            Initialize(location);
            Reset();
        }

        protected abstract void Initialize(Vector2 location);

        public virtual void Reset()
        {
            SpriteState.Reset();
            MotionState.Reset();
        }

        public void Load(ContentManager content)
        {
            SpriteState.Load(content);
        }

        public void Update()
        {
            SpriteState.Update();
            MotionState.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            SpriteState.ActiveSprite().Draw(spriteBatch, MotionState.Position);
        }

        public void PassCommand(ICommand command)
        {
            
        }

        public Rectangle GetPositionRectangle()
        {
            return SpriteState.ActiveSprite().GetDestination(MotionState.Position);
        }

        public Vector2 GetPositionPoint()
        {
            return MotionState.Position;
        }
    }
}