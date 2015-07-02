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
            marioDeadCommand = new MarioDeadCommand(game);
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

            keyboardController.RegisterCommand(Keys.Q, quitCommand, false);
            keyboardController.RegisterCommand(Keys.R, resetCommand, false);
            gamepadController.RegisterCommand(Buttons.Back, quitCommand, false);
            keyboardController.RegisterCommand(Keys.F, marioFireCommand, true);
            keyboardController.RegisterCommand(Keys.O, marioDeadCommand, false);
            keyboardController.RegisterCommand(Keys.Up, marioUpCommand, false);
            keyboardController.RegisterCommand(Keys.Down, marioDownCommand, false);
            keyboardController.RegisterCommand(Keys.Left, marioLeftCommand, false);
            keyboardController.RegisterCommand(Keys.Right, marioRightCommand, false);
            keyboardController.RegisterCommand(Keys.W, cameraUpCommand, false);
            keyboardController.RegisterCommand(Keys.S, cameraDownCommand, false);
            keyboardController.RegisterCommand(Keys.A, cameraLeftCommand, false);
            keyboardController.RegisterCommand(Keys.D, cameraRightCommand, false);
            keyboardController.RegisterCommand(Keys.X, marioFireballCommand, false);
        }

        public void Update() {
            keyboardController.Update();
            gamepadController.Update();
        }
    }
}