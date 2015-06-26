namespace WindowsGame1
{
    public class State<TS, TM>
        where TS : ISpriteState
        where TM : IMotionState
    {
        public IObject Object { get; set; }
        public TS SpriteState { get; set; }
        public TM MotionState { get; set; }
    }
}