using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    public abstract class ObjectKernelNew<TSpriteState, TMotionState> : IObject
        where TSpriteState : ISpriteState
        where TMotionState : IMotionState
    {
        public WorldManager World { get; private set; }

        protected ISpriteState SpriteState;

        protected IMotionState MotionState;

        protected ICommandHandler<TSpriteState, TMotionState> CommandHandler;

        protected ICollisionHandler<TSpriteState, TMotionState> CollisionHandler;

        protected ObjectKernelNew(Vector2 location, WorldManager world)
        {
            World = world;
            Initialize(location);
            Reset();
        }

        protected abstract void Initialize(Vector2 location);

        public virtual void Reset()
        {
            SpriteState.Reset();
            MotionState.Reset();
        }

        public void Load(ContentManager content)
        {
            SpriteState.Load(content);
        }

        public void Update()
        {
            if (CommandHandler != null)
            {
                ExecuteAction(CommandHandler.GetAction());
            }
            ExecuteAction(CollisionHandler.GetAction());
            SpriteState.Update();
            MotionState.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            SpriteState.ActiveSprite().Draw(spriteBatch, MotionState.Position);
        }

        public void PassCommand(ICommand command)
        {
            CommandHandler.ReadCommand(command);
        }

        protected void ExecuteAction(List<Action<TSpriteState, TMotionState>> actionList)
        {
            foreach (var action in actionList)
            {
                action((TSpriteState)SpriteState, (TMotionState)MotionState);
            }
        }

        public Rectangle GetPositionRectangle()
        {
            return SpriteState.ActiveSprite().GetDestination(MotionState.Position);
        }

        public Vector2 GetPositionPoint()
        {
            return MotionState.Position;
        }
    }
}