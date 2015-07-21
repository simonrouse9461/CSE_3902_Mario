using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class CameraLeftCommand : CommandKernel
    {
        public CameraLeftCommand(MarioGame game) : base(game) { }

        public override void Execute()
        {
            Camera.Adjust(new Vector2(0, 0));
        }
    }
}