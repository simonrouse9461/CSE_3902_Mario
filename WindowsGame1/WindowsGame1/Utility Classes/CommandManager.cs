using Microsoft.Xna.Framework.Input;

namespace MarioGame
{
    public class CommandManager
    {
        private IController<Keys> keyboardController;
        private IController<Buttons> gamepadController;

        // Program quit command
        private ICommand quitCommand;
        private ICommand resetCommand;
        private ICommand pauseCommand;
        // Mario Commands
        private ICommand marioFireCommand;
        private ICommand marioDeadCommand;
        private ICommand marioUpCommand;
        private ICommand marioDownCommand;
        private ICommand marioLeftCommand;
        private ICommand marioRightCommand;
        private ICommand marioFireballCommand;

        public CommandManager(MarioGame game)
        {

            keyboardController = new KeyboardController();
            gamepadController = new GamepadController();

            marioFireCommand = new MarioFireCommand(game);
            marioDeadCommand = new MarioDieCommand();
            marioUpCommand = new MarioUpCommand(game);
            marioDownCommand = new MarioDownCommand(game);
            marioLeftCommand = new MarioLeftCommand(game);
            marioRightCommand = new MarioRightCommand(game);
            marioFireballCommand = new MarioFireballCommand(game);
            pauseCommand = new PauseCommand(game);
            resetCommand = new ResetCommand(game);
            quitCommand = new QuitCommand(game);

            keyboardController.RegisterCommand(Keys.P, pauseCommand);
            keyboardController.RegisterCommand(Keys.Q, quitCommand);
            keyboardController.RegisterCommand(Keys.R, resetCommand);
            gamepadController.RegisterCommand(Buttons.Back, quitCommand);
            keyboardController.RegisterCommand(Keys.F, marioFireCommand);
            keyboardController.RegisterCommand(Keys.O, marioDeadCommand);
            keyboardController.RegisterCommand(Keys.Up, marioUpCommand);
            keyboardController.RegisterCommand(Keys.Down, marioDownCommand);
            keyboardController.RegisterCommand(Keys.Left, marioLeftCommand);
            keyboardController.RegisterCommand(Keys.Right, marioRightCommand);
            keyboardController.RegisterCommand(Keys.X, marioFireballCommand);
        }

        public void Update()
        {
            keyboardController.Update();
            gamepadController.Update();
        }
    }
}