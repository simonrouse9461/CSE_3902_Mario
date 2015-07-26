using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario
{
    public struct SpriteTransformation
    {
        public int Index;
        public SpriteEffects Effect;
        public float Rotation;
        public Color Color;
        public float Scale;
        public SpriteOrigin Origin;

        public SpriteTransformation(int index, SpriteEffects effect = SpriteEffects.None, double rotation = 0,
            Color? color = null, float scale = 1, SpriteOrigin origin = SpriteOrigin.Bottom)
        {
            Index = index;
            Effect = effect;
            Rotation = (float)rotation;
            Color = color ?? Color.White;
            Scale = scale;
            Origin = origin;
        }

        public static SpriteTransformation Center(int index, SpriteEffects effect = SpriteEffects.None, double rotation = 0,
            Color? color = null, float scale = 1)
        {
            return new SpriteTransformation(index, effect, rotation, color, scale, SpriteOrigin.Center);
        }

        public static SpriteTransformation Bottom(int index, SpriteEffects effect = SpriteEffects.None, double rotation = 0,
            Color? color = null, float scale = 1)
        {
            return new SpriteTransformation(index, effect, rotation, color, scale, SpriteOrigin.Bottom);
        }

        public static SpriteTransformation Top(int index, SpriteEffects effect = SpriteEffects.None, double rotation = 0,
            Color? color = null, float scale = 1)
        {
            return new SpriteTransformation(index, effect, rotation, color, scale, SpriteOrigin.Top);
        }

        public static SpriteTransformation Left(int index, SpriteEffects effect = SpriteEffects.None, double rotation = 0,
            Color? color = null, float scale = 1)
        {
            return new SpriteTransformation(index, effect, rotation, color, scale, SpriteOrigin.Left);
        }

        public static SpriteTransformation Right(int index, SpriteEffects effect = SpriteEffects.None, double rotation = 0,
            Color? color = null, float scale = 1)
        {
            return new SpriteTransformation(index, effect, rotation, color, scale, SpriteOrigin.Right);
        }
    }
}