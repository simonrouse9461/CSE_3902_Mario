using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class MarioCommandHandler : CommandHandlerKernel
    {
        private readonly MarioSpriteState _spriteState;
        private readonly MarioMotionState _motionState;

        public MarioCommandHandler(MarioSpriteState spriteState, MarioMotionState motionState)
        {
            _spriteState = spriteState;
            _motionState = motionState;
        }

        protected override void Initialize()
        {
            CommandAction = new Dictionary<Type, Action>
            {
                {typeof(MarioDeadCommand), () => _spriteState.BecomeDead()},
                {typeof(MarioBigCommand), () => _spriteState.BecomeBig()},
                {typeof(MarioSmallCommand), () => _spriteState.BecomeSmall()},
                {typeof(MarioFireCommand), () => _spriteState.BecomeFire()},
                {typeof(MarioLeftCommand), () => _spriteState.FaceLeft()},
                {typeof(MarioRightCommand), () => _spriteState.FaceRight()},
                {typeof(MarioUpCommand), () =>
                {
                    if (_spriteState.IsCrouch())
                        _spriteState.Stand();
                    else if (_spriteState.IsStand())
                        _spriteState.Run();
                    else if (_spriteState.IsRun())
                        _spriteState.Jump();
                }},
                {typeof(MarioDownCommand), () =>
                {
                    if (_spriteState.IsJump())
                        _spriteState.Run();
                    else if (_spriteState.IsRun())
                        _spriteState.Stand();
                    else if (_spriteState.IsStand())
                        _spriteState.Crouch();
                }},
            };
        }
    }
}