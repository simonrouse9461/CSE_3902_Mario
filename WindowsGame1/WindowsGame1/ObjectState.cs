using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class ObjectState<T, K>
        where T : struct, IConvertible
        where K : struct, IConvertible
    {
        public Vector2 Location;

        public T ActiveSprite;

        public Dictionary<K, bool> EffectiveMotion;

        public ObjectState(Vector2 location)
        {
            Location = location;
            ActiveSprite = new T();
            EffectiveMotion = new Dictionary<K, bool>();
            foreach (K motion in Enum.GetValues(typeof (K)))
            {
                EffectiveMotion.Add(motion, false);
            }
        }
    }
}