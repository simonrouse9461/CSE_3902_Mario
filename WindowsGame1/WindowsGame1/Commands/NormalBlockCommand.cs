
namespace WindowsGame1
{
    public class NormalBlockCommand : CommandKernel
    {
        public NormalBlockCommand(MarioGame game) : base(game) { }

        public override void Execute()
        {
            Game.World.NormalBlock.SpriteState.Status = NormalBlockSpriteState.StatusEnum.Destroyed;
        }

    }
}
