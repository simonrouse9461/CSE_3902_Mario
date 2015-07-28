namespace SuperMario
{
    public class MarioDieCommand : CommandKernel
    {
        public override void Execute()
        {
            WorldManager.FindObject<Mario>().PassCommand(this);
        } 
    }
}