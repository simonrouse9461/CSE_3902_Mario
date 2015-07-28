using System.Web.UI.WebControls;

namespace SuperMario
{
    public abstract class EnemyMotionStateKernel : MotionStateKernelNew, IEnemyMotionState
    {
        protected EnemyMotionStateKernel()
        {
            AddMotion(UniformMotion.EnemyMoveLeft);
            AddMotion(UniformMotion.EnemyMoveRight);
            AddMotion<GravityMotion>();
            AddMotion(BounceUpMotion.FireballBounce);

            LoseGravity();
        }

        public virtual void SetDefaultHorizontal()
        {
            TurnOffMotion(UniformMotion.EnemyMoveLeft);
            TurnOffMotion(UniformMotion.EnemyMoveRight);
        }

        public virtual bool DefaultHotizontal
        {
            get
            {
                return !CheckMotion(UniformMotion.EnemyMoveLeft)
                       && !CheckMotion(UniformMotion.EnemyMoveRight);
            }
        }

        public virtual void SetDefaultVertical()
        {
            TurnOffMotion<BounceUpMotion>();
        }

        public virtual bool DefaultVertical
        {
            get { return !CheckMotion<BounceUpMotion>(); }
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

        public abstract void Turn(Orientation orientation);

        public abstract Orientation Orientation { get; }

        public void GoLeft()
        {
            SetDefaultHorizontal();
            TurnOnMotion(UniformMotion.EnemyMoveLeft);
        }

        public bool GoingLeft
        {
            get { return CheckMotion(UniformMotion.EnemyMoveLeft); }
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

        public void MarioSmash()
        {
            LoseGravity();
            SetDefaultHorizontal();
            SetDefaultVertical();
        }

        public void Flip()
        {
            TurnOnMotion<BounceUpMotion>();
            ObtainGravity();
        }
    }
}