using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    public struct SpriteTransformation
    {
        public int Index;
        public SpriteEffects Effect;
        public float Rotation;
        public Color Color;
        public int Scale;

        public SpriteTransformation(int index = 0, SpriteEffects effect = SpriteEffects.None, float rotation = 0,
            Color? color = null, int scale = 1)
        {
            Index = index;
            Effect = effect;
            Rotation = rotation;
            Color = color ?? Color.White;
            Scale = scale;
        }
    }
}