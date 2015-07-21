namespace MarioGame
{
    public class MarioUpCommand : CommandKernel
    {
        public MarioUpCommand(MarioGame game) : base(game) { }

        public override void Execute()
        {
            WorldManager.FindObject<MarioObject>().PassCommand(this);
        }
    }
}