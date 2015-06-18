using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public abstract class SpriteKernel : ISprite
    {
        protected SpriteSource Source { get; set; }
        protected PeriodicFunction<int> Animation { get; set; }

        protected SpriteKernel()
        {
            Initialize(); 

            Animation = Animation ?? new PeriodicFunction<int>();

            Reset();
        }

        protected abstract void Initialize();

        public void Reset()
        {
            Animation.Reset();
        }

        public abstract void Load(ContentManager content);

        public void Update()
        {
            Animation.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = Source.Coodinates[Animation.GetValue()];
            Rectangle destinationRectangle = GetDestination(location);
            spriteBatch.Draw(Source.Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public Rectangle GetDestination(Vector2 location)
        {
            return new Rectangle(
                (int)location.X - Source.Coodinates[Animation.GetValue()].Width/2,
                (int)location.Y - Source.Coodinates[Animation.GetValue()].Height,
                Source.Coodinates[Animation.GetValue()].Width,
                Source.Coodinates[Animation.GetValue()].Height
                );
        }
    }
}