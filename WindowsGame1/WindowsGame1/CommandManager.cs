using Microsoft.Xna.Framework.Input;

namespace WindowsGame1
{
    public class CommandManager
    {
        private IController<Keys> _keyboardController;
        private IController<Buttons> _gamepadController;

        // Program quit command
        private ICommand quitCommand;

        // Mario Commands
        private ICommand marioBigCommand;
        private ICommand marioSmallCommand;
        private ICommand marioFireCommand;
        private ICommand marioDeadCommand;
        private ICommand marioUpCommand;
        private ICommand marioDownCommand;
        private ICommand marioLeftCommand;
        private ICommand marioRightCommand;

        // Other Commands
        private ICommand questionBlockCommand;
        private ICommand normalBlockCommand;
        private ICommand fireflowerCommand;
        private ICommand mushroomCommand;
        private ICommand koopaCommand;
        private ICommand hiddenBlockCommand;

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

            quitCommand = new QuitCommand(game);
            questionBlockCommand = new QuestionBlockCommand(game);
            mushroomCommand = new MushroomCommand(game);
            fireflowerCommand = new FireflowerCommand(game);
            koopaCommand = new KoopaCommand(game);
            normalBlockCommand = new NormalBlockCommand(game);
            hiddenBlockCommand = new HiddenBlockCommand(game);
            _keyboardController.RegisterCommand(Keys.Q, quitCommand);
            _keyboardController.RegisterCommand(Keys.Z, questionBlockCommand);
            _keyboardController.RegisterCommand(Keys.K, koopaCommand);
            _keyboardController.RegisterCommand(Keys.M, mushroomCommand);
            _keyboardController.RegisterCommand(Keys.F, fireflowerCommand);
            _keyboardController.RegisterCommand(Keys.X, normalBlockCommand);
            _keyboardController.RegisterCommand(Keys.C, hiddenBlockCommand);
            _gamepadController.RegisterCommand(Buttons.Back, quitCommand);

            _keyboardController.RegisterCommand(Keys.Y, marioSmallCommand);
            _keyboardController.RegisterCommand(Keys.U, marioBigCommand);
            _keyboardController.RegisterCommand(Keys.I, marioFireCommand);
            _keyboardController.RegisterCommand(Keys.O, marioDeadCommand);
            _keyboardController.RegisterCommand(Keys.Up, marioUpCommand, true);
            _keyboardController.RegisterCommand(Keys.Down, marioDownCommand, true);
            _keyboardController.RegisterCommand(Keys.Left, marioLeftCommand);
            _keyboardController.RegisterCommand(Keys.Right, marioRightCommand);

        }

        public void Update()
        {
            _keyboardController.Update();
            _gamepadController.Update();
        }
    }
}