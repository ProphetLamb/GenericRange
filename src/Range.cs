using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;

namespace GenericRange
{
    /// <summary>Represents a range that has start and end indices.</summary>
    /// <typeparam name="T">
    ///     The primitive type of the index, one of <see langword="sbyte"/>, <see langword="byte"/>, <see langword="short"/>, <see langword="ushort"/>, <see langword="int"/>,
    ///     <see langword="uint"/>, <see langword="long"/>, <see langword="ulong"/>, <see langword="float"/>, <see langword="double"/>, <see langword="decimal"/>, <see langword="char"/>,
    ///     <see langword="TimeSpan"/>, or any <see cref="Enum"/> type with one of the aforementioned as underlying type.
    /// </typeparam>
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct Range<T> : IEquatable<Range<T>>
        where T : unmanaged, IComparable
    {
        /// <summary>Constructs a <see cref="Range{T}"/> with the specified <paramref name="start"/>, and <paramref name="end"/> indices.</summary>
        /// <param name="start">The start index.</param>
        /// <param name="end">The end index.</param>
        public Range(in Index<T> start, in Index<T> end)
        {
            Start = start;
            End = end;
        }
        
        /// <summary>
        /// Constructs a <see cref="Range{T}"/> with the specified <paramref name="start"/>, and <paramref name="end"/> indices.
        /// </summary>
        /// <param name="start">The start index.</param>
        /// <param name="startFromEnd">Whether the start index is from the end.</param>
        /// <param name="end">The end index.</param>
        /// <param name="endFromEnd">Whether the end index is from the end.</param>
        public Range(in T start, bool startFromEnd, in T end, bool endFromEnd)
        {
            Start = new Index<T>(start, startFromEnd);
            End = new Index<T>(end, endFromEnd);
        }

        /// <summary>
        /// Constructs a <see cref="Range{T}"/> with the specified <paramref name="start"/>, and <paramref name="end"/> indices.
        /// </summary>
        /// <param name="start">The start index.</param>
        /// <param name="end">The end index.</param>
        /// <param name="endFromEnd">Whether the end index is from the end.</param>
        public Range(in T start, in T end, bool endFromEnd)
        {
            Start = new Index<T>(start);
            End = new Index<T>(end, endFromEnd);
        }

        /// <summary>The inclusive start index of the <see cref="Range{T}"/>.</summary>
        public Index<T> Start { get; }
        
        /// <summary>The end index of the <see cref="Range{T}"/>.</summary>
        public Index<T> End { get; }
        
        /// <summary>Indicates whether a specified value is within the range.</summary>
        /// <param name="value">The value to seek.</param>
        /// <param name="length">The value that represents the length of the collection that the range will be used with.</param>
        /// <returns><see langword="true"/> if the <paramref name="value"/> is within the range, otherwise; <see langword="false"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains(in T value, in T length) => Start.GetOffset(length).CompareTo(value) <= 0 && End.GetOffset(length).CompareTo(value) > 0;
        
        /// <summary>Indicates whether a specified value is within the range. Disallows indices from end in favour of performance.</summary>
        /// <param name="value">The value to seek.</param>
        /// <returns><see langword="true"/> if the <paramref name="value"/> is within the range, otherwise; <see langword="false"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains(in T value)
        {
            Debug.Assert(!Start.IsFromEnd && !End.IsFromEnd, "!Start.IsFromEnd && !End.IsFromEnd");
            return Start.Value.CompareTo(value) <= 0 && End.Value.CompareTo(value) > 0;
        }

        /// <summary>Indicates whether a <see cref="Range{T}"/> is completely contained within the range.</summary>
        /// <param name="other">The other range.</param>
        /// <param name="length">The value that represents the length of the collection that the range will be used with.</param>
        /// <returns><see langword="true"/> if the <paramref name="other"/> range completely contained within the range, otherwise; <see langword="false"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Encompasses(in Range<T> other, in T length)
        {
            T startOff = Start.GetOffset(length), endOff = End.GetOffset(length), otherStartOff = other.Start.GetOffset(length), otherEndOff = other.End.GetOffset(length);
            return startOff.CompareTo(otherStartOff) <= 0 && endOff.CompareTo(otherStartOff) >= 0
                && startOff.CompareTo(otherEndOff) <= 0 && endOff.CompareTo(otherEndOff) >= 0;
        }
        
        /// <summary>Indicates whether a <see cref="Range{T}"/> is completely contained within the range. Disallows indices from end in favour of performance.</summary>
        /// <param name="other">The other range.</param>
        /// <returns><see langword="true"/> if the <paramref name="other"/> range completely contained within the range, otherwise; <see langword="false"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Encompasses(in Range<T> other)
        {
            Debug.Assert(!Start.IsFromEnd && !End.IsFromEnd, "!Start.IsFromEnd && !End.IsFromEnd");
            return Start.Value.CompareTo(other.Start.Value) <= 0 && End.Value.CompareTo(other.Start.Value) >= 0
                && Start.Value.CompareTo(other.End.Value) <= 0 && End.Value.CompareTo(other.End.Value) >= 0;
        }
        
        /// <summary>Indicates whether a <see cref="Range{T}"/> is intersects with the range.</summary>
        /// <param name="other">The other range.</param>
        /// <param name="length">The value that represents the length of the collection that the range will be used with.</param>
        /// <returns><see langword="true"/> if the <paramref name="other"/> range intersects with the range, otherwise; <see langword="false"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Intersects(in Range<T> other, in T length)
        {
            T startOff = Start.GetOffset(length), endOff = End.GetOffset(length), otherStartOff = other.Start.GetOffset(length), otherEndOff = other.End.GetOffset(length);
            return startOff.CompareTo(otherEndOff) <= 0 && endOff.CompareTo(otherStartOff) >= 0;
        }
        
        /// <summary>Indicates whether a <see cref="Range{T}"/> is intersects with the range. Disallows indices from end in favour of performance.</summary>
        /// <param name="other">The other range.</param>
        /// <returns><see langword="true"/> if the <paramref name="other"/> range intersects with the range, otherwise; <see langword="false"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Intersects(in Range<T> other)
        {
            Debug.Assert(!Start.IsFromEnd && !End.IsFromEnd, "!Start.IsFromEnd && !End.IsFromEnd");
            return Start.Value.CompareTo(other.End.Value) <= 0 && End.Value.CompareTo(other.Start.Value) >= 0;
        }
        
        /// <summary>Calculates the start offset and length of the <see cref="Range{T}"/> object using a collection length.</summary>
        /// <param name="length">The value that represents the length of the collection that the range will be used with.</param>
        /// <returns>The start offset and length of the range.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public (T Offset, T Length) GetOffsetAndLength(in T length)
        {
            T start = Start.GetOffset(length);
            T end = End.GetOffset(length);
            if (end.CompareTo(length) > 0 || start.CompareTo(end) > 0)
                throw new ArgumentOutOfRangeException(nameof(length), "Value cannot be zero, or greater then " + nameof(End));
            return (start, Index<T>.Subtract(end, start));
        }
        
        /// <summary>Calculates the start offset and length of the <see cref="Range{T}"/> object using a collection length. Disallows indices from end in favour of performance.</summary>
        /// <returns>The start offset and length of the range.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public (T Offset, T Length) GetOffsetAndLength()
        {
            Debug.Assert(!Start.IsFromEnd && !End.IsFromEnd, "!Start.IsFromEnd && !End.IsFromEnd");
            if (Start.Value.CompareTo(End.Value) > 0)
                throw new ArgumentOutOfRangeException(nameof(Start), "Value less then " + nameof(End));
            return (Start.Value, Index<T>.Subtract(End.Value, Start.Value));
        }

        public override string ToString()
        {
            ValueStringBuilder vsb = new(stackalloc char[32]);
            if (Start.IsFromEnd)
                vsb.Append('^');
            vsb.Append(Start.Value.ToString());
            vsb.Append(End.IsFromEnd ? "..^" : "..");
            vsb.Append(End.Value.ToString());
            return vsb.ToString();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Range<T> other) => Start.Equals(other.Start) && End.Equals(other.End);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals([NotNullWhen(true)] object? obj) => obj is Range<T> other && Equals(other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => HashCode.Combine(Start, End);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(in Range<T> left, in Range<T> right) => left.Equals(right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(in Range<T> left, in Range<T> right) => !left.Equals(right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Range<T>(in (T Start, T End) tuple) => new(tuple.Start, tuple.End);
    }
}