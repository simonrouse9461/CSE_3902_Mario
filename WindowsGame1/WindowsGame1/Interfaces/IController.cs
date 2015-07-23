using Microsoft.Xna.Framework.Input;

namespace SuperMario
{
    public interface IController<T>
    {
        void RegisterCommand(T key, ICommand command);
        void Update();
    }
}
