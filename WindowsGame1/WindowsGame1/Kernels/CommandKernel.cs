namespace WindowsGame1
{
    public abstract class CommandKernel : ICommand
    {
        protected MarioGame Game { get; set; }

        protected CommandKernel(MarioGame game)
        {
            Game = game;
        }

        public abstract void Execute();
    }
}