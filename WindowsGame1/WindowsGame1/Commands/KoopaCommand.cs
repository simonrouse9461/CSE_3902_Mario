namespace WindowsGame1
{
    public class KoopaCommand : CommandKernel
    {
        public KoopaCommand(MarioGame game) : base(game) { }

        public override void Execute()
        {
            //Game.World.Koopa.SwitchSprite(EnemySpriteEnum.Koopa);
        }

    }
}
