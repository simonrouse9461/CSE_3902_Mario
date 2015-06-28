using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class CameraRightCommand : CommandKernel
    {
        public CameraRightCommand(MarioGame game) : base(game) { }

        public override void Execute()
        {
            Camera.Instance.Adjust(new Vector2(1, 0));
        }
    }
}