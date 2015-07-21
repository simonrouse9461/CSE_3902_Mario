using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class MarioLeftCommand : CommandKernel
    {
        public MarioLeftCommand(MarioGame game) : base(game) { }

        public override void Execute()
        {
            WorldManager.FindObject<MarioObject>().PassCommand(this);
        }
    }
}