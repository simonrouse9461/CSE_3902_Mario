using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class KoopaSpriteState : EnemySpriteState
    {
        private enum StatusEnum
        {
            Shell,
            LeftWalking,
            RightWalking,
            Flip
        }

        private StatusEnum Status;

        public KoopaSpriteState()
        {
            SpriteList = new Collection<ISprite>
            {
                new ShellKoopaSprite(),
                new LeftWalkingKoopaSprite(),
                new RightWalkingKoopaSprite(),
                new UpsideDownShellKoopaSprite()
            };

            Status = StatusEnum.LeftWalking;
            ChangeSpriteFrequency(25);
        }

        protected override ISprite RawSprite
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
                else if (Status == StatusEnum.LeftWalking)
                {
                    return FindSprite<LeftWalkingKoopaSprite>();
                }
                else if (Status == StatusEnum.Flip)
                {
                    return FindSprite<UpsideDownShellKoopaSprite>();
                }
                else
                {
                    return null;
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
            get { return Status == StatusEnum.Shell || Status == StatusEnum.Flip; }
        }

        public void Flip()
        {
            Status = StatusEnum.Flip;
        }
    }
}
