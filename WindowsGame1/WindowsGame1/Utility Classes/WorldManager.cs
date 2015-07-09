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
                // Background objects should be drawn first
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
                new Collection<Fireflower>(),
                new Collection<Mushroom>(),
                new Collection<OneUp>(),

                // then enemies
                new Collection<Goomba>(),
                new Collection<Koopa>(),
                new Collection<FloorBlockObject>(),

                // Mario should be drawn after items and enemies
                new Collection<MarioObject>(),

                // Put green pipe after Mario to allow Mario goes into pipe
                new Collection<GreenPipeObject>(),

                // Fireball is on the top of everything
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

        public void LoadObject(Object obj, Vector2 position)
        {
            ((IObject) obj).Load(Content, position);
            Instance.ObjectList.First(list => list.GetType().GetGenericArguments().Single() == obj.GetType())
                .Add(obj);
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

        public void LoadLevel(ContentManager content)
        {
            Content = content;
            LevelData = content.Load<ObjectData[]>("LevelData");
            var nameSpace = GetType().Namespace;
            CreateObject<MarioObject>(new Vector2(75, 398));
            foreach (var data in LevelData)
            {
                var type = Type.GetType(nameSpace + "." + data.Type);
                if (type == null) throw new Exception(nameSpace + "." + data.Type + " is not a valid type!");
                var obj = Activator.CreateInstance(type);
                try
                {
                    if (data.Version != "") obj = type.GetProperty(data.Version).GetValue(obj, null);
                    LoadObject(obj, data.Location);
                }
                catch (Exception)
                {
                    throw new Exception(nameSpace + "." + data.Type + " has no version called " + data.Version + "!");
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
            else foreach (var collection in ObjectList)
                for (var i = 0; i < collection.Count; i++)
                    ((IObject) collection[i]).Update();
            
            if (Camera.OutOfRange(FindObject<MarioObject>(), new Vector4(0,200,0,200))) Reset();
        }

        public void Reset()
        {
            foreach (var collection in ObjectList)
                for (var i = collection.Count - 1; i >= 0; i--)
                    collection.Remove(collection[i]);
            LoadLevel(Content);
            Camera.Reset();
            RestoreWorld();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var collection in ObjectList)
                foreach (IObject obj in collection)
                    obj.Draw(spriteBatch);
        }
    }
}