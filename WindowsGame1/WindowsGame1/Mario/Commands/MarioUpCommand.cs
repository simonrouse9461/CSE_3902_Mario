namespace WindowsGame1
{
    public class MarioUpCommand : CommandKernel
    {
        public MarioUpCommand(MarioGame game) : base(game) { }

        public override void Execute()
        {
            Game.World.Mario.PassCommand(this);
        }
    }
}