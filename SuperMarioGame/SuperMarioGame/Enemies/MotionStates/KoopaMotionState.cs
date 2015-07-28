using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class KoopaMotionState : EnemyMotionStateKernel
    {
        public KoopaMotionState()
        {
            AddMotion(UniformMotion.KoopaShellLeft);
            AddMotion(UniformMotion.KoopaShellRight);
        }

        public override void SetDefaultHorizontal()
        {
            TurnOffMotion(UniformMotion.EnemyMoveLeft);
            TurnOffMotion(UniformMotion.EnemyMoveRight);
            TurnOffMotion(UniformMotion.KoopaShellLeft);
            TurnOffMotion(UniformMotion.KoopaShellRight);
        }

        public override bool DefaultHotizontal
        {
            get
            {
                return !CheckMotion(UniformMotion.EnemyMoveLeft)
                       && !CheckMotion(UniformMotion.EnemyMoveRight)
                       && !CheckMotion(UniformMotion.KoopaShellLeft)
                       && !CheckMotion(UniformMotion.KoopaShellRight);
            }
        }

        public override void Turn(Orientation orientation)
        {
            switch (orientation)
            {
                case Orientation.Default:
                    if (SlippingLeft || GoingLeft) Turn(Orientation.Right);
                    if (SlippingRight || GoingRight) Turn(Orientation.Right);
                    break;
                case Orientation.Left:
                    SetDefaultHorizontal();
                    if (SlippingLeft || SlippingRight) SlipLeft();
                    else GoLeft();
                    break;
                case Orientation.Right:
                    SetDefaultHorizontal();
                    if (SlippingLeft || SlippingRight) SlipRight();
                    else GoRight();
                    break;
            }
        }

        public void Push(Orientation orientation)
        {
            SetDefaultHorizontal();
            if (orientation == Orientation.Left)
                SlipLeft();
            if (orientation == Orientation.Right)
                SlipRight();
        }

        public void SlipLeft()
        {
            SetDefaultHorizontal();
            TurnOnMotion(UniformMotion.KoopaShellLeft);
        }

        public void SlipRight()
        {
            SetDefaultHorizontal();
            TurnOnMotion(UniformMotion.KoopaShellRight);
        }

        public bool SlippingLeft
        {
            get { return CheckMotion(UniformMotion.KoopaShellLeft); }
        }

        public bool SlippingRight
        {
            get { return CheckMotion(UniformMotion.KoopaShellRight); }
        }

        public bool IsMovingShell
        {
            get { return SlippingLeft || SlippingRight; }
        }

        public override Orientation Orientation
        {
            get
            {
                if (GoingLeft || SlippingLeft) return Orientation.Left;
                if (GoingRight || SlippingRight) return Orientation.Right;
                return Orientation.Default;
            }
        }
    }
}