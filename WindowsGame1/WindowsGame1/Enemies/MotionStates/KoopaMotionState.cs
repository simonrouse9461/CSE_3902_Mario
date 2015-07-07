using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class KoopaMotionState : EnemyMotionState
    {
        private enum MotionEnum
        {
            None,
            LeftWalk,
            RightWalk,
            LeftShellKick,
            RightShellKick,
            Null
        }

        private MotionEnum OutgoingMotionStatus;
        private MotionEnum MotionStatus;

        public KoopaMotionState()
        {
            MotionList = new Collection<StatusSwitch<IMotion>>
            {
                new StatusSwitch<IMotion>(new MoveLeftMotion().EnemyVelocity),
                new StatusSwitch<IMotion>(new MoveRightMotion().EnemyVelocity),
                new StatusSwitch<IMotion>(new MoveLeftFastMotion()),
                new StatusSwitch<IMotion>(new MoveRightFastMotion()),
                new StatusSwitch<IMotion>(new GravityMotion())
            };

            FindMotion<GravityMotion>().Toggle(true);

            OutgoingMotionStatus = MotionEnum.Null;
            MotionStatus = MotionEnum.LeftWalk;
        }

        protected override void RefreshMotionStatus()
        {
            if (OutgoingMotionStatus != MotionEnum.Null) {
                if (OutgoingMotionStatus == MotionEnum.LeftWalk)
                {
                    FindMotion<MoveLeftMotion>().Toggle(false);
                }
                else if (OutgoingMotionStatus == MotionEnum.RightWalk)
                {
                    FindMotion<MoveRightMotion>().Toggle(false);
                }

                OutgoingMotionStatus = MotionEnum.Null;
            }

            if (MotionStatus == MotionEnum.LeftWalk)
            {
                FindMotion<MoveLeftMotion>().Toggle(true);
            }
            else if (MotionStatus == MotionEnum.RightWalk)
            {
                FindMotion<MoveRightMotion>().Toggle(true);
            }
            else if (MotionStatus == MotionEnum.LeftShellKick)
            {
                FindMotion<MoveLeftFastMotion>().Toggle(true);
            }
            else if (MotionStatus == MotionEnum.RightShellKick)
            {
                FindMotion<MoveRightFastMotion>().Toggle(true);
            }
        }

        protected override void SetToDefaultState()
        {
        }

        public override void Turn()
        {
            OutgoingMotionStatus = MotionStatus;

            if (OutgoingMotionStatus == MotionEnum.LeftWalk)
            {
                MotionStatus = MotionEnum.RightWalk;
            }
            else if (OutgoingMotionStatus == MotionEnum.RightWalk)
            {
                MotionStatus = MotionEnum.LeftWalk;
            }
            else if (OutgoingMotionStatus == MotionEnum.LeftShellKick)
            {
                MotionStatus = MotionEnum.RightShellKick;
            }
            else if (OutgoingMotionStatus == MotionEnum.RightShellKick)
            {
                MotionStatus = MotionEnum.LeftShellKick;
            }
        }

        public override void MarioSmash()
        {
            OutgoingMotionStatus = MotionStatus;
            MotionStatus = MotionEnum.None;
        }

        public override void TakeMarioHitFromSide(string leftOrRight)
        {
            if (MotionStatus == MotionEnum.None)
            {
                if (leftOrRight.Equals("left"))
                {
                    OutgoingMotionStatus = MotionStatus;
                    MotionStatus = MotionEnum.RightShellKick;
                }
                else if (leftOrRight.Equals("right"))
                {
                    OutgoingMotionStatus = MotionStatus;
                    MotionStatus = MotionEnum.LeftShellKick;
                }
                else
                {
                    throw new System.ArgumentException("Parameter must be \"left\" or \"right\".", "leftOrRight");
                }
            }
            
        }

        public bool isMoving
        {
            get { return MotionStatus != MotionEnum.None; }
        }

        public void ObtainGravity()
        {
            FindMotion<GravityMotion>().Toggle(true);
        }

        public void LoseGravity()
        {
            FindMotion<GravityMotion>().Toggle(false);
        }
    }
}