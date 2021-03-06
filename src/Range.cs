using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

using GenericRange.TypeConverters;

namespace GenericRange
{
    /// <summary>Represents a range that has start and end indices.</summary>
    /// <typeparam name="T">
    ///     The primitive type of the index, one of <see langword="sbyte"/>, <see langword="byte"/>, <see langword="short"/>, <see langword="ushort"/>, <see langword="int"/>,
    ///     <see langword="uint"/>, <see langword="long"/>, <see langword="ulong"/>, <see langword="float"/>, <see langword="double"/>, <see langword="decimal"/>, <see langword="char"/>,
    ///     <see langword="TimeSpan"/>, or any <see cref="Enum"/> type with one of the aforementioned as underlying type.
    /// </typeparam>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct Range<T> : IEquatable<Range<T>>
        where T : unmanaged, IComparable
    {
#region Ctor

        /// <summary>Constructs a <see cref="Range{T}"/> with the specified <paramref name="start"/>, and <paramref name="end"/> indices.</summary>
        /// <param name="start">The start index.</param>
        /// <param name="end">The end index.</param>
        public Range(in Index<T> start, in Index<T> end)
        {
            Start = start;
            End = end;
        }
        
        /// <summary>Constructs a <see cref="Range{T}"/> with the specified <paramref name="start"/>, and <paramref name="end"/> indices.</summary>
        /// <param name="start">The start index.</param>
        /// <param name="startFromEnd">Whether the start index is from the end.</param>
        /// <param name="end">The end index.</param>
        /// <param name="endFromEnd">Whether the end index is from the end.</param>
        public Range(in T start, bool startFromEnd, in T end, bool endFromEnd)
        {
            Start = new Index<T>(start, startFromEnd);
            End = new Index<T>(end, endFromEnd);
        }
        
        /// <summary>Constructs a <see cref="Range{T}"/> with the specified <paramref name="start"/>, and <paramref name="end"/> indices.</summary>
        /// <param name="start">The start index.</param>
        /// <param name="startFromEnd">Whether the start index is from the end.</param>
        /// <param name="end">The end index.</param>
        public Range(in T start, bool startFromEnd, in T end)
        {
            Start = new Index<T>(start, startFromEnd);
            End = new Index<T>(end);
        }

        /// <summary>Constructs a <see cref="Range{T}"/> with the specified <paramref name="start"/>, and <paramref name="end"/> indices.</summary>
        /// <param name="start">The start index.</param>
        /// <param name="end">The end index.</param>
        /// <param name="endFromEnd">Whether the end index is from the end.</param>
        public Range(in T start, in T end, bool endFromEnd)
        {
            Start = new Index<T>(start);
            End = new Index<T>(end, endFromEnd);
        }

#endregion

#region Properties

        /// <summary>The inclusive start index of the <see cref="Range{T}"/>.</summary>
        public Index<T> Start { get; }
        
        /// <summary>The end index of the <see cref="Range{T}"/>.</summary>
        public Index<T> End { get; }

#endregion

#region Public members

        /// <summary>Indicates whether a specified value is within the range.</summary>
        /// <param name="value">The value to seek.</param>
        /// <param name="length">The value that represents the length of the set that the range will be used with.</param>
        /// <returns><see langword="true"/> if the <paramref name="value"/> is within the range, otherwise; <see langword="false"/>.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains(in Index<T> value, in T length) => Start.CompareTo(value, length) <= 0 && End.CompareTo(value, length) >= 0;
        
        /// <summary>Indicates whether a specified value is within the range.</summary>
        /// <param name="value">The value to seek.</param>
        /// <returns><see langword="true"/> if the <paramref name="value"/> is within the range, otherwise; <see langword="false"/>.</returns>
        /// <remarks>Disallows indices <see cref="Index{T}.IsFromEnd"/> in favour of performance.</remarks>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains(in Index<T> value)
        {
            AssertNotFromEnd();
            value.AssertNotFromEnd();
            return Start.CompareTo(value) <= 0 && End.CompareTo(value) >= 0;
        }

        /// <summary>Indicates whether a <see cref="Range{T}"/> is completely contained within the range.</summary>
        /// <param name="other">The other range.</param>
        /// <param name="length">The value that represents the length of the set that the range will be used with.</param>
        /// <returns><see langword="true"/> if the <paramref name="other"/> range completely contained within the range, otherwise; <see langword="false"/>.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Encompasses(in Range<T> other, in T length)
        {
            return Start.CompareTo(other.Start, length) <= 0 && End.CompareTo(other.Start, length) >= 0
                && Start.CompareTo(other.End, length) <= 0 && End.CompareTo(other.End, length) >= 0;
        }
        
        /// <summary>Indicates whether a <see cref="Range{T}"/> is completely contained within the range.</summary>
        /// <param name="other">The other range.</param>
        /// <returns><see langword="true"/> if the <paramref name="other"/> range completely contained within the range, otherwise; <see langword="false"/>.</returns>
        /// <remarks>Disallows indices <see cref="Index{T}.IsFromEnd"/> in favour of performance.</remarks>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Encompasses(in Range<T> other)
        {
            AssertNotFromEnd();
            other.AssertNotFromEnd();
            return Start.CompareTo(other.Start) <= 0 && End.CompareTo(other.Start) >= 0
                && Start.CompareTo(other.End) <= 0 && End.CompareTo(other.End) >= 0;
        }
        
        /// <summary>Indicates whether a <see cref="Range{T}"/> is intersects with the range.</summary>
        /// <param name="other">The other range.</param>
        /// <param name="length">The value that represents the length of the set that the range will be used with.</param>
        /// <returns><see langword="true"/> if the <paramref name="other"/> range intersects with the range, otherwise; <see langword="false"/>.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Intersects(in Range<T> other, in T length)
        {
            return Start.CompareTo(other.End, length) <= 0 && End.CompareTo(other.Start, length) >= 0;
        }
        
        /// <summary>Indicates whether a <see cref="Range{T}"/> is intersects with the range.</summary>
        /// <param name="other">The other range.</param>
        /// <returns><see langword="true"/> if the <paramref name="other"/> range intersects with the range, otherwise; <see langword="false"/>.</returns>
        /// <remarks>Disallows indices <see cref="Index{T}.IsFromEnd"/> in favour of performance.</remarks>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Intersects(in Range<T> other)
        {
            AssertNotFromEnd();
            other.AssertNotFromEnd();
            return Start.CompareTo(other.End) <= 0 && End.CompareTo(other.Start) >= 0;
        }
        
        /// <summary>Returns the start offset and length of the <see cref="Range{T}"/> object using a set length.</summary>
        /// <param name="length">The value that represents the length of the set that the range will be used with.</param>
        /// <returns>The start offset and length of the range.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public (T Offset, T Length) GetOffsetAndLength(in T length)
        {
            T start = Start.GetOffset(length);
            T end = End.GetOffset(length);
            if (end.CompareTo(length) > 0 || start.CompareTo(end) > 0)
                throw new ArgumentOutOfRangeException(nameof(length), "Value cannot be zero, or greater then " + nameof(End));
            return (start, Index<T>.Subtract(end, start));
        }
        
        /// <summary>Returns the start offset and length of the <see cref="Range{T}"/> object using a set length.</summary>
        /// <returns>The start offset and length of the range.</returns>
        /// <remarks>Disallows indices <see cref="Index{T}.IsFromEnd"/> in favour of performance.</remarks>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public (T Offset, T Length) GetOffsetAndLength()
        {
            AssertNotFromEnd();
            if (Start.CompareTo(End) > 0)
                throw new ArgumentOutOfRangeException(nameof(Start), "Value less then " + nameof(End));
            return (Start.Value, Index<T>.Subtract(End.Value, Start.Value));
        }

        /// <summary>Returns the continuous union with an<paramref name="other"/> range in a set of a given <paramref name="length"/>.</summary>
        /// <param name="other">The range to unify with.</param>
        /// <param name="length">The length of the set.</param>
        /// <returns>The continuous union between <see langword="this"/> and the <paramref name="other"/> <see cref="Range{T}"/>.</returns>
        /// <remarks>Same as <see cref="Span{T}"/> but requires the union to be continues.</remarks>
        /// <exception cref="ArgumentOutOfRangeException">The <see cref="Start"/> of the <paramref name="other"/> range is greather then the <see cref="End"/> of the range.</exception>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Range<T> Union(in Range<T> other, in T length)
        {
            if (End.CompareTo(other.Start, length) < 0)
                throw new ArgumentOutOfRangeException(nameof(other), "The ranges are not continuous.");
            return Span(other, length);
        }
        
        /// <summary>Returns the continuous union with an<paramref name="other"/> range in an arbitrary set.</summary>
        /// <param name="other">The range to unify with.</param>
        /// <returns>The continuous union between <see langword="this"/> and the <paramref name="other"/> <see cref="Range{T}"/>.</returns>
        /// <remarks>
        ///     Same as <see cref="Span{T}"/> but requires the union to be continues.
        ///     <br/>
        ///     Disallows indices <see cref="Index{T}.IsFromEnd"/> in favour of performance.
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException">The <see cref="Start"/> of the <paramref name="other"/> range is greather then the <see cref="End"/> of the range.</exception>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Range<T> Union(in Range<T> other)
        {
            AssertNotFromEnd();
            other.AssertNotFromEnd();
            if (End.CompareTo(other.Start) < 0)
                throw new ArgumentOutOfRangeException(nameof(other), "The ranges are not continuous.");
            return Span(other);
        }

        /// <summary>Returns the expanded-union with an<paramref name="other"/> range in a set of a given <paramref name="length"/>.</summary>
        /// <param name="other">The range to unify with.</param>
        /// <param name="length">The length of the set.</param>
        /// <returns>The expanded-union between <see langword="this"/> and the <paramref name="other"/> <see cref="Range{T}"/>.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Range<T> Span(in Range<T> other, in T length)
        {
            return new(Start.CompareTo(other.Start, length) < 0 ? Start : other.Start, End.CompareTo(other.End, length) < 0 ? other.End : End);
        }
        
        /// <summary>Returns the expanded-union with an<paramref name="other"/> range in an arbitrary set.</summary>
        /// <param name="other">The range to unify with.</param>
        /// <returns>The expanded-union between <see langword="this"/> and the <paramref name="other"/> <see cref="Range{T}"/>.</returns>
        /// <remarks>Disallows indices <see cref="Index{T}.IsFromEnd"/> in favour of performance.</remarks>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Range<T> Span(in Range<T> other)
        {
            AssertNotFromEnd();
            other.AssertNotFromEnd();
            return new(Start.CompareTo(other.Start) < 0 ? Start : other.Start, End.CompareTo(other.End) < 0 ? other.End : End);
        }

        /// <summary>Returns the intersection with an<paramref name="other"/> range in a set of a given <paramref name="length"/>.</summary>
        /// <param name="other">The range to unify with.</param>
        /// <param name="length">The length of the set.</param>
        /// <returns>The intersection between <see langword="this"/> and the <paramref name="other"/> <see cref="Range{T}"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><c>!this.Intersects(other, length)</c></exception>
        [Pure]
        public Range<T> Clamp(in Range<T> other, in T length)
        {
            Index<T> start = Start.CompareTo(other.Start, length) < 0 ? other.Start : Start;
            Index<T> end = End.CompareTo(other.End, length) < 0 ? End : other.End;
            if (start.CompareTo(end, length) > 0)
                throw new ArgumentOutOfRangeException(nameof(other), "The value does not intersect with the range.");
            return new Range<T>(start, end);
        }

        /// <summary>Returns the intersection with an<paramref name="other"/> range in an arbitrary set.</summary>
        /// <param name="other">The range to unify with.</param>
        /// <returns>The intersection between <see langword="this"/> and the <paramref name="other"/> <see cref="Range{T}"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><c>!this.Intersects(other, length)</c></exception>
        /// <remarks>Disallows indices <see cref="Index{T}.IsFromEnd"/> in favour of performance.</remarks>
        [Pure]
        public Range<T> Clamp(in Range<T> other)
        {
            AssertNotFromEnd();
            other.AssertNotFromEnd();
            Index<T> start = Start.CompareTo(other.Start) < 0 ? other.Start : Start;
            Index<T> end = End.CompareTo(other.End) < 0 ? End : other.End;
            if (start.CompareTo(end) > 0)
                throw new ArgumentOutOfRangeException(nameof(other), "The value does not intersect with the range.");
            return new Range<T>(start, end);
        }

        /// <summary>Returns a new <see cref="Range{T}"/> with a start-index equal to <see cref="Start"/> and the provided end-index.</summary>
        /// <param name="endIndex">The end-index.</param>
        public Range<T> GetLeftPart(in Index<T> endIndex) => new(Start, endIndex);

        /// <summary>Returns a new <see cref="Range{T}"/> with a the provided start-index and end-index equal to <see cref="End"/>.</summary>
        /// <param name="startIndex">The end-index.</param>
        public Range<T> GetRightPart(in Index<T> startIndex) => new(startIndex, End);

        /// <inheritdoc/>
        public override string ToString() => RangeConverter<T>.ToString(this);

        /// <summary>Indicates whether the indices inside a set of a specific <paramref name="length"/> of the <see cref="Range{T}"/> are equal to another.</summary>
        /// <param name="other">The other <see cref="Range{T}"/>.</param>
        /// <param name="length">The length of the set.</param>
        /// <returns><see langword="true"/> if the current object is equal to the other parameter; otherwise, <see langword="false"/>.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(in Range<T> other, in T length) => Start.Equals(other.Start, length) && End.Equals(other.End, length);
        
        /// <inheritdoc/>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Range<T> other) => Start.Equals(other.Start) && End.Equals(other.End);

        /// <inheritdoc/>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals([NotNullWhen(true)] object? obj) => obj is Range<T> other && Equals(other);

        /// <inheritdoc/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => HashCode.Combine(Start, End);
        
        /// <summary>Converts the <see cref="Value"/> to the specified type.</summary>
        /// <typeparam name="TOut">The type to convert to.</typeparam>
        /// <returns>A new <see cref="Range{TOut}"/> of the desired type.</returns>
        /// <exception cref="InvalidCastException">This conversion is not supported. -or- value is null and conversionType is a value type. -or- value does not implement the IConvertible interface.</exception>
        /// <remarks>Uses <see cref="Convert.ChangeType(object, Type)"/>, but the generic constraints do not ensure that the Types are IConvertible use at own discretion.</remarks>
        public Range<TOut> ToRange<TOut>()
            where TOut: unmanaged, IComparable, IConvertible
        {
            return new(Start.ToIndex<TOut>(), End.ToIndex<TOut>());
        }
        
        /// <summary>Parses the string to a range.</summary>
        /// <param name="serialized">The string to parse.</param>
        /// <returns>The range parsed from the string.</returns>
        public static Range<T> Parse(string serialized) => RangeConverter<T>.Parse(serialized);

#endregion

#region Internal members
        
        [Conditional("DEBUG")]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal void AssertNotFromEnd()
        {
            Start.AssertNotFromEnd();
            End.AssertNotFromEnd();
        }

#endregion
        
#region Operators

        /// <summary>Indicates whether the two values are equal.</summary>
        /// <param name="left">The left argument.</param>
        /// <param name="right">The right argument.</param>
        /// <returns><see langword="true"/> if the two indices are equal; otherwise, <see langword="false"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(in Range<T> left, in Range<T> right) => left.Equals(right);

        /// <summary>Indicates whether the two values are not equal.</summary>
        /// <param name="left">The left argument.</param>
        /// <param name="right">The right argument.</param>
        /// <returns><see langword="true"/> if the two indices are not equal; otherwise, <see langword="false"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(in Range<T> left, in Range<T> right) => !left.Equals(right);
        
        /// <summary>Deconstructs the tuple to a range.</summary>
        /// <param name="tuple">The tuple to deconstruct.</param>
        /// <returns>The range represented by the tuple.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Range<T>(in (T Start, T End) tuple) => new(tuple.Start, tuple.End);

        /// <summary>Uses <see cref="Convert.ChangeType(object, Type)"/> to convert the range to the specific generic type.</summary>
        /// <remarks>Warning: does not work for not <see cref="IConvertible"/>'s such as <see cref="Enum"/> types.</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Range<T>(in Range range) => new((Index<T>)range.Start, (Index<T>)range.End);

#endregion
    }
}