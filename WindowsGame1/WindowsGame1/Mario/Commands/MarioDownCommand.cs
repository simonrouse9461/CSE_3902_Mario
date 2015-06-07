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
                case MarioSpriteState.ActionEnum.Stand:
                    Game.World.Mario.SpriteState.Action = MarioSpriteState.ActionEnum.Crouch;
                    break;
                case MarioSpriteState.ActionEnum.Run:
                    Game.World.Mario.SpriteState.Action = MarioSpriteState.ActionEnum.Stand;
                    break;
                case MarioSpriteState.ActionEnum.Jump:
                    Game.World.Mario.SpriteState.Action = MarioSpriteState.ActionEnum.Run;
                    break;
            }
        }
    }
}