using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class GreenPipeObject : ObjectKernelNew<PipeStateController>, IPipe
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
