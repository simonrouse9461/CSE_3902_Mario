namespace WindowsGame1
{
    public abstract class CollisionHandlerKernel<TObject> : ICollisionHandler where TObject : IObject
    {
        protected readonly TObject Object;

        protected CollisionHandlerKernel(TObject obj)
        {
            Object = obj;
            Initialize();
        }

        protected abstract void Initialize();

        public abstract void Handle();
    }
}