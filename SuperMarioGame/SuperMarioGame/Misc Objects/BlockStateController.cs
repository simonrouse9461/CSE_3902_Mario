﻿using System;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class BlockStateController : StateControllerKernelNew<BlockSpriteState, BlockMotionState>
    {
        public bool giveCoin { get; private set; }
        public bool giveItem { get; private set; }
        public bool giveStar { get; private set; }
        public bool giveOneUp { get; private set; }

        private int numberCoinsLeft = 10;

        private int CoinLeft
        {
            get { return numberCoinsLeft; }
            set
            {
                numberCoinsLeft = value;
                if (value <= 0)
                {
                    SpriteState.QuestionToUsedBlock();
                }
            }
        }

        public void hasCoin()
        {
            giveCoin = true;
            giveItem = false;
            giveOneUp = false;
            giveStar = false;
        }

        public void hasItem()
        {
            giveCoin = false;
            giveItem = true;
            giveOneUp = false;
            giveStar = false;
        }

        public void hasStar()
        {
            giveItem = false;
            giveCoin = false;
            giveOneUp = false;
            giveStar = true;
        }

        public void hasOneUp()
        {
            giveItem = false;
            giveCoin = false;
            giveOneUp = true;
            giveStar = false;
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
            SpriteState.SetSpriteFrequency(20);

            Core.Object.Generate(new Vector2(-(float) Core.Object.PositionRectangle.Width/4, 0),
                BlockDebrisObject.LowerLeft);
            Core.Object.Generate(new Vector2((float) Core.Object.PositionRectangle.Width/4, 0),
                BlockDebrisObject.LowerRight);
            Core.Object.Generate(
                new Vector2(-(float) Core.Object.PositionRectangle.Width/4,
                    -(float) Core.Object.PositionRectangle.Height/2), BlockDebrisObject.UpperLeft);
            Core.Object.Generate(
                new Vector2((float) Core.Object.PositionRectangle.Width/4,
                    -(float) Core.Object.PositionRectangle.Height/2), BlockDebrisObject.UpperRight);
            Core.Object.Unload();
        }
    }
}