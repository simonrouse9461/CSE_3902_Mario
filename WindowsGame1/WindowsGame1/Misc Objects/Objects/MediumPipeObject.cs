using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class MediumPipeObject : GreenPipeObject, IPipe
    {

        public MediumPipeObject()
        {
            StateController.SpriteState.MediumPipe();
        }
    }
}
