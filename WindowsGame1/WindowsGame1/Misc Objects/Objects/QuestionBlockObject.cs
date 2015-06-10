using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class QuestionBlockObject : ObjectKernelNew<QuestionBlockSpriteState, QuestionBlockMotionState>
    {

        public QuestionBlockObject(Vector2 location) : base(location) { }


        protected override void Initialize(Vector2 location)
        {
            SpriteState = new QuestionBlockSpriteState();
            MotionState = new QuestionBlockMotionState(location);
        }
        protected void Reset()
        {

        }
    }
}
