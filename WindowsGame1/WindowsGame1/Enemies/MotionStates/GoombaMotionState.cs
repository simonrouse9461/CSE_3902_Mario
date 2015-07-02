using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class GoombaMotionState : EnemyMotionState
    {
        private enum MotionEnum
        {
            None,
            LeftWalk,
            RightWalk
        }

        private MotionEnum MotionStatus;

        public GoombaMotionState()
        {
            MotionList = new Collection<StatusSwitch<IMotion>>
            {
                new StatusSwitch<IMotion>(new MoveLeftMotion().EnemyVelocity),
                new StatusSwitch<IMotion>(new MoveRightMotion().EnemyVelocity)
            };

            MotionStatus = MotionEnum.None;
        }

        protected override void RefreshMotionStatus()
        {
            switch (MotionStatus)
            {
                case MotionEnum.None:
                    FindMotion<MoveLeftMotion>().Toggle(false);
                    FindMotion<MoveRightMotion>().Toggle(false);
                    break;
                case MotionEnum.LeftWalk:
                    FindMotion<MoveLeftMotion>().Toggle(true);
                    FindMotion<MoveRightMotion>().Toggle(false);
                    break;
                case MotionEnum.RightWalk:
                    FindMotion<MoveLeftMotion>().Toggle(false);
                    FindMotion<MoveRightMotion>().Toggle(true);
                    break;
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
            
        }
    }
}