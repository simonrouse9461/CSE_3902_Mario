using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class GoombaSpriteState : EnemySpriteState
    {
        private enum StatusEnum
        {
            Dead,
            Walking
        }

        private StatusEnum Status;

        public GoombaSpriteState()
        {
            SpriteList = new Collection<ISpriteNew>
            {
                new DeadGoombaSprite(),
                new WalkingGoombaSprite()
            };

            Status = StatusEnum.Walking;
            ChangeFrequency(6);
        }

        public override ISpriteNew Sprite
        {
            get
            {
                if (Status == StatusEnum.Dead)
                {
                    return FindSprite<DeadGoombaSprite>();
                }
                else
                {
                    return FindSprite<WalkingGoombaSprite>();
                }
            }
        }

        public override void MarioSmash()
        {
            Status = StatusEnum.Dead;
        }
    }
}