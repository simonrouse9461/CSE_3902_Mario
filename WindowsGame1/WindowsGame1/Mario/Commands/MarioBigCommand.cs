using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class MarioBigCommand : CommandKernel
    {
        public MarioBigCommand(Game1 game) : base(game) { }

        public override void Execute()
        {
            Game.Mario.SpriteState.Status = MarioSpriteState.StatusEnum.Big;
        }
    }
}