using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class BlockSpriteState : SpriteStateKernelNew<BlockSpriteVersion>
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

        private enum ColorList
        {
            Transparent
        }

        //private StatusEnum Status;

        public BlockSpriteState()
        {

            AddSprite<UsedBlockSprite>();
            AddSprite<QuestionBlockSprite>();
            AddSprite<NormalBlockSprite>();
            AddSprite<FloorBlockSprite>();
            AddSprite<IndestructibleBlockSprite>();
            AddSprite<CastleSprite>();
            AddSprite<FlagPoleSprite>();

            AddColorScheme(ColorList.Transparent,
                new[] { Color.Transparent });
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

        
        //public void Destroyed()
        //{
        //    Status = StatusEnum.Destroyed;
        //}

        public bool isQuestion
        {
            get { return IsSprite<QuestionBlockSprite>(); }
        }

        public bool isHidden
        {
            get { return IsColorScheme(ColorList.Transparent); }
        }

        public void Castle()
        {
            SetSprite<CastleSprite>();
        }
    }
}

