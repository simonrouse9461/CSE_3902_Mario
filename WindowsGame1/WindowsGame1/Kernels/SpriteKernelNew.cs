using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public abstract class SpriteKernelNew : ISpriteNew
    {
        private const double UniversalScale = 1.75;

        protected Dictionary<int, SpriteSourceNew> SourceList { get; set; }
        protected PeriodicFunction<SpriteTransformation> Animation { get; set; }

        protected SortedList<Rectangle, Orientation> FrameData { get { return SourceList[Version].FrameData; } }
        protected Rectangle SourceCoodinates { get { return FrameData.ElementAt(Index).Key; } }
        protected Orientation SourceOrientation { get { return FrameData.ElementAt(Index).Value; } }
        protected Texture2D Texture { get { return SourceList[Version].Texture; } }
        protected int Index { get { return Animation.Value.Index; } }
        protected int Scale { get { return Animation.Value.Scale; } }
        protected float Rotation { get { return Animation.Value.Rotation; } }
        protected Color Color { get { return Animation.Value.Color; } }
        protected SpriteEffects Effect { get { return Animation.Value.Effect; } }

        public int Cycle { get; private set; }
        public int Version { get; private set; }

        public void SetVersion(int version)
        {
            Version = version;
        } 

        protected SpriteKernelNew()
        {
            SourceList = new Dictionary<int, SpriteSourceNew>();
            Animation = new PeriodicFunction<SpriteTransformation>(stage => new SpriteTransformation());
        }

        protected void AddSource(IConvertible version, string file, SortedList<Rectangle, Orientation> data)
        {
            SourceList.Add((int)version, new SpriteSourceNew(file)
            {
                FrameData = data
            });
        }

        protected void AddSource(string file, SortedList<Rectangle, Orientation> data)
        {
            AddSource(0, file, data);
        }

        protected void SetAnimation(SpriteTransformation[] transformation)
        {
            Animation = new PeriodicFunction<SpriteTransformation>(stage => transformation[stage], transformation.Length);
        }

        public void Reset()
        {
            Animation.Reset();
            Cycle = 0;
        }

        public void Load(ContentManager content)
        {
            foreach (var source in SourceList)
            {
                source.Value.Load(content);
            }
        }

        public void Update()
        {
            if (Animation.Update()) Cycle++;
        }

        private static SpriteEffects GetEffect(Orientation origin, Orientation goal)
        {
            if (origin == Orientation.Default || goal == Orientation.Default || origin == goal) return SpriteEffects.None;
            return SpriteEffects.FlipHorizontally;
        }

        private static KeyValuePair<SpriteEffects, float> MixEffect(SpriteEffects orientationEffect, SpriteEffects extraEffect)
        {
            if (orientationEffect == SpriteEffects.None) return new KeyValuePair<SpriteEffects, float>(extraEffect, 0);
            switch (extraEffect)
            {
                case SpriteEffects.FlipHorizontally:
                    return new KeyValuePair<SpriteEffects, float>(SpriteEffects.None, 0);
                case SpriteEffects.FlipVertically:
                    return new KeyValuePair<SpriteEffects, float>(SpriteEffects.None, (float)Math.PI);
                default:
                    return new KeyValuePair<SpriteEffects, float>(orientationEffect, 0);
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Orientation orientation, Color? color = null)
        {
            var orientationEffect = GetEffect(SourceOrientation, orientation);
            var mixedEffect = MixEffect(orientationEffect, Effect);
            var rotation = orientation == Orientation.Left ? mixedEffect.Value - Rotation : mixedEffect.Value + Rotation;

            if (color == null) color = Color;
            spriteBatch.Draw(Texture, GetDestination(location), SourceCoodinates, color.Value, rotation, default(Vector2), mixedEffect.Key, 1);
        }

        public Rectangle GetDestination(Vector2 location)
        {
            var width = SourceCoodinates.Width*Scale*UniversalScale;
            var height = SourceCoodinates.Height*Scale*UniversalScale;
            return new Rectangle(
                (int)(location.X - width/2),
                (int)(location.Y - height),
                (int)(width),
                (int)(height)
                );
        }
    }
}