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
                new StatusSwitch<IMotion>(MoveLeftMotion.EnemyVelocity),
                new StatusSwitch<IMotion>(MoveRightMotion.EnemyVelocity),
                new StatusSwitch<IMotion>(new GravityMotion())
            };

            MotionStatus = MotionEnum.LeftWalk;
            LoseGravity();
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

            if (Gravity)
            {
                FindMotion<GravityMotion>().Toggle(true);
            }
            else
            {
                FindMotion<GravityMotion>().Toggle(false);
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
            Display.Increment<Goomba>();
        }


        public bool isAlive()
        {
            return MotionStatus != MotionEnum.None;
        }

        public override void TakeMarioHitFromSide(string leftOrRight)
        {
            
        }

        public void ObtainGravity()
        {
            Gravity = true;
        }

        public void LoseGravity()
        {
            Gravity = false;
        }
    }
}