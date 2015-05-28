namespace WindowsGame1
{
    public abstract class CommandKernel : ICommand
    {
        protected Game1 Game;

        protected CommandKernel(Game1 game)
        {
            Game = game;
        }

        public abstract void Execute();
    }
}