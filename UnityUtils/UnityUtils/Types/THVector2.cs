using static System.Math;

namespace ToothlessUtils.Types
{
    /// <summary>
    /// Replacement for <see cref="UnityEngine.Vector2"/> <para />
    /// Fully Interchangeable with <see cref="UnityEngine.Vector2"/>
    /// </summary>
    [System.Serializable]
    [System.ComponentModel.DefaultValue(typeof(THVector2), "THVector2.up")]
    public struct THVector2
    {
        /// <summary>
        /// The X component
        /// </summary>
        public float x;
        /// <summary>
        /// The Y component
        /// </summary>
        public float y;

        /// <summary>
        /// Magnitude of the vector
        /// </summary>
        public float magnitude
        {
            get { return (float)Sqrt(squareMagnitude); }
        }
        /// <summary>
        /// Square magnitude of vector
        /// </summary>
        public float squareMagnitude
        {
            get { return x * x + y * y; }
        }

        public THVector2(float x = 0, float y = 0)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Normalize this vector
        /// </summary>
        /// <returns>The normalized vector</returns>
        public THVector2 Normalize()
        {
            return Normalize(this);
        }
        /// <summary>
        /// Normilize a <see cref="THVector2"/>
        /// </summary>
        /// <param name="vector2">Vector to normalize</param>
        /// <returns>The normalized vector</returns>
        public static THVector2 Normalize(THVector2 vector2)
        {
            var scale = 1f / vector2.magnitude;
            vector2 *= scale;
            return vector2;
        }

        /// <summary>
        /// Is this vector bigger than another?
        /// </summary>
        /// <param name="v1">Other vector</param>
        /// <returns>true if this vector is bigger</returns>
        public bool isMagBigger(THVector2 v1)
        {
            if (magnitude > v1.magnitude) return true;
            return false;
        }

        /// <summary>
        /// Dot Product of 2 vectors
        /// </summary>
        /// <param name="a">First vector</param>
        /// <param name="b">Second vector</param>
        /// <returns>The dot product</returns>
        public static float Dot(THVector2 a, THVector2 b)
        {
            return UnityEngine.Vector2.Dot(a, b);
        }
        
        /// <summary>
        /// Distance between <paramref name="a"/> and <paramref name="b"/>
        /// </summary>
        /// <param name="a">First vector</param>
        /// <param name="b">Second vector</param>
        /// <returns>Returns distacne between vectors</returns>
        public float Distane(THVector2 a, THVector2 b)
        {
            return (a - b).magnitude;
        }
        
        /// <summary>
        /// converts the vector to a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"X:{x}, Y:{y}";
        }

        #region Default Values
        /// <summary>
        /// Default up
        /// </summary>
        public static THVector2 up { get { return new THVector2(0, 1); } }
        /// <summary>
        /// Default down
        /// </summary>
        public static THVector2 down { get { return new THVector2(0 -1); } }
        /// <summary>
        /// Default right
        /// </summary>
        public static THVector2 right { get { return new THVector2(1, 1); } }
        /// <summary>
        /// Default left
        /// </summary>
        public static THVector2 left { get { return new THVector2(-1, 0); } }
        #endregion

        #region Operators
        public static THVector2 operator +(THVector2 v1, THVector2 v2)
        {
            return new THVector2(v1.x + v2.x, v1.y + v2.y);
        }

        public static THVector2 operator -(THVector2 v1, THVector2 v2)
        {
            return new THVector2(v1.x - v2.x, v1.y - v2.y);
        }

        public static THVector2 operator *(THVector2 v1, THVector2 v2)
        {
            return new THVector2(v1.x * v2.x, v1.y * v2.y);
        }

        public static THVector2 operator /(THVector2 v1, THVector2 v2)
        {
            return new THVector2(v1.x / v2.x, v1.y / v2.y);
        }

        public static THVector2 operator +(THVector2 v1, float v2)
        {
            return new THVector2(v1.x + v2, v1.y + v2);
        }

        public static THVector2 operator -(THVector2 v1, float v2)
        {
            return new THVector2(v1.x - v2, v1.y - v2);
        }

        public static THVector2 operator *(THVector2 v1, float v2)
        {
            return new THVector2(v1.x * v2, v1.y * v2);
        }

        public static THVector2 operator /(THVector2 v1, float v2)
        {
            return new THVector2(v1.x / v2, v1.y / v2);
        }

        public static bool operator ==(THVector2 v1, object v2)
        {
            if (v2.GetType() != typeof(THVector2)) return false;

            THVector2 v3 = (THVector2)v2;

            return v1.GetHashCode() == v3.GetHashCode();
        }

        public static bool operator !=(THVector2 v1, object v2)
        {
            if (v2.GetType() != typeof(THVector2)) return true;

            THVector2 v3 = (THVector2)v2;

            return v1.GetHashCode() != v3.GetHashCode();
        }
        
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        #endregion

        #region Type Conversions
        public static implicit operator UnityEngine.Vector2(THVector2 v)
        {
            return new UnityEngine.Vector2(v.x, v.y);
        }

        public static implicit operator THVector2(UnityEngine.Vector2 v)
        {
            return new THVector2(v.x, v.y);
        }
        #endregion

        #region HashCode
        public override int GetHashCode()
        {
            unsafe
            {
                var h = (((int)x * 56905) ^ 93) ^ (((int)y * 32041) ^ 75);

                return h;
            }
        }
        #endregion
    }
}
