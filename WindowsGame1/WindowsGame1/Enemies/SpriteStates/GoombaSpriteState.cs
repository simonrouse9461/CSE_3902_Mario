using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class GoombaSpriteState : EnemySpriteState
    {
        public enum StatusEnum
        {
            Dead,
            Walking
        }

        public StatusEnum Status { get; set; }

        protected override void Initialize()
        {
            SpriteList = new List<ISprite>
            {
                new DeadGoombaSprite(), //0
                new WalkingGoombaSprite(), //1
            };

            Status = StatusEnum.Walking;
        }

        public override ISprite Sprite
        {
            get { return Status == StatusEnum.Dead ? SpriteList[0] : SpriteList[1]; }
        }

        public override void MarioSmash()
        {
            Status = StatusEnum.Dead;
        }
    }
}