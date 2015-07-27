using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;

namespace SuperMario
{ 
    public abstract class BarrierHandlerKernelNew<TStateController> : IBarrierHandler
        where TStateController : IStateControllerNew, new()
    {
        public Collision BarrierCollision { get; private set; }
        public Collection<Type> BarrierList { get; private set; }
        public Collection<Type> BarrierExceptionList { get; private set; }

        protected CoreNew<TStateController> Core { get; set; } 

        protected BarrierHandlerKernelNew(ICoreNew core)
        {
            if (core is CoreNew<TStateController>)
                Core = (CoreNew<TStateController>)core;
            else
                Core = new CoreNew<TStateController>(core.Object)
                {
                    StateController = (TStateController)core.GeneralStateController,
                    CollisionHandler = core.CollisionHandler,
                    CommandExecutor = core.CommandExecutor,
                    BarrierHandler = core.BarrierHandler
                };
            BarrierList = new Collection<Type>();
            BarrierExceptionList = new Collection<Type>();
        }

        public Collision DetectBarrier(int offset = 0)
        {
            return Core.CollisionDetector.Detect(BarrierList, BarrierExceptionList, obj => obj.Solid, offset);
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

        public void Update()
        {
            BarrierCollision = DetectBarrier(1);
        }

        public virtual void ResetVelocity()
        {
            if (BarrierCollision.Bottom.Touch && Core.Object.GoingDown) Core.GeneralMotionState.ResetVerticalVelocity();
            if (BarrierCollision.Top.Touch && Core.Object.GoingUp) Core.GeneralMotionState.ResetVerticalVelocity();
            if (BarrierCollision.Left.Touch && Core.Object.GoingLeft) Core.GeneralMotionState.ResetHorizontalVelocity();
            if (BarrierCollision.Right.Touch && Core.Object.GoingRight) Core.GeneralMotionState.ResetHorizontalVelocity();
        }

        public abstract void HandleCollision();

        public virtual void HandleOverlap()
        {
            if (DetectBarrier().AnyEdge.Touch)
            {
                while (DetectBarrier().Bottom.Touch)
                    Core.GeneralMotionState.AdjustPosition(new Vector2(0, -1));
                while (DetectBarrier().Top.Touch)
                    Core.GeneralMotionState.AdjustPosition(new Vector2(0, 1));
                while (DetectBarrier().Left.Touch)
                    Core.GeneralMotionState.AdjustPosition(new Vector2(1, 0));
                while (DetectBarrier().Right.Touch)
                    Core.GeneralMotionState.AdjustPosition(new Vector2(-1, 0));
            }
        }
    }
}