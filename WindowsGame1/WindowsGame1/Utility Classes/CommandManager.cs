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
        private ICommand marioFireCommand;
        private ICommand marioDeadCommand;
        private ICommand marioUpCommand;
        private ICommand marioDownCommand;
        private ICommand marioLeftCommand;
        private ICommand marioRightCommand;
        private ICommand marioFireballCommand;
        // Camera Commands
        private ICommand cameraUpCommand;
        private ICommand cameraDownCommand;
        private ICommand cameraLeftCommand;
        private ICommand cameraRightCommand;

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
            resetCommand = new ResetCommand(game);
            quitCommand = new QuitCommand(game);

            cameraUpCommand = new CameraUpCommand(game);
            cameraDownCommand = new CameraDownCommand(game);
            cameraLeftCommand = new CameraLeftCommand(game);
            cameraRightCommand = new CameraRightCommand(game);

            keyboardController.RegisterCommand(Keys.Q, quitCommand);
            keyboardController.RegisterCommand(Keys.R, resetCommand);
            gamepadController.RegisterCommand(Buttons.Back, quitCommand);
            keyboardController.RegisterCommand(Keys.F, marioFireCommand);
            keyboardController.RegisterCommand(Keys.O, marioDeadCommand);
            keyboardController.RegisterCommand(Keys.Up, marioUpCommand);
            keyboardController.RegisterCommand(Keys.Down, marioDownCommand);
            keyboardController.RegisterCommand(Keys.Left, marioLeftCommand);
            keyboardController.RegisterCommand(Keys.Right, marioRightCommand);
            keyboardController.RegisterCommand(Keys.W, cameraUpCommand);
            keyboardController.RegisterCommand(Keys.S, cameraDownCommand);
            keyboardController.RegisterCommand(Keys.A, cameraLeftCommand);
            keyboardController.RegisterCommand(Keys.D, cameraRightCommand);
            keyboardController.RegisterCommand(Keys.X, marioFireballCommand);
        }

        public void Update() {
            keyboardController.Update();
            gamepadController.Update();
        }
    }
}