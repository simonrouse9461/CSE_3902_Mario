namespace WindowsGame1
{
    public class QuitCommand : ICommand
    {
        private Game1 myGame;

        public QuitCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.Exit();
        }
    }

    public class RunningInPlaceCommand : ICommand
    {
        private Game1 myGame;

        public RunningInPlaceCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.currentSprite = Game1.Sprite.runningInPlace;
        }
    }

    public class DeadCommand : ICommand
    {
        private Game1 myGame;

        public DeadCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.currentSprite = Game1.Sprite.dead;
        }
    }

    public class RunningCommand : ICommand
    {
        private Game1 myGame;

        public RunningCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.currentSprite = Game1.Sprite.running;
        }
    }
}