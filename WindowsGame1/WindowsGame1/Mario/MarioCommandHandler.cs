using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class MarioCommandHandler : CommandHandlerKernel<MarioSpriteState, MarioMotionState>
    {
        public MarioCommandHandler(MarioSpriteState spriteState, MarioMotionState motionState) : base(spriteState, motionState) { }

        protected override void Initialize()
        {
            CommandAction = new Dictionary<Type, Action>
            {
                {typeof(MarioDeadCommand), () => SpriteState.BecomeDead()},
                {typeof(MarioBigCommand), () => SpriteState.BecomeBig()},
                {typeof(MarioSmallCommand), () => SpriteState.BecomeSmall()},
                {typeof(MarioFireCommand), () => SpriteState.BecomeFire()},
                {typeof(MarioLeftCommand), () =>
                {
                    SpriteState.FaceLeft();
                    MotionState.MoveLeft();
                }},
                {typeof(MarioRightCommand), () =>
                {
                    SpriteState.FaceRight();
                    MotionState.MoveRight();
                }},
                {typeof(MarioUpCommand), () =>
                {
                    if (SpriteState.IsCrouch())
                        SpriteState.Stand();
                    else if (SpriteState.IsStand())
                        SpriteState.Run();
                    else if (SpriteState.IsRun())
                        SpriteState.Jump();
                }},
                {typeof(MarioDownCommand), () =>
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