using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class KoopaSpriteState : SpriteStateKernelNew<int>, IEnemySpriteState
    {
        public KoopaSpriteState()
        {
            AddSprite<ShellKoopaSprite>();
            AddSprite<WalkingKoopaSprite>();
            AddSprite<UpsideDownShellKoopaSprite>();

            Walk();
            SetSpriteFrequency(12);
        }

        public void Walk()
        {
            SetSprite<WalkingKoopaSprite>();
        }

        public void MarioSmash()
        {
            SetSprite<ShellKoopaSprite>();
        }

        public bool Dead
        {
            get { return IsSprite<ShellKoopaSprite>() || IsSprite<UpsideDownShellKoopaSprite>(); }
        }

        public void Flip()
        {
            SetSprite<UpsideDownShellKoopaSprite>();
        }
    }
}
