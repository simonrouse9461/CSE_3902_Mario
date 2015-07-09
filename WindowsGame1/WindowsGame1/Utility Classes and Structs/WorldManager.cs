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

        ObjectData[] LevelData;

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
                new Collection<OneUp>(),

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

        public void FreezeWorld(int time = 0)
        {
            freeze = true;
            freezeTimer = new Counter(time);
        }

        public void RestoreWorld()
        {
            freeze = false;
        }

        public void LoadContent(ContentManager content)
        {
            Content = content;

            FindObjectCollection<MarioObject>().Add(new MarioObject());
            FindObject<MarioObject>().Load(content, new Vector2(75, 398));

            LevelData = content.Load<ObjectData[]>("LevelData");
            for (var i = 0; i < LevelData.Length; i++)
            {
                switch (LevelData[i].Type)
                {
                    case "Goomba":
                        CreateObject<Goomba>(LevelData[i].Location);
                        break;
                    case "Koopa":
                        CreateObject<Koopa>(LevelData[i].Location);
                        break;
                    case "BlockKernel":
                        CreateObject<BlockKernel>(LevelData[i].Location);
                        break;
                    case "QuestionBlockObject":
                        CreateObject<QuestionBlockObject>(LevelData[i].Location);
                        break;
                    case "HiddenBlockObject":
                        CreateObject<HiddenBlockObject>(LevelData[i].Location);
                        break;
                    case "NormalBlockObject":
                        CreateObject<NormalBlockObject>(LevelData[i].Location);
                        break;
                    case "FloorBlockObject":
                        CreateObject<FloorBlockObject>(LevelData[i].Location);
                        break;
                    case "GreenPipeObject":
                        CreateObject<GreenPipeObject>(LevelData[i].Location);
                        break;
                    case "Hill":
                        CreateObject<Hill>(LevelData[i].Location);
                        break;
                    case "Bush":
                        CreateObject<Bush>(LevelData[i].Location);
                        break;
                    case "Cloud":
                        CreateObject<Cloud>(LevelData[i].Location);
                        break;
                    case "Fireflower":
                        CreateObject<Fireflower>(LevelData[i].Location);
                        break;
                    case "Mushroom":
                        CreateObject<Mushroom>(LevelData[i].Location);
                        break;
                    case "Star":
                        CreateObject<Star>(LevelData[i].Location);
                        break;
                }
            }
        }

        public void Update()
        {
            if (freeze)
            {
                FindObject<MarioObject>().Update();
                if (freezeTimer.Update()) RestoreWorld();
            }
            else
            {
                // In order to avoid exception when objects unload themselves,
                // for loops below should not be converted to foreach loops.
                for (var i = 0; i < ObjectList.Count; i++)
                {
                    for (var j = 0; j < ObjectList[i].Count; j++)
                    {
                        ((IObject)ObjectList[i][j]).Update();
                    }
                }
            }

            if (Camera.OutOfRange(FindObject<MarioObject>(), new Vector4(0,200,0,200)))
            {
                Reset();
            }
        }

        public void Reset()
        {
            foreach (var collection in ObjectList)
            {
                for (var i = collection.Count - 1; i >= 0; i--)
                {
                    collection.Remove(collection[i]);
                }
            }
            LoadContent(Content);
            Camera.Reset();
            RestoreWorld();
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