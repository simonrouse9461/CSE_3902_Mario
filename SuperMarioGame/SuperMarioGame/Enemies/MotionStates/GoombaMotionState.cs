using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class GoombaMotionState : MotionStateKernel
    {
        private enum MotionEnum
        {
            None,
            LeftWalk,
            RightWalk,
            Flip
        }

        private  MotionEnum MotionStatus;
        public bool Gravity { get; private set; }

        public GoombaMotionState()
        {
            MotionList = new Collection<StatusSwitch<IMotion>>
            {
                new StatusSwitch<IMotion>(UniformMotion.EnemyMoveLeft),
                new StatusSwitch<IMotion>(UniformMotion.EnemyMoveRight),
                new StatusSwitch<IMotion>(new GravityMotion()),
                new StatusSwitch<IMotion>(BounceUpMotion.FireballBounce)
            };

            LoseGravity();
            SetDefaultVertical();
            SetDefaultHorizontal();
        }

        public void SetDefaultHorizontal()
        {
            MotionStatus = MotionEnum.LeftWalk;
            FindMotion(UniformMotion.EnemyMoveLeft).Toggle(true);
            FindMotion(UniformMotion.EnemyMoveRight).Toggle(false);
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
                FindMotion(UniformMotion.EnemyMoveRight).Toggle(true);
                FindMotion(UniformMotion.EnemyMoveLeft).Toggle(false);
                MotionStatus = MotionEnum.RightWalk;
            }
            else if (MotionStatus == MotionEnum.RightWalk)
            {
                FindMotion(UniformMotion.EnemyMoveRight).Toggle(false);
                FindMotion(UniformMotion.EnemyMoveLeft).Toggle(true);
                MotionStatus = MotionEnum.LeftWalk;
            }
        }


        public void MarioSmash()
        {
            MotionStatus = MotionEnum.None;
            FindMotion(UniformMotion.EnemyMoveLeft).Toggle(false);
            FindMotion(UniformMotion.EnemyMoveRight).Toggle(false);
        }


        public bool isAlive()
        {
            return MotionStatus != MotionEnum.None && MotionStatus != MotionEnum.Flip;
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