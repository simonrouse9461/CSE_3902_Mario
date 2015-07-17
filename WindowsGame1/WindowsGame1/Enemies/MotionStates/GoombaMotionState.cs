using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class GoombaMotionState : MotionStateKernelNew
    {
        private enum MotionEnum
        {
            None,
            LeftWalk,
            RightWalk,
            Flip
        }

        private MotionEnum MotionStatus;
        public bool Gravity { get; private set; }

        public GoombaMotionState()
        {
            MotionList = new Collection<StatusSwitch<IMotion>>
            {
                new StatusSwitch<IMotion>(MoveLeftMotion.EnemyVelocity),
                new StatusSwitch<IMotion>(MoveRightMotion.EnemyVelocity),
                new StatusSwitch<IMotion>(new GravityMotion()),
                new StatusSwitch<IMotion>(BounceUpMotion.FireballBounce)
            };

            LoseGravity();
            SetDefaultVertical();
            SetDefaultHorizontal();
        }

        // this method has been abandoned

//        protected override void RefreshMotionStatus()
//        {
//            switch (MotionStatus)
//            {
//                case MotionEnum.None:
//                    FindMotion<MoveLeftMotion>().Toggle(false);
//                    FindMotion<MoveRightMotion>().Toggle(false);
//                    break;
//                case MotionEnum.LeftWalk:
//                    FindMotion<MoveLeftMotion>().Toggle(true);
//                    FindMotion<MoveRightMotion>().Toggle(false);
//                    break;
//                case MotionEnum.RightWalk:
//                    FindMotion<MoveLeftMotion>().Toggle(false);
//                    FindMotion<MoveRightMotion>().Toggle(true);
//                    break;
//            }
//
//            if (Gravity)
//            {
//                FindMotion<GravityMotion>().Toggle(true);
//            }
//            else
//            {
//                FindMotion<GravityMotion>().Toggle(false);
//            }
//        }
        public void SetDefaultHorizontal()
        {
            MotionStatus = MotionEnum.LeftWalk;
            FindMotion<MoveLeftMotion>().Toggle(true);
            FindMotion<MoveRightMotion>().Toggle(false);
        }

        public void SetDefaultVertical()
        {
            Gravity = false;
            FindMotion<GravityMotion>().Toggle(false);
            FindMotion<BounceUpMotion>().Toggle(false);
        }

        public void Turn()
        {
            if (MotionStatus == MotionEnum.LeftWalk)
            {
                FindMotion<MoveRightMotion>().Toggle(true);
                FindMotion<MoveLeftMotion>().Toggle(false);
                MotionStatus = MotionEnum.RightWalk;
            }
            else if (MotionStatus == MotionEnum.RightWalk)
            {
                FindMotion<MoveRightMotion>().Toggle(false);
                FindMotion<MoveLeftMotion>().Toggle(true);
                MotionStatus = MotionEnum.LeftWalk;
            }
        }


        public void MarioSmash()
        {
            MotionStatus = MotionEnum.None;
            FindMotion<MoveLeftMotion>().Toggle(false);
            FindMotion<MoveRightMotion>().Toggle(false);
        }


        public bool isAlive()
        {
            return MotionStatus != MotionEnum.None && MotionStatus != MotionEnum.Flip;
        }

        public void TakeMarioHitFromSide(string leftOrRight)
        {
            
        }

        public void ObtainGravity()
        {
            Gravity = true;
            FindMotion<GravityMotion>().Toggle(true);
        }

        public void LoseGravity()
        {
            Gravity = false;
            FindMotion<GravityMotion>().Toggle(false);
        }

        public void Flip()
        {
            MotionStatus = MotionEnum.Flip;
            FindMotion<BounceUpMotion>().Toggle(true);
        }
    }
}