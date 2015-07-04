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

        private bool freeze;
        private Counter freezeTimer;

        private static WorldManager _instance;
        public static WorldManager Instance
        {
            get
            {
                _instance = _instance ?? new WorldManager();
                return _instance;
            }
        }

        private WorldManager()
        {
            ObjectList = new Collection<IList>
            {
                
                // background objects should be drawn first
                new Collection<Hill>(),
                new Collection<Bush>(),
                new Collection<Cloud>(),

                // then items
                new Collection<Coin>(),
                new Collection<Star>(),
                new Collection<QuestionBlockObject>(),
                new Collection<HiddenBlockObject>(),
                new Collection<NormalBlockObject>(),
               
                new Collection<BlockKernel>(),
                new Collection<GreenPipeObject>(),
                new Collection<Fireflower>(),
                new Collection<Mushroom>(),
                new Collection<_1up>(),

                // then enemies
                new Collection<Goomba>(),
                new Collection<Koopa>(),
                 new Collection<FloorBlockObject>(),
                // Mario should be drawn in the end
                new Collection<MarioObject>(),

                new Collection<FireballObject>()
            };
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
            catch (Exception)
            {
                return default(T);
            }
        }

        public void RemoveObject(IObject obj)
        {
            foreach (var collection in ObjectList)
            {
                collection.Remove(obj);
            }
        }

        public void CreateObject<T>(Vector2 position, T obj = null) where T : class, IObject, new()
        {
            obj = obj ?? new T();
            obj.Load(Content, position);
            FindObjectCollection<T>().Add(obj);
        }

        public void ReplaceObject<T>(IObject obj, T substitute = null) where T : class, IObject, new()
        {
            CreateObject(obj.PositionPoint, substitute);
            RemoveObject(obj);
        }

        public void FreezeWorld(int time)
        {
            freeze = true;
            freezeTimer = new Counter(time);
        }

        public void LoadContent(ContentManager content)
        {
            Content = content;

            FindObjectCollection<MarioObject>().Add(new MarioObject());
            FindObject<MarioObject>().Load(content, new Vector2(75, 398));

            Locations = content.Load<ObjectData[]>("Locations");
            for (int i = 0; i < Locations.Length; i++)
            {
                switch (Locations[i].Type)
                {
                    case "Goomba":
                        FindObjectCollection<Goomba>().Add(new Goomba());
                        FindObjectCollection<Goomba>().Last().Load(content, Locations[i].Location);
                        break;
                    case "Koopa":
                        FindObjectCollection<Koopa>().Add(new Koopa());
                        FindObjectCollection<Koopa>().Last().Load(content, Locations[i].Location);
                        break;
                    case "BlockKernel":
                        FindObjectCollection<BlockKernel>().Add(new BlockKernel());
                        FindObjectCollection<BlockKernel>().Last().Load(content, Locations[i].Location);
                        break;
                    case "QuestionBlockObject":
                        FindObjectCollection<QuestionBlockObject>().Add(new QuestionBlockObject());
                        FindObjectCollection<QuestionBlockObject>().Last().Load(content, Locations[i].Location);
                        break;
                    case "HiddenBlockObject":
                        FindObjectCollection<HiddenBlockObject>().Add(new HiddenBlockObject());
                        FindObjectCollection<HiddenBlockObject>().Last().Load(content, Locations[i].Location);
                        break;
                    case "NormalBlockObject":
                        FindObjectCollection<NormalBlockObject>().Add(new NormalBlockObject());
                        FindObjectCollection<NormalBlockObject>().Last().Load(content, Locations[i].Location);
                        break;
                    case "FloorBlockObject":
                        FindObjectCollection<FloorBlockObject>().Add(new FloorBlockObject());
                        FindObjectCollection<FloorBlockObject>().Last().Load(content, Locations[i].Location);
                        break;
                    case "GreenPipeObject":
                        FindObjectCollection<GreenPipeObject>().Add(new GreenPipeObject());
                        FindObjectCollection<GreenPipeObject>().Last().Load(content, Locations[i].Location);
                        break;
                    case "Hill":
                        FindObjectCollection<Hill>().Add(new Hill());
                        FindObjectCollection<Hill>().Last().Load(content, Locations[i].Location);
                        break;
                    case "Bush":
                        FindObjectCollection<Bush>().Add(new Bush());
                        FindObjectCollection<Bush>().Last().Load(content, Locations[i].Location);
                        break;
                    case "Cloud":
                        FindObjectCollection<Cloud>().Add(new Cloud());
                        FindObjectCollection<Cloud>().Last().Load(content, Locations[i].Location);
                        break;
                    case "Fireflower":
                        FindObjectCollection<Fireflower>().Add(new Fireflower());
                        FindObjectCollection<Fireflower>().Last().Load(content, Locations[i].Location);
                        break;
                    case "Mushroom":
                        FindObjectCollection<Mushroom>().Add(new Mushroom());
                        FindObjectCollection<Mushroom>().Last().Load(content, Locations[i].Location);
                        break;
                    case "Star":
                        FindObjectCollection<Star>().Add(new Star());
                        FindObjectCollection<Star>().Last().Load(content, Locations[i].Location);
                        break;
                    default:
                        break;
                }
            }
        }

        public void Update()
        {
            if (freeze)
            {
                FindObject<MarioObject>().Update();
                if (freezeTimer.Update())
                    freeze = false;
            }
            else
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