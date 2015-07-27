using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class GoombaSpriteState : EnemySpriteState
    {
        public GoombaSpriteState()
        {
            AddSprite<DeadGoombaSprite>();
            AddSprite<WalkingGoombaSprite>();
            AddSprite<UpsideDownGoombaSprite>();

            SetSprite<WalkingGoombaSprite>();
            SetSpriteFrequency(12);
        }

        public override void Turn()
        {
           
        }

        public override void MarioSmash()
        {
            SetSprite<DeadGoombaSprite>();
        }

        public void Flip()
        {
            SetSprite<UpsideDownGoombaSprite>();
        }

        public override bool Dead
        {
            get { return IsSprite<DeadGoombaSprite>() || IsSprite<UpsideDownGoombaSprite>(); }
        }
    }
}