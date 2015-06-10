namespace WindowsGame1
{
    public class MushroomCommand : CommandKernel
    {
        public MushroomCommand(MarioGame game) : base(game) { }

        public override void Execute()
        {
            //Game.World.Mushroom.SwitchSprite(MushroomSpriteEnum.Mushroom);
        }

    }
}

