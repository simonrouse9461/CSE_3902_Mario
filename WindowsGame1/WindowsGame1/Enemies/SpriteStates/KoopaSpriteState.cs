using System;
using System.Collections.Generic;

namespace WindowsGame1
{
    public class KoopaSpriteState : SpriteStateKernel
    {
        public enum StatusEnum
        {
            Walking,
            Shell

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
               new WalkingKoopaSprite(), //1
               new ShellKoopaSprite(),   //0
           };

            Status = StatusEnum.Walking;
        }

        public override ISprite ActiveSprite()
        {
            if (Status == StatusEnum.Shell) { return SpriteList[0]; }
            else { return SpriteList[1]; }
        }
    }
}
