namespace WindowsGame1
{
    public class MarioDieCommand : CommandKernel
    {
        public override void Execute()
        {
            WorldManager.FindObject<MarioObject>().PassCommand(this);
        } 
    }
}