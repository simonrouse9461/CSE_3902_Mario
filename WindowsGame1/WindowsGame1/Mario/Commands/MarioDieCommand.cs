namespace SuperMario
{
    public class MarioDieCommand : CommandKernel
    {
        public override void Execute()
        {
            WorldManager.FindObject<MarioObject>().PassCommand(this);
        } 
    }
}