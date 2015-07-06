using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class CoreNew<TStateController> : ICore
        where TStateController : IStateController, new()
    {
        private class Reservation
        {
            public Action Command { get; set; }
            public Func<bool> Dependency { get; set; }
            public Counter Timer { get; set; }
        }

        private Collection<Reservation> Waitlist;

        public IObject Object { get; set; }
        public CollisionDetector CollisionDetector { get; set; }
        public BarrierDetector BarrierDetector { get; set; }
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

        public CoreNew(IObject obj)
        {
            Object = obj;
            Waitlist = new Collection<Reservation>();
            StateController = new TStateController {Core = this};
            CollisionDetector = new CollisionDetector(obj);
            BarrierDetector = new BarrierDetector(this);
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

        public void SwitchComponent(Object obj)
        {
            if (obj is ISpriteState || obj is IMotionState)
                //StateController.SwitchComponent(obj);
            if (obj is ICollisionHandler)
                CollisionHandler = (ICollisionHandler)obj;
            if (obj is ICommandExecutor)
                CommandExecutor = (ICommandExecutor)obj;
            if (obj is BarrierDetector)
                BarrierDetector = (BarrierDetector)obj;
            if (obj is TStateController)
                StateController = (TStateController) obj;
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