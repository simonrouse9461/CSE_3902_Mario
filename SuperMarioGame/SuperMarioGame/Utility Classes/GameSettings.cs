using Microsoft.Xna.Framework.Graphics;

namespace SuperMario
{
    public static class GameSettings
    {
        public const float SpriteScale = 2;
        public const int GridUnit = 16;
        public const int MaxTime = 120;

        public static int ScaledGridLength
        {
            get { return (int) SpriteScale*GridUnit; }
        }

        public static SamplerState TextureSampling
        {
            get { return SamplerState.PointClamp; }
        }
    }
}