using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    public abstract class ObjectKernelNew<TStateController> : IObject
        where TStateController : IStateControllerNew, new()
    {
        // Constructor
        protected ObjectKernelNew()
        {
            Core = new CoreNew<TStateController>(this);
        } 

        // Object core that wraps all internal components of the object
        protected CoreNew<TStateController> Core { get; set; }

        // Protected Properties
        protected ISpriteStateNew GeneralSpriteState
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

        // Public State Properties
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
            get { return GeneralSpriteState.Sprite.GetDestination(GeneralMotionState.Position); }
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
            GeneralMotionState.Position = location;
        }

        public void Unload()
        {
            Core.DelayCommand(() => WorldManager.RemoveObject(this));
        }

        public void Transform<T>(T obj = null) where T : class, IObject, new()
        {
            WorldManager.ReplaceObject(this, obj);
        }

        public void Generate<T>(Vector2 offset = default(Vector2), T obj = null) where T : class, IObject, new()
        {
            WorldManager.CreateObject(PositionPoint + offset, obj);
        }

        public void Update()
        {
            var haveBarrierHandler = Solid && !(GeneralMotionState is StaticMotionState) && BarrierHandler != null;
            Core.Update();
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
            GeneralSpriteState.Sprite.Draw(spriteBatch, relativePosition, GeneralSpriteState.Orientation, GeneralSpriteState.Color);
        }

        public void PassCommand(ICommand command)
        {
            CommandExecutor.ReadCommand(command);
        }
    }
}