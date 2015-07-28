using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class MarioFireCommand : CommandKernel
    {
        public MarioFireCommand(MainGame game) : base(game) { }

        public override void Execute()
        {
            WorldManager.FindObject<Mario>().PassCommand(this);
        }  
    }
}