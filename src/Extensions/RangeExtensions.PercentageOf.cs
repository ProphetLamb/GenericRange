using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace GenericRange.Extensions
{
    public static partial class RangeExtensions
    {
        /// <summary>Returns the percentage of the <see cref="value"/> within the <see cref="Range{T}"/>.</summary>
        /// <param name="range">The range.</param>
        /// <param name="value">The value inside the set.</param>
        /// <param name="length">The length of the set.</param>
        /// <returns>The percentage of the <see cref="value"/> within the <see cref="Range{T}"/>.</returns>
        /// <remarks>
        ///     <c>0.0</c> if the <paramref name="value"/> is equal to <see cref="Range{T}.Start"/>,<br/>
        ///     <c>1.0</c> if the <paramref name="value"/> is equal to <see cref="Range{T}.End"/>.
        /// </remarks>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal PercentageOf(this Range<decimal> range, in Index<decimal> value, decimal length)
        {
            (decimal offset, decimal len) = range.GetOffsetAndLength(length);
            return (value.GetOffset(length) - offset) / len;
        }
        
        /// <summary>Returns the percentage of the <see cref="value"/> within the <see cref="Range{T}"/>.</summary>
        /// <param name="range">The range.</param>
        /// <param name="value">The value inside the set.</param>
        /// <returns>The percentage of the <see cref="value"/> within the <see cref="Range{T}"/>.</returns>
        /// <remarks>
        ///     <c>0.0</c> if the <paramref name="value"/> is equal to <see cref="Range{T}.Start"/>,<br/>
        ///     <c>1.0</c> if the <paramref name="value"/> is equal to <see cref="Range{T}.End"/>.
        /// </remarks>
        /// <remarks>Disallows <see cref="Index{T}.IsFromEnd"/> in favour of performance.</remarks>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal PercentageOf(this Range<decimal> range, in Index<decimal> value)
        {
            (decimal offset, decimal len) = range.GetOffsetAndLength();
            return (value.Value - offset) / len;
        }

        /// <summary>Returns the percentage of the <see cref="value"/> within the <see cref="Range{T}"/>.</summary>
        /// <param name="range">The range.</param>
        /// <param name="value">The value inside the set.</param>
        /// <param name="length">The length of the set.</param>
        /// <returns>The percentage of the <see cref="value"/> within the <see cref="Range{T}"/>.</returns>
        /// <remarks>
        ///     <c>0.0</c> if the <paramref name="value"/> is equal to <see cref="Range{T}.Start"/>,<br/>
        ///     <c>1.0</c> if the <paramref name="value"/> is equal to <see cref="Range{T}.End"/>.
        /// </remarks>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double PercentageOf(this Range<double> range, in Index<double> value, double length)
        {
            (double offset, double len) = range.GetOffsetAndLength(length);
            return (value.GetOffset(length) - offset) / len;
        }
        
        /// <summary>Returns the percentage of the <see cref="value"/> within the <see cref="Range{T}"/>.</summary>
        /// <param name="range">The range.</param>
        /// <param name="value">The value inside the set.</param>
        /// <returns>The percentage of the <see cref="value"/> within the <see cref="Range{T}"/>.</returns>
        /// <remarks>
        ///     <c>0.0</c> if the <paramref name="value"/> is equal to <see cref="Range{T}.Start"/>,<br/>
        ///     <c>1.0</c> if the <paramref name="value"/> is equal to <see cref="Range{T}.End"/>.
        /// </remarks>
        /// <remarks>Disallows <see cref="Index{T}.IsFromEnd"/> in favour of performance.</remarks>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double PercentageOf(this Range<double> range, in Index<double> value)
        {
            (double offset, double len) = range.GetOffsetAndLength();
            return (value.Value - offset) / len;
        }

        /// <summary>Returns the percentage of the <see cref="value"/> within the <see cref="Range{T}"/>.</summary>
        /// <param name="range">The range.</param>
        /// <param name="value">The value inside the set.</param>
        /// <param name="length">The length of the set.</param>
        /// <returns>The percentage of the <see cref="value"/> within the <see cref="Range{T}"/>.</returns>
        /// <remarks>
        ///     <c>0.0</c> if the <paramref name="value"/> is equal to <see cref="Range{T}.Start"/>,<br/>
        ///     <c>1.0</c> if the <paramref name="value"/> is equal to <see cref="Range{T}.End"/>.
        /// </remarks>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float PercentageOf(this Range<float> range, in Index<float> value, float length)
        {
            (float offset, float len) = range.GetOffsetAndLength(length);
            return (value.GetOffset(length) - offset) / len;
        }
        
        /// <summary>Returns the percentage of the <see cref="value"/> within the <see cref="Range{T}"/>.</summary>
        /// <param name="range">The range.</param>
        /// <param name="value">The value inside the set.</param>
        /// <returns>The percentage of the <see cref="value"/> within the <see cref="Range{T}"/>.</returns>
        /// <remarks>
        ///     <c>0.0</c> if the <paramref name="value"/> is equal to <see cref="Range{T}.Start"/>,<br/>
        ///     <c>1.0</c> if the <paramref name="value"/> is equal to <see cref="Range{T}.End"/>.
        /// </remarks>
        /// <remarks>Disallows <see cref="Index{T}.IsFromEnd"/> in favour of performance.</remarks>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float PercentageOf(this Range<float> range, in Index<float> value)
        {
            (float offset, float len) = range.GetOffsetAndLength();
            return (value.Value - offset) / len;
        }

        /// <summary>Returns the percentage of the <see cref="value"/> within the <see cref="Range{T}"/>.</summary>
        /// <param name="range">The range.</param>
        /// <param name="value">The value inside the set.</param>
        /// <param name="length">The length of the set.</param>
        /// <returns>The percentage of the <see cref="value"/> within the <see cref="Range{T}"/>.</returns>
        /// <remarks>
        ///     <c>0.0</c> if the <paramref name="value"/> is equal to <see cref="Range{T}.Start"/>,<br/>
        ///     <c>1.0</c> if the <paramref name="value"/> is equal to <see cref="Range{T}.End"/>.
        /// </remarks>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double PercentageOf(this Range<long> range, in Index<long> value, long length)
        {
            (long offset, long len) = range.GetOffsetAndLength(length);
            return (value.GetOffset(length) - offset) / (double)len;
        }
        
        /// <summary>Returns the percentage of the <see cref="value"/> within the <see cref="Range{T}"/>.</summary>
        /// <param name="range">The range.</param>
        /// <param name="value">The value inside the set.</param>
        /// <returns>The percentage of the <see cref="value"/> within the <see cref="Range{T}"/>.</returns>
        /// <remarks>
        ///     <c>0.0</c> if the <paramref name="value"/> is equal to <see cref="Range{T}.Start"/>,<br/>
        ///     <c>1.0</c> if the <paramref name="value"/> is equal to <see cref="Range{T}.End"/>.
        /// </remarks>
        /// <remarks>Disallows <see cref="Index{T}.IsFromEnd"/> in favour of performance.</remarks>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double PercentageOf(this Range<long> range, in Index<long> value)
        {
            (long offset, long len) = range.GetOffsetAndLength();
            return (value.Value - offset) / (double)len;
        }

        /// <summary>Returns the percentage of the <see cref="value"/> within the <see cref="Range{T}"/>.</summary>
        /// <param name="range">The range.</param>
        /// <param name="value">The value inside the set.</param>
        /// <param name="length">The length of the set.</param>
        /// <returns>The percentage of the <see cref="value"/> within the <see cref="Range{T}"/>.</returns>
        /// <remarks>
        ///     <c>0.0</c> if the <paramref name="value"/> is equal to <see cref="Range{T}.Start"/>,<br/>
        ///     <c>1.0</c> if the <paramref name="value"/> is equal to <see cref="Range{T}.End"/>.
        /// </remarks>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double PercentageOf(this Range<int> range, in Index<int> value, int length)
        {
            (int offset, int len) = range.GetOffsetAndLength(length);
            return (value.GetOffset(length) - offset) / (double)len;
        }
        
        /// <summary>Returns the percentage of the <see cref="value"/> within the <see cref="Range{T}"/>.</summary>
        /// <param name="range">The range.</param>
        /// <param name="value">The value inside the set.</param>
        /// <returns>The percentage of the <see cref="value"/> within the <see cref="Range{T}"/>.</returns>
        /// <remarks>
        ///     <c>0.0</c> if the <paramref name="value"/> is equal to <see cref="Range{T}.Start"/>,<br/>
        ///     <c>1.0</c> if the <paramref name="value"/> is equal to <see cref="Range{T}.End"/>.
        /// </remarks>
        /// <remarks>Disallows <see cref="Index{T}.IsFromEnd"/> in favour of performance.</remarks>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double PercentageOf(this Range<int> range, in Index<int> value)
        {
            (int offset, int len) = range.GetOffsetAndLength();
            return (value.Value - offset) / (double)len;
        }
    }
}
