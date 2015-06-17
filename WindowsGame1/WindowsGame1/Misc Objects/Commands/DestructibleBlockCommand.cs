
namespace WindowsGame1
{
    public class DestructibleBlockCommand : CommandKernel
    {
        public DestructibleBlockCommand(MarioGame game) : base(game) { }

        public override void Execute()
        {
            Game.World.DestructibleBlock.PassCommand(this);
        }

    }
}
