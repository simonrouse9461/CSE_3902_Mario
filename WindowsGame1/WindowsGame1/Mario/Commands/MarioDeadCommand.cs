namespace WindowsGame1
{
    public class MarioDeadCommand : CommandKernel
    {
        public MarioDeadCommand(MarioGame game) : base(game) { }

        public override void Execute()
        {
            WorldManager.FindObject<MarioObject>().PassCommand(this);
        } 
    }
}