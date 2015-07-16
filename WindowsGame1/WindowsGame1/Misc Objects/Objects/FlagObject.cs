using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class FlagObject : ObjectKernel<BlockStateController>
    {

        public FlagObject()
        {
            StateController.Flag();
        }
    }
}
