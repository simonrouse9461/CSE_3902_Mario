
namespace WindowsGame1
{
    public class HiddenBlockCommand : CommandKernel
    {
        public HiddenBlockCommand(MarioGame game) : base(game) { }

        public override void Execute()
        {
            Game.World.HiddenBlock.SpriteState.Status = HiddenBlockSpriteState.StatusEnum.UsedBlock;
        }

    }
}
