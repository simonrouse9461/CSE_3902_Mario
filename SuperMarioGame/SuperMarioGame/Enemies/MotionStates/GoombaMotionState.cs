using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class GoombaMotionState : MotionStateKernelNew, IEnemyMotionState
    {
        public GoombaMotionState()
        {
            AddMotion(UniformMotion.EnemyMoveLeft);
            AddMotion(UniformMotion.EnemyMoveRight);
            AddMotion<GravityMotion>();
            AddMotion(BounceUpMotion.FireballBounce);

            LoseGravity();
            SetDefaultVertical();
            SetDefaultHorizontal();
        }

        public void SetDefaultHorizontal()
        {
            TurnOffMotion(UniformMotion.EnemyMoveLeft);
            TurnOffMotion(UniformMotion.EnemyMoveRight);
        }

        public void SetDefaultVertical()
        {
            TurnOffMotion<BounceUpMotion>();
        }

        public void ObtainGravity()
        {
            FindMotion<GravityMotion>().Toggle(true);
        }

        public void LoseGravity()
        {
            FindMotion<GravityMotion>().Toggle(false);
        }

        public bool Gravity
        {
            get { return CheckMotion<GravityMotion>(); }
        }

        public void Turn(Orientation orientation)
        {
            switch (orientation)
            {
                case Orientation.Default:
                    if (GoingLeft) GoRight();
                    else GoLeft();
                    break;
                case Orientation.Left:
                    GoLeft();
                    break;
                case Orientation.Right:
                    GoRight();
                    break;
            }
        }

        public void GoLeft()
        {
            SetDefaultHorizontal();
            TurnOnMotion(UniformMotion.EnemyMoveLeft);
        }

        public bool GoingLeft
        {
            get { return CheckMotion(UniformMotion.EnemyMoveLeft);}
        }

        public void GoRight()
        {
            SetDefaultHorizontal();
            TurnOnMotion(UniformMotion.EnemyMoveRight);
        }

        public bool GoingRight
        {
            get { return CheckMotion(UniformMotion.EnemyMoveRight); }
        }

        public Orientation Orientation
        {
            get
            {
                if (GoingLeft) return Orientation.Left;
                if (GoingRight) return Orientation.Right;
                return Orientation.Default;
            }
        }

        public void MarioSmash()
        {
            LoseGravity();
            SetDefaultHorizontal();
        }

        public void Flip()
        {
            TurnOnMotion<BounceUpMotion>();
            ObtainGravity();
        }
    }
}