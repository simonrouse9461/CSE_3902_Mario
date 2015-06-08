using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    public class WorldManager
    {
        public MarioObject Mario;

        public IObject<BlockSpriteEnum, BlockMotionEnum> QuestionBlock;
        public IObject<BlockSpriteEnum, BlockMotionEnum> UsedBlock;
        public IObject<BlockSpriteEnum, BlockMotionEnum> NormalBlock;
        public IObject<BlockSpriteEnum, BlockMotionEnum> HiddenBlock;
        public IObject<BlockSpriteEnum, BlockMotionEnum> IndestructibleBlock;
        public IObject<BlockSpriteEnum, BlockMotionEnum> DestructibleBlock;
        public IObject<BlockSpriteEnum, BlockMotionEnum> GreenPipe;
        public IObject<FireflowerSpriteEnum, FireflowerMotionEnum> Fireflower;
        public IObject<CoinSpriteEnum, CoinMotionEnum> Coin;
        public IObject<StarSpriteEnum, StarMotionEnum> Star;
        public IObject<MushroomSpriteEnum, MushroomMotionEnum> Mushroom;
        public IObject<_1upSpriteEnum, MushroomMotionEnum> _1up;
        public IObject<EnemySpriteEnum, EnemyMotionEnum> Koopa;
        public IObject<EnemySpriteEnum, EnemyMotionEnum> Goomba;

        public WorldManager()
        {
            Mario = new MarioObject(new Vector2(200, 100));

            QuestionBlock = new BlockObject(new Vector2(300, 200));
            UsedBlock = new BlockObject(new Vector2(250, 200));
            UsedBlock.SwitchSprite(BlockSpriteEnum.UsedBlock);
            NormalBlock = new BlockObject(new Vector2(200, 200));
            NormalBlock.SwitchSprite(BlockSpriteEnum.NormalBlock);
            HiddenBlock = new BlockObject(new Vector2(150, 200));
            HiddenBlock.SwitchSprite(BlockSpriteEnum.HiddenBlock);
            IndestructibleBlock = new BlockObject(new Vector2(150, 200));
            IndestructibleBlock.SwitchSprite(BlockSpriteEnum.IndestructibleBlock);
            DestructibleBlock = new BlockObject(new Vector2(350, 200));
            DestructibleBlock.SwitchSprite(BlockSpriteEnum.DestructibleBlock);
            GreenPipe = new BlockObject(new Vector2(300, 100));
            GreenPipe.SwitchSprite(BlockSpriteEnum.GreenPipe);
            Fireflower = new Fireflower(new Vector2(400, 300));
            Coin = new Coin(new Vector2(100, 100));
            Star = new Star(new Vector2(120, 100));
            Mushroom = new Mushroom(new Vector2(500, 300));
            _1up = new _1up(new Vector2(600, 300));
            Koopa = new Koopa(new Vector2(300, 300));
            Goomba = new Goomba(new Vector2(340, 302));
            Goomba.SwitchSprite(EnemySpriteEnum.Goomba);
        }

        public void LoadContent(ContentManager content)
        {

            Mario.Load(content);

            QuestionBlock.Load(content);
            UsedBlock.Load(content);
            NormalBlock.Load(content);
            HiddenBlock.Load(content);
            IndestructibleBlock.Load(content);
            DestructibleBlock.Load(content);
            GreenPipe.Load(content);
            Mushroom.Load(content);
            _1up.Load(content);
            Fireflower.Load(content);
            Coin.Load(content);
            Star.Load(content);
            Koopa.Load(content);
            Goomba.Load(content);
        }

        public void Update()
        {
            Mario.Update();

            QuestionBlock.Update();
            Fireflower.Update();
            Coin.Update();
            Star.Update();
            Mushroom.Update();
            _1up.Update();
            Koopa.Update();
            Goomba.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Mario.Draw(spriteBatch);

            QuestionBlock.Draw(spriteBatch);
            UsedBlock.Draw(spriteBatch);
            NormalBlock.Draw(spriteBatch);
            HiddenBlock.Draw(spriteBatch);
            IndestructibleBlock.Draw(spriteBatch);
            DestructibleBlock.Draw(spriteBatch);
            GreenPipe.Draw(spriteBatch);
            Fireflower.Draw(spriteBatch);
            Coin.Draw(spriteBatch);
            Star.Draw(spriteBatch);
            Mushroom.Draw(spriteBatch);
            _1up.Draw(spriteBatch);
            Koopa.Draw(spriteBatch);
            Goomba.Draw(spriteBatch);
        }
    }
}