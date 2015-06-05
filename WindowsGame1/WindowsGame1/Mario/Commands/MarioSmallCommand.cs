using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class MarioSmallCommand : CommandKernel
    {
        public MarioSmallCommand(Game1 game) : base(game) { }

        public override void Execute()
        {
            Game.Mario.SpriteState.Status = MarioSpriteState.StatusEnum.Small;
        }
    }
}