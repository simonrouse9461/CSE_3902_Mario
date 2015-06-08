namespace WindowsGame1
{
    public class FireflowerCommand : CommandKernel
    {
        public FireflowerCommand(MarioGame game) : base(game) { }

        public override void Execute()
        {
            Game.World.Fireflower.SwitchSprite(FireflowerSpriteEnum.Fireflower);
        }

    }
}