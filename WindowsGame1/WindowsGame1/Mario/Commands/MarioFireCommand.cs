using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class MarioFireCommand : CommandKernel
    {
        public MarioFireCommand(MarioGame game) : base(game) { }

        public override void Execute()
        {
            Game.World.Mario.BecomeFire();
        }  
    }
}