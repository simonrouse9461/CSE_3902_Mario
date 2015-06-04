namespace WindowsGame1
{
    public class KoopaCommand : CommandKernel
    {
        public KoopaCommand(Game1 game) : base(game) { }

        public override void Execute()
        {
            Game.Koopa.SwitchSprite(EnemySpriteEnum.Koopa);
        }

    }
}
