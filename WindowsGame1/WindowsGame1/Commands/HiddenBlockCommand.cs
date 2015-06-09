
namespace WindowsGame1
{
    public class HiddenBlockCommand : CommandKernel
    {
        public HiddenBlockCommand(MarioGame game) : base(game) { }

        public override void Execute()
        {
            Game.World.NormalBlock.SwitchSprite(BlockSpriteEnum.UsedBlock);
        }

    }
}
