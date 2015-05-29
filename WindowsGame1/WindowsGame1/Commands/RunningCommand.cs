namespace WindowsGame1
{
    public class RunningCommand : CommandKernel
    {
        public RunningCommand(Game1 game) : base(game) { }

        public override void Execute()
        {
            Game.Mario.SwitchSprite(MarioSpriteEnum.Running);
        }
    }
}