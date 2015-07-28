using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class FlagPoleStateController : StateControllerKernelNew<FlagPoleSpriteState, StaticMotionStateNew>
    {

        public void FlagPole()
        {
            SpriteState.SetFlagPole();
        }
    }
}
