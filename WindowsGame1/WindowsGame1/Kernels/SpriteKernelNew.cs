using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public abstract class SpriteKernelNew : ISprite
    {
        // Sprite source information
        protected SpriteSourceNew Source;

        // A structure that defines how does the sprite animate
        protected SpriteAnimation Animation;

        // Constructor
        public SpriteKernelNew()
        {
            Initialize();
            Reset();
        }

        // Initialize sprite properties.
        protected abstract void Initialize();

        // Reset states.
        public void Reset()
        {
            Animation.Reset();
        }

        // Load image content.
        public abstract void Load(ContentManager content);

        // Update state.
        public void Update()
        {
            Animation.Update();
        }

        // Draw on the canvas.
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = Source.Coodinates[Animation.GetValue()];
            Rectangle destinationRectangle = new Rectangle(
                (int)location.X - Source.Coodinates[Animation.GetValue()].Width/2,
                (int)location.Y - Source.Coodinates[Animation.GetValue()].Height,
                Source.Coodinates[Animation.GetValue()].Width,
                Source.Coodinates[Animation.GetValue()].Height
                );
            spriteBatch.Draw(Source.Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}