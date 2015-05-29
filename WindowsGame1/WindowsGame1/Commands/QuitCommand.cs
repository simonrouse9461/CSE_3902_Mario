namespace WindowsGame1
{
    public class QuitCommand : CommandKernel
    {
        public QuitCommand(Game1 game) : base(game) { }

        public override void Execute()
        {
            Game.Exit();
        }
    }
}