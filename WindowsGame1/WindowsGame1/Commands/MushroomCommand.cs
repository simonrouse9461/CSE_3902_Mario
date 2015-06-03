

namespace WindowsGame1
{
    public class MushroomCommand : CommandKernel
    {
        public MushroomCommand(Game1 game) : base(game) { }

        public override void Execute()
        {
            Game.Mushroom.SwitchSprite(ItemSpriteEnum.Mushroom);
        }

    }
}

