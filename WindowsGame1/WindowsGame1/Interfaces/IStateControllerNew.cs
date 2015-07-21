using System;

namespace MarioGame
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