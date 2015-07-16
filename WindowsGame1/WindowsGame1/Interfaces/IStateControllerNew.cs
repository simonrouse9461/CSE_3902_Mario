using System;

namespace WindowsGame1
{
    public interface IStateControllerNew
    {
        ICoreNew Core { set; }
        ISpriteStateNew GeneralSpriteState { get; }
        IMotionState GeneralMotionState { get; }

        void Update();
        void RefreshState();
        void SwitchComponent(object component);
    }
}