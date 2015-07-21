using System.Collections.ObjectModel;
using System.Dynamic;
using System.Web.Management;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class QuestionBlockSpriteState : SpriteStateKernelNew<QuestionBlockSpriteVersion>
    {

        private enum VersionAnimation
        {
            Overworld,
            Underworld
        }

        public QuestionBlockSpriteState()
        {

            AddSprite<QuestionBlockSprite>();
            AddVersionAnimator(VersionAnimation.Overworld,
            new[] {QuestionBlockSpriteVersion.OrangeOver, QuestionBlockSpriteVersion.BrownOver,
            QuestionBlockSpriteVersion.OrangeOver, QuestionBlockSpriteVersion.YellowOver,
            QuestionBlockSpriteVersion.YellowOver});
            AddVersionAnimator(VersionAnimation.Underworld,
            new[] {QuestionBlockSpriteVersion.OrangeUnder, QuestionBlockSpriteVersion.BrownUnder,
            QuestionBlockSpriteVersion.OrangeUnder, QuestionBlockSpriteVersion.YellowUnder,
            QuestionBlockSpriteVersion.YellowUnder});
            SetVersionFrequency(10);
            SetVersionAnimator(VersionAnimation.Overworld);
        }
    }
}
