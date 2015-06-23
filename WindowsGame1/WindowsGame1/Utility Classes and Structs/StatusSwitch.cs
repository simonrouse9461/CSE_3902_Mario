using System;

namespace WindowsGame1
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

        public void Reset(Action<T> reset)
        {
            reset(Content);
            Status = false;
        }
    }
}