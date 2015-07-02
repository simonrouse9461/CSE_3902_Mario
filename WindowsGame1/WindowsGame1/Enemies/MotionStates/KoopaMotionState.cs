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
            RightShellKick
        }

        private MotionEnum MotionStatus;

        public KoopaMotionState()
        {
            MotionList = new Collection<StatusSwitch<IMotion>>
            {
                new StatusSwitch<IMotion>(new MoveLeftMotion().EnemyVelocity),
                new StatusSwitch<IMotion>(new MoveRightMotion().EnemyVelocity),
                new StatusSwitch<IMotion>(new MoveLeftFastMotion()),
                new StatusSwitch<IMotion>(new MoveRightFastMotion())
            };

            MotionStatus = MotionEnum.None;
        }

        protected override void RefreshMotionStatus()
        {
            foreach (StatusSwitch<IMotion> s in MotionList) {
                s.Toggle(false);
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
            if (MotionStatus == MotionEnum.LeftWalk)
            {
                MotionStatus = MotionEnum.RightWalk;
            }
            else if (MotionStatus == MotionEnum.RightWalk)
            {
                MotionStatus = MotionEnum.LeftWalk;
            }
        }

        public override void MarioSmash()
        {
            MotionStatus = MotionEnum.None;
        }

        public override void TakeMarioHitFromSide(string leftOrRight)
        {
            if (MotionStatus == MotionEnum.None)
            {
                if (leftOrRight.Equals("left"))
                {
                    MotionStatus = MotionEnum.RightShellKick;
                }
                else if (leftOrRight.Equals("right"))
                {
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
    }
}