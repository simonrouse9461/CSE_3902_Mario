namespace SuperMario
{
    public class MarioRightCommand : CommandKernel
    {
        public MarioRightCommand(MainGame game) : base(game) { }

        public override void Execute()
        {
            WorldManager.FindObject<MarioObject>().PassCommand(this);
        }
    }
}