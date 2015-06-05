using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class MarioRightCommand : CommandKernel
    {
        public MarioRightCommand(Game1 game) : base(game) { }

        public override void Execute()
        {
            Game.Mario.SpriteState.Orientation = MarioSpriteState.OrientationEnum.Right;
        }
    }
}