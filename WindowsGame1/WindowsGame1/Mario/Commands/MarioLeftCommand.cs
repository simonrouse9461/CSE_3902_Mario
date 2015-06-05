using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class MarioLeftCommand : CommandKernel
    {
        public MarioLeftCommand(Game1 game) : base(game) { }

        public override void Execute()
        {
            Game.Mario.SpriteState.Orientation = MarioSpriteState.OrientationEnum.Left;
        }
    }
}