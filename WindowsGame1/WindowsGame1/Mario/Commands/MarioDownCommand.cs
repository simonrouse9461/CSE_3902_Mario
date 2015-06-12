namespace WindowsGame1
{
    public class MarioDownCommand : CommandKernel
    {
        public MarioDownCommand(MarioGame game) : base(game) { }

        public override void Execute()
        {
            if (Game.World.Mario.IsJump())
                Game.World.Mario.Run();
            else if (Game.World.Mario.IsRun())
                Game.World.Mario.Stand();
            else if (Game.World.Mario.IsStand())
                Game.World.Mario.Crouch();
        }
    }
}