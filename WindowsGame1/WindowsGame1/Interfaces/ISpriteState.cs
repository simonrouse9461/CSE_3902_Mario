using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public interface ISpriteState
    {
        ISprite Sprite { get; }
        Color Color { get; }
        void Load(ContentManager content);
        void UpdateFrequency(int frequency);
        void Reset();
        void Update();
    }
}