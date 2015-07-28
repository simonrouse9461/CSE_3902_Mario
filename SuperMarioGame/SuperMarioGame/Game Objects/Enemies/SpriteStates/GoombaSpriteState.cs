using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class GoombaSpriteState : SpriteStateKernelNew<int>, IEnemySpriteState
    {
        public GoombaSpriteState()
        {
            AddSprite<SquashedGoombaSprite>();
            AddSprite<WalkingGoombaSprite>();
            AddSprite<UpsideDownGoombaSprite>();

            SetSprite<WalkingGoombaSprite>();
            SetSpriteFrequency(12);
        }

        public void Squash()
        {
            SetSprite<SquashedGoombaSprite>();
        }

        public void Flip()
        {
            SetSprite<UpsideDownGoombaSprite>();
        }

        public bool Dead
        {
            get { return IsSprite<SquashedGoombaSprite>() || IsSprite<UpsideDownGoombaSprite>(); }
        }
    }
}