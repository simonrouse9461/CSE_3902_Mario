using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public abstract class AbstractBarrierHandlerKernel<TStateController> : IBarrierHandler
        where TStateController : IStateControllerNew
    {
        public bool IsBarrier { get; private set; }

        public bool NoBarrier
        {
            get { return BarrierList.Count == 0; }
        }

        protected Collision BarrierCollision { get; private set; }
        private Collection<Type> BarrierList { get; set; }
        private Collection<Type> BarrierExceptionList { get; set; }

        protected ICoreNew AbstractCore { get; set; }

        protected TStateController AbstractStateController
        {
            get { return (TStateController) AbstractCore.GeneralStateController; }
        }

        protected AbstractBarrierHandlerKernel(ICoreNew core)
        {
            AbstractCore = core;
            BarrierList = new Collection<Type>();
            BarrierExceptionList = new Collection<Type>();
            BecomeBarrier();
        }

        public Collision DetectBarrier(int offset = 0)
        {
            return AbstractCore.CollisionDetector.Detect(BarrierList, BarrierExceptionList, obj => obj.IsBarrier, offset);
        } 

        private static bool RemoveType(IList<Type> typeList, Type type)
        {
            var found = false;
            for (var i = 0; i < typeList.Count; i++)
            {
                var currentType = typeList[i];
                if (type.IsAssignableFrom(currentType))
                {
                    if (currentType == type) found = true;
                    typeList.Remove(currentType);
                }
            }
            return found;
        }
        
        private static void AddType(ICollection<Type> typeList, Type type)
        {
            foreach (var currentType in typeList)
            {
                if (currentType.IsAssignableFrom(type))
                    return;
            }
            typeList.Add(type);
        }

        public void AddBarrier<T>(Type type = null) where T : IObject
        {
            type = type ?? typeof(T);
            if (!RemoveType(BarrierExceptionList, type))
                AddType(BarrierList, type);
        }

        public void RemoveBarrier<T>(Type type = null) where T : IObject
        {
            type = type ?? typeof(T);
            if (!RemoveType(BarrierList, type))
               AddType(BarrierExceptionList, type);
        }

        public void ClearBarrier()
        {
            BarrierList = new Collection<Type>();
            BarrierExceptionList = new Collection<Type>();
        }

        public void BecomeBarrier()
        {
            IsBarrier = true;
        }

        public void BecomeNonBarrier()
        {
            IsBarrier = false;
        }

        public void Update()
        {
            BarrierCollision = DetectBarrier(1);
        }

        public virtual void ResetVelocity()
        {
            if (BarrierCollision.Bottom.Touch && AbstractCore.Object.GoingDown) AbstractCore.GeneralMotionState.ResetVerticalVelocity();
            if (BarrierCollision.Top.Touch && AbstractCore.Object.GoingUp) AbstractCore.GeneralMotionState.ResetVerticalVelocity();
            if (BarrierCollision.Left.Touch && AbstractCore.Object.GoingLeft) AbstractCore.GeneralMotionState.ResetHorizontalVelocity();
            if (BarrierCollision.Right.Touch && AbstractCore.Object.GoingRight) AbstractCore.GeneralMotionState.ResetHorizontalVelocity();
        }

        public abstract void HandleCollision();

        public virtual void HandleOverlap()
        {
            if (DetectBarrier().AnyEdge.Touch)
            {
                while (DetectBarrier().Bottom.Touch)
                    AbstractCore.GeneralMotionState.AdjustPosition(new Vector2(0, -1));
                while (DetectBarrier().Top.Touch)
                    AbstractCore.GeneralMotionState.AdjustPosition(new Vector2(0, 1));
                while (DetectBarrier().Left.Touch)
                    AbstractCore.GeneralMotionState.AdjustPosition(new Vector2(1, 0));
                while (DetectBarrier().Right.Touch)
                    AbstractCore.GeneralMotionState.AdjustPosition(new Vector2(-1, 0));
            }
        }
    }
}