using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;

namespace WindowsGame1
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
            SetVersion(BlockSpriteVersion.Used);
        }

        public void HiddenToUsedBlock()
        {
            SetVersion(BlockSpriteVersion.Used);
        }

        public void FloorBlock()
        {
            SetVersion(BlockSpriteVersion.Floor);
        }

        public void HiddenBlock()
        {
           SetVersion(BlockSpriteVersion.Hidden);
        }

        public void Indestructible()
        {
            SetVersion(BlockSpriteVersion.Indestructible);
        }

        public void QuestionBlock()
        {
            SetVersion(BlockSpriteVersion.Question);
        }

        public void NormalBlock()
        {
            SetVersion(BlockSpriteVersion.Normal);
        }

        public bool isNormal
        {
            get { return IsVersion(BlockSpriteVersion.Normal); }
        }

        public bool isUsed
        {
            get { return IsVersion(BlockSpriteVersion.Used); }
        }

        //public void Destroyed()
        //{
        //    Status = StatusEnum.Destroyed;
        //}

        public bool isQuestion
        {
            get { return IsVersion(BlockSpriteVersion.Question); }
        }

        public bool isHidden
        {
            get { return IsVersion(BlockSpriteVersion.Hidden); }
        }
    }
}

