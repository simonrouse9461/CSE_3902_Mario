
namespace WindowsGame1
{
    public class QuestionBlockCommand : CommandKernel
    {
        public QuestionBlockCommand(MarioGame game) : base(game) { }

        public override void Execute()
        {
            Game.World.QuestionBlock.QuestionToUsedBlock();
        }

    }
}
