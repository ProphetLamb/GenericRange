using System;

namespace GenericRange.Extensions
{
    public static partial class RangeExtensions
    {
        /// <summary>
        /// Interpolates the <paramref name="range"/> linearly by a <paramref name="percentage"/>.
        /// </summary>
        /// <param name="range">The range.</param>
        /// <param name="length">The length of the collection.</param>
        /// <param name="percentage">The percentage to interpolate with, 0.00 returns <see cref="Range.Start"/>, and 1.00 returns <see cref="Range.End"/>.</param>
        /// <returns>The interpolated value.</returns>
        public static double Interpolate(this Range<double> range, double length, double percentage)
        {
            (double offset, double len) = range.GetOffsetAndLength(length);
            return offset + len * percentage;
        }
        
        /// <summary>
        /// Interpolates the <paramref name="range"/> linearly by a <paramref name="percentage"/>.
        /// </summary>
        /// <param name="range">The range.</param>
        /// <param name="percentage">The percentage to interpolate with, 0.00 returns <see cref="Range.Start"/>, and 1.00 returns <see cref="Range.End"/>.</param>
        /// <returns>The interpolated value.</returns>
        public static double Interpolate(this Range<double> range, double percentage)
        {
            (double offset, double len) = range.GetOffsetAndLength();
            return offset + len * percentage;
        }
        
        /// <summary>
        /// Interpolates the <paramref name="range"/> linearly by a <paramref name="percentage"/>.
        /// </summary>
        /// <param name="range">The range.</param>
        /// <param name="length">The length of the collection.</param>
        /// <param name="percentage">The percentage to interpolate with, 0.00 returns <see cref="Range.Start"/>, and 1.00 returns <see cref="Range.End"/>.</param>
        /// <returns>The interpolated value.</returns>
        public static float Interpolate(this Range<float> range, float length, float percentage)
        {
            (float offset, float len) = range.GetOffsetAndLength(length);
            return offset + len * percentage;
        }
        
        /// <summary>
        /// Interpolates the <paramref name="range"/> linearly by a <paramref name="percentage"/>.
        /// </summary>
        /// <param name="range">The range.</param>
        /// <param name="percentage">The percentage to interpolate with, 0.00 returns <see cref="Range.Start"/>, and 1.00 returns <see cref="Range.End"/>.</param>
        /// <returns>The interpolated value.</returns>
        public static float Interpolate(this Range<float> range, float percentage)
        {
            (float offset, float len) = range.GetOffsetAndLength();
            return offset + len * percentage;
        }
        
        /// <summary>
        /// Interpolates the <paramref name="range"/> linearly by a <paramref name="percentage"/>.
        /// </summary>
        /// <param name="range">The range.</param>
        /// <param name="length">The length of the collection.</param>
        /// <param name="percentage">The percentage to interpolate with, 0.00 returns <see cref="Range.Start"/>, and 1.00 returns <see cref="Range.End"/>.</param>
        /// <returns>The interpolated value.</returns>
        public static double Interpolate(this Range<int> range, int length, double percentage)
        {
            (int offset, int len) = range.GetOffsetAndLength(length);
            return offset + len * percentage;
        }
        
        /// <summary>
        /// Interpolates the <paramref name="range"/> linearly by a <paramref name="percentage"/>.
        /// </summary>
        /// <param name="range">The range.</param>
        /// <param name="percentage">The percentage to interpolate with, 0.00 returns <see cref="Range.Start"/>, and 1.00 returns <see cref="Range.End"/>.</param>
        /// <returns>The interpolated value.</returns>
        public static double Interpolate(this Range<int> range, double percentage)
        {
            (int offset, int len) = range.GetOffsetAndLength();
            return offset + len * percentage;
        }
    }
}
