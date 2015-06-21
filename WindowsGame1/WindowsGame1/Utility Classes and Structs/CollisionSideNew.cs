namespace WindowsGame1
{
    public struct CollisionSideNew
    {
        public struct CollisionType
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
                    return new CollisionType();
                if (a.Cover && b.Cover)
                    return new CollisionType().SetToCover();
                return new CollisionType().SetToContact();
            }

            public static CollisionType operator |(CollisionType a, CollisionType b)
            {
                if (a.Cover || b.Cover)
                    return new CollisionType().SetToCover();
                if (a.Contact || b.Contact)
                    return new CollisionType().SetToContact();
                return new CollisionType();
            }
        }

        public CollisionType TopLeft { get; private set; }
        public CollisionType TopRight { get; private set; }
        public CollisionType BottomLeft { get; private set; }
        public CollisionType BottomRight { get; private set; }
        public CollisionType LeftTop { get; private set; }
        public CollisionType LeftBottom { get; private set; }
        public CollisionType RightTop { get; private set; }
        public CollisionType RightBottom { get; private set; }

        public CollisionType Top
        {
            get { return TopLeft & TopRight; }
        }

        public CollisionType Bottom
        {
            get { return BottomLeft & BottomRight; }
        }

        public CollisionType Left
        {
            get { return LeftTop & LeftBottom; }
        }

        public CollisionType Right
        {
            get { return RightTop & RightBottom; }
        }

        public CollisionType Side
        {
            get { return Left | Right; }
        }

        public CollisionType Any
        {
            get { return Side | Top | Bottom; }
        }

        public static bool operator ==(CollisionSideNew a, CollisionSideNew b)
        {
            return a.TopLeft == b.TopLeft
                && a.TopRight == b.TopRight
                && a.BottomLeft == b.BottomLeft
                && a.BottomRight == b.BottomRight
                && a.LeftTop == b.LeftTop
                && a.LeftBottom == b.LeftBottom
                && a.RightTop == b.RightTop
                && a.RightBottom == b.RightBottom;
        }

        public static bool operator !=(CollisionSideNew a, CollisionSideNew b)
        {
            return !(a == b);
        }
    }
}