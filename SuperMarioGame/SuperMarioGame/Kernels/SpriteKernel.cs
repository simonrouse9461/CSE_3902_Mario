using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace SuperMario
{
    public abstract class SpriteKernel : ISprite
    {
        protected Dictionary<IConvertible, SpriteSource> SourceList { get; private set; }
        protected PeriodicFunction<SpriteTransformation> Animation { get; private set; }
        protected Orientation ReferenceOrientation { get; private set; }
        protected Collection<IConvertible> RegisteredVersion { get; private set; }

        protected OrderedPairs<Rectangle, Orientation> FrameData
        {
            get { return SourceList[Version].FrameData; }
        }

        protected Rectangle SourceCoodinates
        {
            get { return FrameData.KeyAt(Index); }
        }

        protected Orientation SourceOrientation
        {
            get { return FrameData.ValueAt(Index); }
        }

        protected Texture2D Texture
        {
            get { return SourceList[Version].Texture; }
        }

        protected int Index
        {
            get { return Animation.Value.Index; }
        }

        protected float Scale
        {
            get { return Animation.Value.Scale; }
        }

        protected float Rotation
        {
            get { return Animation.Value.Rotation; }
        }

        protected Color Color
        {
            get { return Animation.Value.Color; }
        }

        protected SpriteEffects Effect
        {
            get { return Animation.Value.Effect; }
        }

        protected SpriteOrigin Origin
        {
            get { return Animation.Value.Origin; }
        }

        public int Cycle { get { return Animation.Cycle; } }

        public float Width { get { return (int)(SourceCoodinates.Width*GameSettings.SpriteScale*Scale); } }

        public float Height { get { return (int)(SourceCoodinates.Height*GameSettings.SpriteScale*Scale); } }

        public IConvertible Version { get; private set; }

        public ISprite Clone
        {
            get
            {
                var copy = (SpriteKernel)MemberwiseClone();
                copy.Animation = Utility.DeepClone(Animation);
                return copy;
            }
        }

        public void SetVersion(IConvertible version)
        {
            if (RegisteredVersion.Contains(version)) Version = version;
        }

        protected SpriteKernel(IConvertible initialVersion)
        {
            SourceList = new Dictionary<IConvertible, SpriteSource>();
            Animation = new PeriodicFunction<SpriteTransformation>(stage => new SpriteTransformation(0));
            RegisteredVersion = new Collection<IConvertible>();
            Version = initialVersion;
        }

        protected SpriteKernel() : this(0) { }

        protected void AddSource(IConvertible version, string file, OrderedPairs<Rectangle, Orientation> data)
        {
            SourceList.Add(version, new SpriteSource(file)
            {
                FrameData = data
            });
            RegisteredVersion.Add(version);
        }

        protected void AddSource(string file, OrderedPairs<Rectangle, Orientation> data)
        {
            AddSource(0, file, data);
        }

        protected void AddSource(IConvertible version, string file, Rectangle coodinates, Orientation orientation)
        {
            AddSource(version, file, new OrderedPairs<Rectangle, Orientation>
            {
                {coodinates, orientation}
            });
        }

        protected void AddSource(string file, Rectangle coodinates, Orientation orientation)
        {
            AddSource(0, file, coodinates, orientation);
        }

        protected void AddSource(string file, Rectangle coodinates)
        {
            AddSource(0, file, coodinates, Orientation.Default);
        }

        protected void SetAnimation(Orientation reference, SpriteTransformation[] transformation)
        {
            ReferenceOrientation = reference;
            Animation = new PeriodicFunction<SpriteTransformation>(stage => transformation[stage], transformation.Length);
        }

        protected void SetAnimation(SpriteTransformation[] transformation)
        {
            SetAnimation(Orientation.Default, transformation);
        }

        public void Reset()
        {
            Animation.Reset();
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
            Animation.Update();
        }

        private static SpriteEffects GetEffect(Orientation origin, Orientation goal)
        {
            if (origin == Orientation.Default || goal == Orientation.Default || origin == goal)
                return SpriteEffects.None;
            return SpriteEffects.FlipHorizontally;
        }

        private static KeyValuePair<SpriteEffects, float> MixEffect(SpriteEffects orientationEffect,
            SpriteEffects extraEffect)
        {
            if (orientationEffect == SpriteEffects.None) return new KeyValuePair<SpriteEffects, float>(extraEffect, 0);
            switch (extraEffect)
            {
                case SpriteEffects.FlipHorizontally:
                    return new KeyValuePair<SpriteEffects, float>(SpriteEffects.None, 0);
                case SpriteEffects.FlipVertically:
                    return new KeyValuePair<SpriteEffects, float>(SpriteEffects.None, (float) Math.PI);
                default:
                    return new KeyValuePair<SpriteEffects, float>(orientationEffect, 0);
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Orientation orientation, IConvertible version, Color? color = null)
        {
            SetVersion(version);
            var orientationEffect = GetEffect(SourceOrientation, orientation);
            var mixedEffect = MixEffect(orientationEffect, Effect);
            var rotation = orientation == Orientation.Left ? mixedEffect.Value - Rotation : mixedEffect.Value + Rotation;

            if (color == null) color = Color;
            spriteBatch.Draw(Texture, GetScreenLocation(location, orientation), SourceCoodinates, color.Value, rotation,
                new Vector2((float)SourceCoodinates.Width/2, (float)SourceCoodinates.Height/2), GameSettings.SpriteScale*Scale, mixedEffect.Key, 1);
        }

        public Rectangle GetScreenDestination(Vector2 position, Orientation orientation)
        {
            var x = position.X - (CheckOrientation(orientation) ? ((int) Origin%3) : (2 - (int) Origin%3))*(Width/2);
            var y = position.Y - ((int) ((int) Origin/3))*(Height/2);
            return new Rectangle(
                (int) (x),
                (int) (y),
                (int) (Width),
                (int) (Height));
        }

        public Vector2 GetScreenLocation(Vector2 position, Orientation orientation)
        {
            var x = position.X - ((int) Origin%3 - 1)*(Width/2)*(CheckOrientation(orientation) ? 1 : -1);
            var y = position.Y - ((int) ((int) Origin/3) - 1)*(Height/2);
            return new Vector2(
                (int) (x),
                (int) (y));
        }

        private bool CheckOrientation(Orientation orientation)
        {
            return ReferenceOrientation == Orientation.Default || ReferenceOrientation == orientation;
        }
    }
}