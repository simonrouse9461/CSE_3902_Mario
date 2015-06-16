using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class MarioCommandHandler : CommandHandlerKernel<MarioSpriteState, MarioMotionState>
    {
        protected override void Initialize()
        {
            CommandAction = new Dictionary<Type, Action<MarioSpriteState, MarioMotionState>>
            {
                {typeof(MarioDeadCommand), (SpriteState, MotionState) => SpriteState.BecomeDead()},
                {typeof(MarioBigCommand), (SpriteState, MotionState) => SpriteState.BecomeBig()},
                {typeof(MarioSmallCommand), (SpriteState, MotionState) => SpriteState.BecomeSmall()},
                {typeof(MarioFireCommand), (SpriteState, MotionState) => SpriteState.BecomeFire()},
                {typeof(MarioLeftCommand), (SpriteState, MotionState) =>
                {
                    SpriteState.FaceLeft();
                    MotionState.MoveLeft();
                }},
                {typeof(MarioRightCommand), (SpriteState, MotionState) =>
                {
                    SpriteState.FaceRight();
                    MotionState.MoveRight();
                }},
                {typeof(MarioUpCommand), (SpriteState, MotionState) =>
                {
                    if (SpriteState.IsCrouch())
                        SpriteState.Stand();
                    else if (SpriteState.IsStand())
                        SpriteState.Run();
                    else if (SpriteState.IsRun())
                        SpriteState.Jump();
                }},
                {typeof(MarioDownCommand), (SpriteState, MotionState) =>
                {
                    if (SpriteState.IsJump())
                        SpriteState.Run();
                    else if (SpriteState.IsRun())
                        SpriteState.Stand();
                    else if (SpriteState.IsStand())
                        SpriteState.Crouch();
                }},
            };
        }
    }
}