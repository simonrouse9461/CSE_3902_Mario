using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class MarioCommandHandler : CommandHandlerKernel<MarioObject>
    {
        private MarioSpriteState SpriteState;
        private MarioMotionState MotionState;

        public MarioCommandHandler(MarioObject obj) : base(obj) { }

        protected override void Initialize()
        {
            SpriteState = (MarioSpriteState)Object.SpriteState;
            MotionState = (MarioMotionState)Object.MotionState;

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