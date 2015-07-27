using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class GoombaSpriteState : SpriteStateKernelNew<int>, IEnemySpriteState
    {
        public GoombaSpriteState()
        {
            AddSprite<DeadGoombaSprite>();
            AddSprite<WalkingGoombaSprite>();
            AddSprite<UpsideDownGoombaSprite>();

            SetSprite<WalkingGoombaSprite>();
            SetSpriteFrequency(12);
        }

        public void MarioSmash()
        {
            SetSprite<DeadGoombaSprite>();
        }

        public void Flip()
        {
            SetSprite<UpsideDownGoombaSprite>();
        }

        public bool Dead
        {
            get { return IsSprite<DeadGoombaSprite>() || IsSprite<UpsideDownGoombaSprite>(); }
        }
    }
}