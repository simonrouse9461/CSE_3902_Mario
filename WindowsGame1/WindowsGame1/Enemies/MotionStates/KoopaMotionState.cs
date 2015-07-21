using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Collections.ObjectModel;

namespace MarioGame
{
    public class KoopaMotionState : MotionStateKernelNew
    {
        private enum MotionEnum
        {
            None,
            LeftWalk,
            RightWalk,
            LeftShellKick,
            RightShellKick,
            Flip
        }

        private MotionEnum MotionStatus;
        public bool Gravity { get; private set; }

        public KoopaMotionState()
        {
            MotionList = new Collection<StatusSwitch<IMotion>>
            {
                new StatusSwitch<IMotion>(UniformMotion.EnemyMoveLeft),
                new StatusSwitch<IMotion>(UniformMotion.EnemyMoveRight),
                new StatusSwitch<IMotion>(UniformMotion.KoopaSlipLeft),
                new StatusSwitch<IMotion>(UniformMotion.KoopaSlipRight),
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
//            if (OutgoingMotionStatus != MotionEnum.Null) {
//                if (OutgoingMotionStatus == MotionEnum.LeftWalk)
//                {
//                    FindMotion<MoveLeftMotion>().Toggle(false);
//                }
//                else if (OutgoingMotionStatus == MotionEnum.RightWalk)
//                {
//                    FindMotion(UniformMotion.EnemyMoveRight).Toggle(false);
//                }
//
//                OutgoingMotionStatus = MotionEnum.Null;
//            }
//
//            switch (MotionStatus)
//            {
//                case MotionEnum.LeftWalk:
//                    FindMotion<MoveLeftMotion>().Toggle(true);
//                    break;
//                case MotionEnum.RightWalk:
//                    FindMotion(UniformMotion.EnemyMoveRight).Toggle(true);
//                    break;
//                case MotionEnum.LeftShellKick:
//                    FindMotion(UniformMotion.KoopaSlipLeft).Toggle(true);
//                    break;
//                case MotionEnum.RightShellKick:
//                    FindMotion(UniformMotion.KoopaSlipRight).Toggle(true);
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
            FindMotion(UniformMotion.EnemyMoveLeft).Toggle(true);
            FindMotion(UniformMotion.EnemyMoveRight).Toggle(false);
            FindMotion(UniformMotion.KoopaSlipLeft).Toggle(false);
            FindMotion(UniformMotion.KoopaSlipRight).Toggle(false);
        }

        public void SetDefaultVertical()
        {
            Gravity = false;
            FindMotion<GravityMotion>().Toggle(false);
            FindMotion<BounceUpMotion>().Toggle(false);
        }

        public void Turn(string leftOrRight)
        {
            if (leftOrRight.Equals("left"))
            {
                if (MotionStatus == MotionEnum.RightWalk)
                {
                    FindMotion(UniformMotion.EnemyMoveRight).Toggle(false);
                    FindMotion(UniformMotion.EnemyMoveLeft).Toggle(true);
                    MotionStatus = MotionEnum.LeftWalk;
                }
                else if (MotionStatus == MotionEnum.RightShellKick)
                {
                    FindMotion(UniformMotion.KoopaSlipRight).Toggle(false);
                    FindMotion(UniformMotion.KoopaSlipLeft).Toggle(true);
                    MotionStatus = MotionEnum.LeftShellKick;
                }
            }
            else if (leftOrRight.Equals("right"))
            {
                if (MotionStatus == MotionEnum.LeftWalk)
                {
                    FindMotion(UniformMotion.EnemyMoveRight).Toggle(true);
                    FindMotion(UniformMotion.EnemyMoveLeft).Toggle(false);
                    MotionStatus = MotionEnum.RightWalk;
                }
                else if (MotionStatus == MotionEnum.LeftShellKick)
                {
                    FindMotion(UniformMotion.KoopaSlipRight).Toggle(true);
                    FindMotion(UniformMotion.KoopaSlipLeft).Toggle(false);
                    MotionStatus = MotionEnum.RightShellKick;
                }
            }
            else
            {
                throw new System.ArgumentException("Parameter must be \"left\" or \"right\".", "leftOrRight");
            }
        }

        public void MarioSmash()
        {
            MotionStatus = MotionEnum.None;

            FindMotion(UniformMotion.EnemyMoveLeft).Toggle(false);
            FindMotion(UniformMotion.EnemyMoveRight).Toggle(false);
            FindMotion(UniformMotion.KoopaSlipRight).Toggle(false);
            FindMotion(UniformMotion.KoopaSlipLeft).Toggle(false);
        }

        public void TakeMarioHitFromSide(string leftOrRight)
        {
            if (MotionStatus == MotionEnum.None)
            {
                if (leftOrRight.Equals("left"))
                {
                    MotionStatus = MotionEnum.RightShellKick;
                    FindMotion(UniformMotion.KoopaSlipRight).Toggle(true);
                }
                else if (leftOrRight.Equals("right"))
                {
                    MotionStatus = MotionEnum.LeftShellKick;
                    FindMotion(UniformMotion.KoopaSlipLeft).Toggle(true);
                }
                else
                {
                    throw new System.ArgumentException("Parameter must be \"left\" or \"right\".", "leftOrRight");
                }
            }
            
        }

        public bool isMoving
        {
            get { return MotionStatus != MotionEnum.None;  }
        }

        public bool isDead()
        {
            return MotionStatus == MotionEnum.None || MotionStatus == MotionEnum.Flip;
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
            ObtainGravity();
        }
    }
}