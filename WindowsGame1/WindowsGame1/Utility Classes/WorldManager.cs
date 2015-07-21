using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using WindowsGame1.Exceptions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using LevelLoader;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WindowsGame1
{
    public class WorldManager
    {
        private bool frozen;
        private Counter freezeTimer;
        private readonly Collection<IList> _objectList;
        private static WorldManager _instance;

        private static bool Modified { get; set; }

        private ObjectData[] LevelData { get; set; }

        private ContentManager Content { get; set; }

        private static WorldManager Instance
        {
            get
            {
                Initialize();
                return _instance;
            }
        }

        public enum LevelSection
        {
            Default,
            Underground,
            Warp
        }

        public static LevelSection CurrentSection { get; set; }

        public static void SetDefaultSection()
        {
            CurrentSection = LevelSection.Default;
            Reload();
        }

        public static void SetUndergroundSection()
        {
            CurrentSection = LevelSection.Underground;
            Reload();
        }
        public static void SetWarpSection()
        {
            CurrentSection = LevelSection.Warp;
            Reload();
        }

        private WorldManager()
        {
            _objectList = new Collection<IList>
            {
                // Background objects should be drawn first
                new Collection<Hill>(),
                new Collection<Bush>(),
                new Collection<Cloud>(),

                // then items
                new Collection<Coin>(),
                new Collection<Star>(),
                new Collection<Fireflower>(),
                new Collection<Mushroom>(),
                new Collection<OneUp>(),
                new Collection<FloatingCoinObject>(),

                // then blocks
                new Collection<QuestionBlockObject>(),
                new Collection<HiddenBlockObject>(),
                new Collection<NormalBlockObject>(),
                new Collection<BlockKernel>(),

                // then scenery
                new Collection<FloorBlockObject>(),
                new Collection<CastleObject>(),
                new Collection<FlagPoleObject>(),

                // then enemies
                new Collection<Goomba>(),
                new Collection<Koopa>(),

                // Mario should be drawn after items and enemies
                new Collection<MarioObject>(),

                // Put green pipe after Mario to allow Mario goes into pipe
                new Collection<GreenPipeObject>(),
                new Collection<SmallPipeObject>(),
                new Collection<MediumPipeObject>(),
                new Collection<SecretPipeObject>(),

                // Fireball is on the top of everything
                new Collection<FireballObject>()
            };
        }

        public static void Initialize()
        {
            _instance = _instance ?? new WorldManager();
        }

        public static List<IObject> ObjectList
        {
            get { return Instance._objectList.SelectMany(list => (IEnumerable<IObject>)list).ToList(); }
        }

        public static List<Collection<T>> FindObjectCollectionList<T>() where T : IObject
        {
            return Instance._objectList.OfType<Collection<T>>().ToList();
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

        public static void RemoveObject(IObject obj)
        {
            if (obj is MarioObject) return;
            if (!ObjectList.Contains(obj)) return;
            foreach (var collection in Instance._objectList)
            {
                collection.Remove(obj);
            }
            Camera.RemoveObject(obj);
        }

        public static void CreateObject<T>(Vector2 position, T obj = null) where T : class, IObject, new()
        {
            obj = obj ?? new T();
            obj.Load(Instance.Content, position);
            FindObjectCollection<T>().Add(obj);
            Modified = true;
        }

        public static void ReplaceObject<T>(IObject obj, T substitute = null) where T : class, IObject, new()
        {
            CreateObject(obj.PositionPoint, substitute);
            RemoveObject(obj);
            Modified = true;
        }

        public static void LoadObject(Object obj, Vector2 position)
        {
            ((IObject)obj).Load(Instance.Content, position);
            Instance._objectList.First(list => list.GetType().GetGenericArguments().Single() == obj.GetType())
                .Add(obj);
        }

        public static void FreezeWorld(int time = 0)
        {
            Instance.frozen = true;
            Instance.freezeTimer = new Counter(time);
        }

        public static void RestoreWorld()
        {
            Instance.frozen = false;
        }

        public static void LoadLevel(ContentManager content)
        {
            Instance.Content = content;
            //CurrentSection = LevelSection.Default;
            if (CurrentSection == LevelSection.Default)
            {
                Instance.LevelData = content.Load<ObjectData[]>("LevelData");
                CreateObject<MarioObject>(new Vector2(75, 398));
            }
            else if (CurrentSection == LevelSection.Underground)
            {
                Instance.LevelData = content.Load<ObjectData[]>("UndergroundLevel");
                CreateObject<MarioObject>(new Vector2(50, 200));
            }
            else if (CurrentSection == LevelSection.Warp)
            {
                Instance.LevelData = content.Load<ObjectData[]>("LevelData");
                CreateObject<MarioObject>(new Vector2(5216, 370));
                Camera.Adjust(new Vector2(5200, 0));
            }

            var nameSpace = Instance.GetType().Namespace;
            foreach (var data in Instance.LevelData)
            {
                try
                {
                    var type = Type.GetType(nameSpace + "." + data.Type);
                    Debug.Assert(type != null);
                    var obj = Activator.CreateInstance(type);
                    if (!string.IsNullOrEmpty(data.Version)) obj = type.GetProperty(data.Version).GetValue(null, null);
                    LoadObject(obj, data.Location);
                }
                catch (Exception)
                {
                    var type = nameSpace + "." + data.Type;
                    var version = string.IsNullOrEmpty(data.Version)
                        ? string.Empty
                        : " with a version name " + data.Version;
                    throw new InvalidIObjectException("Unable to create instance of an IObject from type " + type + version + "!");
                }
            }
        }

        public static void Update()
        {
            FindObject<MarioObject>().Update();

            if (Camera.Adjusted || Modified)
            {
                Camera.ClearObject();
                foreach (var collection in Instance._objectList)
                    for (var i = 0; i < collection.Count; i++)
                    {
                        var obj = (IObject) collection[i];
                        if (!Camera.OutOfRange(obj)) Camera.AddObject(obj);
                    }
            }

            Modified = false;

            if (Instance.frozen)
            {
                if (Instance.freezeTimer.Update()) RestoreWorld();
            }
            else
            {
                for (var i = 0; i < Camera.ObjectList.Count; i++)
                {
                    if (Camera.ObjectList[i] is MarioObject) continue;
                    Camera.ObjectList[i].Update();
                }
            }
            if (Camera.OutOfRange(FindObject<MarioObject>()))
            {
                new MarioDieCommand().Execute();
                FindObject<MarioObject>().Freeze();
            }
            if (SoundManager.DieMusicFinished)
            {
                Reload();
            }
        }

        public static void Reload()
        {
            foreach (var collection in Instance._objectList)
                collection.Clear();
            LoadLevel(Instance.Content);
            Camera.Reset();
            Modified = true;
            RestoreWorld();

            if (CurrentSection == LevelSection.Default)
            {
                Display.Reset();
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (var collection in Instance._objectList)
                foreach (IObject obj in collection)
                    if (!Camera.OutOfRange(obj)) obj.Draw(spriteBatch);
        }
    }
}