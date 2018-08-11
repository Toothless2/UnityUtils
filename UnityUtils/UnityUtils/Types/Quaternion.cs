using System;
using static System.Math;
using static UnityEngine.Mathf;

namespace ToothlessUtils.Types
{
    [System.Serializable]
    [System.ComponentModel.DefaultValue(typeof(THQuaternion), "THQuaternion.identity")]
    public struct THQuaternion
    {
        const float radToDeg = (float)(180 / Math.PI);
        const float degToRad = (float)(Math.PI / 180);

        /// <summary>
        /// X Component
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
        /// XYZ component of Quaternion
        /// </summary>
        public THVector3 xyz
        {
            get
            {
                return new THVector3(x, y, z);
            }

            set
            {
                this.x = value.x;
                this.y = value.y;
                this.z = value.z;
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
                    default: throw new IndexOutOfRangeException($"{index} is not a valid index. Valid range is 0-3.");
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
                    default: throw new IndexOutOfRangeException($"{index} is not a valid index. Valid range is 0-3.");
                }
            }
        }

        /// <summary>
        /// Default position
        /// </summary>
        public static THQuaternion identity
        {
            get
            {
                return new THQuaternion(0, 0, 0, 1);
            }
        }

        /// <summary>
        /// Change Quaternion angles<para/>
        /// Input in deg, output in rads
        /// </summary>
        public THVector3 eulerAngles
        {
            get
            {
                return ToEulerRad(this) * radToDeg;
            }
            set
            {
                this = FromEulerRad(value * degToRad);
            }
        }

        /// <summary>
        /// Length of Quaternion
        /// </summary>
        public float length
        {
            get
            {
                return Sqrt(lengthSquared);
            }
        }

        /// <summary>
        /// Suared length of Quaternion
        /// </summary>
        public float lengthSquared
        {
            get
            {
                return x * x + y * y + z * z + w * w;
            }
        }

        public THQuaternion(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
        public THQuaternion(THVector3 xyz, float w)
        {
            this.x = xyz.x;
            this.y = xyz.y;
            this.z = xyz.z;
            this.w = w;
        }

        /// <summary>
        /// Set Quaternion values<para />
        /// Must already be in correct form
        /// </summary>
        /// <param name="x">X Rotation</param>
        /// <param name="y">Y Rotation</param>
        /// <param name="z">Z Rotation</param>
        /// <param name="w">W</param>
        public void Set(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
        /// <summary>
        /// Set Quaternion values<para />
        /// XYZ must be in degs
        /// </summary>
        /// <param name="xyz">XYZ Angles</param>
        public void Set(THVector3 xyz)
        {
            eulerAngles = xyz;
        }

        /// <summary>
        /// Normalize Quaternion
        /// </summary>
        public void Normalize()
        {
            this = Normalize(this);
        }
        /// <summary>
        /// Normalize a Quaternion
        /// </summary>
        /// <param name="quaternion"></param>
        /// <returns></returns>
        public static THQuaternion Normalize(THQuaternion quaternion)
        {
            var scale = 1.0f / quaternion.length;
            quaternion.xyz *= scale;
            quaternion.w *= scale;

            return quaternion;
        }
        /// <summary>
        /// Produce a normalized version of an input Quaternion
        /// </summary>
        /// <param name="q">Input Quaternion</param>
        /// <param name="result">Output Quaternion</param>
        public static void Normalize(ref THQuaternion q, out THQuaternion result)
        {
            var scale = 1f / q.length;
            result = new THQuaternion(q.xyz * scale, q.w * scale);
        }

        /// <summary>
        /// Produce a Dot procude of the Quaternion
        /// </summary>
        /// <param name="a">First Quaternion</param>
        /// <param name="b">Second Quaternion</param>
        /// <returns></returns>
        public static float Dot(THQuaternion a, THQuaternion b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w;
        }

        /// <summary>
        /// Causes a rotation <paramref name="angle"/> degs around <paramref name="axis"/> <para />
        /// Renaming of <see cref="RotateAroundAxis(float, THVector3)"/>
        /// </summary>
        /// <param name="angle">Angle to rotate</param>
        /// <param name="axis">Rotation axis</param>
        /// <returns>A rotated Quaternion</returns>
        public static THQuaternion RotateAroundAxis(float angle, THVector3 axis)
        {
            return AngleAxis(angle, ref axis);
        }
        /// <summary>
        /// Causes a rotation <paramref name="angle"/> degs around <paramref name="axis"/>
        /// </summary>
        /// <param name="angle">Angle to rotate</param>
        /// <param name="axis">Axis to rotate around</param>
        /// <returns>A Rotated Quaternion</returns>
        public static THQuaternion AngleAxis(float angle, THVector3 axis)
        {
            return AngleAxis(angle, ref axis);
        }
        /// <summary>
        /// Causes a rotation <paramref name="angle"/> degs around <paramref name="axis"/>
        /// </summary>
        /// <param name="angle">Angle to rotate</param>
        /// <param name="axis">Rotation axis</param>
        /// <returns>A rotated Quaternion</returns>
        public static THQuaternion AngleAxis(float angle, ref THVector3 axis)
        {
            if ((axis.magnitude * axis.magnitude) == 0) return identity;

            var result = identity;
            var rads = angle * degToRad;

            rads *= 0.5f;
            axis.Normalize();
            axis = axis * (float)Sin(rads);
            result.x = axis.x;
            result.y = axis.y;
            result.z = axis.z;
            result.w = (float)Cos(rads);

            return Normalize(result);
        }

        /// <summary>
        /// Returns this Quaternion as an Angle and Axis
        /// </summary>
        /// <param name="angle">Rotation angle</param>
        /// <param name="axis">Rotation axis</param>
        public void ToAngleAxis(out float angle, out THVector3 axis)
        {
            ToAxisAngleRad(this, out axis, out angle);
            angle *= radToDeg;
        }


        /// <summary>
        /// Creates a rotation which rotates from <paramref name="a"/> to <paramref name="b"/>
        /// </summary>
        /// <param name="a">Start rotation</param>
        /// <param name="b">End rotation</param>
        public static THQuaternion FromToRotation(THVector3 a, THVector3 b)
        {
            return RotateTowards(LookRotation(a), LookRotation(b), float.MaxValue);
        }
        /// <summary>
        /// Rotates this Quaternion from <paramref name="a"/> to <paramref name="b"/>
        /// </summary>
        /// <param name="a">Start rotation</param>
        /// <param name="b">End rotation</param>
        public void SetFromToRotation(THVector3 a, THVector3 b)
        {
            this = FromToRotation(a, b);
        }

        /// <summary>
        /// Creates a rotation with the specified <paramref name="forward"/> and <paramref name="upwards"/> directions
        /// </summary>
        /// <param name="forward">Forward direction</param>
        /// <param name="upwards">Upward direction</param>
        /// <returns>rotated Quaternion</returns>
        public static THQuaternion LookRotation(THVector3 forward, [System.ComponentModel.DefaultValue("THVector3.up")] THVector3 upwards)
        {
            return LookRotation(ref forward, ref upwards);
        }
        /// <summary>
        /// Creates a rotation with the specified <paramref name="forward"/> direction
        /// </summary>
        /// <param name="forward">Forward direction</param>
        /// <returns>Rotated Quaternion</returns>
        public static THQuaternion LookRotation(THVector3 forward)
        {
            var up = THVector3.up;
            return LookRotation(ref forward, ref up);
        }
        // from http://answers.unity3d.com/questions/467614/what-is-the-source-code-of-quaternionlookrotation.html
        /// <summary>
        /// Creates a rotation with the specified <paramref name="forward"/> and <paramref name="up"/> directions
        /// </summary>
        /// <param name="forward">Forward direction</param>
        /// <param name="up">Upward direction</param>
        /// <returns></returns>
        private static THQuaternion LookRotation(ref THVector3 forward, ref THVector3 up)
        {
            // Magic

            forward = THVector3.Normalize(forward);
            THVector3 right = THVector3.Normalize(THVector3.Cross(up, forward));
            up = THVector3.Cross(forward, right);
            var m00 = right.x;
            var m01 = right.y;
            var m02 = right.z;
            var m10 = up.x;
            var m11 = up.y;
            var m12 = up.z;
            var m20 = forward.x;
            var m21 = forward.y;
            var m22 = forward.z;


            float num8 = (m00 + m11) + m22;
            var quaternion = new THQuaternion();
            if (num8 > 0f)
            {
                var num = (float)System.Math.Sqrt(num8 + 1f);
                quaternion.w = num * 0.5f;
                num = 0.5f / num;
                quaternion.x = (m12 - m21) * num;
                quaternion.y = (m20 - m02) * num;
                quaternion.z = (m01 - m10) * num;
                return quaternion;
            }
            if ((m00 >= m11) && (m00 >= m22))
            {
                var num7 = (float)System.Math.Sqrt(((1f + m00) - m11) - m22);
                var num4 = 0.5f / num7;
                quaternion.x = 0.5f * num7;
                quaternion.y = (m01 + m10) * num4;
                quaternion.z = (m02 + m20) * num4;
                quaternion.w = (m12 - m21) * num4;
                return quaternion;
            }
            if (m11 > m22)
            {
                var num6 = (float)System.Math.Sqrt(((1f + m11) - m00) - m22);
                var num3 = 0.5f / num6;
                quaternion.x = (m10 + m01) * num3;
                quaternion.y = 0.5f * num6;
                quaternion.z = (m21 + m12) * num3;
                quaternion.w = (m20 - m02) * num3;
                return quaternion;
            }
            var num5 = (float)System.Math.Sqrt(((1f + m22) - m00) - m11);
            var num2 = 0.5f / num5;
            quaternion.x = (m20 + m02) * num2;
            quaternion.y = (m21 + m12) * num2;
            quaternion.z = 0.5f * num5;
            quaternion.w = (m01 - m10) * num2;
            return quaternion;
        }

        /// <summary>
        /// Sets the look(forward) rotation
        /// </summary>
        /// <param name="view">Look rotation</param>
        public void SetLookRotation(THVector3 view)
        {
            THVector3 up = THVector3.up;
            SetLookRotation(view, up);
        }
        /// <summary>
        /// Creates a rotation with <paramref name="view"/>(forward) and <paramref name="up"/> directions
        /// </summary>
        /// <param name="view">View direction</param>
        /// <param name="up">Up direction</param>
        public void SetLookRotation(THVector3 view, [System.ComponentModel.DefaultValue("THVector3.up")] THVector3 up)
        {
            this = LookRotation(view, up);
        }

        /// <summary>
        /// Spherically interpolates between <paramref name="a"/> and <paramref name="b"/> by <paramref name="t"/>. The parameter <paramref name="t"/> is clamped to the range [0, 1].</para>
        /// </summary>
        /// <param name="a">First Quaternion</param>
        /// <param name="b">Second Quaternion</param>
        /// <param name="t">Steps</param>
        /// <returns>Slerped Quaternion</returns>
        public static THQuaternion Slerp(THQuaternion a, THQuaternion b, float t)
        {
            return Slerp(ref a, ref b, t);
        }
        private static THQuaternion Slerp(ref THQuaternion a, ref THQuaternion b, float t)
        {
            return SlerpUnclamped(ref a, ref b, Clamp01(t));
        }

        /// <summary>
        /// Sphericaly interpolates between <paramref name="a"/> and <paramref name="b"/> by <paramref name="t"/>. <paramref name="t"/> is unclamped
        /// </summary>
        /// <param name="a">First Quaternion</param>
        /// <param name="b">First Quaternion</param>
        /// <param name="t">Interpolation steps</param>
        /// <returns>Slerped Quaternion</returns>
        public static THQuaternion SlerpUnclamped(THQuaternion a, THQuaternion b, float t)
        {
            return SlerpUnclamped(ref a, ref b, t);
        }
        private static THQuaternion SlerpUnclamped(ref THQuaternion a, ref THQuaternion b, float t)
        {
            // if either input is zero, return the other.
            if (a.lengthSquared == 0.0f)
            {
                if (b.lengthSquared == 0.0f)
                {
                    return identity;
                }
                return b;
            }
            else if (b.lengthSquared == 0.0f)
            {
                return a;
            }
            
            float cosHalfAngle = a.w * b.w + THVector3.Dot(a.xyz, b.xyz);

            if (cosHalfAngle >= 1.0f || cosHalfAngle <= -1.0f)
            {
                // angle = 0.0f, so just return one input.
                return a;
            }
            else if (cosHalfAngle < 0.0f)
            {
                b.xyz = -b.xyz;
                b.w = -b.w;
                cosHalfAngle = -cosHalfAngle;
            }

            float blendA;
            float blendB;
            if (cosHalfAngle < 0.99f)
            {
                // do proper slerp for big angles
                float halfAngle = (float)Math.Acos(cosHalfAngle);
                float sinHalfAngle = (float)Math.Sin(halfAngle);
                float oneOverSinHalfAngle = 1.0f / sinHalfAngle;
                blendA = (float)Math.Sin(halfAngle * (1.0f - t)) * oneOverSinHalfAngle;
                blendB = (float)Math.Sin(halfAngle * t) * oneOverSinHalfAngle;
            }
            else
            {
                // do lerp if angle is really small.
                blendA = 1.0f - t;
                blendB = t;
            }

            THQuaternion result = new THQuaternion(a.xyz * blendA + b.xyz * blendB, blendA * a.w + blendB * b.w);
            if (result.lengthSquared > 0.0f)
                return Normalize(result);
            else
                return identity;
        }

        /// <summary>
        /// Interpolates between <paramref name="a"/> and <paramref name="b"/> by <paramref name="t"/> then Normalizes the result. <paramref name="t"/> is clampled from 0-1
        /// </summary>
        /// <param name="a">First Quaternion</param>
        /// <param name="b">Second Quaternion</param>
        /// <param name="t">Interpolation steps</param>
        /// <returns>Lerped Quaternion</returns>
        public static THQuaternion Lerp(THQuaternion a, THQuaternion b, float t)
        {
            if (t > 1) t = 1;
            if (t < 0) t = 0;
            return Slerp(ref a, ref b, t); // TODO: use lerp not slerp, "Because quaternion works in 4D. Rotation in 4D are linear" ???
        }

        /// <summary>
        /// Interpolates between <paramref name="a"/> and <paramref name="b"/> by <paramref name="t"/> and normalizes the result afterwards. The parameter <paramref name="t"/> is not clamped
        /// </summary>
        /// <param name="a">First Quaternion</param>
        /// <param name="b">Second Quaternion</param>
        /// <param name="t">Interpolation steps</param>
        /// <remarks>Lerped Quaternion</remarks>
        public static THQuaternion LerpUnclamped(THQuaternion a, THQuaternion b, float t)
        {
            return Slerp(ref a, ref b, t);
        }

        /// <summary>
        /// Rotates from <paramref name="a"/> towards <paramref name="b"/> by a maximum angle <paramref name="maxDegreesDelta"/>
        /// </summary>
        /// <param name="a">First Quaternion</param>
        /// <param name="b">Second Quaternion</param>
        /// <param name="maxDegreesDelta">Max change in angle</param>
        public static THQuaternion RotateTowards(THQuaternion a, THQuaternion b, float maxDegreesDelta)
        {
            float num = THQuaternion.Angle(a, b);
            if (num == 0f)
            {
                return b;
            }
            float t = Math.Min(1f, maxDegreesDelta / num);
            return THQuaternion.SlerpUnclamped(a, b, t);
        }

        /// <summary>
        /// Retuens the invenrse of a <paramref name="rotation"/>
        /// </summary>
        /// <param name="rotation">Rotation</param>
        /// <returns>Inverted rotation</returns>
        public static THQuaternion Inverse(THQuaternion rotation)
        {
            float lengthSq = rotation.lengthSquared;
            if (lengthSq != 0.0)
            {
                float i = 1.0f / lengthSq;
                return new THQuaternion(rotation.xyz * -i, rotation.w * i);
            }
            return rotation;
        }

        /// <summary>
        /// Returns a nice string
        /// </summary>
        public override string ToString()
        {
            return $"X:{x} Y:{y} Z:{z} W:{w}";
        }

        /// <summary>
        /// Returns the angle in degrees between two rotations <paramref name="a"/> and <paramref name="b"/>
        /// </summary>
        /// <param name="a">First Quaternion</param>
        /// <param name="b">First Quaternion</param>
        public static float Angle(THQuaternion a, THQuaternion b)
        {
            float f = THQuaternion.Dot(a, b);
            return Acos(UnityEngine.Mathf.Min(UnityEngine.Mathf.Abs(f), 1f)) * 2f * radToDeg;
        }
        
        /// <summary>
        /// Returns a rotation that rotates z degrees around the z axis, x degrees around the x axis, and y degrees around the y axis (in that order)
        /// </summary>
        /// <param name="x">X rotation</param>
        /// <param name="y">Y rotation</param>
        /// <param name="z">Z rotation</param>
        public static THQuaternion Euler(float x, float y, float z)
        {
            return FromEulerRad(new THVector3((float)x, (float)y, (float)z) * degToRad);
        }
        /// <summary>
        /// Returns a rotation that rotates z degrees around the z axis, x degrees around the x axis, and y degrees around the y axis (in that order)
        /// </summary>
        /// <param name="euler">Rotation</param>
        public static THQuaternion Euler(THVector3 euler)
        {
            return FromEulerRad(euler * degToRad);
        }

        // from http://stackoverflow.com/questions/12088610/conversion-between-euler-quaternion-like-in-unity3d-engine
        private static THVector3 ToEulerRad(THQuaternion rotation)
        {
            float sqw = rotation.w * rotation.w;
            float sqx = rotation.x * rotation.x;
            float sqy = rotation.y * rotation.y;
            float sqz = rotation.z * rotation.z;
            float unit = sqx + sqy + sqz + sqw; // if normalised is one, otherwise is correction factor
            float test = rotation.x * rotation.w - rotation.y * rotation.z;
            THVector3 v;

            if (test > 0.4995f * unit)
            { // singularity at north pole
                v.y = 2f * Atan2(rotation.y, rotation.x);
                v.x = UnityEngine.Mathf.PI / 2;
                v.z = 0;
                return NormalizeAngles(v * Rad2Deg);
            }
            if (test < -0.4995f * unit)
            { // singularity at south pole
                v.y = -2f * Atan2(rotation.y, rotation.x);
                v.x = -UnityEngine.Mathf.PI / 2;
                v.z = 0;
                return NormalizeAngles(v * Rad2Deg);
            }
            THQuaternion q = new THQuaternion(rotation.w, rotation.z, rotation.x, rotation.y);
            v.y = (float)System.Math.Atan2(2f * q.x * q.w + 2f * q.y * q.z, 1 - 2f * (q.z * q.z + q.w * q.w));     // Yaw
            v.x = (float)System.Math.Asin(2f * (q.x * q.z - q.w * q.y));                             // Pitch
            v.z = (float)System.Math.Atan2(2f * q.x * q.y + 2f * q.z * q.w, 1 - 2f * (q.y * q.y + q.z * q.z));      // Roll
            return NormalizeAngles(v * Rad2Deg);
        }

        private static THVector3 NormalizeAngles(THVector3 angles)
        {
            angles.x = NormalizeAngle(angles.x);
            angles.y = NormalizeAngle(angles.y);
            angles.z = NormalizeAngle(angles.z);
            return angles;
        }
        private static float NormalizeAngle(float angle)
        {
            while (angle > 360)
                angle -= 360;
            while (angle < 0)
                angle += 360;
            return angle;
        }
        
        // from http://stackoverflow.com/questions/11492299/quaternion-to-euler-angles-algorithm-how-to-convert-to-y-up-and-between-ha
        private static THQuaternion FromEulerRad(THVector3 euler)
        {
            var yaw = euler.x;
            var pitch = euler.y;
            var roll = euler.z;
            float rollOver2 = roll * 0.5f;
            float sinRollOver2 = (float)System.Math.Sin((float)rollOver2);
            float cosRollOver2 = (float)System.Math.Cos((float)rollOver2);
            float pitchOver2 = pitch * 0.5f;
            float sinPitchOver2 = (float)System.Math.Sin((float)pitchOver2);
            float cosPitchOver2 = (float)System.Math.Cos((float)pitchOver2);
            float yawOver2 = yaw * 0.5f;
            float sinYawOver2 = (float)System.Math.Sin((float)yawOver2);
            float cosYawOver2 = (float)System.Math.Cos((float)yawOver2);
            THQuaternion result;
            result.x = cosYawOver2 * cosPitchOver2 * cosRollOver2 + sinYawOver2 * sinPitchOver2 * sinRollOver2;
            result.y = cosYawOver2 * cosPitchOver2 * sinRollOver2 - sinYawOver2 * sinPitchOver2 * cosRollOver2;
            result.z = cosYawOver2 * sinPitchOver2 * cosRollOver2 + sinYawOver2 * cosPitchOver2 * sinRollOver2;
            result.w = sinYawOver2 * cosPitchOver2 * cosRollOver2 - cosYawOver2 * sinPitchOver2 * sinRollOver2;
            return result;

        }

        private static void ToAxisAngleRad(THQuaternion q, out THVector3 axis, out float angle)
        {
            if (Math.Abs(q.w) > 1.0f)
                q.Normalize();
            angle = 2.0f * (float)Math.Acos(q.w); // angle
            float den = (float)Sqrt(1.0 - q.w * q.w);
            if (den > 0.0001f)
            {
                axis = q.xyz / den;
            }
            else
            {
                // This occurs when the angle is zero. 
                // Not a problem: just set an arbitrary normalized axis.
                axis = new THVector3(1, 0, 0);
            }
        }
        
        public override int GetHashCode()
        {
            return this.x.GetHashCode() ^ this.y.GetHashCode() << 2 ^ this.z.GetHashCode() >> 2 ^ this.w.GetHashCode() >> 1;
        }

        public override bool Equals(object other)
        {
            if (!(other is THQuaternion))
            {
                return false;
            }
            THQuaternion quaternion = (THQuaternion)other;
            return this.x.Equals(quaternion.x) && this.y.Equals(quaternion.y) && this.z.Equals(quaternion.z) && this.w.Equals(quaternion.w);
        }
        public bool Equals(THQuaternion other)
        {
            return this.x.Equals(other.x) && this.y.Equals(other.y) && this.z.Equals(other.z) && this.w.Equals(other.w);
        }
        public static THQuaternion operator *(THQuaternion lhs, THQuaternion rhs)
        {
            return new THQuaternion(lhs.w * rhs.x + lhs.x * rhs.w + lhs.y * rhs.z - lhs.z * rhs.y, lhs.w * rhs.y + lhs.y * rhs.w + lhs.z * rhs.x - lhs.x * rhs.z, lhs.w * rhs.z + lhs.z * rhs.w + lhs.x * rhs.y - lhs.y * rhs.x, lhs.w * rhs.w - lhs.x * rhs.x - lhs.y * rhs.y - lhs.z * rhs.z);
        }
        public static THVector3 operator *(THQuaternion rotation, THVector3 point)
        {
            float num = rotation.x * 2f;
            float num2 = rotation.y * 2f;
            float num3 = rotation.z * 2f;
            float num4 = rotation.x * num;
            float num5 = rotation.y * num2;
            float num6 = rotation.z * num3;
            float num7 = rotation.x * num2;
            float num8 = rotation.x * num3;
            float num9 = rotation.y * num3;
            float num10 = rotation.w * num;
            float num11 = rotation.w * num2;
            float num12 = rotation.w * num3;
            THVector3 result;
            result.x = (1f - (num5 + num6)) * point.x + (num7 - num12) * point.y + (num8 + num11) * point.z;
            result.y = (num7 + num12) * point.x + (1f - (num4 + num6)) * point.y + (num9 - num10) * point.z;
            result.z = (num8 - num11) * point.x + (num9 + num10) * point.y + (1f - (num4 + num5)) * point.z;
            return result;
        }
        public static bool operator ==(THQuaternion lhs, THQuaternion rhs)
        {
            return Dot(lhs, rhs) > 0.999999f;
        }
        public static bool operator !=(THQuaternion lhs, THQuaternion rhs)
        {
            return Dot(lhs, rhs) <= 0.999999f;
        }
        #region Implicit conversions to and from Unity's Quaternion
        public static implicit operator UnityEngine.Quaternion(THQuaternion me)
        {
            return new UnityEngine.Quaternion((float)me.x, (float)me.y, (float)me.z, (float)me.w);
        }
        public static implicit operator THQuaternion(UnityEngine.Quaternion other)
        {
            return new THQuaternion((float)other.x, (float)other.y, (float)other.z, (float)other.w);
        }
        #endregion
    }
}