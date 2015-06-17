using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class HiddenBlockCommandHandler : CommandHandlerKernel<HiddenBlockSpriteState, HiddenBlockMotionState>
    {

        public HiddenBlockCommandHandler(HiddenBlockSpriteState spriteState, HiddenBlockMotionState motionState) : base(spriteState, motionState) { }

        protected override void Initialize()
        {
            CommandAction = new Dictionary<Type, Action>
            {
                {typeof(HiddenBlockCommand),() => SpriteState.HiddenBlock()},
                {typeof(HiddenBlockCommand), () => SpriteState.HiddenToUsedBlock()}
            };
        }
    }
}
