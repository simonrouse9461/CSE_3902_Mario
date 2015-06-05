using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class MarioUpCommand : CommandKernel
    {
        public MarioUpCommand(Game1 game) : base(game) { }

        public override void Execute()
        {
            switch (Game.Mario.SpriteState.Action)
            {
                case MarioSpriteState.ActionEnum.Running:
                    Game.Mario.SpriteState.Action = MarioSpriteState.ActionEnum.Facing;
                    break;
                case MarioSpriteState.ActionEnum.Facing:
                    Game.Mario.SpriteState.Action = MarioSpriteState.ActionEnum.Jumping;
                    break;
            }
        }
    }
}