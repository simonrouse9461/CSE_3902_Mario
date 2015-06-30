using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class KoopaSpriteState : EnemySpriteState
    {
        private enum StatusEnum
        {
            Shell,
            Walking
        }

        private StatusEnum Status;

        public KoopaSpriteState()
        {
            SpriteList = new Collection<ISprite>
            {
                new ShellKoopaSprite(),
                new WalkingKoopaSprite()
            };

            Status = StatusEnum.Walking;
            ChangeSpriteFrequency(25);
        }

        public override ISprite Sprite
        {
            get
            {
                if (Status == StatusEnum.Shell)
                {
                    return FindSprite<ShellKoopaSprite>();
                }
                else
                {
                    return FindSprite<WalkingKoopaSprite>();
                }
            }
        }

        public override void MarioSmash()
        {
            Status = StatusEnum.Shell;
        }
        
        public override bool Dead
        {
            get { return Status == StatusEnum.Shell; }
        }
    }
}
