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

        private StatusEnum status;

        public StatusEnum Status
        {
            get { return status; }
            set { status = value; }
        }

        protected override void Initialize()
        {
            SpriteList = new List<ISprite>
            {
                new DeadGoombaSprite(), //0
                new WalkingGoombaSprite(), //1
            };

            Status = StatusEnum.Walking;
        }

        public override ISprite ActiveSprite()
        {
            if (Status == StatusEnum.Dead) { return SpriteList[0]; }
            else { return SpriteList[1]; }
        }

        public override void MarioSmash()
        {
            Status = StatusEnum.Dead;
        }
    }
}