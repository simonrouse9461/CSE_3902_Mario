using System;

namespace WindowsGame1
{
    public class MushroomStateController : StateControllerKernel<MushroomSpriteState, MushroomMotionState>
    {

        public void Generate()
        {
            MotionState.Generated();
        }

        public void StartMoving()
        {
            MotionState.Moving();
        }





        //private Collision collision;

        //private void CheckFloor()
        //{
        //    if (!collision.Bottom.Touch)
        //    {
        //        MotionState.ObtainGravity();
        //    }
        //    else
        //    {
        //        MotionState.LoseGravity();
        //    }
        //}

        //public void Update()
        //{
        //    collision = Core.CollisionDetector.Detect<IBlock>();
        //    CheckFloor();
        //}
    }
}