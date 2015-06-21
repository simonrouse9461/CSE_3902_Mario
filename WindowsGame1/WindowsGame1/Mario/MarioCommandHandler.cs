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
                {typeof(MarioFireCommand), () => SpriteState.GetFire()},
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
                    SpriteState.Crouch();
                    MotionState.Raise();
                }},
                {typeof(MarioDownCommand), () =>
                {
                    MotionState.Fall();
                    SpriteState.Crouch();
                }},
            };
        }
    }
}