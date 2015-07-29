namespace SuperMario
{
    public class PipeBody : BasicBackgroundObject<PipeBodySprite>, IPipe
    {
        public bool IsSecret
        {
            get { return false; }
        }
    }
}