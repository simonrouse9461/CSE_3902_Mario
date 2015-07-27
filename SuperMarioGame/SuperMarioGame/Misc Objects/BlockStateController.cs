using System;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class BlockStateController : StateControllerKernelNew<BlockSpriteState, BlockMotionState>
    {
        private enum GenerateType
        {
            None,
            Coin,
            Item,
            Star,
            OneUp
        }

        private GenerateType ContainedItem { get; set; }

        public bool HasNothing { get { return ContainedItem == GenerateType.None; } }
        public bool HasCoin { get { return ContainedItem == GenerateType.Coin; } }
        public bool HasItem { get { return ContainedItem == GenerateType.Item; } }
        public bool HasStar { get { return ContainedItem == GenerateType.Star; } }
        public bool HasOneUp { get { return ContainedItem == GenerateType.OneUp; } }

        private int _coinLeft = 10;
        private int CoinLeft
        {
            get { return _coinLeft; }
            set
            {
                _coinLeft = value;
                if (value <= 0)
                {
                    SpriteState.ToUsedBlock();
                }
            }
        }

        public void PutCoin()
        {
            ContainedItem = GenerateType.Coin;
        }

        public void PutItem()
        {
            ContainedItem = GenerateType.Item;
        }

        public void PutStar()
        {
            ContainedItem = GenerateType.Star;
        }

        public void PutOneUp()
        {
            ContainedItem = GenerateType.OneUp;
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

        public void GotHit()
        {
            MotionState.BounceUp();
        }

        public override void Update()
        {
            if (MotionState.IsHit && MotionState.Position.Y + MotionState.Velocity.Y > MotionState.LastSetPosition.Y)
            {
                MotionState.StopFall();
                MotionState.SetPosition(MotionState.LastSetPosition);
            }
        }

        public void GiveThings(bool bigMario)
        {
            switch (ContainedItem)
            {
                case GenerateType.None:
                    return;
                case GenerateType.Coin:
                    Core.Object.Generate<Coin>();
                    Display.AddScore<Coin>();
                    if (SpriteState.isQuestion) break;
                    CoinLeft--;
                    return;
                case GenerateType.Item:
                    if (bigMario) Core.Object.Generate<Fireflower>();
                    else Core.Object.Generate<Mushroom>();
                    break;
                case GenerateType.Star:
                    Core.Object.Generate<Star>();
                    break;
                case GenerateType.OneUp:
                    Core.Object.Generate<OneUp>();
                    break;
            }
            if (SpriteState.isQuestion || SpriteState.isHidden || HasStar)
                SpriteState.ToUsedBlock();
        }

        public void NormalBlockDestroyed()
        {
            SpriteState.SetSpriteFrequency(20);
            SoundManager.BlockBreakSoundPlay();
            Core.Object.Generate(new Vector2(-(float) Core.Object.PositionRectangle.Width/4, 0),
                BlockDebris.LowerLeft);
            Core.Object.Generate(new Vector2((float) Core.Object.PositionRectangle.Width/4, 0),
                BlockDebris.LowerRight);
            Core.Object.Generate(
                new Vector2(-(float) Core.Object.PositionRectangle.Width/4,
                    -(float) Core.Object.PositionRectangle.Height/2), BlockDebris.UpperLeft);
            Core.Object.Generate(
                new Vector2((float) Core.Object.PositionRectangle.Width/4,
                    -(float) Core.Object.PositionRectangle.Height/2), BlockDebris.UpperRight);
            Core.Object.Unload();
        }
    }
}
