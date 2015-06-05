using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class MarioDownCommand : CommandKernel
    {
        public MarioDownCommand(Game1 game) : base(game) { }

        public override void Execute()
        {
            switch (Game.Mario.SpriteState.Action)
            {
                case MarioSpriteState.ActionEnum.Jumping:
                    Game.Mario.SpriteState.Action = MarioSpriteState.ActionEnum.Facing;
                    break;
                case MarioSpriteState.ActionEnum.Facing:
                    Game.Mario.SpriteState.Action = MarioSpriteState.ActionEnum.Running;
                    break;
            }
        }
    }
}