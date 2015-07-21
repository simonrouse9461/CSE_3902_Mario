using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MarioGame
{
    public class CastleObject : ObjectKernel<BlockStateController>
    {

        public CastleObject()
        {
            StateController.Castle();
        }
    }
}
