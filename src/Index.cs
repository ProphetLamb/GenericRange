using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

using GenericRange.TypeConverters;

namespace GenericRange
{
    /// <summary>Represents a type that can be used to index a collection either from the start or the end.</summary>
    /// <typeparam name="T">
    ///     The primitive type of the index, one of <see langword="sbyte"/>, <see langword="byte"/>, <see langword="short"/>, <see langword="ushort"/>, <see langword="int"/>,
    ///     <see langword="uint"/>, <see langword="long"/>, <see langword="ulong"/>, <see langword="float"/>, <see langword="double"/>, <see langword="decimal"/>, <see langword="char"/>,
    ///     <see langword="TimeSpan"/>, or any <see cref="Enum"/> type with one of the aforementioned as underlying type.
    /// </typeparam>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly partial struct Index<T> :
        IEquatable<Index<T>>,
        IComparable,
        IComparable<Index<T>>
        where T : unmanaged, IComparable
    {
#region Ctor

        /// <summary>Construct an <see cref="Index{T}"/> using a value and indicating if the index is from the start or from the end.</summary>
        /// <param name="value">The index value.</param>
        /// <param name="fromEnd">Indicating if the index is from the start or from the end.</param>
        /// <remarks>If the <see cref="Index{T}"/> constructed from the end, index value 1 means pointing at the last element and index value 0 means pointing at beyond last element.</remarks>
        public Index(in T value, bool fromEnd)
        {
            Value = value;
            IsFromEnd = fromEnd;
        }

        /// <summary>Construct an <see cref="Index{T}"/> from the start using a value.</summary>
        /// <param name="value">The index value.</param>
        public Index(in T value)
        {
            Value = value;
            IsFromEnd = false;
        }

#endregion

#region Properties

        /// <summary>Indicates whether the index is from the start or the end.</summary>
        public bool IsFromEnd { get; }
        
        /// <summary>Returns the index value.</summary>
        public T Value { get; }
        
#endregion

#region Public members

        /// <summary>Returns the offset from the start of a set.</summary>
        /// <param name="length">The length of the set.</param>
        /// <returns>The offset from the start of a set.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T GetOffset(in T length) => IsFromEnd ? Subtract(length, Value) : Value;
        
        /// <inheritdoc/>
        public override string ToString() => IndexConverter<T>.ToString(this);

        /// <inheritdoc/>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Index<T> other) => Compare(Value, other.Value) == 0 && IsFromEnd == other.IsFromEnd;
        
        /// <summary>Indicates whether the <see cref="Index{T}"/> points to the same element in a set.</summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <param name="length">The length of the collection.</param>
        /// <returns><see langword="true"/> if the current object is equal to the other parameter; otherwise, <see langword="false"/>.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(in Index<T> other, in T length) => CompareTo(other, length) == 0;

        /// <inheritdoc/>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals([NotNullWhen(true)] object? obj) => obj is Index<T> other && Equals(other) || obj is T value && Equals(value);
        
        /// <inheritdoc/>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => HashCode.Combine(Value, IsFromEnd);

        /// <inheritdoc/>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int CompareTo(object? obj) => obj switch {
            Index<T> other => CompareTo(other),
            T value => CompareTo(new Index<T>(value)),
            _ => throw new ArgumentException("Allowed types for the value is Index<T> or T.", nameof(obj))
        };

        /// <inheritdoc/>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int CompareTo(Index<T> other)
        {
            Debug.Assert(IsFromEnd == other.IsFromEnd, "IsFromEnd == other.IsFromEnd");
            return Compare(Value, other.Value);
        }

        /// <summary>
        ///     Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes,
        ///     follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="other">An object to compare with this instance.</param>
        /// <param name="length">The length of the set.</param>
        /// <returns>
        ///     A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance precedes
        ///     other in the sort order. Zero This instance occurs in the same position in the sort order as other. Greater than zero This instance follows other in the sort order.
        /// </returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int CompareTo(in Index<T> other, in T length) => Compare(GetOffset(length), other.GetOffset(length));
        
        /// <summary>Converts the <see cref="Value"/> to the specified type.</summary>
        /// <typeparam name="TOut">The type to convert to.</typeparam>
        /// <returns>A new <see cref="Index{TOut}"/> of the desired type.</returns>
        /// <exception cref="InvalidCastException">This conversion is not supported. -or- value is null and conversionType is a value type. -or- value does not implement the IConvertible interface.</exception>
        /// <remarks>Uses <see cref="Convert.ChangeType(object, Type)"/>, but the generic constraints do not ensure that the Types are IConvertible use at own discretion.</remarks>
        public Index<TOut> ToIndex<TOut>()
            where TOut: unmanaged, IComparable, IConvertible
        {
            return new Index<TOut>(ConvertMarshaledValue<TOut>(Value), IsFromEnd);
        }

        /// <summary>Returns the <see cref="Index{T}"/> that points to the element with the lower index of two indices.</summary>
        /// <param name="left">The first index.</param>
        /// <param name="right">The second index.</param>
        /// <param name="length">The length of the set.</param>
        /// <returns>The smaller <see cref="Index{T}"/>.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Index<T> Min(in Index<T> left, in Index<T> right, in T length) => left.CompareTo(right, length) < 0 ? left : right;

        /// <summary>Returns the smaller of the two indices.</summary>
        /// <param name="left">The first index.</param>
        /// <param name="right">The second index.</param>
        /// <returns>The smaller <see cref="Index{T}"/>.</returns>
        /// <remarks>Disallows <see cref="Index{T}.IsFromEnd"/> in favour of performance.</remarks>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Index<T> Min(in Index<T> left, in Index<T> right) => left.CompareTo(right) < 0 ? left : right;
        
        /// <summary>Returns the <see cref="Index{T}"/> that points to the element with the higher index of two indices.</summary>
        /// <param name="left">The first index.</param>
        /// <param name="right">The second index.</param>
        /// <param name="length">The length of the set.</param>
        /// <returns>The greater <see cref="Index{T}"/>.</returns>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Index<T> Max(in Index<T> left, in Index<T> right, in T length) => left.CompareTo(right, length) < 0 ? right : left;
        
        /// <summary>Returns the greater of the two indices.</summary>
        /// <param name="left">The first index.</param>
        /// <param name="right">The second index.</param>
        /// <returns>The greater <see cref="Index{T}"/>.</returns>
        /// <remarks>Disallows <see cref="Index{T}.IsFromEnd"/> in favour of performance.</remarks>
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Index<T> Max(in Index<T> left, in Index<T> right) => left.CompareTo(right) < 0 ? right : left;

        /// <summary>Parses the string to a index.</summary>
        /// <param name="serialized">The string to parse.</param>
        /// <returns>The index parsed from the string.</returns>
        public static Index<T> Parse(ReadOnlySpan<char> serialized) => IndexConverter<T>.Parse(serialized);

#endregion

#region InternalMembers

        [Conditional("DEBUG")]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal void AssertNotFromEnd()
        {
            Debug.Assert(!IsFromEnd, "!index.IsFromEnd");
        }
        
        /// <summary>
        ///     Ensure that T is TOut or IConvertible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static unsafe TOut ConvertMarshaledValue<TOut>(T value) where TOut : unmanaged
        {
            TOut retVal;

            if (typeof(TOut) != typeof(T))
            {
                if (typeof(T) != typeof(TimeSpan))
                {
                    if (!typeof(T).IsEnum)
                    {
                        retVal = (TOut) Convert.ChangeType(value, typeof(TOut));
                    }
                    else
                    {
                        retVal = sizeof(T) switch
                        {
                            8 => (TOut) Convert.ChangeType(*(long*) &value, typeof(TOut)),
                            4 => (TOut) Convert.ChangeType(*(int*) &value, typeof(TOut)),
                            2 => (TOut) Convert.ChangeType(*(short*) &value, typeof(TOut)),
                            1 => (TOut) Convert.ChangeType(*(byte*) &value, typeof(TOut)),
                            _ => throw new NotSupportedException("Only enums with a width of 1, 2, 4, or 8 bytes a eligible.")
                        };
                    }
                }
                else
                {
                    retVal = (TOut) Convert.ChangeType((*(TimeSpan*) &value).Ticks, typeof(TOut));
                }
            }
            else
            {
                retVal = *(TOut*) &value;
            }

            return retVal;
        }
        
        /// <summary>
        ///     Ensure that T is TIn or IConvertible.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static unsafe T ConvertMarshaledValue<TIn>(TIn value) where TIn : unmanaged
        {
            T retVal;

            if (typeof(TIn) != typeof(T))
            {
                if (typeof(TIn) != typeof(TimeSpan))
                {
                    if (!typeof(TIn).IsEnum)
                    {
                        retVal = (T) Convert.ChangeType(value, typeof(T));
                    }
                    else
                    {
                        retVal = sizeof(TIn) switch
                        {
                            8 => (T) Convert.ChangeType(*(long*) &value, typeof(T)),
                            4 => (T) Convert.ChangeType(*(int*) &value, typeof(T)),
                            2 => (T) Convert.ChangeType(*(short*) &value, typeof(T)),
                            1 => (T) Convert.ChangeType(*(byte*) &value, typeof(T)),
                            _ => throw new NotSupportedException("Only enums with a width of 1, 2, 4, or 8 bytes a eligible.")
                        };
                    }
                }
                else
                {
                    retVal = (T) Convert.ChangeType((*(TimeSpan*) &value).Ticks, typeof(T));
                }
            }
            else
            {
                retVal = *(T*) &value;
            }

            return retVal;
        }
        
#endregion
        
#region Operators
        
        /// <summary>Indicates whether the two values are equal.</summary>
        /// <param name="left">The left argument.</param>
        /// <param name="right">The right argument.</param>
        /// <returns><see langword="true"/> if the two indices are equal; otherwise, <see langword="false"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(in Index<T> left, in Index<T> right) => left.Equals(right);

        /// <summary>Indicates whether the two values are not equal.</summary>
        /// <param name="left">The left argument.</param>
        /// <param name="right">The right argument.</param>
        /// <returns><see langword="true"/> if the two indices are not equal; otherwise, <see langword="false"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(in Index<T> left, in Index<T> right) => !left.Equals(right);

        /// <summary>Boxes the value with a index.</summary>
        /// <param name="value">The value of the index.</param>
        /// <returns>The index with the value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Index<T>(in T value) => new(value);

        /// <summary>Unboxes the value of the index, which is not from the end.</summary>
        /// <param name="index">The index.</param>
        /// <returns>The value of the index.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator T(in Index<T> index)
        {
            index.AssertNotFromEnd();
            return index.Value;
        }

        /// <summary>Uses <see cref="Convert.ChangeType(object, Type)"/> to convert the index to the specific generic type.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Index<T>(in Index index) => new(ConvertMarshaledValue(index.Value), index.IsFromEnd);

#endregion
    }
}
