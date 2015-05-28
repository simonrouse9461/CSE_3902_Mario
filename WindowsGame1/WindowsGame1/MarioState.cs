using System;

namespace WindowsGame1
{
    public class MarioState : StateKernel
    {
        public override void Initialize()
        {
            ActiveSprite = new MarioSpriteEnum();
            foreach (MarioMotionEnum motion in Enum.GetValues(typeof(MarioMotionEnum)))
            {
                EffectiveMotion.Add(motion, false);
            }
        }
    }
}