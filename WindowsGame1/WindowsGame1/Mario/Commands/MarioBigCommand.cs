namespace WindowsGame1
{
    public class MarioBigCommand : CommandKernel
    {
        public MarioBigCommand(MarioGame game) : base(game) { }

        public override void Execute()
        {
            //Game.World.Mario.SpriteState.Status = MarioSpriteState.StatusEnum.Big;
            Game.World.Mario.BecomeBig();
        }
    }
}