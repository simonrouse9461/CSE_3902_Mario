using Microsoft.Xna.Framework.Input;

namespace MarioGame
{
    public interface IController<T>
    {
        void RegisterCommand(T key, ICommand command);
        void Update();
    }
}
