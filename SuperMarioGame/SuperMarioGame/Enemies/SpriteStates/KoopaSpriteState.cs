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
            AddSprite<RestoringKoopaSprite>();

            Walk();
            SetSpriteFrequency(12);
        }

        public void Restore()
        {
            SetSprite<RestoringKoopaSprite>();
        }

        public bool Restoring
        {
            get { return IsSprite<RestoringKoopaSprite>(); }
        }

        public void Walk()
        {
            SetSprite<WalkingKoopaSprite>();
        }

        public bool Walking
        {
            get { return IsSprite<WalkingKoopaSprite>(); }
        }

        public void MarioSmash()
        {
            SetSprite<ShellKoopaSprite>();
        }

        public void Flip()
        {
            SetSprite<UpsideDownShellKoopaSprite>();
        }

        public bool Dead
        {
            get { return IsSprite<ShellKoopaSprite>() || IsSprite<UpsideDownShellKoopaSprite>(); }
        }
    }
}
