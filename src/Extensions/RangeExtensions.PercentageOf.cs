using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace GenericRange.Extensions
{
    public static partial class RangeExtensions
    {
        /// <summary>Returns the percentage of the <see cref="value"/> within the <see cref="Range{T}"/>.</summary>
        /// <param name="range">The range.</param>
        /// <param name="length">The length of the set.</param>
        /// <param name="value">The value inside the set.</param>
        /// <returns>The percentage of the <see cref="value"/> within the <see cref="Range{T}"/>.</returns>
        /// <remarks>
        ///     <c>0.0</c> if the <paramref name="value"/> is equal to <see cref="Range{T}.Start"/>,<br/>
        ///     <c>1.0</c> if the <paramref name="value"/> is equal to <see cref="Range{T}.End"/>.
        /// </remarks>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal PercentageOf(this Range<decimal> range, decimal length, decimal value)
        {
            (decimal offset, decimal len) = range.GetOffsetAndLength(length);
            return (value - offset) / len;
        }
        
        /// <summary>Returns the percentage of the <see cref="value"/> within the <see cref="Range{T}"/>.</summary>
        /// <param name="range">The range.</param>
        /// <param name="value">The value inside the set.</param>
        /// <returns>The percentage of the <see cref="value"/> within the <see cref="Range{T}"/>.</returns>
        /// <remarks>
        ///     <c>0.0</c> if the <paramref name="value"/> is equal to <see cref="Range{T}.Start"/>,<br/>
        ///     <c>1.0</c> if the <paramref name="value"/> is equal to <see cref="Range{T}.End"/>.
        /// </remarks>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal PercentageOf(this Range<decimal> range, decimal value)
        {
            value.AssertNotFromEnd();
            (decimal offset, decimal len) = range.GetOffsetAndLength();
            return (value - offset) / len;
        }
        
        /// <summary>Returns the percentage of the <see cref="value"/> within the <see cref="Range{T}"/>.</summary>
        /// <param name="range">The range.</param>
        /// <param name="length">The length of the set.</param>
        /// <param name="value">The value inside the set.</param>
        /// <returns>The percentage of the <see cref="value"/> within the <see cref="Range{T}"/>.</returns>
        /// <remarks>
        ///     <c>0.0</c> if the <paramref name="value"/> is equal to <see cref="Range{T}.Start"/>,<br/>
        ///     <c>1.0</c> if the <paramref name="value"/> is equal to <see cref="Range{T}.End"/>.
        /// </remarks>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double PercentageOf(this Range<double> range, double length, double value)
        {
            (double offset, double len) = range.GetOffsetAndLength(length);
            return (value - offset) / len;
        }
        
        /// <summary>Returns the percentage of the <see cref="value"/> within the <see cref="Range{T}"/>.</summary>
        /// <param name="range">The range.</param>
        /// <param name="value">The value inside the set.</param>
        /// <returns>The percentage of the <see cref="value"/> within the <see cref="Range{T}"/>.</returns>
        /// <remarks>
        ///     <c>0.0</c> if the <paramref name="value"/> is equal to <see cref="Range{T}.Start"/>,<br/>
        ///     <c>1.0</c> if the <paramref name="value"/> is equal to <see cref="Range{T}.End"/>.
        /// </remarks>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double PercentageOf(this Range<double> range, double value)
        {
            value.AssertNotFromEnd();
            (double offset, double len) = range.GetOffsetAndLength();
            return (value - offset) / len;
        }
        
        /// <summary>Returns the percentage of the <see cref="value"/> within the <see cref="Range{T}"/>.</summary>
        /// <param name="range">The range.</param>
        /// <param name="length">The length of the set.</param>
        /// <param name="value">The value inside the set.</param>
        /// <returns>The percentage of the <see cref="value"/> within the <see cref="Range{T}"/>.</returns>
        /// <remarks>
        ///     <c>0.0</c> if the <paramref name="value"/> is equal to <see cref="Range{T}.Start"/>,<br/>
        ///     <c>1.0</c> if the <paramref name="value"/> is equal to <see cref="Range{T}.End"/>.
        /// </remarks>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float PercentageOf(this Range<float> range, float length, float value)
        {
            (float offset, float len) = range.GetOffsetAndLength(length);
            return (value - offset) / len;
        }
        
        /// <summary>Returns the percentage of the <see cref="value"/> within the <see cref="Range{T}"/>.</summary>
        /// <param name="range">The range.</param>
        /// <param name="value">The value inside the set.</param>
        /// <returns>The percentage of the <see cref="value"/> within the <see cref="Range{T}"/>.</returns>
        /// <remarks>
        ///     <c>0.0</c> if the <paramref name="value"/> is equal to <see cref="Range{T}.Start"/>,<br/>
        ///     <c>1.0</c> if the <paramref name="value"/> is equal to <see cref="Range{T}.End"/>.
        /// </remarks>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float PercentageOf(this Range<float> range, float value)
        {
            value.AssertNotFromEnd();
            (float offset, float len) = range.GetOffsetAndLength();
            return (value - offset) / len;
        }
        
        /// <summary>Returns the percentage of the <see cref="value"/> within the <see cref="Range{T}"/>.</summary>
        /// <param name="range">The range.</param>
        /// <param name="length">The length of the set.</param>
        /// <param name="value">The value inside the set.</param>
        /// <returns>The percentage of the <see cref="value"/> within the <see cref="Range{T}"/>.</returns>
        /// <remarks>
        ///     <c>0.0</c> if the <paramref name="value"/> is equal to <see cref="Range{T}.Start"/>,<br/>
        ///     <c>1.0</c> if the <paramref name="value"/> is equal to <see cref="Range{T}.End"/>.
        /// </remarks>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double PercentageOf(this Range<int> range, int length, int value)
        {
            (int offset, int len) = range.GetOffsetAndLength(length);
            return (value - offset) / (double)len;
        }
        
        /// <summary>Returns the percentage of the <see cref="value"/> within the <see cref="Range{T}"/>.</summary>
        /// <param name="range">The range.</param>
        /// <param name="value">The value inside the set.</param>
        /// <returns>The percentage of the <see cref="value"/> within the <see cref="Range{T}"/>.</returns>
        /// <remarks>
        ///     <c>0.0</c> if the <paramref name="value"/> is equal to <see cref="Range{T}.Start"/>,<br/>
        ///     <c>1.0</c> if the <paramref name="value"/> is equal to <see cref="Range{T}.End"/>.
        /// </remarks>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double PercentageOf(this Range<int> range, int value)
        {
            value.AssertNotFromEnd();
            (int offset, int len) = range.GetOffsetAndLength();
            return (value - offset) / (double)len;
        }
    }
}
