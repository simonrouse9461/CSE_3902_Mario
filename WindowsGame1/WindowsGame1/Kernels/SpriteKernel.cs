using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public abstract class SpriteKernel : ISprite
    {
        // Sprite source information
        protected SingleLineSpriteSource Source;

        // A structure that defines how does the sprite animate
        protected SpriteAnimation Animation;

        // Constructor
        public SpriteKernel()
        {
            Initialize();
            Reset();
        }

        // Initialize sprite properties.
        public abstract void Initialize();

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
            Rectangle sourceRectangle =
                new Rectangle((int) Source.StartCoordinate.X + Source.Width*Animation.GetValue(),
                    (int) Source.StartCoordinate.Y,
                    Source.Width, Source.Height);
            Rectangle destinationRectangle = new Rectangle((int) location.X, (int) location.Y, Source.Width,
                Source.Height);
            spriteBatch.Draw(Source.Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}