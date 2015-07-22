using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public interface ISpriteNew
    {
        int Cycle { get; }
        IConvertible Version { get; }
        int Width { get; }
        int Height { get; }

        void SetVersion(IConvertible version);
        void Reset();
        void Load(ContentManager content);
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 location, Orientation orientation, IConvertible version, Color? color = null);
        Rectangle GetScreenDestination(Vector2 position);
        Vector2 GetScreenLocation(Vector2 position);
    }
}