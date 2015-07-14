namespace WindowsGame1
{
    public class MarioDeadCommand : CommandKernel
    {
        public override void Execute()
        {
            WorldManager.FindObject<MarioObject>().PassCommand(this);
        } 
    }
}