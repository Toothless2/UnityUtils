using static System.Math;
using System;
using ToothlessUtils.Extensions;

namespace ToothlessUtils.Types
{
    [System.Serializable]
    public struct THVector4
    {
        const float kEpsilon = 0.00001F;
        
        /// <summary>
        /// X Componemt
        /// </summary>
        public float x;
        /// <summary>
        /// Y Component
        /// </summary>
        public float y;
        /// <summary>
        /// Z Component
        /// </summary>
        public float z;
        /// <summary>
        /// W Component
        /// </summary>
        public float w;
        
        /// <summary>
        /// XYZ of vector
        /// </summary>
        public THVector3 xyz
        {
            get
            {
                return new THVector3(x, y, z);
            }

            set
            {
                x = value.x;
                y = value.y;
                z = value.z;
            }
        }

        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return x;
                    case 1: return y;
                    case 2: return z;
                    case 3: return w;
                    default:
                        throw new IndexOutOfRangeException($"{index} is out of range. Valid indexs are from 0 to 3");
                }
            }

            set
            {
                switch (index)
                {
                    case 0: x = value; break;
                    case 1: y = value; break;
                    case 2: z = value; break;
                    case 3: w = value; break;
                    default:
                        throw new IndexOutOfRangeException($"{index} is out of range. Valid indexs are from 0 to 3");
                }
            }
        }

        // Creates a new vector with given x, y, z, w components.
        public THVector4(float x = 1, float y = 1, float z = 0, float w = 0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
        public THVector4(THVector3 xyz, float w)
        {
            this.x = xyz.x;
            this.y = xyz.y;
            this.z = xyz.z;
            this.w = w;
        }
        
        /// <summary>
        /// Sets X, Y, Z, and W components of an existing vector
        /// </summary>
        /// <param name="newX">X</param>
        /// <param name="newY">Y</param>
        /// <param name="newZ">Z</param>
        /// <param name="newW">W</param>
        public void Set(float newX, float newY, float newZ, float newW)
        {
            x = newX;
            y = newY;
            z = newZ;
            w = newW;
        }
        
        /// <summary>
        /// Linearly interpolates between two vectors. <paramref name="t"/> is clamped between 0 and 1
        /// </summary>
        /// <param name="a">First vector</param>
        /// <param name="b">Second vector</param>
        /// <param name="t">Lerp steps</param>
        /// <returns>Lerped vector</returns>
        public static THVector4 Lerp(THVector4 a, THVector4 b, float t)
        {
            t = t.Clamp(0, 1);
            return new THVector4(
                a.x + (b.x - a.x) * t,
                a.y + (b.y - a.y) * t,
                a.z + (b.z - a.z) * t,
                a.w + (b.w - a.w) * t
                );
        }
        
        /// <summary>
        /// Linearly interpolates between two vectors. <paramref name="t"/> is unclamped
        /// </summary>
        /// <param name="a">First vector</param>
        /// <param name="b">Second vector</param>
        /// <param name="t">Lerp steps</param>
        /// <returns>Lerped vector</returns>
        public static THVector4 LerpUnclamped(THVector4 a, THVector4 b, float t)
        {
            return new THVector4(
                a.x + (b.x - a.x) * t,
                a.y + (b.y - a.y) * t,
                a.z + (b.z - a.z) * t,
                a.w + (b.w - a.w) * t
                );
        }

        // Moves a point /current/ towards /target/.
        public static THVector4 MoveTowards(THVector4 current, THVector4 target, float maxDistanceDelta)
        {
            THVector4 toVector = target - current;
            float dist = toVector.magnitude;
            if (dist <= maxDistanceDelta || dist == 0)
                return target;
            return current + toVector / dist * maxDistanceDelta;
        }

        // Multiplies two vectors component-wise.
        public static THVector4 Scale(THVector4 a, THVector4 b)
        {
            return new THVector4(a.x * b.x, a.y * b.y, a.z * b.z, a.w * b.w);
        }

        // Multiplies every component of this vector by the same component of /scale/.
        public void Scale(THVector4 scale)
        {
            x *= scale.x;
            y *= scale.y;
            z *= scale.z;
            w *= scale.w;
        }

        // used to allow Vector4s to be used as keys in hash tables
        public override int GetHashCode()
        {
            return x.GetHashCode() ^ (y.GetHashCode() << 2) ^ (z.GetHashCode() >> 2) ^ (w.GetHashCode() >> 1);
        }

        // also required for being able to use Vector4s as keys in hash tables
        public override bool Equals(object other)
        {
            if (!(other is THVector4)) return false;

            return Equals((THVector4)other);
        }

        public bool Equals(THVector4 other)
        {
            return x.Equals(other.x) && y.Equals(other.y) && z.Equals(other.z) && w.Equals(other.w);
        }

        // *undoc* --- we have normalized property now
        public static THVector4 Normalize(THVector4 a)
        {
            float mag = Magnitude(a);
            if (mag > kEpsilon)
                return a / mag;
            else
                return zero;
        }

        // Makes this vector have a ::ref::magnitude of 1.
        public void Normalize()
        {
            float mag = Magnitude(this);
            if (mag > kEpsilon)
                this = this / mag;
            else
                this = zero;
        }

        // Returns this vector with a ::ref::magnitude of 1 (RO).
        public THVector4 normalized
        {
            get
            {
                return THVector4.Normalize(this);
            }
        }

        // Dot Product of two vectors.
        public static float Dot(THVector4 a, THVector4 b) { return a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w; }

        // Projects a vector onto another vector.
        public static THVector4 Project(THVector4 a, THVector4 b) { return b * Dot(a, b) / Dot(b, b); }

        // Returns the distance between /a/ and /b/.
        public static float Distance(THVector4 a, THVector4 b) { return Magnitude(a - b); }

        // *undoc* --- there's a property now
        public static float Magnitude(THVector4 a) { return (float)Sqrt(Dot(a, a)); }

        // Returns the length of this vector (RO).
        public float magnitude { get { return (float)Sqrt(Dot(this, this)); } }

        // Returns the squared length of this vector (RO).
        public float sqrMagnitude { get { return Dot(this, this); } }

        // Returns a vector that is made from the smallest components of two vectors.
        public static THVector4 Min(THVector4 lhs, THVector4 rhs)
        {
            return new THVector4((float)Math.Min(lhs.x, rhs.x), (float)Math.Min(lhs.y, rhs.y), (float)Math.Min(lhs.z, rhs.z), (float)Math.Min(lhs.w, rhs.w));
        }

        // Returns a vector that is made from the largest components of two vectors.
        public static THVector4 Max(THVector4 lhs, THVector4 rhs)
        {
            return new THVector4((float)Math.Max(lhs.x, rhs.x), (float)Math.Max(lhs.y, rhs.y), (float)Math.Max(lhs.z, rhs.z), (float)Math.Max(lhs.w, rhs.w));
        }

        static readonly THVector4 zeroVector = new THVector4(0F, 0F, 0F, 0F);
        static readonly THVector4 oneVector = new THVector4(1F, 1F, 1F, 1F);
        static readonly THVector4 positiveInfinityVector = new THVector4(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);
        static readonly THVector4 negativeInfinityVector = new THVector4(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);

        // Shorthand for writing @@Vector4(0,0,0,0)@@
        public static THVector4 zero { get { return zeroVector; } }
        // Shorthand for writing @@Vector4(1,1,1,1)@@
        public static THVector4 one { get { return oneVector; } }
        // Shorthand for writing @@Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity)@@
        public static THVector4 positiveInfinity { get { return positiveInfinityVector; } }
        // Shorthand for writing @@Vector3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity)@@
        public static THVector4 negativeInfinity { get { return negativeInfinityVector; } }

        // Adds two vectors.
        public static THVector4 operator +(THVector4 a, THVector4 b) { return new THVector4(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w); }
        // Subtracts one vector from another.
        public static THVector4 operator -(THVector4 a, THVector4 b) { return new THVector4(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w); }
        // Negates a vector.
        public static THVector4 operator -(THVector4 a) { return new THVector4(-a.x, -a.y, -a.z, -a.w); }
        // Multiplies a vector by a number.
        public static THVector4 operator *(THVector4 a, float d) { return new THVector4(a.x * d, a.y * d, a.z * d, a.w * d); }
        // Multiplies a vector by a number.
        public static THVector4 operator *(float d, THVector4 a) { return new THVector4(a.x * d, a.y * d, a.z * d, a.w * d); }
        // Divides a vector by a number.
        public static THVector4 operator /(THVector4 a, float d) { return new THVector4(a.x / d, a.y / d, a.z / d, a.w / d); }

        // Returns true if the vectors are equal.
        public static bool operator ==(THVector4 lhs, THVector4 rhs)
        {
            // Returns false in the presence of NaN values.
            return SqrMagnitude(lhs - rhs) < kEpsilon * kEpsilon;
        }

        // Returns true if vectors are different.
        public static bool operator !=(THVector4 lhs, THVector4 rhs)
        {
            // Returns true in the presence of NaN values.
            return !(lhs == rhs);
        }

        // Converts a [[Vector3]] to a Vector4.
        public static implicit operator THVector4(THVector3 v)
        {
            return new THVector4(v.x, v.y, v.z, 0.0F);
        }

        // Converts a Vector4 to a [[Vector3]].
        public static explicit operator THVector3(THVector4 v)
        {
            return new THVector3(v.x, v.y, v.z);
        }

        // Converts a [[Vector2]] to a Vector4.
        public static implicit operator THVector4(THVector2 v)
        {
            return new THVector4(v.x, v.y, 0.0F, 0.0F);
        }

        // Converts a Vector4 to a [[Vector2]].
        public static explicit operator THVector2(THVector4 v)
        {
            return new THVector2(v.x, v.y);
        }

        public override string ToString()
        {
            return $"X:{x} Y:{y} Z:{z} W:{w}";
        }

        // *undoc* --- there's a property now
        public static float SqrMagnitude(THVector4 a) { return THVector4.Dot(a, a); }
        // *undoc* --- there's a property now
        public float SqrMagnitude() { return Dot(this, this); }
    }
}
