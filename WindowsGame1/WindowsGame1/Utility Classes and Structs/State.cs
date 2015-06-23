namespace WindowsGame1
{
    public class State<TS, TM>
        where TS : ISpriteStateNew
        where TM : IMotionState
    {
        public IObject Object { get; set; }
        public TS SpriteState { get; set; }
        public TM MotionState { get; set; }
    }
}