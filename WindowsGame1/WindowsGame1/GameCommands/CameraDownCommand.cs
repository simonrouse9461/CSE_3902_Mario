using Microsoft.Xna.Framework;

namespace MarioGame
{
    public class CameraDownCommand : CommandKernel
    {
        public CameraDownCommand(MarioGame game) : base(game) { }

        public override void Execute()
        {
            Camera.Adjust(new Vector2(0, 1));
        }
    }
}