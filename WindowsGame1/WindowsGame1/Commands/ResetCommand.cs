
namespace WindowsGame1
{
    public class ResetCommand : CommandKernel
    {
        public ResetCommand(MarioGame game) : base(game) { }

        public override void Execute()
        {
            Game.World.QuestionBlock.SpriteState.Status = QuestionBlockSpriteState.StatusEnum.Animated;
            Game.World.Mario.FaceLeft();
            Game.World.Mario.BecomeBig();
            Game.World.Mario.StandStill();
            Game.World.NormalBlock.SpriteState.Status = NormalBlockSpriteState.StatusEnum.Normal;
            Game.World.HiddenBlock.SpriteState.Status = HiddenBlockSpriteState.StatusEnum.Hidden;
        }

    }
}
