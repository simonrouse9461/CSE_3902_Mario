using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace SuperMario
{
    public abstract class SpriteKernel : ISprite
    {
        private float SCALE = GameSettings.SpriteScale;
        protected SymmetricPair<SpriteSource> Source { get; set; }
        protected SymmetricPair<PeriodicFunction<int>> Animation { get; set; }
        protected SymmetricPair<string> ImageFile { get; set; }

        public int Cycle { get; private set; }

        protected SpriteKernel()
        {
            Source = new SymmetricPair<SpriteSource>();
            Animation = new SymmetricPair<PeriodicFunction<int>>
            {
                Default = new PeriodicFunction<int>()
            };
            ImageFile = new SymmetricPair<string>();
        }

        public void Reset()
        {
            Animation.Left.Reset();
            Animation.Right.Reset();
            Cycle = 0;
        }

        public void Load(ContentManager content)
        {
            if (Source.Default != null) { Source.Default.Load(content, ImageFile.Default); }
            if (Source.Left != null) { Source.Left.Load(content, ImageFile.Left); }
            if (Source.Right != null) { Source.Right.Load(content, ImageFile.Right); }
        }

        public void Update()
        {
            if (Animation.IsDefault)
            {
                if (Animation.Default.Update()) Cycle++; 
                return;
            }
            var leftCycleComplete = Animation.Left.Update();
            var rightCycleComplete = Animation.Right.Update();
            if (leftCycleComplete || rightCycleComplete) Cycle++;
        }

        private void Draw(SpriteBatch spriteBatch, Vector2 location, Color? color, SpriteSource source, PeriodicFunction<int> animation)
        {
            if (color == null) color = Color.White;
            Rectangle sourceRectangle = source.Coordinates[animation.Value];
            Rectangle destinationRectangle = GetDestination(location);
            spriteBatch.Draw(source.Texture, destinationRectangle, sourceRectangle, color.Value);
        }

        public void DrawLeft(SpriteBatch spriteBatch, Vector2 location, Color? color = null)
        {
            Draw(spriteBatch, location, color, Source.Left, Animation.Left);
        }

        public void DrawRight(SpriteBatch spriteBatch, Vector2 location, Color? color = null)
        {
            Draw(spriteBatch, location, color, Source.Right, Animation.Right);
        }

        public void DrawDefault(SpriteBatch spriteBatch, Vector2 location, Color? color = null)
        {
            Draw(spriteBatch, location, color, Source.Default, Animation.Default);
        }

        public Rectangle GetDestination(Vector2 location)
        {
            var width = Source.Default.Coordinates[Animation.Default.Value].Width*SCALE;
            var height = Source.Default.Coordinates[Animation.Default.Value].Height*SCALE;
            return new Rectangle(
                (int)(location.X - width/2),
                (int)(location.Y - height),
                (int)(width),
                (int)(height)
                );
        }
    }
}