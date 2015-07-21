namespace MarioGame
{
    public abstract class CommandKernel : ICommand
    {
        protected MarioGame Game { get; set; }

        protected CommandKernel(MarioGame game = null)
        {
            Game = game;
        }

        public abstract void Execute();
    }
}