using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class FlagStateController : StateControllerKernelNew<FlagSpriteState, StaticMotionStateNew>
    {

        public void Flag()
        {
            SpriteState.SetFlag();
        }
    }
}
