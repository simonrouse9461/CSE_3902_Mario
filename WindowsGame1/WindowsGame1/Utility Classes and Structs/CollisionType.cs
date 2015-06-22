namespace WindowsGame1
{
    public struct CollisionType : ICollisionType
    {
        private bool _contact;
        private bool _cover;

        public bool Contact
        {
            get { return _contact; }
            private set
            {
                _contact = value;
                if (!value) Cover = false;
            }
        }

        public bool Cover
        {
            get { return _cover; }
            private set
            {
                _cover = value;
                if (value) Contact = true;
            }
        }

        public bool None
        {
            get { return !Contact; }
            private set { if (value) Contact = false; }
        }

        public CollisionType SetToNone()
        {
            None = true;
            return this;
        }

        public CollisionType SetToContact()
        {
            SetToNone();
            Contact = true;
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
            return a.Contact == b.Contact && a.Cover == b.Cover;
        }

        public static bool operator !=(CollisionType a, CollisionType b)
        {
            return !(a == b);
        }

        public static CollisionType operator &(CollisionType a, CollisionType b)
        {
            if (a.None && b.None)
                return default(CollisionType);
            if (a.Cover && b.Cover)
                return default(CollisionType).SetToCover();
            return default(CollisionType).SetToContact();
        }

        public static CollisionType operator |(CollisionType a, CollisionType b)
        {
            if (a.Cover || b.Cover)
                return default(CollisionType).SetToCover();
            if (a.Contact || b.Contact)
                return default(CollisionType).SetToContact();
            return default(CollisionType);
        }
    }
}