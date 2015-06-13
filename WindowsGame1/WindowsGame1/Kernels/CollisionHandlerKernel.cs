namespace WindowsGame1
{
    public abstract class CollisionHandlerKernel : ICollisionHandler
    {
        protected CollisionHandlerKernel()
        {
            Initialize();
        }

        protected abstract void Initialize();
        public abstract void Handle();
    }
}