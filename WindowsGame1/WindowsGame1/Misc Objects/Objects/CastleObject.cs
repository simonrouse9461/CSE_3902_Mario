using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class CastleObject : ObjectKernelNew<CastleStateController>
    {

        public CastleObject()
        {
            StateController.Castle();
        }
    }
}
