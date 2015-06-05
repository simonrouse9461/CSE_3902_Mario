using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace WindowsGame1
{
    public interface ISpriteState
    {
        ISprite ActiveSprite();
        void Load(ContentManager content);
        void Reset(int frequency = 10);
        void Update();
    }
}