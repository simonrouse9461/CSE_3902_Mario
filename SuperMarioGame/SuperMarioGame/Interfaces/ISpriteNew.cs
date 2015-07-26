using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario
{
    public interface ISpriteNew
    {
        int Cycle { get; }
        IConvertible Version { get; }
        float Width { get; }
        float Height { get; }
        ISpriteNew Clone { get; }

        void SetVersion(IConvertible version);
        void Reset();
        void Load(ContentManager content);
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 location, Orientation orientation, IConvertible version, Color? color = null);
        Rectangle GetScreenDestination(Vector2 position, Orientation orientation);
        Vector2 GetScreenLocation(Vector2 position, Orientation orientation);
    }
}