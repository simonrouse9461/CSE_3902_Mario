
namespace MarioGame
{
    public class ResetCommand : CommandKernel
    {
        public ResetCommand(MarioGame game) : base(game) { }

        public override void Execute()
        {
            new MarioDieCommand().Execute();
        }
    }
}
