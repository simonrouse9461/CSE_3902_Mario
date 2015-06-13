namespace WindowsGame1
{
    interface IMario : IObject
    {
        /*
         * Orientation
         */
        void FaceLeft();
        bool IsLeft();

        void FaceRight();
        bool IsRight();

        /*
         * Status
         */
        void BecomeBig();
        bool IsBig();

        void BecomeSmall();
        bool IsSmall();

        void BecomeDead();
        bool IsDead();

        void BecomeFire();
        bool IsFire();

        /*
         * Action
         */
        void Run();
        bool IsRun();

        void Jump();
        bool IsJump();

        void Crouch();
        bool IsCrouch();

        void Stand();
        bool IsStand();
    }
}