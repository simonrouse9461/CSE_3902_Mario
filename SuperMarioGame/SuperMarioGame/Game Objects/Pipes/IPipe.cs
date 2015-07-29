using System.Security.Cryptography.X509Certificates;

namespace SuperMario
{
    public interface IPipe : IObject
    {
        bool IsSecret { get; } 
    }
}