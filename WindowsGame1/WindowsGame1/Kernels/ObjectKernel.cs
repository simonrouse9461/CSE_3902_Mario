using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    public abstract class ObjectKernel<TSpriteState, TMotionState> : IObject
        where TSpriteState : ISpriteState 
        where TMotionState : IMotionState 
    {
        protected TSpriteState SpriteState;

        protected TMotionState MotionState;

        protected ObjectKernel(Vector2 location)
        {
            Reset(location);
        }

        protected abstract void Initialize(Vector2 location);

        public virtual void Reset(Vector2 location)
        {
            Initialize(location);
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
            SpriteState.ActiveSprite().Draw(spriteBatch, MotionState.CurrentLocation());
        }

        public Rectangle GetPosition()
        {
            return SpriteState.ActiveSprite().GetDestination(MotionState.CurrentLocation());
        }
    }
}