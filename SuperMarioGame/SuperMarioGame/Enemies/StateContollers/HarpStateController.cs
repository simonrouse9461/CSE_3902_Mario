using System;

namespace SuperMario
{
    public class HarpStateController : StateControllerKernel<HarpSpriteState, HarpMotionState>
    {
        public override void Update()
        {
        }

        public void Die()
        {
            Core.DelayCommand(() =>
            {
                Core.Obj.Unload();
            });

            SoundManager.ChangeToOverworldMusic();
        }
    }
}