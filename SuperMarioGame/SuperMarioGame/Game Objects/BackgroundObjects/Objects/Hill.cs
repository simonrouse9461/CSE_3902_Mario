using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class Hill : BackgroundObjectKernel<HillSpriteState>
    {
        public static Hill Large
        {
            get
            {
                var instance = new Hill();
                instance.SpriteState.Large();
                return instance;
            }
        }

        public static Hill Small
        {
            get
            {
                var instance = new Hill();
                instance.SpriteState.Small();
                return instance;
            }
        }
    }
}
