using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class MarioCommandExecutor : CommandExecutorKernel<MarioSpriteState, MarioMotionState>
    {
        public MarioCommandExecutor(State<MarioSpriteState, MarioMotionState> state) : base(state)
        {
            CommandAction = new Dictionary<Type, Action>
            {
                {typeof(MarioDeadCommand), () => State.SpriteState.BecomeDead()},
                {typeof(MarioBigCommand), () => State.SpriteState.BecomeBig()},
                {typeof(MarioSmallCommand), () => State.SpriteState.BecomeSmall()},
                {typeof(MarioFireCommand), () => State.SpriteState.GetFire()},
                {typeof(MarioLeftCommand), () =>
                {
                    State.SpriteState.ToLeft();
                    State.MotionState.MoveLeft();
                }},
                {typeof(MarioRightCommand), () =>
                {
                    State.SpriteState.ToRight();
                    State.MotionState.MoveRight();
                }},
                {typeof(MarioUpCommand), () =>
                {
                    State.MotionState.Raise();
                }},
                {typeof(MarioDownCommand), () =>
                {
                    State.MotionState.Fall();
                }}
            };
        }
    }
}