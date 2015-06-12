namespace WindowsGame1
{
    public class MarioUpCommand : CommandKernel
    {
        public MarioUpCommand(MarioGame game) : base(game) { }

        public override void Execute()
        {
            if (Game.World.Mario.IsCrouch())
                Game.World.Mario.Stand();
            if (Game.World.Mario.IsStand())
                Game.World.Mario.Run();
            if (Game.World.Mario.IsRun())
                Game.World.Mario.Jump();
        }
    }
}