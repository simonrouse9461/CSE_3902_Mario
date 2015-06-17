using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class NormalBlockCommandHandler : CommandHandlerKernel<NormalBlockSpriteState, NormalBlockMotionState>
    {

        public NormalBlockCommandHandler(NormalBlockSpriteState spriteState, NormalBlockMotionState motionState) : base(spriteState, motionState) { }

        protected override void Initialize()
        {
            CommandAction = new Dictionary<Type, Action>
            {
                {typeof(NormalBlockCommand),() => SpriteState.DestroyedBlock()},
                {typeof(NormalBlockCommand), () => SpriteState.NormalBlock()}
            };
        }
    }
}
