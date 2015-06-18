using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class KoopaSpriteState : EnemySpriteState
    {
        public enum StatusEnum
        {
            Walking,
            Shell
        }

        public StatusEnum Status { get; set; }

        protected override void Initialize()
        {
            SpriteList = new List<ISprite>
            {
                new ShellKoopaSprite(), //0
                new WalkingKoopaSprite(), //1 
            };

            Status = StatusEnum.Walking;
        }

        public override ISprite Sprite
        {
            get
            {
                return Status == StatusEnum.Shell ? SpriteList[0] : SpriteList[1];
            }
        }

        public override void MarioSmash()
        {
            Status = StatusEnum.Shell;
        }
    }
}
