using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarioGame
{
    public class FlagSpriteState : SpriteStateKernelNew<FlagSpriteVersion>
    {

        public FlagSpriteState()
        {

        }
        public void Flag()
        {
            SetSprite<FlagPoleSprite>();
        }
    }
}
