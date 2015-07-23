namespace SuperMario
{
    public class SymmetricPair<T> where T : class
    {
        public T Left { get; set; }
        public T Right { get; set; }

        public T Default
        {
            get { return Left; }
            set
            {
                Left = value;
                Right = value;
            }
        }

        public bool IsDefault
        {
            get { return Left == Right; }
        }
    }
}