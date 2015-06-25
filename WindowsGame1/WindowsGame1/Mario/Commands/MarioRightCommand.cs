namespace WindowsGame1
{
    public class MarioRightCommand : CommandKernel
    {
        public MarioRightCommand(MarioGame game) : base(game) { }

        public override void Execute()
        {
            WorldManager.FindObject<MarioObject>().PassCommand(this);
        }
    }
}