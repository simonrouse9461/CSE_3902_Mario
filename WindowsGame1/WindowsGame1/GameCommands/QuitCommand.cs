namespace SuperMario
{
    public class QuitCommand : CommandKernel
    {
        public QuitCommand(MainGame game) : base(game) { }

        public override void Execute()
        {
            Game.Exit();
        }
    }
}