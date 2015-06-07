namespace WindowsGame1
{
    public class MarioUpCommand : CommandKernel
    {
        public MarioUpCommand(MarioGame game) : base(game) { }

        public override void Execute()
        {
            switch (Game.World.Mario.SpriteState.Action)
            {
                case MarioSpriteState.ActionEnum.Running:
                    Game.World.Mario.SpriteState.Action = MarioSpriteState.ActionEnum.Facing;
                    break;
                case MarioSpriteState.ActionEnum.Facing:
                    Game.World.Mario.SpriteState.Action = MarioSpriteState.ActionEnum.Jumping;
                    break;
            }
        }
    }
}