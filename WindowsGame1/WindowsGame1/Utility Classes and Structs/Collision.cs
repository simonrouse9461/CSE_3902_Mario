namespace WindowsGame1
{
    public struct Collision
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

        public CollisionType TopLeft { get; set; }
        public CollisionType TopRight { get; set; }
        public CollisionType BottomLeft { get; set; }
        public CollisionType BottomRight { get; set; }
        public CollisionType LeftTop { get; set; }
        public CollisionType LeftBottom { get; set; }
        public CollisionType RightTop { get; set; }
        public CollisionType RightBottom { get; set; }

        public CollisionType Top
        {
            get { return TopLeft & TopRight; }
            set
            {
                TopLeft = value;
                TopRight = value;
            }
        }

        public CollisionType Bottom
        {
            get { return BottomLeft & BottomRight; }
            set
            {
                BottomLeft = value;
                BottomRight = value;
            }
        }

        public CollisionType Left
        {
            get { return LeftTop & LeftBottom; }
            set
            {
                LeftTop = value;
                LeftBottom = value;
            }
        }

        public CollisionType Right
        {
            get { return RightTop & RightBottom; }
            set
            {
                RightTop = value;
                RightBottom = value;
            }
        }

        public CollisionType AnySide
        {
            get { return Left | Right; }
        }

        public CollisionType BothSide
        {
            get { return Left & Right; }
            set
            {
                Left = value;
                Right = value;
            }
        }

        public CollisionType AnyEdge
        {
            get { return AnySide | Top | Bottom; }
        }

        public CollisionType AllEdge
        {
            get { return AnySide & Top & Bottom; }
            set
            {
                BothSide = value;
                Top = value;
                Bottom = value;
            }
        }

        public static bool operator ==(Collision a, Collision b)
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

        public static bool operator !=(Collision a, Collision b)
        {
            return !(a == b);
        }

        public static Collision operator +(Collision a, Collision b)
        {
            var value = default(Collision);
            value.TopLeft = a.TopLeft | b.TopLeft;
            value.TopRight = a.TopRight | b.TopRight;
            value.BottomLeft = a.BottomLeft | b.BottomLeft;
            value.BottomRight = a.BottomRight | b.BottomRight;
            value.LeftTop = a.LeftTop | b.LeftTop;
            value.LeftBottom = a.LeftBottom | b.LeftBottom;
            value.RightTop = a.RightTop | b.RightTop;
            value.RightBottom = a.RightBottom | b.RightBottom;
            return value;
        }
    }
}