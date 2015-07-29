using System;

namespace SuperMario
{
    public class HarpStateController : StateControllerKernel<HarpSpriteState, StaticMotionState>
    {
        private bool _wasInScreen;

        private bool WasInScreen
        {
            get { return _wasInScreen; }
            set
            {
                if (WasInScreen && !value) SoundManager.ResumeLastMusic(false);
                if (!WasInScreen && value) SoundManager.SwitchToHarpMusic();
                _wasInScreen = value;
            }
        }

        public override void Update()
        {
            WasInScreen = !Camera.OutOfRange(Core.Object);
        }

        public void Die()
        {
            Core.Object.Unload();
            SoundManager.SwitchToOverworldMusic();
        }
    }
}