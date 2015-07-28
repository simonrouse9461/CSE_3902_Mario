namespace SuperMario
{
    public interface IEnemyMotionState : IMotionStateNew
    {
        void SetDefaultHorizontal();
        bool DefaultHotizontal { get; }
        void SetDefaultVertical();
        bool DefaultVertical { get; }
        void ObtainGravity();
        void LoseGravity();
        bool Gravity { get; } 
        void Turn(Orientation orientation);
        Orientation Orientation { get; }
        void GoLeft();
        bool GoingLeft { get; }
        void GoRight();
        bool GoingRight { get; }
        void MarioSmash();
        void Flip();
    }
}