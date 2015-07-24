namespace LevelGenerator
{
    public class OverWorldLevel : LevelKernel
    {
        public OverWorldLevel()
        {
            AddObjectBatch(new Item("FloorBlockObject"), new []
            {
                new Section(0, 0, 20, 2)
            });
        }
    }
}