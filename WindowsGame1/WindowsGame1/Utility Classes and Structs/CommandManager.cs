using Microsoft.Xna.Framework.Input;

namespace WindowsGame1
{
    public class CommandManager
    {
        private IController<Keys> keyboardController;
        private IController<Buttons> gamepadController;

        // Program quit command
        private ICommand quitCommand;
        private ICommand resetCommand;
        // Mario Commands
        private ICommand marioBigCommand;
        private ICommand marioSmallCommand;
        private ICommand marioFireCommand;
        private ICommand marioDeadCommand;
        private ICommand marioUpCommand;
        private ICommand marioDownCommand;
        private ICommand marioLeftCommand;
        private ICommand marioRightCommand;
        

        public CommandManager(MarioGame game)
        {

            keyboardController = new KeyboardController();
            gamepadController = new GamepadController();

            marioBigCommand = new MarioBigCommand(game);
            marioSmallCommand = new MarioSmallCommand(game);
            marioFireCommand = new MarioFireCommand(game);
            marioDeadCommand = new MarioDeadCommand(game);
            marioUpCommand = new MarioUpCommand(game);
            marioDownCommand = new MarioDownCommand(game);
            marioLeftCommand = new MarioLeftCommand(game);
            marioRightCommand = new MarioRightCommand(game);
            resetCommand = new ResetCommand(game);
            quitCommand = new QuitCommand(game);

            keyboardController.RegisterCommand(Keys.Q, quitCommand, false);
            keyboardController.RegisterCommand(Keys.R, resetCommand, false);
            gamepadController.RegisterCommand(Buttons.Back, quitCommand, false);
            keyboardController.RegisterCommand(Keys.Y, marioSmallCommand, false);
            keyboardController.RegisterCommand(Keys.U, marioBigCommand, false);
            keyboardController.RegisterCommand(Keys.I, marioFireCommand, false);
            keyboardController.RegisterCommand(Keys.O, marioDeadCommand, false);
            keyboardController.RegisterCommand(Keys.Up, marioUpCommand, false);
            keyboardController.RegisterCommand(Keys.Down, marioDownCommand, false);
            keyboardController.RegisterCommand(Keys.Left, marioLeftCommand, false);
            keyboardController.RegisterCommand(Keys.Right, marioRightCommand, false);

        }

        public void Update()
        {
            keyboardController.Update();
            gamepadController.Update();
        }
    }
}