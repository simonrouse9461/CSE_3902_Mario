using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    public class MarioFireballCommand : CommandKernel
    {
        public MarioFireballCommand(MarioGame game) : base(game) { }

        public override void Execute()
        {
            WorldManager.FindObject<MarioObject>().PassCommand(this);
        } 
    }
}
