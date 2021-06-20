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
        /// <param name="sourceLength">The length of the source set.</param>
        /// <param name="target">The range to map the <paramref name="value"/> to.</param>
        /// <param name="targetLength">The length of the target set.</param>
        /// <param name="value">The value.</param>
        /// <returns>The <paramref name="value"/> mapped to the <paramref name="target"/> range.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Map(this Range<decimal> source, decimal sourceLength, Range<decimal> target, decimal targetLength, Index<decimal> value)
        {
            return target.Interpolate(targetLength, source.PercentageOf(sourceLength, value));
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
        public static decimal Map(this Range<decimal> source, Range<decimal> target, Index<decimal> value)
        {
            return target.Interpolate(source.PercentageOf(value));
        }
        
        /// <summary>
        /// Interpolates the value from the <paramref name="source"/> <see cref="Range{T}"/> to the <see cref="target"/> range.
        /// </summary>
        /// <param name="source">The range within the <paramref name="value"/> exists.</param>
        /// <param name="sourceLength">The length of the source set.</param>
        /// <param name="target">The range to map the <paramref name="value"/> to.</param>
        /// <param name="targetLength">The length of the target set.</param>
        /// <param name="value">The value.</param>
        /// <returns>The <paramref name="value"/> mapped to the <paramref name="target"/> range.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Map(this Range<double> source, double sourceLength, Range<double> target, double targetLength, Index<double> value)
        {
            return target.Interpolate(targetLength, source.PercentageOf(sourceLength, value));
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
        public static double Map(this Range<double> source, Range<double> target, Index<double> value)
        {
            return target.Interpolate(source.PercentageOf(value));
        }
        
        /// <summary>
        /// Interpolates the value from the <paramref name="source"/> <see cref="Range{T}"/> to the <see cref="target"/> range.
        /// </summary>
        /// <param name="source">The range within the <paramref name="value"/> exists.</param>
        /// <param name="sourceLength">The length of the source set.</param>
        /// <param name="target">The range to map the <paramref name="value"/> to.</param>
        /// <param name="targetLength">The length of the target set.</param>
        /// <param name="value">The value.</param>
        /// <returns>The <paramref name="value"/> mapped to the <paramref name="target"/> range.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Map(this Range<float> source, float sourceLength, Range<float> target, float targetLength, Index<float> value)
        {
            return target.Interpolate(targetLength, source.PercentageOf(sourceLength, value));
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
        public static float Map(this Range<float> source, Range<float> target, Index<float> value)
        {
            return target.Interpolate(source.PercentageOf(value));
        }
        
        /// <summary>
        /// Interpolates the value from the <paramref name="source"/> <see cref="Range{T}"/> to the <see cref="target"/> range.
        /// </summary>
        /// <param name="source">The range within the <paramref name="value"/> exists.</param>
        /// <param name="sourceLength">The length of the source set.</param>
        /// <param name="target">The range to map the <paramref name="value"/> to.</param>
        /// <param name="targetLength">The length of the target set.</param>
        /// <param name="value">The value.</param>
        /// <returns>The <paramref name="value"/> mapped to the <paramref name="target"/> range.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Map(this Range<long> source, long sourceLength, Range<long> target, long targetLength, Index<long> value)
        {
            return (long)target.Interpolate(targetLength, source.PercentageOf(sourceLength, value));
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
        public static long Map(this Range<long> source, Range<long> target, Index<long> value)
        {
            return (long)target.Interpolate(source.PercentageOf(value));
        }
        
        /// <summary>
        /// Interpolates the value from the <paramref name="source"/> <see cref="Range{T}"/> to the <see cref="target"/> range.
        /// </summary>
        /// <param name="source">The range within the <paramref name="value"/> exists.</param>
        /// <param name="sourceLength">The length of the source set.</param>
        /// <param name="target">The range to map the <paramref name="value"/> to.</param>
        /// <param name="targetLength">The length of the target set.</param>
        /// <param name="value">The value.</param>
        /// <param name="rounding">Rounding mode.</param>
        /// <returns>The <paramref name="value"/> mapped to the <paramref name="target"/> range.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Map(this Range<long> source, long sourceLength, Range<long> target, long targetLength, Index<long> value, MidpointRounding rounding)
        {
            return (long)Math.Round(target.Interpolate(targetLength, source.PercentageOf(sourceLength, value)), rounding);
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
        public static long Map(this Range<long> source, Range<long> target, Index<long> value, MidpointRounding rounding)
        {
            return (long)Math.Round(target.Interpolate(source.PercentageOf(value)), rounding);
        }
        
        /// <summary>
        /// Interpolates the value from the <paramref name="source"/> <see cref="Range{T}"/> to the <see cref="target"/> range.
        /// </summary>
        /// <param name="source">The range within the <paramref name="value"/> exists.</param>
        /// <param name="sourceLength">The length of the source set.</param>
        /// <param name="target">The range to map the <paramref name="value"/> to.</param>
        /// <param name="targetLength">The length of the target set.</param>
        /// <param name="value">The value.</param>
        /// <returns>The <paramref name="value"/> mapped to the <paramref name="target"/> range.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Map(this Range<int> source, int sourceLength, Range<int> target, int targetLength, Index<int> value)
        {
            return (int)target.Interpolate(targetLength, source.PercentageOf(sourceLength, value));
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
        public static int Map(this Range<int> source, Range<int> target, Index<int> value)
        {
            return (int)target.Interpolate(source.PercentageOf(value));
        }
        
        /// <summary>
        /// Interpolates the value from the <paramref name="source"/> <see cref="Range{T}"/> to the <see cref="target"/> range.
        /// </summary>
        /// <param name="source">The range within the <paramref name="value"/> exists.</param>
        /// <param name="sourceLength">The length of the source set.</param>
        /// <param name="target">The range to map the <paramref name="value"/> to.</param>
        /// <param name="targetLength">The length of the target set.</param>
        /// <param name="value">The value.</param>
        /// <param name="rounding">Rounding mode.</param>
        /// <returns>The <paramref name="value"/> mapped to the <paramref name="target"/> range.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Map(this Range<int> source, int sourceLength, Range<int> target, int targetLength, Index<int> value, MidpointRounding rounding)
        {
            return (int)Math.Round(target.Interpolate(targetLength, source.PercentageOf(sourceLength, value)), rounding);
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
        public static int Map(this Range<int> source, Range<int> target, Index<int> value, MidpointRounding rounding)
        {
            return (int)Math.Round(target.Interpolate(source.PercentageOf(value)), rounding);
        }
    }
}
