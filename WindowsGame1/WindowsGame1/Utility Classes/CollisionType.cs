namespace SuperMario
{
    public struct CollisionType
    {
        private bool _touch;
        private bool _cover;

        public bool Touch
        {
            get { return _touch; }
            private set
            {
                _touch = value;
                if (!value) Cover = false;
            }
        }

        public bool Cover
        {
            get { return _cover; }
            private set
            {
                _cover = value;
                if (value) Touch = true;
            }
        }

        public bool None
        {
            get { return !Touch; }
            private set { if (value) Touch = false; }
        }

        public CollisionType SetToNone()
        {
            None = true;
            return this;
        }

        public CollisionType SetToContact()
        {
            SetToNone();
            Touch = true;
            return this;
        }

        public CollisionType SetToCover()
        {
            SetToNone();
            Cover = true;
            return this;
        }

        public static bool operator ==(CollisionType a, CollisionType b)
        {
            return a.Touch == b.Touch && a.Cover == b.Cover;
        }

        public static bool operator !=(CollisionType a, CollisionType b)
        {
            return !(a == b);
        }

        public static CollisionType operator +(CollisionType a, CollisionType b)
        {
            if (a.None && b.None)
                return default(CollisionType);
            if (a.Cover && b.Cover)
                return default(CollisionType).SetToCover();
            return default(CollisionType).SetToContact();
        }

        public static CollisionType operator &(CollisionType a, CollisionType b)
        {
            if (a.Cover && b.Cover)
                return default(CollisionType).SetToCover();
            if (a.Touch && b.Touch)
                return default(CollisionType).SetToContact();
            return default(CollisionType);
        }

        public static CollisionType operator |(CollisionType a, CollisionType b)
        {
            if (a.Cover || b.Cover)
                return default(CollisionType).SetToCover();
            if (a.Touch || b.Touch)
                return default(CollisionType).SetToContact();
            return default(CollisionType);
        }

        public override bool Equals(object obj)
        {
            if (obj is CollisionType)
                return this == (CollisionType)obj;
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}