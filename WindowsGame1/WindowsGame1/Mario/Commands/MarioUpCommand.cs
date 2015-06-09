namespace WindowsGame1
{
    public class MarioUpCommand : CommandKernel
    {
        public MarioUpCommand(MarioGame game) : base(game) { }

        public override void Execute()
        {
            switch (Game.World.Mario.SpriteState.Action)
            {
                case MarioSpriteState.ActionEnum.Crouch:
                    Game.World.Mario.SpriteState.Action = MarioSpriteState.ActionEnum.Stand;
                    break;
                case MarioSpriteState.ActionEnum.Stand:
                    Game.World.Mario.SpriteState.Action = MarioSpriteState.ActionEnum.Run;
                    break;
                case MarioSpriteState.ActionEnum.Run:
                    Game.World.Mario.SpriteState.Action = MarioSpriteState.ActionEnum.Jump;
                    break;
            }
        }
    }
}