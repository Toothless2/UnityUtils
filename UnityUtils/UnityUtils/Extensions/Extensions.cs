using System;

namespace ToothlessUtils.Extensions
{
    public static class Extensions
    {
        /// <summary>
        /// A clamp function
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="val"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static T Clamp<T>(this T val, T min, T max) where T : IComparable
        {
            if (val.CompareTo(min) < 0) return min;
            else if (val.CompareTo(max) > 1) return max;
            return val;
        }
    }
}
