using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperMario
{
    public class MarioFireballCommand : CommandKernel
    {
        public MarioFireballCommand(MainGame game) : base(game) { }

        public override void Execute()
        {
            WorldManager.FindObject<Mario>().PassCommand(this);
        } 
    }
}
