using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    public abstract class ObjectKernelNew : IObject
    {
        protected ObjectKernelNew(Vector2 location)
        {
            Reset(location);
        }

        protected abstract void Initialize(Vector2 location);

        public virtual void Reset(Vector2 location)
        {
            Initialize(location);
        }

        public abstract void Load(ContentManager content);

        public abstract void Update();

        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract Rectangle GetPosition();
    }
}