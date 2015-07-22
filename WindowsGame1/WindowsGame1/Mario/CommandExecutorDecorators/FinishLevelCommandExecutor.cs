namespace MarioGame.BarrierHandlerDecorators
{
    public class FinishLevelCommandExecutor : MarioCommandExecutor, IDecorator
    {
        public MarioCommandExecutor DefaultCommandExecutor { get; private set; }
        public FinishLevelCommandExecutor(ICoreNew core) : base(core)
        {
            DefaultCommandExecutor = (MarioCommandExecutor)core.CommandExecutor;
            ClearCommands();
            RegisterCommand(typeof(MarioDieCommand), Core.StateController.Die);
        }

        public void Restore()
        {
            Core.SwitchComponent(DefaultCommandExecutor);
        }

        public void DelayRestore(int timeDelay)
        {
            Core.DelayCommand(Restore, () => Core.CommandExecutor is FinishLevelCommandExecutor, timeDelay);
        }

    }
}