using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    public class WorldManager
    {
        public List<IObject> ObjectList;
 
        public MarioObject Mario;

        public QuestionBlockObject QuestionBlock;
        public HiddenBlockObject HiddenBlock;
        public NormalBlockObject NormalBlock;
        public DestructibleBlockObject DestructibleBlock;
        public IndestructibleBlockObject IndestructibleBlock;
        public UsedBlockObject UsedBlock;

        public Koopa Koopa;
        public Goomba Goomba;

        public Coin Coin;
        public Star Star;
        public Fireflower Fireflower;
        public _1up _1up;
        public Mushroom Mushroom;
        public GreenPipeObject GreenPipe;

        public WorldManager()
        {
            ObjectList = new List<IObject>();

            Mario = new MarioObject(new Vector2(200, 170), this);
            Goomba = new Goomba(new Vector2(240, 170), this);
            Coin = new Coin(new Vector2(450, 300));
            Star = new Star(new Vector2(500, 300));
            QuestionBlock = new QuestionBlockObject(new Vector2(300, 200));
            HiddenBlock = new HiddenBlockObject(new Vector2(200, 200));
            NormalBlock = new NormalBlockObject(new Vector2(100, 200));
            DestructibleBlock = new DestructibleBlockObject(new Vector2(350, 200));
            IndestructibleBlock = new IndestructibleBlockObject(new Vector2(150, 200));
            GreenPipe = new GreenPipeObject(new Vector2(500, 200));
            UsedBlock = new UsedBlockObject(new Vector2(250, 200));
            Fireflower = new Fireflower(new Vector2(400, 304));
            Mushroom = new Mushroom(new Vector2(550, 300));
            _1up = new _1up(new Vector2(600, 300));
            Koopa = new Koopa(new Vector2(200, 300));

            //ObjectList.Add(Goomba);
            ObjectList.Add(Coin);
            ObjectList.Add(Star);
            ObjectList.Add(QuestionBlock);
            ObjectList.Add(HiddenBlock);
            ObjectList.Add(NormalBlock);
            ObjectList.Add(DestructibleBlock);
            ObjectList.Add(IndestructibleBlock);
            ObjectList.Add(GreenPipe);
            ObjectList.Add(UsedBlock);
            ObjectList.Add(Fireflower);
            ObjectList.Add(Mushroom);
            ObjectList.Add(_1up);
            ObjectList.Add(Koopa);
            ObjectList.Add(Mario);
        }

        public void LoadContent(ContentManager content)
        {
            foreach (var obj in ObjectList)
            {
                obj.Load(content);
            }
        }

        public void Update()
        {
            foreach (var obj in ObjectList)
            {
                obj.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var obj in ObjectList)
            {
                obj.Draw(spriteBatch);
            }
        }
    }
}