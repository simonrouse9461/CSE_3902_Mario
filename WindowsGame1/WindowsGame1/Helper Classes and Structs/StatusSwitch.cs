using System;

namespace MarioGame
{
    public class StatusSwitch<T>
    {
        private readonly T _content;

        public T Content
        {
            get { return _content; }
        }

        public bool Status { get; private set; }

        public StatusSwitch(T content)
        {
            _content = content;
        }

        public void Toggle(bool status)
        {
            Status = status;
        }

        public void Reset(Action<T> reset = null)
        {
            if (reset != null) reset(Content);
            Status = false;
        }
    }
}