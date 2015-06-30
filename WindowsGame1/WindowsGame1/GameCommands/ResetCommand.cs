
namespace WindowsGame1
{
    public class ResetCommand : CommandKernel
    {
        public ResetCommand(MarioGame game) : base(game) { }

        public override void Execute()
        {
            WorldManager.FindObject<MarioObject>().Reset();
        }

    }
}
