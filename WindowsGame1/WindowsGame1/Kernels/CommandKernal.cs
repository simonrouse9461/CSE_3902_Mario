namespace WindowsGame1
{
    public abstract class CommandKernel : ICommand
    {
        protected MarioGame Game;

        protected CommandKernel(MarioGame game)
        {
            Game = game;
        }

        public abstract void Execute();
    }
}