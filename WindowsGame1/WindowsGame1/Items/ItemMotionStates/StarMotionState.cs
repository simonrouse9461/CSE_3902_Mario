using System.Collections.ObjectModel;

namespace MarioGame
{
    public class StarMotionState : MotionStateKernelNew
    {

        public bool Gravity { get; private set; }

        public StarMotionState()
        {
            MotionList = new Collection<StatusSwitch<IMotion>>
            {
                new StatusSwitch<IMotion>(UniformMotion.ItemMoveLeft),
                new StatusSwitch<IMotion>(UniformMotion.ItemMoveRight),
                new StatusSwitch<IMotion>(new GravityMotion()),
                new StatusSwitch<IMotion>(new RaiseUpMotion()),
                new StatusSwitch<IMotion>(BounceUpMotion.StarMotion)
            };
            LoseGravity();
            SetDefaultHorizontal();
        }

        public void SetDefaultHorizontal()
        {
            FindMotion(UniformMotion.EnemyMoveLeft).Toggle(false);
        }

        public void SetDefaultVertical()
        {
            FindMotion<RaiseUpMotion>().Toggle(false);
            FindMotion<BounceUpMotion>().Toggle(false);
        }

        public void Generated()
        {
            FindMotion<RaiseUpMotion>().Toggle(true);
        }

        public void ObtainGravity()
        {
            Gravity = true;
        }

        public void LoseGravity()
        {
            Gravity = false;
        }

        public void Moving()
        {
            FindMotion<RaiseUpMotion>().Toggle(false);
            FindMotion(UniformMotion.EnemyMoveRight).Toggle(true);
            FindMotion<BounceUpMotion>().Toggle(true);
            FindMotion<GravityMotion>().Toggle(true);
        }

        public bool isGenerating
        {
            get
            {
                return FindMotion<RaiseUpMotion>().Status;
            }
        }

        public void ChangeDirection()
        {
            if (FindMotion(UniformMotion.EnemyMoveRight).Status)
            {
                FindMotion(UniformMotion.EnemyMoveRight).Toggle(false);
                FindMotion(UniformMotion.EnemyMoveLeft).Toggle(true);
            }
            else
            {
                FindMotion(UniformMotion.EnemyMoveLeft).Toggle(false);
                FindMotion(UniformMotion.EnemyMoveRight).Toggle(true);
            }
        }

        public void Bouncing()
        {
            SetDefaultVertical();
            FindMotion<BounceUpMotion>().Content.Reset();
            FindMotion<BounceUpMotion>().Toggle(true);
        }

    }
}
