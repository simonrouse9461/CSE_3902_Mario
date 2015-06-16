using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    public abstract class ObjectKernelNew : IObject
    {
        protected ISpriteState SpriteState;

        protected IMotionState MotionState;

        protected ICommandHandler CommandHandler;

        protected ICollisionHandler CollisionHandler;

        protected ObjectKernelNew(Vector2 location)
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
            CommandHandler.Handle();
            CollisionHandler.Handle();
            SpriteState.Update();
            MotionState.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            SpriteState.ActiveSprite().Draw(spriteBatch, MotionState.Position);
        }

        public void PassCommand(ICommand command)
        {
            CommandHandler.ReadCommand(command);
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