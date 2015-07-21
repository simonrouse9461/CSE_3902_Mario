using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MarioGame
{
    public class FlagPoleObject : ObjectKernel<BlockStateController>
    {

        public FlagPoleObject()
        {
            StateController.Flag();
        }
    }
}
