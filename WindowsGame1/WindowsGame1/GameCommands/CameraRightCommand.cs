using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class CameraRightCommand : CommandKernel
    {
        public CameraRightCommand(MarioGame game) : base(game) { }

        public override void Execute()
        {
            Camera.Adjust(new Vector2(5, 0));
        }
    }
}