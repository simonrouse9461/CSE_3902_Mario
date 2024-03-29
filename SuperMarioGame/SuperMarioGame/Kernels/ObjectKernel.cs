﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario
{
    public abstract class ObjectKernel<TStateController> : IObject
        where TStateController : IStateController, new()
    {
        // Constructor
        protected ObjectKernel()
        {
            Core = new Core<TStateController>(this);
            BarrierHandler = new DefaultBarrierHandler(Core);
        } 

        // Object core that wraps all internal components of the object
        protected Core<TStateController> Core { get; set; }

        // Protected Properties
        protected ISpriteState GeneralSpriteState
        {
            get { return Core.GeneralSpriteState; }
        }

        protected IMotionState GeneralMotionState
        {
            get { return Core.GeneralMotionState; }
        }

        protected IBarrierHandler BarrierHandler
        {
            get { return Core.BarrierHandler; }
            set { Core.BarrierHandler = value; }
        }

        protected TStateController StateController
        {
            get { return Core.StateController; }
            set { Core.StateController = value; }   
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

        protected IEventTrigger EventTrigger
        {
            get { return Core.EventTrigger; }
            set { Core.EventTrigger = value; }
        }

        // Public State Properties
        public bool IsBarrier { get { return BarrierHandler.IsBarrier; } }

        public virtual bool Stealth
        {
            get { return false; }
        }

        public bool GoingUp
        {
            get { return GeneralMotionState.Velocity.Y < 0; }
        }

        public bool GoingDown
        {
            get { return GeneralMotionState.Velocity.Y > 0; }
        }

        public bool GoingLeft
        {
            get { return GeneralMotionState.Velocity.X < 0; }
        }

        public bool GoingRight
        {
            get { return GeneralMotionState.Velocity.X > 0; }
        }

        public virtual Rectangle CollisionRectangle { get { return PositionRectangle; } }

        public Rectangle PositionRectangle
        {
            get
            {
                return GeneralSpriteState.Sprite.GetScreenDestination(
                    GeneralMotionState.Position,
                    GeneralSpriteState.Orientation);
            }
        }

        public Vector2 PositionPoint
        {
            get { return GeneralMotionState.Position; }
        }

        // public methods
        public virtual void Reset()
        {
            GeneralSpriteState.Reset();
            GeneralMotionState.Reset();
            Core.ClearDelayedCommands();
            BarrierHandler.ClearBarrier();
        }

        public void Load(ContentManager content, Vector2 location)
        {
            GeneralSpriteState.Load(content);
            GeneralMotionState.SetPosition(location);
        }

        public virtual void Unload(bool immediate = false)
        {
            if (immediate) WorldManager.RemoveObject(this);
            else Core.DelayCommand(() => WorldManager.RemoveObject(this));
        }

        public void Transform<T>(T obj = null) where T : class, IObject, new()
        {
            WorldManager.ReplaceObject(this, obj);
        }

        public void Generate<T>(Vector2 offset = default(Vector2), T obj = null) where T : class, IObject, new()
        {
            WorldManager.CreateObject(PositionPoint + offset, obj);
        }

        public void Generate<T>(T obj) where T : class, IObject, new()
        {
            Generate(default(Vector2), obj);
        }

        public void Update()
        {
            var haveBarrierHandler = !(GeneralMotionState is StaticMotionState)
                && BarrierHandler != null
                && !BarrierHandler.NoBarrier;
            Core.Update();
            EventTrigger.CheckEvent();
            if (CommandExecutor != null) CommandExecutor.Execute();
            if (haveBarrierHandler) BarrierHandler.Update();
            if (haveBarrierHandler) BarrierHandler.ResetVelocity();
            if (haveBarrierHandler) BarrierHandler.HandleCollision();
            StateController.Update();
            StateController.RefreshState();
            if (haveBarrierHandler) BarrierHandler.HandleOverlap();
            if (CollisionHandler != null) CollisionHandler.Handle();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            var relativePosition = GeneralMotionState.Position - Camera.Location;
            GeneralSpriteState.Sprite.Draw(spriteBatch, relativePosition, GeneralSpriteState.Orientation, GeneralSpriteState.Version, GeneralSpriteState.Color);
        }

        public void PassCommand(ICommand command)
        {
            CommandExecutor.ReadCommand(command);
        }
    }
}