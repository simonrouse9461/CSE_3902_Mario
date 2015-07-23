using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;

namespace MarioGame
{ 
    public abstract class BarrierHandlerKernel<TStateController> : IBarrierHandler
        where TStateController : IStateController, new()
    {
        public Collision BarrierCollision { get; private set; }
        public Collection<Type> BarrierList { get; private set; }
        public Collection<Type> BarrierExceptionList { get; private set; }

        protected Core<TStateController> Core { get; set; } 

        protected BarrierHandlerKernel(ICore core)
        {
            if (core is Core<TStateController>)
                Core = (Core<TStateController>)core;
            else
                Core = new Core<TStateController>(core.Obj)
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
            if (BarrierCollision.Bottom.Touch && Core.Obj.GoingDown) Core.GeneralMotionState.ResetVerticalVelocity();
            if (BarrierCollision.Top.Touch && Core.Obj.GoingUp) Core.GeneralMotionState.ResetVerticalVelocity();
            if (BarrierCollision.Left.Touch && Core.Obj.GoingLeft) Core.GeneralMotionState.ResetHorizontalVelocity();
            if (BarrierCollision.Right.Touch && Core.Obj.GoingRight) Core.GeneralMotionState.ResetHorizontalVelocity();
        }

        public abstract void HandleCollision();

        public virtual void HandleOverlap()
        {
            if (DetectBarrier().AnyEdge.Touch)
            {
                while (DetectBarrier().Bottom.Touch)
                    Core.GeneralMotionState.Adjust(new Vector2(0, -1));
                while (DetectBarrier().Top.Touch)
                    Core.GeneralMotionState.Adjust(new Vector2(0, 1));
                while (DetectBarrier().Left.Touch)
                    Core.GeneralMotionState.Adjust(new Vector2(1, 0));
                while (DetectBarrier().Right.Touch)
                    Core.GeneralMotionState.Adjust(new Vector2(-1, 0));
            }
        }
    }
}