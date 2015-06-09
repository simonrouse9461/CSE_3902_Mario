using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class MarioSmallCommand : CommandKernel
    {
        public MarioSmallCommand(MarioGame game) : base(game) { }

        public override void Execute()
        {
            Game.World.Mario.SpriteState.Status = MarioSpriteState.StatusEnum.Small;
        }
    }
}