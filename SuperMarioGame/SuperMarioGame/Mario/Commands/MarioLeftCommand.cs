using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class MarioLeftCommand : CommandKernel
    {
        public MarioLeftCommand(MainGame game) : base(game) { }

        public override void Execute()
        {
            WorldManager.FindObject<Mario>().PassCommand(this);
        }
    }
}