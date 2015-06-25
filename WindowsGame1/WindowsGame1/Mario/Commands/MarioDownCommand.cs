﻿namespace WindowsGame1
{
    public class MarioDownCommand : CommandKernel
    {
        public MarioDownCommand(MarioGame game) : base(game) { }

        public override void Execute()
        {
            WorldManager.FindObject<MarioObject>().PassCommand(this);
        }
    }
}