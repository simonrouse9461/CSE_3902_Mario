namespace SuperMario
{
    public class PipeBody : BasicBarrierObject<PipeBodySprite>, IPipe
    {
        public bool IsSecret
        {
            get { return false; }
        }
    }
}