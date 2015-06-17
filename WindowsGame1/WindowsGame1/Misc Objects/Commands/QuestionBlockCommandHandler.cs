using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class QuestionBlockCommandHandler : CommandHandlerKernel<QuestionBlockSpriteState, QuestionBlockMotionState>
    {

        public QuestionBlockCommandHandler(QuestionBlockSpriteState spriteState, QuestionBlockMotionState motionState) : base(spriteState, motionState) {}

        protected override void Initialize()
        {
            CommandAction = new Dictionary<Type, Action>
            {
                {typeof(QuestionBlockCommand),() => SpriteState.UsedBlock()},
                {typeof(QuestionBlockCommand), () => SpriteState.Animated()}
            };
        }
    }
}
