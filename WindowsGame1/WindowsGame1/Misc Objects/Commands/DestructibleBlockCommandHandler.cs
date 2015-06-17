using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class DestructibleBlockCommandHandler : CommandHandlerKernel<DestructibleBlockSpriteState, DestructibleBlockMotionState>
    {

        public DestructibleBlockCommandHandler(DestructibleBlockSpriteState spriteState, DestructibleBlockMotionState motionState) : base(spriteState, motionState) { }

        protected override void Initialize()
        {
            CommandAction = new Dictionary<Type, Action>
            {
                {typeof(DestructibleBlockCommand),() => SpriteState.DestructibleBlock()},
                {typeof(DestructibleBlockCommand),() => SpriteState.DestructibleDestroyed()}
            };
        }
    }
}
