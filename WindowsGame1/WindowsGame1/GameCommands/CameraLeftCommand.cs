using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class CameraLeftCommand : CommandKernel
    {
        public CameraLeftCommand(MarioGame game) : base(game) { }

        public override void Execute()
        {
            Camera.Adjust(new Vector2(-1, 0));
        }
    }
}