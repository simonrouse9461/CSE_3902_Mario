
namespace SuperMario
{
    public class ResetCommand : CommandKernel
    {
        public ResetCommand(MainGame game) : base(game) { }

        public override void Execute()
        {
            new MarioDieCommand().Execute();
        }
    }
}
