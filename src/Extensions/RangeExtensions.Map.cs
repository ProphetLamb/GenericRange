using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace GenericRange.Extensions
{
    public static partial class RangeExtensions
    {
        /// <summary>
        /// Interpolates the value from the <paramref name="source"/> <see cref="Range{T}"/> to the <see cref="target"/> range.
        /// </summary>
        /// <param name="source">The range within the <paramref name="value"/> exists.</param>
        /// <param name="target">The range to map the <paramref name="value"/> to.</param>
        /// <param name="length">The length of the set.</param>
        /// <param name="value">The value.</param>
        /// <returns>The <paramref name="value"/> mapped to the <paramref name="target"/> range.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Map(this Range<decimal> source, Range<decimal> target, decimal length, decimal value)
        {
            decimal percentage = source.PercentageOf(length, value);
            return target.Interpolate(length, percentage);
        }
        
        /// <summary>
        /// Interpolates the value from the <paramref name="source"/> <see cref="Range{T}"/> to the <see cref="target"/> range.
        /// </summary>
        /// <param name="source">The range within the <paramref name="value"/> exists.</param>
        /// <param name="target">The range to map the <paramref name="value"/> to.</param>
        /// <param name="value">The value.</param>
        /// <returns>The <paramref name="value"/> mapped to the <paramref name="target"/> range.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Map(this Range<decimal> source, Range<decimal> target, decimal value)
        {
            decimal percentage = source.PercentageOf(value);
            return target.Interpolate(percentage);
        }
        
        /// <summary>
        /// Interpolates the value from the <paramref name="source"/> <see cref="Range{T}"/> to the <see cref="target"/> range.
        /// </summary>
        /// <param name="source">The range within the <paramref name="value"/> exists.</param>
        /// <param name="target">The range to map the <paramref name="value"/> to.</param>
        /// <param name="length">The length of the set.</param>
        /// <param name="value">The value.</param>
        /// <returns>The <paramref name="value"/> mapped to the <paramref name="target"/> range.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Map(this Range<double> source, Range<double> target, double length, double value)
        {
            double percentage = source.PercentageOf(length, value);
            return target.Interpolate(length, percentage);
        }
        
        /// <summary>
        /// Interpolates the value from the <paramref name="source"/> <see cref="Range{T}"/> to the <see cref="target"/> range.
        /// </summary>
        /// <param name="source">The range within the <paramref name="value"/> exists.</param>
        /// <param name="target">The range to map the <paramref name="value"/> to.</param>
        /// <param name="value">The value.</param>
        /// <returns>The <paramref name="value"/> mapped to the <paramref name="target"/> range.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Map(this Range<double> source, Range<double> target, double value)
        {
            double percentage = source.PercentageOf(value);
            return target.Interpolate(percentage);
        }
        
        /// <summary>
        /// Interpolates the value from the <paramref name="source"/> <see cref="Range{T}"/> to the <see cref="target"/> range.
        /// </summary>
        /// <param name="source">The range within the <paramref name="value"/> exists.</param>
        /// <param name="target">The range to map the <paramref name="value"/> to.</param>
        /// <param name="length">The length of the set.</param>
        /// <param name="value">The value.</param>
        /// <returns>The <paramref name="value"/> mapped to the <paramref name="target"/> range.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Map(this Range<float> source, Range<float> target, float length, float value)
        {
            float percentage = source.PercentageOf(length, value);
            return target.Interpolate(length, percentage);
        }
        
        /// <summary>
        /// Interpolates the value from the <paramref name="source"/> <see cref="Range{T}"/> to the <see cref="target"/> range.
        /// </summary>
        /// <param name="source">The range within the <paramref name="value"/> exists.</param>
        /// <param name="target">The range to map the <paramref name="value"/> to.</param>
        /// <param name="value">The value.</param>
        /// <returns>The <paramref name="value"/> mapped to the <paramref name="target"/> range.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Map(this Range<float> source, Range<float> target, float value)
        {
            float percentage = source.PercentageOf(value);
            return target.Interpolate(percentage);
        }
        
        /// <summary>
        /// Interpolates the value from the <paramref name="source"/> <see cref="Range{T}"/> to the <see cref="target"/> range.
        /// </summary>
        /// <param name="source">The range within the <paramref name="value"/> exists.</param>
        /// <param name="target">The range to map the <paramref name="value"/> to.</param>
        /// <param name="length">The length of the set.</param>
        /// <param name="value">The value.</param>
        /// <returns>The <paramref name="value"/> mapped to the <paramref name="target"/> range.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Map(this Range<int> source, Range<int> target, int length, int value)
        {
            double percentage = source.PercentageOf(length, value);
            return (int)target.Interpolate(length, percentage);
        }
        
        /// <summary>
        /// Interpolates the value from the <paramref name="source"/> <see cref="Range{T}"/> to the <see cref="target"/> range.
        /// </summary>
        /// <param name="source">The range within the <paramref name="value"/> exists.</param>
        /// <param name="target">The range to map the <paramref name="value"/> to.</param>
        /// <param name="value">The value.</param>
        /// <returns>The <paramref name="value"/> mapped to the <paramref name="target"/> range.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Map(this Range<int> source, Range<int> target, int value)
        {
            double percentage = source.PercentageOf(value);
            return (int)target.Interpolate(percentage);
        }
        
        /// <summary>
        /// Interpolates the value from the <paramref name="source"/> <see cref="Range{T}"/> to the <see cref="target"/> range.
        /// </summary>
        /// <param name="source">The range within the <paramref name="value"/> exists.</param>
        /// <param name="target">The range to map the <paramref name="value"/> to.</param>
        /// <param name="length">The length of the set.</param>
        /// <param name="value">The value.</param>
        /// <param name="rounding">Rounding mode.</param>
        /// <returns>The <paramref name="value"/> mapped to the <paramref name="target"/> range.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Map(this Range<int> source, Range<int> target, int length, int value, MidpointRounding rounding)
        {
            double percentage = source.PercentageOf(length, value);
            return (int)Math.Round(target.Interpolate(length, percentage), rounding);
        }

        /// <summary>
        /// Interpolates the value from the <paramref name="source"/> <see cref="Range{T}"/> to the <see cref="target"/> range.
        /// </summary>
        /// <param name="source">The range within the <paramref name="value"/> exists.</param>
        /// <param name="target">The range to map the <paramref name="value"/> to.</param>
        /// <param name="value">The value.</param>
        /// <param name="rounding">Rounding mode.</param>
        /// <returns>The <paramref name="value"/> mapped to the <paramref name="target"/> range.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Map(this Range<int> source, Range<int> target, int value, MidpointRounding rounding)
        {
            double percentage = source.PercentageOf(value);
            return (int)Math.Round(target.Interpolate(percentage), rounding);
        }
    }
}
