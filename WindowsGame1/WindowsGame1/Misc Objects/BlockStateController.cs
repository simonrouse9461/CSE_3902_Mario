using System;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class BlockStateController : StateControllerKernel<BlockSpriteState, BlockMotionState>
    {
        private enum Version
        {
            Coin,
            Item,
            Star,
            ExtraLife
        }

        private Version version;
        private int _coinLeft = 10;

        private int CoinLeft
        {
            get { return _coinLeft; }
            set
            {
                _coinLeft = value;
                if (value <= 0)
                {
                    SpriteState.QuestionToUsedBlock();
                }
            }          
        }

        public bool giveCoin
        {
            get
            {
                return version == Version.Coin;
            }
        }

        public bool giveItem
        {
            get
            {
                return version == Version.Item;
            }
        }

        public bool giveStar
        {
            get
            {
                return version == Version.Star;
            }
        }

        public bool giveOneUp
        {
            get
            {
                return version == Version.ExtraLife;
            }
        }

        public void QuestionBlock()
        {
            SpriteState.QuestionBlock();
        }

        public void HiddenBlock()
        {
            SpriteState.HiddenBlock();
        }

        public void NormalBlock()
        {
            SpriteState.NormalBlock();
        }

        public void FloorBlock()
        {
            SpriteState.FloorBlock();
        }

        public void IndestructibleBlock()
        {
            SpriteState.Indestructible();
        }

        public void QuestionBlockGiveFireflower()
        {
            Core.Object.Generate<Fireflower>();           
            SpriteState.QuestionToUsedBlock();
        }

        public void QuestionBlockGiveMushroom()
        {
            Core.Object.Generate<Mushroom>();
            SpriteState.QuestionToUsedBlock();
        }

        public void QuestionBlockGiveCoin()
        {
            Core.Object.Generate<Coin>();           
            SpriteState.QuestionToUsedBlock();
        }

        public void NormalBlockCoinHit()
        {
            Core.Object.Generate<Coin>();
            CoinLeft--;
        }

        public void HiddenBlockGive1Up()
        {
            Core.Object.Generate<OneUp>();
            SpriteState.HiddenToUsedBlock();
        }

        public void NormalBlockGiveStar()
        {
            Core.Object.Generate<Star>();
            SpriteState.QuestionToUsedBlock();
        }

        public void NormalBlockDestroyed()
        {
            SpriteState.Destroyed();
            Core.DelayCommand(() => Core.Object.Unload(), 12);
        }


    }
}
