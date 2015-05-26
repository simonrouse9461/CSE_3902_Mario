namespace WindowsGame1
{
    public abstract class CommandKernal : ICommand
    {
        protected Game1 Game;

        protected CommandKernal(Game1 game)
        {
            Game = game;
        }

        public abstract void Execute();
    }
}