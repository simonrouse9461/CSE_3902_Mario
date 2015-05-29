using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class MarioState : StateKernel
    {
        protected override void Initialize()
        {
            Location = default(Vector2);
            EffectiveMotion = new Dictionary<Enum, bool>();
            ActiveSprite = new MarioSpriteEnum();
            foreach (MarioMotionEnum motion in Enum.GetValues(typeof(MarioMotionEnum)))
            {
                
                EffectiveMotion.Add(motion, false);
            }
        }
    }
}