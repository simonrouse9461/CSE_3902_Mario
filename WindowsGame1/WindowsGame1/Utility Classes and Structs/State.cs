namespace WindowsGame1
{
    public class State<TS, TM>
        where TS : ISpriteState
        where TM : IMotionState
    {
        public IObject Object;
        public TS SpriteState;
        public TM MotionState;
    }
}