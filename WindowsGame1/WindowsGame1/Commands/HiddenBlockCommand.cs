
namespace WindowsGame1
{
    public class HiddenBlockCommand : CommandKernel
    {
        public HiddenBlockCommand(Game1 game) : base(game) { }

        public override void Execute()
        {
            Game.NormalBlock.SwitchSprite(BlockSpriteEnum.UsedBlock);
        }

    }
}
