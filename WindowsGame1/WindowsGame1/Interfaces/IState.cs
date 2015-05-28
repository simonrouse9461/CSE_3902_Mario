using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public interface IState
    {
        Vector2 Location { get; set; }

        Enum ActiveSprite { get; set; }

        Dictionary<Enum, bool> EffectiveMotion { get; set; }
    }
}