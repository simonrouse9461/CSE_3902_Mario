using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class MarioCommandExecutor : CommandExecutorKernel<MarioSpriteState, MarioMotionState>
    {
        private CollisionDetector Detector;

        public MarioCommandExecutor(Core<MarioSpriteState, MarioMotionState> core) : base(core)
        {
            Detector = new CollisionDetector(Core.Object);
            CommandAction = new Dictionary<Type, Action>
            {
                {typeof(MarioDeadCommand), () => Core.SpriteState.BecomeDead()},
                {typeof(MarioLeftCommand), () =>
                {
                    Core.SpriteState.ToLeft();
                    Core.MotionState.MoveLeft();
                }},
                {typeof(MarioRightCommand), () =>
                {
                    Core.SpriteState.ToRight();
                    Core.MotionState.MoveRight();
                }},
                {typeof(MarioUpCommand), () =>
                {
                    if (Detector.Detect<IObject>(obj => obj.Solid).Bottom.Touch)
                        Core.MotionState.Raise();
                }},
                {typeof(MarioDownCommand), () => Core.MotionState.Fall()}
            };
        }
    }
}