using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class MarioFireCommand : CommandKernel
    {
        public MarioFireCommand(Game1 game) : base(game) { }

        public override void Execute()
        {
            Game.Mario.SpriteState.Status = MarioSpriteState.StatusEnum.Fire;
        }  
    }
}