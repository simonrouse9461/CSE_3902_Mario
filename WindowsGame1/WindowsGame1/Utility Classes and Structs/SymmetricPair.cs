namespace WindowsGame1
{
    public class SymmetricPair<T>
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
    }
}