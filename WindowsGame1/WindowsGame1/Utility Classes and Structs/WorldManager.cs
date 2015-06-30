using System;
using System.Collections;
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
        public Collection<IList> ObjectList { get; private set; }

        ObjectData[] Locations;

        private ContentManager Content;
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

        public static List<Collection<T>> FindObjectCollectionList<T>() where T : IObject
        {
            return Instance.ObjectList.OfType<Collection<T>>().ToList();
        }

        public static Collection<T> FindObjectCollection<T>() where T : IObject
        {
            return FindObjectCollectionList<T>().First();
        }

        public static T FindObject<T>(int index = 0) where T : IObject
        {
            try
            {
                return FindObjectCollection<T>()[index];
            }
            catch (Exception e)
            {
                return default(T);
            }
        }

        private static Collection<T> Populator<T>(int amount = 1) where T :  IObject, new()
        {
            var collection = new Collection<T>();
            for (int i = 0; i < amount; i++)
            {
                collection.Add(new T());
            }
            return collection;
        }

        public void RemoveObject(IObject obj)
        {
            foreach (var collection in ObjectList)
            {
                collection.Remove(obj);
            }
        }

        public void ReplaceObject<T>(IObject obj) where T :  IObject, new()
        {
            var substitute = new T();
            substitute.Load(Content, obj.PositionPoint);
            RemoveObject(obj);
            FindObjectCollection<T>().Add(substitute);
        }

        private WorldManager()
        {
            ObjectList = new Collection<IList>
            {
                // background objects should be drawn first
                Populator<Hill>(),
                Populator<Bush>(),
                Populator<Cloud>(),

                // then items
                Populator<Coin>(),
                Populator<Star>(),
                Populator<QuestionBlockObject>(),
                Populator<HiddenBlockObject>(),
                Populator<NormalBlockObject>(),
                Populator<DestructibleBlockObject>(),
                Populator<IndestructibleBlockObject>(),
                Populator<GreenPipeObject>(),
                Populator<UsedBlockObject>(),
                Populator<Fireflower>(),
                Populator<Mushroom>(),
                Populator<_1up>(),

                // then enemies
                Populator<Goomba>(),
                Populator<Koopa>(),

                // Mario should be drawn in the end
                Populator<MarioObject>()
            };
        }

        public void LoadContent(ContentManager content)
        {
            Content = content;
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
            // In order to avoid exception when objects unload themselves,
            // for loops below should not be converted to foreach loops.
            for (int i = 0; i < ObjectList.Count; i++)
            {
                for (int j = 0; j < ObjectList[i].Count; j++)
                {
                    ((IObject)ObjectList[i][j]).Update();
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var collection in ObjectList)
            {
                foreach (IObject obj in collection)
                {
                    obj.Draw(spriteBatch);
                }
            }
        }
    }
}