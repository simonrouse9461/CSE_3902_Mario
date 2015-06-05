using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame1
{
    
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private IController<Keys> _keyboardController;
        private IController<Buttons> _gamepadController;


        //public IObject<MarioSpriteEnum, MarioMotionEnum> Mario;
        public IObject<BlockSpriteEnum, BlockMotionEnum> QuestionBlock;
        public IObject<BlockSpriteEnum, BlockMotionEnum> UsedBlock;
        public IObject<BlockSpriteEnum, BlockMotionEnum> NormalBlock;
        public IObject<BlockSpriteEnum, BlockMotionEnum> HiddenBlock;
        public IObject<BlockSpriteEnum, BlockMotionEnum> IndestructibleBlock;
        public IObject<BlockSpriteEnum, BlockMotionEnum> DestructibleBlock;
        public IObject<BlockSpriteEnum, BlockMotionEnum> GreenPipe;
        public IObject<FireflowerSpriteEnum, FireflowerMotionEnum> Fireflower;
        public IObject<MushroomSpriteEnum, MushroomMotionEnum> Mushroom;
        public IObject<_1upSpriteEnum, MushroomMotionEnum> _1up;
        public IObject<EnemySpriteEnum, EnemyMotionEnum> Koopa;
        public IObject<EnemySpriteEnum, EnemyMotionEnum> Goomba;
        private ICommand quitCommand;
        private ICommand runningInPlaceCommand;
        private ICommand deadCommand;
        private ICommand runningCommand;
        private ICommand questionBlockCommand;
        private ICommand normalBlockCommand;
        private ICommand fireflowerCommand;
        private ICommand mushroomCommand;
        private ICommand koopaCommand;
        private ICommand hiddenBlockCommand;

        private Texture2D background;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

       
        protected override void Initialize()
        {
            
            _keyboardController = new KeyboardController();
            _gamepadController = new GamepadController();

            quitCommand = new QuitCommand(this);
            deadCommand = new DeadCommand(this);
            questionBlockCommand = new QuestionBlockCommand(this);
            mushroomCommand = new MushroomCommand(this);
            fireflowerCommand = new FireflowerCommand(this);
            koopaCommand = new KoopaCommand(this);
            normalBlockCommand = new NormalBlockCommand(this);
            hiddenBlockCommand = new HiddenBlockCommand(this);
            _keyboardController.RegisterCommand(Keys.Q, quitCommand);
            _keyboardController.RegisterCommand(Keys.W, runningInPlaceCommand);
            _keyboardController.RegisterCommand(Keys.E, deadCommand);
            _keyboardController.RegisterCommand(Keys.R, runningCommand);
            _keyboardController.RegisterCommand(Keys.Z, questionBlockCommand);
            _keyboardController.RegisterCommand(Keys.K, koopaCommand);
            _keyboardController.RegisterCommand(Keys.M, mushroomCommand);
            _keyboardController.RegisterCommand(Keys.F, fireflowerCommand);
            _keyboardController.RegisterCommand(Keys.X, normalBlockCommand);
            _keyboardController.RegisterCommand(Keys.C, hiddenBlockCommand);
            _gamepadController.RegisterCommand(Buttons.Back, quitCommand);
            _gamepadController.RegisterCommand(Buttons.A, runningInPlaceCommand);
            _gamepadController.RegisterCommand(Buttons.B, deadCommand);
            _gamepadController.RegisterCommand(Buttons.X, runningCommand);

            //Mario = new MarioObject(new Vector2(400, 240));
            QuestionBlock = new BlockObject(new Vector2(300, 200));
            UsedBlock = new BlockObject(new Vector2(250, 200));
            UsedBlock.SwitchSprite(BlockSpriteEnum.UsedBlock);
            NormalBlock = new BlockObject(new Vector2(200, 200));
            NormalBlock.SwitchSprite(BlockSpriteEnum.NormalBlock);
            HiddenBlock = new BlockObject(new Vector2(150, 200));
            HiddenBlock.SwitchSprite(BlockSpriteEnum.HiddenBlock);
            IndestructibleBlock = new BlockObject(new Vector2(150, 300));
            IndestructibleBlock.SwitchSprite(BlockSpriteEnum.IndestructibleBlock);
            DestructibleBlock = new BlockObject(new Vector2(350, 200));
            DestructibleBlock.SwitchSprite(BlockSpriteEnum.DestructibleBlock);
            GreenPipe = new BlockObject(new Vector2(300, 100));
            GreenPipe.SwitchSprite(BlockSpriteEnum.GreenPipe);
            Fireflower = new Fireflower(new Vector2(400, 300));
            Mushroom = new Mushroom(new Vector2(500, 300));
            _1up = new _1up(new Vector2(600, 300));
            Koopa = new Koopa(new Vector2(300, 300));
            Goomba = new Goomba(new Vector2(340, 302));
            Goomba.SwitchSprite(EnemySpriteEnum.Goomba);
            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            
            spriteBatch = new SpriteBatch(GraphicsDevice);

            
            background = Content.Load<Texture2D>("overworld");

            //Mario.Load(Content);
            QuestionBlock.Load(Content);
            UsedBlock.Load(Content);
            NormalBlock.Load(Content);
            HiddenBlock.Load(Content);
            IndestructibleBlock.Load(Content);
            DestructibleBlock.Load(Content);
            GreenPipe.Load(Content);
            Mushroom.Load(Content);
            _1up.Load(Content);
            Fireflower.Load(Content);
            Koopa.Load(Content);
            Goomba.Load(Content);
            base.LoadContent();
        }

       
        protected override void UnloadContent()
        {
            

            base.UnloadContent();
        }

  
        protected override void Update(GameTime gameTime)
        {
            
            _keyboardController.Update();
            _gamepadController.Update();

            //Mario.Update();
            QuestionBlock.Update();
            Fireflower.Update();
            Mushroom.Update();
            _1up.Update();
            Koopa.Update();
            Goomba.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            spriteBatch.Begin();

            spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.White);

            //Mario.Draw(spriteBatch);
            QuestionBlock.Draw(spriteBatch);
            UsedBlock.Draw(spriteBatch);
            NormalBlock.Draw(spriteBatch);
            HiddenBlock.Draw(spriteBatch);
            IndestructibleBlock.Draw(spriteBatch);
            DestructibleBlock.Draw(spriteBatch);
            GreenPipe.Draw(spriteBatch);
            Fireflower.Draw(spriteBatch);
            Mushroom.Draw(spriteBatch);
            _1up.Draw(spriteBatch);
            Koopa.Draw(spriteBatch);
            Goomba.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
