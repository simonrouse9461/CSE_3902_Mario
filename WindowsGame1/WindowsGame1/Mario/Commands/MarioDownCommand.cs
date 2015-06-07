using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class MarioDownCommand : CommandKernel
    {
        public MarioDownCommand(MarioGame game) : base(game) { }

        public override void Execute()
        {
            switch (Game.World.Mario.SpriteState.Action)
            {
                case MarioSpriteState.ActionEnum.Jumping:
                    Game.World.Mario.SpriteState.Action = MarioSpriteState.ActionEnum.Facing;
                    break;
                case MarioSpriteState.ActionEnum.Facing:
                    Game.World.Mario.SpriteState.Action = MarioSpriteState.ActionEnum.Running;
                    break;
            }
        }
    }
}