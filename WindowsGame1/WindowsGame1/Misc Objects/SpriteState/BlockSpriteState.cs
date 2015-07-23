using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class BlockSpriteState : SpriteStateKernelNew<QuestionBlockSpriteVersion>
    {
        //private enum StatusEnum
        //{
        //    QuestionBlock, 
        //    NormalBlock,
        //    UsedBlock,
        //    HiddenBlock,
        //    FloorBlock,
        //    IndestructibleBlock,
        //    Destroyed,
        //    Castle,
        //    Flag
        //}
        private enum VersionAnimation
        {
            Overworld,
            Underworld
        }
        private enum ColorList
        {
            Transparent,
            Default
        }

        //private StatusEnum Status;

        public BlockSpriteState()
        {

            AddSprite<UsedBlockSprite>();
            AddSprite<QuestionBlockSprite>();
            AddSprite<NormalBlockSprite>();
            AddSprite<FloorBlockSprite>();
            AddSprite<IndestructibleBlockSprite>();
            AddSprite<BlockDebrisSprite>();

            AddVersionAnimator(VersionAnimation.Overworld,
            new[] {QuestionBlockSpriteVersion.OrangeOver, QuestionBlockSpriteVersion.BrownOver,
            QuestionBlockSpriteVersion.OrangeOver, QuestionBlockSpriteVersion.YellowOver,
            QuestionBlockSpriteVersion.YellowOver});

            AddVersionAnimator(VersionAnimation.Underworld,
            new[] {QuestionBlockSpriteVersion.OrangeUnder, QuestionBlockSpriteVersion.BrownUnder,
            QuestionBlockSpriteVersion.OrangeUnder, QuestionBlockSpriteVersion.YellowUnder,
            QuestionBlockSpriteVersion.YellowUnder});

            AddColorScheme(ColorList.Transparent,
                new[] { Color.Transparent });

            AddColorScheme(ColorList.Default,
                new[] { Color.White });
        }

        //protected override ISprite RawSprite
        //{
        //    get
        //    {
        //        switch (Status)
        //        {
        //            case StatusEnum.NormalBlock:
        //                return FindSprite<NormalBlockSprite>();
                        
        //            case StatusEnum.HiddenBlock:
        //                return FindSprite<UsedBlockSprite>();

        //            case StatusEnum.QuestionBlock:
        //                return FindSprite<QuestionBlockSprite>();

        //            case StatusEnum.UsedBlock:
        //                return FindSprite<UsedBlockSprite>();

        //            case StatusEnum.FloorBlock:
        //                return FindSprite<FloorBlockSprite>();

        //            case StatusEnum.Destroyed:
        //                return FindSprite<BlockDebrisSprite>();

        //            case StatusEnum.Castle:
        //                return FindSprite<CastleSprite>();

        //            case StatusEnum.Flag:
        //                return FindSprite<FlagPoleSprite>();

        //            default:
        //                return FindSprite<IndestructibleBlockSprite>();
        //            }
        //        }
        //    }

        //protected override ColorAnimator ColorScheme
        //{
        //    get
        //    {
        //        switch (Status)
        //        {
        //            case StatusEnum.HiddenBlock:
        //                return ColorSchemeList[0];
        //            default:
        //                return null;
        //        }
        //    }
        //}

        public void QuestionToUsedBlock()
        {
            SetSprite<UsedBlockSprite>();
            
        }

        public void HiddenToUsedBlock()
        {
            SetSprite<UsedBlockSprite>();
            SetColorScheme(ColorList.Default);
            
        }

        public void FloorBlock()
        {
            SetSprite<FloorBlockSprite>();
            
        }

        public void HiddenBlock()
        {
            SetColorScheme(ColorList.Transparent);
           
        }

        public void Indestructible()
        {
            SetSprite<IndestructibleBlockSprite>();
            
        }

        public void QuestionBlock()
        {
            SetSprite<QuestionBlockSprite>();
            SetVersionAnimator(VersionAnimation.Overworld);
            SetVersionFrequency(10);
        }

        public void NormalBlock()
        {
            SetSprite<NormalBlockSprite>();
        }

        public bool isNormal
        {
            get { return IsSprite<NormalBlockSprite>(); }
        }

        public bool isUsed
        {
            get { return IsSprite<UsedBlockSprite>(); }
        }


        public void Destroyed()
        {
            SetSprite<BlockDebrisSprite>();
        }

        public bool isQuestion
        {
            get { return IsSprite<QuestionBlockSprite>(); }
        }

        public bool isHidden
        {
            get { return IsColorScheme(ColorList.Transparent); }
        }
    }
}

