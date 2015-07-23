namespace SuperMario
{
    public class MarioUpCommand : CommandKernel
    {
        public MarioUpCommand(MainGame game) : base(game) { }

        public override void Execute()
        {
            WorldManager.FindObject<MarioObject>().PassCommand(this);
        }
    }
}