using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace GenericRange
{
    /// <summary>Represents a type that can be used to index a collection either from the start or the end.</summary>
    /// <typeparam name="T">
    ///     The primitive type of the index, one of <see langword="sbyte"/>, <see langword="byte"/>, <see langword="short"/>, <see langword="ushort"/>, <see langword="int"/>,
    ///     <see langword="uint"/>, <see langword="long"/>, <see langword="ulong"/>, <see langword="float"/>, <see langword="double"/>, <see langword="decimal"/>, <see langword="char"/>,
    ///     <see langword="TimeSpan"/>, or any <see cref="Enum"/> type with one of the aforementioned as underlying type.
    /// </typeparam>
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly partial struct Index<T> : IEquatable<Index<T>>, IComparable, IComparable<Index<T>>
        where T : unmanaged, IComparable
    {
        /// <summary>Construct an Index using a value and indicating if the index is from the start or from the end.</summary>
        /// <param name="value">The index value.</param>
        /// <param name="fromEnd">Indicating if the index is from the start or from the end.</param>
        /// <remarks>If the Index constructed from the end, index value 1 means pointing at the last element and index value 0 means pointing at beyond last element.</remarks>
        public Index(in T value, bool fromEnd = false)
        {
            Value = value;
            IsFromEnd = fromEnd;
        }

        private Index(in T value)
        {
            Value = value;
            IsFromEnd = false;
        }

        /// <summary>Indicates whether the index is from the start or the end.</summary>
        public bool IsFromEnd { get; }
        
        /// <summary>Returns the index value.</summary>
        public T Value { get; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T GetOffset(in T length) => IsFromEnd ? Subtract(length, Value) : Value;

        public override string ToString() => "[Value = \"" + Value + "\", IsFromEnd = " + IsFromEnd + "]";

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Index<T> other) => Value.Equals(other.Value) && IsFromEnd == other.IsFromEnd;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals([NotNullWhen(true)] object? obj) => obj is Index<T> other && Equals(other) || obj is T value && Equals(value);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => HashCode.Combine(Value, IsFromEnd);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int CompareTo(object? obj) => obj switch {
            Index<T> other => CompareTo(other),
            T value => CompareTo(value),
            _ => throw new ArgumentException("Allowed types for the value is Index<T> or T.", nameof(obj))
        };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int CompareTo(Index<T> other) => Value.CompareTo(other.Value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int CompareTo(in Index<T> other, in T length) => GetOffset(length).CompareTo(other.GetOffset(length));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(in Index<T> left, in Index<T> right) => left.Equals(right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(in Index<T> left, in Index<T> right) => !left.Equals(right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Index<T>(in T value) => new(value);
    }
}