using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class MarioFireBallCommand : CommandKernel
    {
        public MarioFireBallCommand(MarioGame game) : base(game) { }

        public override void Execute()
        {
            WorldManager.FindObject<MarioObject>().PassCommand(this);
        }  
    }
}