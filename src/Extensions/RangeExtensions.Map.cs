using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace GenericRange.Extensions
{
    public static partial class RangeExtensions
    {
        /// <summary>
        /// Interpolates the value from the <paramref name="source"/> <see cref="Range{T}"/> to the <paramref name="target"/> range.
        /// </summary>
        /// <param name="source">The range within the <paramref name="value"/> exists.</param>
        /// <param name="sourceLength">The length of the source set.</param>
        /// <param name="target">The range to map the <paramref name="value"/> to.</param>
        /// <param name="targetLength">The length of the target set.</param>
        /// <param name="value">The value.</param>
        /// <returns>The <paramref name="value"/> mapped to the <paramref name="target"/> range.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Map(this Range<decimal> source, decimal sourceLength, in Range<decimal> target, decimal targetLength, in Index<decimal> value)
        {
            return target.Interpolate(targetLength, source.PercentageOf(value, sourceLength));
        }
        
        /// <summary>
        /// Interpolates the value from the <paramref name="source"/> <see cref="Range{T}"/> to the <paramref name="target"/> range.
        /// </summary>
        /// <param name="source">The range within the <paramref name="value"/> exists.</param>
        /// <param name="target">The range to map the <paramref name="value"/> to.</param>
        /// <param name="value">The value.</param>
        /// <returns>The <paramref name="value"/> mapped to the <paramref name="target"/> range.</returns>
        /// <remarks>Disallows <see cref="Index{T}.IsFromEnd"/> in favour of performance.</remarks>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal Map(this Range<decimal> source, in Range<decimal> target, in Index<decimal> value)
        {
            return target.Interpolate(source.PercentageOf(value));
        }
        
        /// <summary>
        /// Interpolates the value from the <paramref name="source"/> <see cref="Range{T}"/> to the <paramref name="target"/> range.
        /// </summary>
        /// <param name="source">The range within the <paramref name="value"/> exists.</param>
        /// <param name="sourceLength">The length of the source set.</param>
        /// <param name="target">The range to map the <paramref name="value"/> to.</param>
        /// <param name="targetLength">The length of the target set.</param>
        /// <param name="value">The value.</param>
        /// <returns>The <paramref name="value"/> mapped to the <paramref name="target"/> range.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Map(this Range<double> source, double sourceLength, in Range<double> target, double targetLength, in Index<double> value)
        {
            return target.Interpolate(targetLength, source.PercentageOf(value, sourceLength));
        }
        
        /// <summary>
        /// Interpolates the value from the <paramref name="source"/> <see cref="Range{T}"/> to the <paramref name="target"/> range.
        /// </summary>
        /// <param name="source">The range within the <paramref name="value"/> exists.</param>
        /// <param name="target">The range to map the <paramref name="value"/> to.</param>
        /// <param name="value">The value.</param>
        /// <returns>The <paramref name="value"/> mapped to the <paramref name="target"/> range.</returns>
        /// <remarks>Disallows <see cref="Index{T}.IsFromEnd"/> in favour of performance.</remarks>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Map(this Range<double> source, in Range<double> target, in Index<double> value)
        {
            return target.Interpolate(source.PercentageOf(value));
        }
        
        /// <summary>
        /// Interpolates the value from the <paramref name="source"/> <see cref="Range{T}"/> to the <paramref name="target"/> range.
        /// </summary>
        /// <param name="source">The range within the <paramref name="value"/> exists.</param>
        /// <param name="sourceLength">The length of the source set.</param>
        /// <param name="target">The range to map the <paramref name="value"/> to.</param>
        /// <param name="targetLength">The length of the target set.</param>
        /// <param name="value">The value.</param>
        /// <returns>The <paramref name="value"/> mapped to the <paramref name="target"/> range.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Map(this Range<float> source, float sourceLength, in Range<float> target, float targetLength, in Index<float> value)
        {
            return target.Interpolate(source.PercentageOf(value, sourceLength), targetLength);
        }
        
        /// <summary>
        /// Interpolates the value from the <paramref name="source"/> <see cref="Range{T}"/> to the <paramref name="target"/> range.
        /// </summary>
        /// <param name="source">The range within the <paramref name="value"/> exists.</param>
        /// <param name="target">The range to map the <paramref name="value"/> to.</param>
        /// <param name="value">The value.</param>
        /// <returns>The <paramref name="value"/> mapped to the <paramref name="target"/> range.</returns>
        /// <remarks>Disallows <see cref="Index{T}.IsFromEnd"/> in favour of performance.</remarks>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Map(this Range<float> source, in Range<float> target, in Index<float> value)
        {
            return target.Interpolate(source.PercentageOf(value));
        }
        
        /// <summary>
        /// Interpolates the value from the <paramref name="source"/> <see cref="Range{T}"/> to the <paramref name="target"/> range.
        /// </summary>
        /// <param name="source">The range within the <paramref name="value"/> exists.</param>
        /// <param name="sourceLength">The length of the source set.</param>
        /// <param name="target">The range to map the <paramref name="value"/> to.</param>
        /// <param name="targetLength">The length of the target set.</param>
        /// <param name="value">The value.</param>
        /// <returns>The <paramref name="value"/> mapped to the <paramref name="target"/> range.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Map(this Range<long> source, long sourceLength, in Range<long> target, long targetLength, in Index<long> value)
        {
            return (long)target.Interpolate(source.PercentageOf(value, sourceLength), targetLength);
        }
        
        /// <summary>
        /// Interpolates the value from the <paramref name="source"/> <see cref="Range{T}"/> to the <paramref name="target"/> range.
        /// </summary>
        /// <param name="source">The range within the <paramref name="value"/> exists.</param>
        /// <param name="target">The range to map the <paramref name="value"/> to.</param>
        /// <param name="value">The value.</param>
        /// <returns>The <paramref name="value"/> mapped to the <paramref name="target"/> range.</returns>
        /// <remarks>Disallows <see cref="Index{T}.IsFromEnd"/> in favour of performance.</remarks>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Map(this Range<long> source, in Range<long> target, in Index<long> value)
        {
            return (long)target.Interpolate(source.PercentageOf(value));
        }
        
        /// <summary>
        /// Interpolates the value from the <paramref name="source"/> <see cref="Range{T}"/> to the <paramref name="target"/> range.
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
        public static long Map(this Range<long> source, long sourceLength, in Range<long> target, long targetLength, in Index<long> value, MidpointRounding rounding)
        {
            return (long)Math.Round(target.Interpolate(source.PercentageOf(value, sourceLength), targetLength), rounding);
        }

        /// <summary>
        /// Interpolates the value from the <paramref name="source"/> <see cref="Range{T}"/> to the <paramref name="target"/> range.
        /// </summary>
        /// <param name="source">The range within the <paramref name="value"/> exists.</param>
        /// <param name="target">The range to map the <paramref name="value"/> to.</param>
        /// <param name="value">The value.</param>
        /// <param name="rounding">Rounding mode.</param>
        /// <returns>The <paramref name="value"/> mapped to the <paramref name="target"/> range.</returns>
        /// <remarks>Disallows <see cref="Index{T}.IsFromEnd"/> in favour of performance.</remarks>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Map(this Range<long> source, in Range<long> target, in Index<long> value, MidpointRounding rounding)
        {
            return (long)Math.Round(target.Interpolate(source.PercentageOf(value)), rounding);
        }
        
        /// <summary>
        /// Interpolates the value from the <paramref name="source"/> <see cref="Range{T}"/> to the <paramref name="target"/> range.
        /// </summary>
        /// <param name="source">The range within the <paramref name="value"/> exists.</param>
        /// <param name="sourceLength">The length of the source set.</param>
        /// <param name="target">The range to map the <paramref name="value"/> to.</param>
        /// <param name="targetLength">The length of the target set.</param>
        /// <param name="value">The value.</param>
        /// <returns>The <paramref name="value"/> mapped to the <paramref name="target"/> range.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Map(this Range<int> source, int sourceLength, in Range<int> target, int targetLength, in Index<int> value)
        {
            return (int)target.Interpolate(source.PercentageOf(value, sourceLength), targetLength);
        }
        
        /// <summary>
        /// Interpolates the value from the <paramref name="source"/> <see cref="Range{T}"/> to the <paramref name="target"/> range.
        /// </summary>
        /// <param name="source">The range within the <paramref name="value"/> exists.</param>
        /// <param name="target">The range to map the <paramref name="value"/> to.</param>
        /// <param name="value">The value.</param>
        /// <returns>The <paramref name="value"/> mapped to the <paramref name="target"/> range.</returns>
        /// <remarks>Disallows <see cref="Index{T}.IsFromEnd"/> in favour of performance.</remarks>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Map(this Range<int> source, in Range<int> target, in Index<int> value)
        {
            return (int)target.Interpolate(source.PercentageOf(value));
        }
        
        /// <summary>
        /// Interpolates the value from the <paramref name="source"/> <see cref="Range{T}"/> to the <paramref name="target"/> range.
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
        public static int Map(this Range<int> source, int sourceLength, in Range<int> target, int targetLength, in Index<int> value, MidpointRounding rounding)
        {
            return (int)Math.Round(target.Interpolate(source.PercentageOf(value, sourceLength), targetLength), rounding);
        }

        /// <summary>
        /// Interpolates the value from the <paramref name="source"/> <see cref="Range{T}"/> to the <paramref name="target"/> range.
        /// </summary>
        /// <param name="source">The range within the <paramref name="value"/> exists.</param>
        /// <param name="target">The range to map the <paramref name="value"/> to.</param>
        /// <param name="value">The value.</param>
        /// <param name="rounding">Rounding mode.</param>
        /// <returns>The <paramref name="value"/> mapped to the <paramref name="target"/> range.</returns>
        /// <remarks>Disallows <see cref="Index{T}.IsFromEnd"/> in favour of performance.</remarks>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Map(this Range<int> source, in Range<int> target, in Index<int> value, MidpointRounding rounding)
        {
            return (int)Math.Round(target.Interpolate(source.PercentageOf(value)), rounding);
        }
    }
}
