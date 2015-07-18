using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public interface ISpriteState
    {
        ISprite Sprite { get; }
        Color Color { get; }
        bool Left { get; }
        bool Right { get; }
        bool Held { get; }

        void Hold();
        void Restore();
        void Load(ContentManager content);
        void ChangeSpriteFrequency(int frequency);
        void ChangeColorFrequency(int frequency);
        void Reset();
        void Update();
    }
}