using System;

namespace WindowsGame1
{
    public class MushroomStateController : StateControllerKernel<MushroomSpriteState, MushroomMotionState>
    {
        private Collision collision;

        private void CheckFloor()
        {
            if (!collision.Bottom.Touch)
            {
                MotionState.ObtainGravity();
            }
            else
            {
                MotionState.LoseGravity();
            }
        }

        protected override void UpdateState()
        {
            collision = Core.CollisionDetector.Detect<IBlock>();
            CheckFloor();
        }
    }
}