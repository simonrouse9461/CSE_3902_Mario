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
            DestructibleBlock,
            IndestructibleBlock,
            Destroyed
        }

        private StatusEnum Status;

        public BlockSpriteState()
        {

            SpriteList = new Collection<ISprite>{
                new NormalBlockSprite(),
                new IndestructibleBlockSprite(),
                new DestructibleBlockSprite(),
                new UsedBlockSprite(),
                new QuestionBlockSprite()
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

                    case StatusEnum.DestructibleBlock:
                        return FindSprite<DestructibleBlockSprite>();

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

        public void DestructibleBlock()
        {
            Status = StatusEnum.DestructibleBlock;
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

        public bool isQuestionBlock
        {
            get { return Status == StatusEnum.QuestionBlock; }
        }

        public bool isNormal
        {
            get { return Status == StatusEnum.NormalBlock; }
        }

        public bool isDestructible
        {
            get { return Status == StatusEnum.DestructibleBlock; }
        }

        public bool isHidden
        {
            get { return Status == StatusEnum.HiddenBlock; }
        }
    }
}

