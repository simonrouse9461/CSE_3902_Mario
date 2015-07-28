using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class SmallPipeObject : GreenPipeObject, IPipe
    {

        public SmallPipeObject()
        {
            StateController.SpriteState.SmallPipe();
        }

        public static SmallPipeObject SmallWarp
        {
            get
            {
                var instance = new SmallPipeObject();
                instance.Core.StateController.isWarp();
                return instance;
            }
        }
    }
}
