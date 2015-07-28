using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class MarioShadowSpriteState : SpriteStateKernelNew<int>
    {
        public MarioShadowSpriteState()
        {
            var c = Color.Black;
            AddColorScheme(0, new[]
            {
                c * 0.1f,
                c * 0.09f,
                c * 0.08f,
                c * 0.07f,
                c * 0.06f,
                c * 0.05f,
                c * 0.04f,
                c * 0.03f,
                c * 0.02f,
                c * 0.01f,
                c * 0
            });
            SetColorScheme(0);
            SetColorFrequency(3);
        }
    }
}