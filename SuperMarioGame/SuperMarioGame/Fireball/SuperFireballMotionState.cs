using System.Collections.ObjectModel;

namespace MarioGame
{
    public class SuperFireballMotionState : MotionStateKernelNew
    {

        private enum OrientationEnum
        {
            Left,
            Right,
        }

        public SuperFireballMotionState()
        {
            MotionList = new Collection<StatusSwitch<IMotion>>{
                new StatusSwitch<IMotion>(UniformMotion.FireballMoveLeft),
                new StatusSwitch<IMotion>(UniformMotion.FireballMoveRight),
            };       
        }

    }
}
