
namespace WindowsGame1
{
    public class NormalBlockCommand : CommandKernel
    {
        public NormalBlockCommand(Game1 game) : base(game) { }

        public override void Execute()
        {
            Game.NormalBlock.SwitchSprite(BlockSpriteEnum.HiddenBlock);
        }

    }
}
