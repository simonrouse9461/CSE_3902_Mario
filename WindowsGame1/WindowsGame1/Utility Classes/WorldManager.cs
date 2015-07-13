﻿using System;
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
        private bool freeze;
        private Counter freezeTimer;
        private readonly Collection<IList> _objectList;
        private static WorldManager _instance;

        private static bool Reloaded { get; set; }

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
                new Collection<SmallPipeObject>(),
                new Collection<MediumPipeObject>(),
                //new Collection<SecretPipeObject>(),

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
            get { return Instance._objectList.SelectMany(list => (IEnumerable<IObject>) list).ToList(); }
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
            foreach (var collection in Instance._objectList)
            {
                collection.Remove(obj);
            }
        }

        public static void CreateObject<T>(Vector2 position, T obj = null) where T : class, IObject, new()
        {
            obj = obj ?? new T();
            obj.Load(Instance.Content, position);
            FindObjectCollection<T>().Add(obj);
        }

        public static void ReplaceObject<T>(IObject obj, T substitute = null) where T : class, IObject, new()
        {
            CreateObject(obj.PositionPoint, substitute);
            RemoveObject(obj);
        }

        public static void LoadObject(Object obj, Vector2 position)
        {
            ((IObject) obj).Load(Instance.Content, position);
            Instance._objectList.First(list => list.GetType().GetGenericArguments().Single() == obj.GetType())
                .Add(obj);
        }

        public static void FreezeWorld(int time = 0)
        {
            Instance.freeze = true;
            Instance.freezeTimer = new Counter(time);
        }

        public static void RestoreWorld()
        {
            Instance.freeze = false;
        }

        public static void LoadLevel(ContentManager content)
        {
            Instance.Content = content;
            Instance.LevelData = content.Load<ObjectData[]>("LevelData");
            var nameSpace = Instance.GetType().Namespace;
            CreateObject<MarioObject>(new Vector2(75, 398));
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

            if (Camera.Adjusted || Reloaded)
                foreach (var collection in Instance._objectList)
                    for (var i = 0; i < collection.Count; i++)
                    {
                        var obj = (IObject) collection[i];
                        if (Camera.OutOfRange(obj)) Camera.RemoveObject(obj);
                        else Camera.AddObject(obj);
                    }

            Reloaded = false;

            if (Instance.freeze)
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

            if (Camera.OutOfRange(FindObject<MarioObject>(), new Vector4(0,200,0,200))) Reload();
        }
        
        public static void Reload()
        {
            foreach (var collection in Instance._objectList)
                collection.Clear();
            LoadLevel(Instance.Content);
            Camera.Reset();
            Display.Reset();
            Reloaded = true;
            RestoreWorld();
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (var collection in Instance._objectList)
                foreach (IObject obj in collection)
                    if (!Camera.OutOfRange(obj)) obj.Draw(spriteBatch);
        }
    }
}