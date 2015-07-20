using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    public abstract class BackgroundObjectKernel<TSpriteState> : IObject 
        where TSpriteState : ISpriteState, new()
    {
        protected BackgroundObjectKernel()
        {
            SpriteState = new TSpriteState();
        } 

        protected TSpriteState SpriteState { get; set; }

        public virtual bool Solid
        {
            get { return false; }
        }

        public virtual bool Stealth
        {
            get { return true; }
        }

        public bool GoingUp
        {
            get { return false; }
        }

        public bool GoingDown
        {
            get { return false; }
        }

        public bool GoingLeft
        {
            get { return false; }
        }

        public bool GoingRight
        {
            get { return false; }
        }

        public virtual Rectangle CollisionRectangle { get { return PositionRectangle; } }

        public Rectangle PositionRectangle
        {
            get { return SpriteState.Sprite.GetDestination(PositionPoint); }
        }

        public Vector2 PositionPoint { get; set; }

        // public methods
        public virtual void Reset()
        {
            SpriteState.Reset();
        }

        public void Load(ContentManager content, Vector2 location)
        {
            SpriteState.Load(content);
            PositionPoint = location;
        }

        public void Unload()
        {
            WorldManager.RemoveObject(this);
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
            SpriteState.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            var relativePosition = PositionPoint - Camera.Location;
            if (SpriteState.Left)
                SpriteState.Sprite.DrawLeft(spriteBatch, relativePosition, SpriteState.Color);
            else if (SpriteState.Right)
                SpriteState.Sprite.DrawRight(spriteBatch, relativePosition, SpriteState.Color);
            else
                SpriteState.Sprite.DrawDefault(spriteBatch, relativePosition, SpriteState.Color);
        }

        public void PassCommand(ICommand command) { }
    }
}