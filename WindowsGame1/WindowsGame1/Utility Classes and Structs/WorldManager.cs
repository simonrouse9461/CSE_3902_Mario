﻿using System.Collections.Generic;
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

        public WorldManager()
        {
            ObjectList = new Collection<IObject>();

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
            Goomba.Load(content, new Vector2(230, 300));
            Koopa.Load(content, new Vector2(200, 300));

            Coin.Load(content, new Vector2(450, 300));
            Star.Load(content, new Vector2(500, 300));
            QuestionBlock.Load(content, new Vector2(300, 200));
            HiddenBlock.Load(content, new Vector2(200, 200));
            NormalBlock.Load(content, new Vector2(100, 200));
            DestructibleBlock.Load(content, new Vector2(350, 200));
            IndestructibleBlock.Load(content, new Vector2(150, 200));
            GreenPipe.Load(content, new Vector2(500, 200));
            UsedBlock.Load(content, new Vector2(250, 200));
            Fireflower.Load(content, new Vector2(400, 304));
            Mushroom.Load(content, new Vector2(550, 300));
            _1up.Load(content, new Vector2(600, 300));
            Hill.Load(content, new Vector2(700, 405));
            Bush.Load(content, new Vector2(450, 405));
            Cloud.Load(content, new Vector2(400, 100));
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