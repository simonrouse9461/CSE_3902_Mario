using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class Cloud : BackgroundObjectKernel<CloudSpriteState>
    {
        public static Cloud Head
        {
            get
            {
                var instance = new Cloud();
                instance.SpriteState.Head();
                return instance;
            }
        }

        public static Cloud Body
        {
            get
            {
                var instance = new Cloud();
                instance.SpriteState.Body();
                return instance;
            }
        }

        public static Cloud Tail
        {
            get
            {
                var instance = new Cloud();
                instance.SpriteState.Tail();
                return instance;
            }
        }
    }
}
