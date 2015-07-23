namespace SuperMario
{
    public class MarioDownCommand : CommandKernel
    {
        public MarioDownCommand(MainGame game) : base(game) { }

        public override void Execute()
        {
            WorldManager.FindObject<MarioObject>().PassCommand(this);
        }
    }
}