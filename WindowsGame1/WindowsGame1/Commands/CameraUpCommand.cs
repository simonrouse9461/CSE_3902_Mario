using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class CameraUpCommand : CommandKernel
    {
        public CameraUpCommand(MarioGame game) : base(game) { }

        public override void Execute()
        {
            Camera.Instance.Adjust(new Vector2(0, -1));
        }
    }
}