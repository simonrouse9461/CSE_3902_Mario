using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public static class GameSettings
    {
        public static float SpriteScale
        {
            get
            {
                return 1.75f;
            }
        }

        public static int MaxTime
        {
            get
            {
                return 120;
            }
        }

        public static SamplerState TextureSampling
        {
            get
            {
                return SamplerState.PointClamp;
            }
        }
    }
}