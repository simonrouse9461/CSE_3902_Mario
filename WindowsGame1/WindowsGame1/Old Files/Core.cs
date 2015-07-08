﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WindowsGame1
{
    public class Core<TS, TM> : ICore
        where TS : ISpriteState
        where TM : IMotionState
    {
        private class Reservation
        {
            public Action Command { get; set; }
            public Func<bool> Dependency { get; set; }
            public Counter Timer { get; set; }
        }

        private Collection<Reservation> Waitlist;

        public IObject Object { get; set; }
        public TS SpriteState { get; set; }
        public TM MotionState { get; set; }
        public CollisionDetector CollisionDetector { get; set; }
        public BarrierDetector BarrierDetector { get; set; }
        public IStateController GeneralStateController { get; set; }
        public ICollisionHandler CollisionHandler { get; set; }
        public ICommandExecutor CommandExecutor { get; set; }

        public ISpriteState GeneralSpriteState
        {
            get { return SpriteState; }
        }

        public IMotionState GeneralMotionState
        {
            get { return MotionState; }
        }

        public Core()
        {
            Waitlist = new Collection<Reservation>();
            CollisionDetector = new CollisionDetector(Object);
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
            if (component is TS)
                SpriteState = (TS)component;
            if (component is TM)
                MotionState = (TM)component;
            if (component is ICollisionHandler)
                CollisionHandler = (ICollisionHandler)component;
            if (component is ICommandExecutor)
                CommandExecutor = (ICommandExecutor)component;
            if (component is BarrierDetector)
                BarrierDetector = (BarrierDetector)component;
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