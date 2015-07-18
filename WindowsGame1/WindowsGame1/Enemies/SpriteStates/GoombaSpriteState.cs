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
            Walking,
            Flip
        }

        private StatusEnum Status;

        public GoombaSpriteState()
        {
            SpriteList = new Collection<ISprite>
            {
                new DeadGoombaSprite(),
                new WalkingGoombaSprite(),
                new UpsideDownGoombaSprite()
            };

            Status = StatusEnum.Walking;
            ChangeSpriteFrequency(6);
        }

        protected override ISprite RawSprite
        {
            get
            {
                if (Status == StatusEnum.Dead)
                {
                    return FindSprite<DeadGoombaSprite>();
                }
                else if (Status == StatusEnum.Walking)
                {
                    return FindSprite<WalkingGoombaSprite>();
                }
                else
                {
                    return FindSprite<UpsideDownGoombaSprite>();
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

        public void Flip()
        {
            Status = StatusEnum.Flip;
        }

        public override bool Dead
        {
            get { return Status == StatusEnum.Dead; }
        }
    }
}