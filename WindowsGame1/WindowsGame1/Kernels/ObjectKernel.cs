﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    public abstract class ObjectKernel<TSpriteState, TMotionState> : IObject
        where TSpriteState : SpriteStateKernel, new()
        where TMotionState : MotionStateKernel, new()
    {
        // Object core that wraps all internal components of the object
        protected Core<TSpriteState, TMotionState> Core { get; private set; }

        // Temporarily made for test cases
        public Core<TSpriteState, TMotionState> CoreGetter
        {
            get { return Core; }
        }

        // Properties
        protected TSpriteState SpriteState
        {
            get { return Core.SpriteState; }
            set { Core.SpriteState = value; }
        }

        protected TMotionState MotionState
        {
            get { return Core.MotionState; }
            set { Core.MotionState = value; }
        }

        protected BarrierDetector BarrierDetector
        {
            get { return Core.BarrierDetector; }
            set { Core.BarrierDetector = value; }
        }

        protected ICommandExecutor CommandExecutor
        {
            get { return Core.CommandExecutor; }
            set { Core.CommandExecutor = value; }
        }

        protected ICollisionHandler CollisionHandler
        {
            get { return Core.CollisionHandler; }
            set { Core.CollisionHandler = value; }
        }

        // Constructor
        protected ObjectKernel()
        {
            Core = new Core<TSpriteState, TMotionState>
            {
                Object = this
            };
            SpriteState = new TSpriteState();
            MotionState = new TMotionState();
            BarrierDetector = new BarrierDetector(Core);
        }

        // Properties
        public virtual bool Solid
        {
            get { return true; }
        }

        public virtual bool Stealth
        {
            get { return false; }
        }

        public bool GoingUp
        {
            get { return MotionState.Velocity.Y < 0; }
        }

        public bool GoingDown
        {
            get { return MotionState.Velocity.Y > 0; }
        }

        public bool GoingLeft
        {
            get { return MotionState.Velocity.X < 0; }
        }

        public bool GoingRight
        {
            get { return MotionState.Velocity.X > 0; }
        }

        public Rectangle PositionRectangle
        {
            get { return SpriteState.Sprite.GetDestination(MotionState.Position); }
        }

        public Vector2 PositionPoint
        {
            get { return MotionState.Position; }
        }

        // protected Methods
        protected virtual void SyncState() { }

        // public methods
        public virtual void Reset()
        {
            SpriteState.Reset();
            MotionState.Reset();
            Core.ClearDelayedCommands();
            BarrierDetector.ClearBarrier();
        }

        public void Load(ContentManager content, Vector2 location)
        {
            SpriteState.Load(content);
            MotionState.Position = location;
        }

        public void Unload()
        {
            Core.DelayCommand(() => WorldManager.Instance.RemoveObject(this));
        }

        public void Substitute<T>() where T : IObject, new()
        {
            WorldManager.Instance.ReplaceObject<T>(this);
        }

        public void Update()
        {
            Core.Update();
            if (CommandExecutor != null) CommandExecutor.Execute();
            SyncState();
            if (CollisionHandler != null) CollisionHandler.Handle();
            SyncState();
            SpriteState.Update();
            MotionState.Update();
            BarrierDetector.Detect();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            var relativePosition = MotionState.Position - Camera.Instance.Location;
            if (SpriteState.Left)
                SpriteState.Sprite.DrawLeft(spriteBatch, relativePosition, SpriteState.Color);
            else if (SpriteState.Right)
                SpriteState.Sprite.DrawRight(spriteBatch, relativePosition, SpriteState.Color);
            else
                SpriteState.Sprite.DrawDefault(spriteBatch, relativePosition, SpriteState.Color);
        }

        public void PassCommand(ICommand command)
        {
            CommandExecutor.ReadCommand(command);
        }
    }
}