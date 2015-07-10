using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class BlockSpriteState : SpriteStateKernel
    {
        private enum StatusEnum
        {
            QuestionBlock, 
            NormalBlock,
            UsedBlock,
            HiddenBlock,
            FloorBlock,
            IndestructibleBlock,
            Destroyed
        }

        private StatusEnum Status;

        public BlockSpriteState()
        {

            SpriteList = new Collection<ISprite>{
                new NormalBlockSprite(),
                new IndestructibleBlockSprite(),
                new FloorBlockSprite(),
                new UsedBlockSprite(),
                new QuestionBlockSprite(),
                new BlockDebrisSprite()
            };
            ColorSchemeList = new Collection<ColorAnimator>{
                new ColorAnimator(new[] {Color.Transparent})
            };

            ChangeSpriteFrequency(10);
        }

        public override ISprite Sprite
        {
            get
            {
                switch (Status)
                {
                    case StatusEnum.NormalBlock:
                        return FindSprite<NormalBlockSprite>();
                        
                    case StatusEnum.HiddenBlock:
                        return FindSprite<UsedBlockSprite>();

                    case StatusEnum.QuestionBlock:
                        return FindSprite<QuestionBlockSprite>();

                    case StatusEnum.UsedBlock:
                        return FindSprite<UsedBlockSprite>();

                    case StatusEnum.FloorBlock:
                        return FindSprite<FloorBlockSprite>();

                    case StatusEnum.Destroyed:
                        return FindSprite<BlockDebrisSprite>();

                    default:
                        return FindSprite<IndestructibleBlockSprite>();
                    }
                }
            }

        protected override ColorAnimator ColorScheme
        {
            get
            {
                switch (Status)
                {
                    case StatusEnum.HiddenBlock:
                        return ColorSchemeList[0];
                    default:
                        return null;
                }
            }
        }

        public void QuestionToUsedBlock()
        {
            Status = StatusEnum.UsedBlock;
        }

        public void HiddenToUsedBlock()
        {
            Status = StatusEnum.UsedBlock;
        }

        public void FloorBlock()
        {
            Status = StatusEnum.FloorBlock;
        }

        public void HiddenBlock()
        {
            Status = StatusEnum.HiddenBlock;
        }

        public void Indestructible()
        {
            Status = StatusEnum.IndestructibleBlock;
        }

        public void QuestionBlock()
        {
            Status = StatusEnum.QuestionBlock;
        }

        public void NormalBlock()
        {
            Status = StatusEnum.NormalBlock;
        }

        public bool isNormal
        {
            get { return Status == StatusEnum.NormalBlock; }
        }

        public void Destroyed()
        {
            Status = StatusEnum.Destroyed;
        }
    }
}

