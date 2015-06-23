using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public interface ISpriteStateNew
    {
        ISpriteNew Sprite { get; }
        Color Color { get; }
        bool Left { get; }
        bool Right { get; }
        void Load(ContentManager content);
        void ChangeFrequency(int frequency);
        void Reset();
        void Update();
    }
}