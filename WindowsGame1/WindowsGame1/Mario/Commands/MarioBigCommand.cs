namespace WindowsGame1
{
    public class MarioBigCommand : CommandKernel
    {
        public MarioBigCommand(MarioGame game) : base(game) { }

        public override void Execute()
        {
            WorldManager.FindObject<MarioObject>().PassCommand(this);
        }
    }
}