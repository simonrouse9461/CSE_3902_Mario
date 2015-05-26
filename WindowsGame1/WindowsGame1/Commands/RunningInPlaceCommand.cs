namespace WindowsGame1
{
    public class RunningInPlaceCommand : CommandKernal
    {
        public RunningInPlaceCommand(Game1 game) : base(game) { }

        public override void Execute()
        {
            Game.CurrentSprite = Game1.Sprite.RunningInPlace;
        }
    }
}