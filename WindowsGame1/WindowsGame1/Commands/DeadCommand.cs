namespace WindowsGame1
{
    public class DeadCommand : CommandKernal
    {
        public DeadCommand(Game1 game) : base(game) { }

        public override void Execute()
        {
            Game.CurrentSprite = Game1.Sprite.Dead;
        } 
    }
}