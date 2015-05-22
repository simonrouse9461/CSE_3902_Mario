using Microsoft.Xna.Framework.Input;

namespace WindowsGame1
{
    public interface IController<T>
    {
        void RegisterCommand(T key, ICommand command);
        void Update();
    }
}
