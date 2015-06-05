namespace WindowsGame1
{
    public class MarioDeadCommand : CommandKernel
    {
        public MarioDeadCommand(Game1 game) : base(game) { }

        public override void Execute()
        {
            Game.Mario.SpriteState.Status = MarioSpriteState.StatusEnum.Dead;
        } 
    }
}