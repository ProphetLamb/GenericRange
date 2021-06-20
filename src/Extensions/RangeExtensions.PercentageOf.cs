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
        public static decimal PercentageOf(this Range<decimal> range, decimal length, Index<decimal> value)
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
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static decimal PercentageOf(this Range<decimal> range, Index<decimal> value)
        {
            value.AssertNotFromEnd();
            (decimal offset, decimal len) = range.GetOffsetAndLength();
            return (value.Value - offset) / len;
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
        public static double PercentageOf(this Range<double> range, double length, Index<double> value)
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
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double PercentageOf(this Range<double> range, Index<double> value)
        {
            value.AssertNotFromEnd();
            (double offset, double len) = range.GetOffsetAndLength();
            return (value.Value - offset) / len;
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
        public static float PercentageOf(this Range<float> range, float length, Index<float> value)
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
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float PercentageOf(this Range<float> range, Index<float> value)
        {
            value.AssertNotFromEnd();
            (float offset, float len) = range.GetOffsetAndLength();
            return (value.Value - offset) / len;
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
        public static double PercentageOf(this Range<long> range, long length, Index<long> value)
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
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double PercentageOf(this Range<long> range, Index<long> value)
        {
            value.AssertNotFromEnd();
            (long offset, long len) = range.GetOffsetAndLength();
            return (value.Value - offset) / (double)len;
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
        public static double PercentageOf(this Range<int> range, int length, Index<int> value)
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
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double PercentageOf(this Range<int> range, Index<int> value)
        {
            value.AssertNotFromEnd();
            (int offset, int len) = range.GetOffsetAndLength();
            return (value.Value - offset) / (double)len;
        }
    }
}
