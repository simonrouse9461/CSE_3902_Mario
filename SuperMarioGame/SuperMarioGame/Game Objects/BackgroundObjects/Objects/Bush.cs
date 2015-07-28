using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class Bush : BackgroundObjectKernel<BushSpriteState>
    {
        public static Bush Head
        {
            get
            {
                var instance = new Bush();
                instance.SpriteState.Head();
                return instance;
            }
        }

        public static Bush Body
        {
            get
            {
                var instance = new Bush();
                instance.SpriteState.Body();
                return instance;
            }
        }

        public static Bush Tail
        {
            get
            {
                var instance = new Bush();
                instance.SpriteState.Tail();
                return instance;
            }
        }
    }
}