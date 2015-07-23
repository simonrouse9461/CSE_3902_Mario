using System;
using System.Collections.ObjectModel;

namespace SuperMario
{
    public class Core<TStateController> : ICore
        where TStateController : IStateController, new()
    {
        private class Reservation
        {
            public Action Command { get; set; }
            public Func<bool> Dependency { get; set; }
            public Counter Timer { get; set; }
        }

        private Collection<Reservation> Waitlist;

        public IObject Obj { get; set; }
        public CollisionDetector CollisionDetector { get; set; }
        public IBarrierHandler BarrierHandler { get; set; }
        public TStateController StateController { get; set; }
        public ICollisionHandler CollisionHandler { get; set; }
        public ICommandExecutor CommandExecutor { get; set; }

        public IStateController GeneralStateController
        {
            get { return StateController; }
        }

        public ISpriteState GeneralSpriteState
        {
            get { return StateController.GeneralSpriteState; }
        }

        public IMotionState GeneralMotionState
        {
            get { return StateController.GeneralMotionState; }
        }

        public Core(IObject obj)
        {
            Obj = obj;
            Waitlist = new Collection<Reservation>();
            StateController = new TStateController {Core = this};
            CollisionDetector = new CollisionDetector(obj);
        }

        public void DelayCommand(Action command, int delay = 1)
        {
            Waitlist.Add(new Reservation
            {
                Command = command,
                Dependency = () => true,
                Timer = new Counter(delay)
            });
        }

        public void DelayCommand(Action command, Func<bool> dependency, int delay = 1)
        {
            Waitlist.Add(new Reservation
            {
                Command = command,
                Dependency = dependency,
                Timer = new Counter(delay)
            });
        }

        public void ClearDelayedCommands()
        {
            Waitlist = new Collection<Reservation>();
        }

        public void SwitchComponent(Object component)
        {
            if (component is ISpriteState || component is IMotionState)
                StateController.SwitchComponent(component);
            if (component is ICollisionHandler)
                CollisionHandler = (ICollisionHandler)component;
            if (component is ICommandExecutor)
                CommandExecutor = (ICommandExecutor)component;
            if (component is IBarrierHandler)
                BarrierHandler = (IBarrierHandler)component;
            if (component is TStateController)
                StateController = (TStateController) component;
        }

        public void Update()
        {
            for (var i = 0; i < Waitlist.Count; i++)
            {
                var reservation = Waitlist[i];
                if (!reservation.Dependency())
                {
                    Waitlist.Remove(reservation);
                }
                if (reservation.Timer.Update())
                {
                    reservation.Command();
                    Waitlist.Remove(reservation);
                }
            }
        }
    }
}