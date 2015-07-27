using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class KoopaMotionState : MotionStateKernelNew, IEnemyMotionState
    {
        public KoopaMotionState()
        {
            AddMotion(UniformMotion.EnemyMoveLeft);
            AddMotion(UniformMotion.EnemyMoveRight);
            AddMotion(UniformMotion.KoopaShellLeft);
            AddMotion(UniformMotion.KoopaShellRight);
            AddMotion<GravityMotion>();
            AddMotion(BounceUpMotion.FireballBounce);

            SetDefaultVertical();
            SetDefaultHorizontal();
        }

        public void SetDefaultHorizontal()
        {
            TurnOffMotion(UniformMotion.EnemyMoveLeft);
            TurnOffMotion(UniformMotion.EnemyMoveRight);
            TurnOffMotion(UniformMotion.KoopaShellLeft);
            TurnOffMotion(UniformMotion.KoopaShellRight);
        }

        public bool DefaultHotizontal
        {
            get
            {
                return !CheckMotion(UniformMotion.EnemyMoveLeft)
                       && !CheckMotion(UniformMotion.EnemyMoveRight)
                       && !CheckMotion(UniformMotion.KoopaShellLeft)
                       && !CheckMotion(UniformMotion.KoopaShellRight);
            }
        }

        public void SetDefaultVertical()
        {
            TurnOffMotion<BounceUpMotion>();
        }

        public void Turn(Orientation orientation)
        {
            switch (orientation)
            {
                case Orientation.Default:
                    if (ShellLeft || MovingLeft) Turn(Orientation.Right);
                    if (ShellRight || MovingRight) Turn(Orientation.Right);
                    break;
                case Orientation.Left:
                    SetDefaultHorizontal();
                    if (ShellLeft || ShellRight) TurnOnMotion(UniformMotion.KoopaShellLeft);
                    else TurnOnMotion(UniformMotion.EnemyMoveLeft);
                    break;
                case Orientation.Right:
                    SetDefaultHorizontal();
                    if (ShellLeft || ShellRight) TurnOnMotion(UniformMotion.KoopaShellRight);
                    else TurnOnMotion(UniformMotion.EnemyMoveRight);
                    break;
            }
        }

        public void MarioSmash()
        {
            SetDefaultHorizontal();
        }

        public void GotHit(Orientation orientation)
        {
            if (!DefaultHotizontal) return;

            if (orientation == Orientation.Left)
                TurnOnMotion(UniformMotion.KoopaShellRight);
            if (orientation == Orientation.Right)
                TurnOnMotion(UniformMotion.KoopaShellLeft);
        }

        public bool MovingLeft
        {
            get { return CheckMotion(UniformMotion.EnemyMoveLeft);}
        }

        public bool MovingRight
        {
            get { return CheckMotion(UniformMotion.EnemyMoveRight); }
        }

        public bool ShellLeft
        {
            get { return CheckMotion(UniformMotion.KoopaShellLeft); }
        }

        public bool ShellRight
        {
            get { return CheckMotion(UniformMotion.KoopaShellRight); }
        }

        public bool IsMovingShell
        {
            get { return ShellLeft || ShellRight; }
        }

        public Orientation Orientation
        {
            get
            {
                if (MovingLeft || ShellLeft) return Orientation.Left;
                if (MovingRight || ShellRight) return Orientation.Right;
                return Orientation.Default;
            }
        }

        public void ObtainGravity()
        {
            TurnOnMotion<GravityMotion>();
        }

        public void LoseGravity()
        {
            TurnOffMotion<GravityMotion>();
        }

        public bool Gravity
        {
            get { return CheckMotion<GravityMotion>(); }
        }

        public void Flip()
        {
            TurnOnMotion<BounceUpMotion>();
            ObtainGravity();
        }
    }
}