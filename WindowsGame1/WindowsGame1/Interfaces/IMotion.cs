using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public interface IMotion
    {
        void Reset(Vector2 initial = default(Vector2));

        void Update(int phase = -1);

        bool End();

        Vector2 GetVelocity(); 
    }
}