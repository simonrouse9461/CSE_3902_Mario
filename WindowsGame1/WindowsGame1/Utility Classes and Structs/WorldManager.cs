using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    public class WorldManager
    {
        public Collection<IObject> ObjectList { get; private set; }

        public MarioObject Mario { get; private set; }

        public QuestionBlockObject QuestionBlock { get; private set; }
        public HiddenBlockObject HiddenBlock { get; private set; }
        public NormalBlockObject NormalBlock { get; private set; }
        public DestructibleBlockObject DestructibleBlock { get; private set; }
        public IndestructibleBlockObject IndestructibleBlock { get; private set; }
        public UsedBlockObject UsedBlock { get; private set; }

        public Koopa Koopa { get; private set; }
        public Goomba Goomba { get; private set; }

        public Coin Coin { get; private set; }
        public Star Star { get; private set; }
        public Fireflower Fireflower { get; private set; }
        public _1up _1up { get; private set; }
        public Mushroom Mushroom { get; private set; }
        public GreenPipeObject GreenPipe { get; private set; }

        public Hill Hill;
        public Bush Bush;
        public Cloud Cloud;

        public WorldManager()
        {
            ObjectList = new Collection<IObject>();

            Mario = new MarioObject(new Vector2(200, 170), this);
            Goomba = new Goomba(new Vector2(230, 300), this); 
            Koopa = new Koopa(new Vector2(200, 300), this);

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
            Hill = new Hill(new Vector2(700, 300), this);
            Bush = new Bush(new Vector2(700, 500), this);
            Cloud = new Cloud(new Vector2(200, 300), this);
            

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
            ObjectList.Add(Goomba);
            ObjectList.Add(Mario);
            ObjectList.Add(Bush);
            ObjectList.Add(Hill);
            ObjectList.Add(Cloud);
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