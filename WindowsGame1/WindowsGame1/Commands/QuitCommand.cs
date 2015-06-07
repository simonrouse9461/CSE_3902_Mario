namespace WindowsGame1
{
    public class QuitCommand : CommandKernel
    {
        public QuitCommand(MarioGame game) : base(game) { }

        public override void Execute()
        {
            Game.Exit();
        }
    }
}