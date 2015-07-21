using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class MarioFireCommand : CommandKernel
    {
        public MarioFireCommand(MarioGame game) : base(game) { }

        public override void Execute()
        {
            WorldManager.FindObject<MarioObject>().PassCommand(this);
        }  
    }
}