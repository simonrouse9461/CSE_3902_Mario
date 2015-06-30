using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class Camera
    {
        private static readonly Camera instance = new Camera();

        public static Camera Instance
        {
            get { return instance; }
        }

        public Vector2 Location { get; set; }

        public void Adjust(Vector2 offset)
        {
            Location += offset;
        }

        private Camera()
        {
            Location = default(Vector2);
        }
    }
}