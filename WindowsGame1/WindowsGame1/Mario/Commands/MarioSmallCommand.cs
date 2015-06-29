using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class MarioSmallCommand : CommandKernel
    {
        public MarioSmallCommand(MarioGame game) : base(game) { }

        public override void Execute()
        {
            WorldManager.FindObject<MarioObject>().PassCommand(this);
        }
    }
}