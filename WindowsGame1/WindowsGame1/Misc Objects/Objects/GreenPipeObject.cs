using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class GreenPipeObject : ObjectKernel<PipeStateController>, IPipe
    {

        public GreenPipeObject()
        {
            StateController.SpriteState.TallPipe();                
        }
       
        public static GreenPipeObject WarpPipe
        {
            get
            {
                var instance = new GreenPipeObject();
                instance.Core.StateController.isWarp();
                return instance;
            }
        }
    }
}
