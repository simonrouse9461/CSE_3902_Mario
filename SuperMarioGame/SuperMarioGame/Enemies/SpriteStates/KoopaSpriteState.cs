using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class KoopaSpriteState : EnemySpriteState
    {
        public KoopaSpriteState()
        {
            AddSprite<ShellKoopaSprite>();
            AddSprite<WalkingKoopaSprite>();
            AddSprite<UpsideDownShellKoopaSprite>();

            SetSprite<WalkingKoopaSprite>();
            SetSpriteFrequency(12);
        }

        public override void MarioSmash()
        {
            SetSprite<ShellKoopaSprite>();
        }

        public override void Turn()
        {
            SetOrientation(Orientation == Orientation.Left ? Orientation.Right : Orientation.Left);
        }
        
        public override bool Dead
        {
            get { return IsSprite<ShellKoopaSprite>() || IsSprite<UpsideDownShellKoopaSprite>(); }
        }

        public void Flip()
        {
            SetSprite<UpsideDownShellKoopaSprite>();
        }
    }
}
