using System;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public interface IState
    {
        ISprite ActiveSprite();

        Vector2 NetMotion();

    }
}