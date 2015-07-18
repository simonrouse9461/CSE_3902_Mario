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

        protected Dictionary<IConvertible, SpriteSourceNew> SourceList { get; private set; }
        protected PeriodicFunction<SpriteTransformation> Animation { get; private set; }
        protected Collection<IConvertible> RegisteredVersion { get; private set; }

        protected OrderedPairs<Rectangle, Orientation> FrameData { get { return SourceList[Version].FrameData; } }
        protected Rectangle SourceCoodinates { get { return FrameData.KeyAt(Index); } }
        protected Orientation SourceOrientation { get { return FrameData.ValueAt(Index); } }
        protected Texture2D Texture { get { return SourceList[Version].Texture; } }
        protected int Index { get { return Animation.Value.Index; } }
        protected int Scale { get { return Animation.Value.Scale; } }
        protected float Rotation { get { return Animation.Value.Rotation; } }
        protected Color Color { get { return Animation.Value.Color; } }
        protected SpriteEffects Effect { get { return Animation.Value.Effect; } }

        public int Cycle { get; private set; }
        public IConvertible Version { get; private set; }

        public void SetVersion(IConvertible version)
        {
            if(RegisteredVersion.Contains(version)) Version = version;
        } 

        protected SpriteKernelNew(IConvertible initialVersion)
        {
            SourceList = new Dictionary<IConvertible, SpriteSourceNew>();
            Animation = new PeriodicFunction<SpriteTransformation>(stage => new SpriteTransformation(0));
            RegisteredVersion = new Collection<IConvertible>();
            Version = initialVersion;
        }

        protected SpriteKernelNew() : this(0) { }

        protected void AddSource(IConvertible version, string file, OrderedPairs<Rectangle, Orientation> data)
        {
            SourceList.Add(version, new SpriteSourceNew(file)
            {
                FrameData = data
            });
            RegisteredVersion.Add(version);
        }

        protected void AddSource(string file, OrderedPairs<Rectangle, Orientation> data)
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