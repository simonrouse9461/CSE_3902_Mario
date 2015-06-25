using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        
        //public MarioFireflowerCollisions MarioFireflowerCollisions;

        private static WorldManager _instance;
        public static WorldManager Instance
        {
            get
            {
                _instance = _instance ?? new WorldManager();
                return _instance;
            }
        }

        public static List<T> FindObjectList<T>() where T : IObject
        {
            return Instance.ObjectList.OfType<T>().ToList();
        }

        public static T FindObject<T>(int index = 0) where T : IObject
        {
            return Instance.ObjectList.OfType<T>().ToList()[index];
        }

        private WorldManager()
        {
            ObjectList = new Collection<IObject>
            {
                // background objects should be drawn first
                new Hill(),
                new Bush(),
                new Cloud(),

                // then items
                new Coin(),
                new Star(),
                new QuestionBlockObject(),
                new HiddenBlockObject(),
                new NormalBlockObject(),
                new DestructibleBlockObject(),
                new IndestructibleBlockObject(),
                new GreenPipeObject(),
                new UsedBlockObject(),
                new Fireflower(),
                new Mushroom(),
                new _1up(),

                // then enemies
                new Goomba(),
                new Koopa(),

                // Mario should be drawn in the end
                new MarioObject()
            };
        }

        public void LoadContent(ContentManager content)
        {
//            foreach (var obj in ObjectList)
//            {
//                obj.Load(content);
//            }
            Locations = content.Load<ObjectData[]>("Locations");
            FindObject<MarioObject>().Load(content, new Vector2(200, 170));
            
            FindObject<Goomba>().Load(content, Locations[1].Location);
            FindObject<Koopa>().Load(content, Locations[2].Location);
            FindObject<Coin>().Load(content, Locations[3].Location);
            FindObject<Star>().Load(content, Locations[4].Location);
            FindObject<QuestionBlockObject>().Load(content, Locations[5].Location);
            FindObject<HiddenBlockObject>().Load(content, Locations[6].Location);
            FindObject<NormalBlockObject>().Load(content, Locations[7].Location);
            FindObject<DestructibleBlockObject>().Load(content, Locations[8].Location);
            FindObject<IndestructibleBlockObject>().Load(content, Locations[9].Location);
            FindObject<GreenPipeObject>().Load(content, Locations[10].Location);
            FindObject<UsedBlockObject>().Load(content, Locations[11].Location);
            FindObject<Fireflower>().Load(content, Locations[12].Location);
            FindObject<Mushroom>().Load(content, Locations[13].Location);
            FindObject<_1up>().Load(content, Locations[14].Location);
            FindObject<Hill>().Load(content, Locations[15].Location);
            FindObject<Bush>().Load(content, Locations[16].Location);
            FindObject<Cloud>().Load(content, Locations[17].Location);
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