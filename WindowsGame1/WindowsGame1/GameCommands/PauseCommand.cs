namespace WindowsGame1
{
    class PauseCommand : CommandKernel
    {
        public PauseCommand(MarioGame game) : base(game) { }

        public override void Execute()
        {
            Game.PauseGame();
        }
    }
}
