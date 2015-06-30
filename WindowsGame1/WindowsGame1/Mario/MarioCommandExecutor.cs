using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class MarioCommandExecutor : CommandExecutorKernel<MarioSpriteState, MarioMotionState>
    {
        public MarioCommandExecutor(Core<MarioSpriteState, MarioMotionState> core) : base(core)
        {
            CommandAction = new Dictionary<Type, Action>
            {
                {typeof(MarioDeadCommand), () => Core.SpriteState.BecomeDead()},
                {typeof(MarioBigCommand), () => Core.SpriteState.BecomeBig()},
                {typeof(MarioSmallCommand), () => Core.SpriteState.BecomeSmall()},
                {typeof(MarioFireCommand), () => Core.SpriteState.GetFire()},
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
                    Core.MotionState.Raise();
                }},
                {typeof(MarioDownCommand), () =>
                {
                    Core.MotionState.Fall();
                }}
            };
        }
    }
}