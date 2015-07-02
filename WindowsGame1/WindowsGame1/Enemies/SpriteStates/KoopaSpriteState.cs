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
            LeftWalking,
            RightWalking
        }

        private StatusEnum Status;

        public KoopaSpriteState()
        {
            SpriteList = new Collection<ISprite>
            {
                new ShellKoopaSprite(),
                new LeftWalkingKoopaSprite(),
                new RightWalkingKoopaSprite()
            };

            Status = StatusEnum.LeftWalking;
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
                else if (Status == StatusEnum.RightWalking)
                {
                    return FindSprite<RightWalkingKoopaSprite>();
                }
                else
                {
                    return FindSprite<LeftWalkingKoopaSprite>();
                }
            }
        }

        public override void MarioSmash()
        {
            Status = StatusEnum.Shell;
        }

        public override void Turn()
        {
            if (Status == StatusEnum.LeftWalking)
            {
                Status = StatusEnum.RightWalking;
            }
            else if (Status == StatusEnum.RightWalking)
            {
                Status = StatusEnum.LeftWalking;
            }
        }
        
        public override bool Dead
        {
            get { return Status == StatusEnum.Shell; }
        }
    }
}
