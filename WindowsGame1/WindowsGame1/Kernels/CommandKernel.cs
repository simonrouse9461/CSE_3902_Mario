namespace SuperMario
{
    public abstract class CommandKernel : ICommand
    {
        protected MainGame Game { get; set; }

        protected CommandKernel(MainGame game = null)
        {
            Game = game;
        }

        public abstract void Execute();
    }
}