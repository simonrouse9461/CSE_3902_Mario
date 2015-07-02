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
            SpriteList = new Collection<ISprite>
            {
                new DeadGoombaSprite(),
                new WalkingGoombaSprite()
            };

            Status = StatusEnum.Walking;
            ChangeSpriteFrequency(6);
        }

        public override ISprite Sprite
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

        public override void Turn()
        {
           
        }

        public override bool Dead
        {
            get { return Status == StatusEnum.Dead; }
        }
    }
}