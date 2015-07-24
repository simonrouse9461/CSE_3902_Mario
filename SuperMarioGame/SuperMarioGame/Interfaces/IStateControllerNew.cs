using System;

namespace SuperMario
{
    public interface IStateControllerNew
    {
        ICoreNew Core { set; }
        ISpriteStateNew GeneralSpriteState { get; }
        IMotionStateNew GeneralMotionState { get; }

        void Update();
        void RefreshState();
        void SwitchComponent(object component);
    }
}