using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

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
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Interpolate(this Range<decimal> range, decimal length, decimal percentage)
        {
            return range.Start.GetOffset(length) * (1 - percentage) + range.End.GetOffset(length) * percentage;
        }
        
        /// <summary>
        /// Interpolates the <paramref name="range"/> linearly by a <paramref name="percentage"/>.
        /// </summary>
        /// <param name="range">The range.</param>
        /// <param name="percentage">The percentage to interpolate with, 0.00 returns <see cref="Range.Start"/>, and 1.00 returns <see cref="Range.End"/>.</param>
        /// <returns>The interpolated value.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Interpolate(this Range<decimal> range, decimal percentage)
        {
            Debug.Assert(!range.Start.IsFromEnd && !range.End.IsFromEnd, "!range.Start.IsFromEnd && !range.End.IsFromEnd");
            return range.Start.Value * (1 - percentage) + range.End.Value * percentage;
        }
        
        
        /// <summary>
        /// Interpolates the <paramref name="range"/> linearly by a <paramref name="percentage"/>.
        /// </summary>
        /// <param name="range">The range.</param>
        /// <param name="length">The length of the collection.</param>
        /// <param name="percentage">The percentage to interpolate with, 0.00 returns <see cref="Range.Start"/>, and 1.00 returns <see cref="Range.End"/>.</param>
        /// <returns>The interpolated value.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Interpolate(this Range<double> range, double length, double percentage)
        {
            return range.Start.GetOffset(length) * (1 - percentage) + range.End.GetOffset(length) * percentage;
        }
        
        /// <summary>
        /// Interpolates the <paramref name="range"/> linearly by a <paramref name="percentage"/>.
        /// </summary>
        /// <param name="range">The range.</param>
        /// <param name="percentage">The percentage to interpolate with, 0.00 returns <see cref="Range.Start"/>, and 1.00 returns <see cref="Range.End"/>.</param>
        /// <returns>The interpolated value.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Interpolate(this Range<double> range, double percentage)
        {
            Debug.Assert(!range.Start.IsFromEnd && !range.End.IsFromEnd, "!range.Start.IsFromEnd && !range.End.IsFromEnd");
            return range.Start.Value * (1 - percentage) + range.End.Value * percentage;
        }
        
        /// <summary>
        /// Interpolates the <paramref name="range"/> linearly by a <paramref name="percentage"/>.
        /// </summary>
        /// <param name="range">The range.</param>
        /// <param name="length">The length of the collection.</param>
        /// <param name="percentage">The percentage to interpolate with, 0.00 returns <see cref="Range.Start"/>, and 1.00 returns <see cref="Range.End"/>.</param>
        /// <returns>The interpolated value.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Interpolate(this Range<float> range, float length, float percentage)
        {
            return range.Start.GetOffset(length) * (1 - percentage) + range.End.GetOffset(length) * percentage;
        }
        
        /// <summary>
        /// Interpolates the <paramref name="range"/> linearly by a <paramref name="percentage"/>.
        /// </summary>
        /// <param name="range">The range.</param>
        /// <param name="percentage">The percentage to interpolate with, 0.00 returns <see cref="Range.Start"/>, and 1.00 returns <see cref="Range.End"/>.</param>
        /// <returns>The interpolated value.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Interpolate(this Range<float> range, float percentage)
        {
            Debug.Assert(!range.Start.IsFromEnd && !range.End.IsFromEnd, "!range.Start.IsFromEnd && !range.End.IsFromEnd");
            return range.Start.Value * (1 - percentage) + range.End.Value * percentage;
        }
        
        /// <summary>
        /// Interpolates the <paramref name="range"/> linearly by a <paramref name="percentage"/>.
        /// </summary>
        /// <param name="range">The range.</param>
        /// <param name="length">The length of the collection.</param>
        /// <param name="percentage">The percentage to interpolate with, 0.00 returns <see cref="Range.Start"/>, and 1.00 returns <see cref="Range.End"/>.</param>
        /// <returns>The interpolated value.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Interpolate(this Range<int> range, int length, double percentage)
        {
            return range.Start.GetOffset(length) * (1 - percentage) + range.End.GetOffset(length) * percentage;
        }
        
        /// <summary>
        /// Interpolates the <paramref name="range"/> linearly by a <paramref name="percentage"/>.
        /// </summary>
        /// <param name="range">The range.</param>
        /// <param name="percentage">The percentage to interpolate with, 0.00 returns <see cref="Range.Start"/>, and 1.00 returns <see cref="Range.End"/>.</param>
        /// <returns>The interpolated value.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Interpolate(this Range<int> range, double percentage)
        {
            Debug.Assert(!range.Start.IsFromEnd && !range.End.IsFromEnd, "!range.Start.IsFromEnd && !range.End.IsFromEnd");
            return range.Start.Value * (1 - percentage) + range.End.Value * percentage;
        }
        
        /// <summary>
        /// Interpolates the <paramref name="range"/> linearly by a <paramref name="percentage"/>.
        /// </summary>
        /// <param name="range">The range.</param>
        /// <param name="length">The length of the collection.</param>
        /// <param name="percentage">The percentage to interpolate with, 0.00 returns <see cref="Range.Start"/>, and 1.00 returns <see cref="Range.End"/>.</param>
        /// <returns>The interpolated value.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Interpolate(this Range<long> range, long length, double percentage)
        {
            return range.Start.GetOffset(length) * (1 - percentage) + range.End.GetOffset(length) * percentage;
        }
        
        /// <summary>
        /// Interpolates the <paramref name="range"/> linearly by a <paramref name="percentage"/>.
        /// </summary>
        /// <param name="range">The range.</param>
        /// <param name="percentage">The percentage to interpolate with, 0.00 returns <see cref="Range.Start"/>, and 1.00 returns <see cref="Range.End"/>.</param>
        /// <returns>The interpolated value.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Interpolate(this Range<long> range, double percentage)
        {
            Debug.Assert(!range.Start.IsFromEnd && !range.End.IsFromEnd, "!range.Start.IsFromEnd && !range.End.IsFromEnd");
            return range.Start.Value * (1 - percentage) + range.End.Value * percentage;
        }
    }
}
