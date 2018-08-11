using static System.Math;

namespace ToothlessUtils.Types
{
    /// <summary>
    /// Replacement for <see cref="UnityEngine.Vector3"/> <para />
    /// Fully Interchangeable with <see cref="UnityEngine.Vector3"/>
    /// </summary>
    [System.Serializable]
    [System.ComponentModel.DefaultValue(typeof(THVector3), "THVector3.up")]
    public struct THVector3
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
        /// The Z component
        /// </summary>
        public float z;

        /// <summary>
        /// The XY component of the vector
        /// </summary>
        public THVector2 xy
        {
            get
            {
                return new THVector2(x, y);
            }
            set
            {
                x = value.x;
                y = value.y;
            }
        }

        /// <summary>
        /// The size of the vector
        /// </summary>
        public float magnitude
        {
            get { return (float)Sqrt(squareMagnitude); }
        }
        /// <summary>
        /// Square size of vector
        /// </summary>
        public float squareMagnitude
        {
            get { return x * x + y * y + z * z; }
        }

        public THVector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public THVector3(THVector2 xy, float z)
        {
            this.x = xy.x;
            this.y = xy.y;
            this.z = z;
        }
        
        /// <summary>
        /// Normalizes this vector
        /// </summary>
        public THVector3 Normalize()
        {
            return Normalize(this);
        }
        /// <summary>
        /// Normalize a vector
        /// </summary>
        /// <param name="vector3">Vector to normalize</param>
        /// <returns>Normalized vector</returns>
        public static THVector3 Normalize(THVector3 vector3)
        {
            var scale = 1f / vector3.magnitude;
            vector3 *= scale;
            return vector3;
        }
        
        /// <summary>
        /// Corss product of 2 vectors
        /// </summary>
        /// <param name="a">First vector</param>
        /// <param name="b">Second vector</param>
        /// <returns>Cross product</returns>
        public static THVector3 Cross(THVector3 a, THVector3 b)
        {
            return UnityEngine.Vector3.Cross(a, b);
        }

        /// <summary>
        /// Dot product of 2 vectors
        /// </summary>
        /// <param name="a">First vector</param>
        /// <param name="b">Second vector</param>
        /// <returns>Dot product</returns>
        public static float Dot(THVector3 a, THVector3 b)
        {
            return UnityEngine.Vector3.Dot(a, b);
        }

        /// <summary>
        /// Vector as a string
        /// </summary>
        /// <returns>Vector as a string</returns>
        public override string ToString()
        {
            return $"{xy.ToString()}, Z:{z}";
        }

        #region Default
        /// <summary>
        /// Default up
        /// </summary>
        public static THVector3 up { get { return new THVector3(0, 1, 0); } }
        /// <summary>
        /// Default down
        /// </summary>
        public static THVector3 down { get { return new THVector3(0, -1, 0); } }
        /// <summary>
        /// Default right
        /// </summary>
        public static THVector3 right { get { return new THVector3(1, 0, 0); } }
        /// <summary>
        /// Default left
        /// </summary>
        public static THVector3 left { get { return new THVector3(-1, 0, 0); } }
        /// <summary>
        /// Default forwards
        /// </summary>
        public static THVector3 forwards { get { return new THVector3(0, 0, 1); } }
        /// <summary>
        /// Default back
        /// </summary>
        public static THVector3 back { get { return new THVector3(0, 0, -1); } }
        #endregion

        #region Operators
        public static THVector3 operator +(THVector3 v1, THVector3 v2)
        {
            return new THVector3(v1.xy + v2.xy, v1.z + v2.z);
        }

        public static THVector3 operator -(THVector3 v1, THVector3 v2)
        {
            return new THVector3(v1.xy - v2.xy, v1.z - v2.z);
        }

        public static THVector3 operator *(THVector3 v1, THVector3 v2)
        {
            return new THVector3(v1.xy * v2.xy, v1.z * v2.z);
        }

        public static THVector3 operator /(THVector3 v1, THVector3 v2)
        {
            return new THVector3(v1.xy / v2.xy, v1.z / v2.z);
        }

        public static THVector3 operator +(THVector3 v1, float v2)
        {
            return new THVector3(v1.x + v2, v1.y + v2, v1.z + v2);
        }

        public static THVector3 operator -(THVector3 v1, float v2)
        {
            return new THVector3(v1.x - v2, v1.y - v2, v1.z - v2);
        }

        public static THVector3 operator *(THVector3 v1, float v2)
        {
            return new THVector3(v1.x * v2, v1.y * v2, v1.z * v2);
        }

        public static THVector3 operator /(THVector3 v1, float v2)
        {
            return new THVector3(v1.x / v2, v1.y / v2, v1.z / v2);
        }

        public static THVector3 operator -(THVector3 v1)
        {
            return new THVector3(-v1.x, -v1.y, -v1.z);
        }

        public static bool operator ==(THVector3 v1, object v2)
        {
            if (v2.GetType() != typeof(THVector3)) return false;

            THVector3 v3 = (THVector3)v2;

            return v1.GetHashCode() == v3.GetHashCode();
        }

        public static bool operator !=(THVector3 v1, object v2)
        {
            if (v2.GetType() != typeof(THVector3)) return true;

            THVector3 v3 = (THVector3)v2;

            return v1.GetHashCode() != v3.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        #endregion

        #region Type Conversions
        public static implicit operator UnityEngine.Vector3(THVector3 v)
        {
            return new UnityEngine.Vector3(v.x, v.y, v.z);
        }

        public static implicit operator THVector3(UnityEngine.Vector3 v)
        {
            return new THVector3(v.x, v.y, v.z);
        }

        public static implicit operator THVector3(THVector2 v)
        {
            return new THVector3(v, 0);
        }

        public static explicit operator THVector2(THVector3 v)
        {
            return new THVector2(v.x, v.y);
        }
        #endregion

        #region HashCode
        public override int GetHashCode()
        {
            unsafe
            {
                var h = xy.GetHashCode() ^ (((int)z * 7985) ^ 45);

                return h;
            }
        }
        #endregion
    }
}
