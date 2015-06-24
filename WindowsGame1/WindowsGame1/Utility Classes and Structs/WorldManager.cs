using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using LevelLoader;

namespace WindowsGame1
{
    public class WorldManager
    {
        public Collection<IObject> ObjectList { get; private set; }

        ObjectData[] Locations;
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

        public Hill Hill { get; private set; }
        public Bush Bush { get; private set; }
        public Cloud Cloud { get; private set; }
        
        //public MarioFireflowerCollisions MarioFireflowerCollisions;

        public WorldManager()
        {
            
            ObjectList = new Collection<IObject>();
            //MarioFireflowerCollisions = new MarioFireflowerCollisions();
            //MarioFireflowerCollisions.MarioFireflowerRightCollision(this);
            Mario = new MarioObject(this);
            Goomba = new Goomba(this); 
            Koopa = new Koopa(this);

            Coin = new Coin(this);
            Star = new Star(this);
            QuestionBlock = new QuestionBlockObject(this);
            HiddenBlock = new HiddenBlockObject(this);
            NormalBlock = new NormalBlockObject(this);
            DestructibleBlock = new DestructibleBlockObject(this);
            IndestructibleBlock = new IndestructibleBlockObject(this);
            GreenPipe = new GreenPipeObject(this);
            UsedBlock = new UsedBlockObject(this);
            Fireflower = new Fireflower(this);
            Mushroom = new Mushroom(this);
            _1up = new _1up(this);
            Hill = new Hill(this);
            Bush = new Bush(this);
            Cloud = new Cloud(this);
            
            // background things should be drawn first
            ObjectList.Add(Bush);
            ObjectList.Add(Hill);
            ObjectList.Add(Cloud);

            // then items
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

            // then enemies
            ObjectList.Add(Koopa);
            ObjectList.Add(Goomba);

            // Mario should be drawn in the end
            ObjectList.Add(Mario);
        }

        public void LoadContent(ContentManager content)
        {
//            foreach (var obj in ObjectList)
//            {
//                obj.Load(content);
//            }
            Locations = content.Load<ObjectData[]>("Locations");
            Mario.Load(content, new Vector2(200, 170));
            
            Goomba.Load(content, Locations[1].Location);
            Koopa.Load(content, Locations[2].Location);
            Coin.Load(content, Locations[3].Location);
            Star.Load(content, Locations[4].Location);
            QuestionBlock.Load(content, Locations[5].Location);
            HiddenBlock.Load(content, Locations[6].Location);
            NormalBlock.Load(content, Locations[7].Location);
            DestructibleBlock.Load(content, Locations[8].Location);
            IndestructibleBlock.Load(content, Locations[9].Location);
            GreenPipe.Load(content, Locations[10].Location);
            UsedBlock.Load(content, Locations[11].Location);
            Fireflower.Load(content, Locations[12].Location);
            Mushroom.Load(content, Locations[13].Location);
            _1up.Load(content, Locations[14].Location);
            Hill.Load(content, Locations[15].Location);
            Bush.Load(content, Locations[16].Location);
            Cloud.Load(content, Locations[17].Location);
        }

        public void Update()
        {
            for (int i = 0; i < ObjectList.Count; i++)
            {
                ObjectList[i].Update();
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