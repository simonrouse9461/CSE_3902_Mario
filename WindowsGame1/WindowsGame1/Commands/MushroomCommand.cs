

namespace WindowsGame1
{
    public class FireflowerCommand : CommandKernel
    {
        public FireflowerCommand(Game1 game) : base(game) { }

        public override void Execute()
        {
            Game.Mushroom.SwitchSprite(ItemSpriteEnum.Mushroom);
        }

    }
}

