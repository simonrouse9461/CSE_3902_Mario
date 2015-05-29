﻿namespace WindowsGame1
{
    public class RunningInPlaceCommand : CommandKernel
    {
        public RunningInPlaceCommand(Game1 game) : base(game) { }

        public override void Execute()
        {
            Game.Mario.SwitchSprite(MarioSpriteEnum.RunningInPlace);
        }
    }
}