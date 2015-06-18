using Microsoft.Xna.Framework.Input;

namespace WindowsGame1
{
    public class CommandManager
    {
        private IController<Keys> _keyboardController;
        private IController<Buttons> _gamepadController;

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

            _keyboardController = new KeyboardController();
            _gamepadController = new GamepadController();

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

            _keyboardController.RegisterCommand(Keys.Q, quitCommand, false);
            _keyboardController.RegisterCommand(Keys.R, resetCommand, false);
            _gamepadController.RegisterCommand(Buttons.Back, quitCommand, false);
            _keyboardController.RegisterCommand(Keys.Y, marioSmallCommand, false);
            _keyboardController.RegisterCommand(Keys.U, marioBigCommand, false);
            _keyboardController.RegisterCommand(Keys.I, marioFireCommand, false);
            _keyboardController.RegisterCommand(Keys.O, marioDeadCommand, false);
            _keyboardController.RegisterCommand(Keys.Up, marioUpCommand, false);
            _keyboardController.RegisterCommand(Keys.Down, marioDownCommand, false);
            _keyboardController.RegisterCommand(Keys.Left, marioLeftCommand, false);
            _keyboardController.RegisterCommand(Keys.Right, marioRightCommand, false);

        }

        public void Update()
        {
            _keyboardController.Update();
            _gamepadController.Update();
        }
    }
}