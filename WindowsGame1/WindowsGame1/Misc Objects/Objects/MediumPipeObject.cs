using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class MediumPipeObject : GreenPipeObject, IPipe
    {

        public MediumPipeObject()
        {
            StateController.SpriteState.MediumPipe();
        }
    }
}
