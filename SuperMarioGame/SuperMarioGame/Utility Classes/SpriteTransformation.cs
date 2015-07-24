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
        public int Scale;

        public SpriteTransformation(int index, SpriteEffects effect = SpriteEffects.None, double rotation = 0,
            Color? color = null, int scale = 1)
        {
            Index = index;
            Effect = effect;
            Rotation = (float)rotation;
            Color = color ?? Color.White;
            Scale = scale;
        }
    }
}