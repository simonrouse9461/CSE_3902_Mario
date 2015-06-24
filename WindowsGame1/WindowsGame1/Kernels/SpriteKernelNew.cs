﻿using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public abstract class SpriteKernelNew : ISpriteNew
    {
        protected SymmetricPair<SpriteSourceNew> Source { get; set; }
        protected SymmetricPair<PeriodicFunction<int>> Animation { get; set; }
        protected SymmetricPair<string> ImageFile { get; set; }

        protected SpriteKernelNew()
        {
            Source = new SymmetricPair<SpriteSourceNew>();
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
        }

        public void Load(ContentManager content)
        {
            if (Source.Default != null) { Source.Default.Load(content, ImageFile.Default); }
            if (Source.Default != null) { Source.Left.Load(content, ImageFile.Left); }
            if (Source.Default != null) { Source.Right.Load(content, ImageFile.Right); }
        }

        public void Update()
        {
            Animation.Left.Update();
            Animation.Right.Update();
        }

        private void Draw(SpriteBatch spriteBatch, Vector2 location, Color? color, SpriteSourceNew source, PeriodicFunction<int> animation)
        {
            if (color == null) color = Color.White;
            Rectangle sourceRectangle = source.Coordinates[animation.GetValue()];
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
            return new Rectangle(
                (int)location.X - Source.Default.Coordinates[Animation.Default.GetValue()].Width/2,
                (int)location.Y - Source.Default.Coordinates[Animation.Default.GetValue()].Height,
                Source.Default.Coordinates[Animation.Default.GetValue()].Width,
                Source.Default.Coordinates[Animation.Default.GetValue()].Height
                );
        }
    }
}