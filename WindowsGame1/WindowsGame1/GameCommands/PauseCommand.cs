namespace SuperMario
{
    class PauseCommand : CommandKernel
    {
        public PauseCommand(MainGame game) : base(game) { }

        public override void Execute()
        {
            Game.PauseGame();
        }
    }
}
