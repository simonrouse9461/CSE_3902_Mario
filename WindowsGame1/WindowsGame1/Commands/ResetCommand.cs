
namespace WindowsGame1
{
    public class ResetCommand : CommandKernel
    {
        public ResetCommand(MarioGame game) : base(game) { }

        public override void Execute()
        {
            Game.World.QuestionBlock.QuestionBlockAnimate();
            Game.World.Mario.FaceLeft();
            Game.World.Mario.BecomeBig();
            Game.World.Mario.StandStill();
            Game.World.NormalBlock.NormalBlockReset();
            Game.World.HiddenBlock.HiddenBlockReset();
        }

    }
}
