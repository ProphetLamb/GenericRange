# Generic Range

[![NuGet](https://img.shields.io/nuget/v/GenericRange)](https://www.nuget.org/packages/GenericRange/)

## Motivation

In multiple projects I've missed `Range` implementations for `Enum`s and especially `TimeSpan`s, but couldn't quite find anything that works.
So instead of multiple implementation of the same thing, but with a different underlying `Type` this project attempts to provide a API similar to the existing, but with whatever primitive the user desires.

## Features

This project provides a generic implementation of `System.Range` and `System.Index` constraint to primitive Types (such as `int`, `char`, and `double`), as well as `Enum`, and `TimeSpan`.

### Supported Types

**Primitives**

Integer | Floating-point
--- | ---
`sbyte` | `float`
`byte` | `double`
`short` | `decimal`
`ushort` |
`int` |
`uint` |
`long` |
`ulong` |

**Others**

Type | Comment
--- | ---
`TimeSpan` | Handled as `long` by `TimeSpan.Ticks`
`Enum` | Arithmetic based on underlying type.

## Getting started

Install the [NuGet package](https://www.nuget.org/packages/GenericRange/)

```ps
dotnet add package GenericRange
```

## `System.Range` compatibility

`System.Range` and `System.Index` can be explicitly cast to `Range<T>`.

```csharp
Range range = 0..^1;
Range<long> longRange = (Range<long>)range;
```

This is only possible for `IConvertible` primitives, but not for `TimeSpan`, and `Enum` types.

```csharp
Range range = 0..^1;
Range<Foo> fooRange = (Range<Foo>)range; // Throws InvalidCastException
Range<TimeSpan> timeRange = (Range<TimeSpan>)range; // Throws InvalidCastException
```

In order to obtain a `System.Range` from a `Range<T>` the `ToRange<T>()` function can be used.

```csharp
Range<int> intRange = new(2, true, 1, true); // ^2..^1
Range range = intRange.ToRange();
```

Analogous to the `System.Range` -> `Range<T>` cast this only work for `IConvertible` primitives.

```csharp
Range<Foo> fooRange = (Foo.One, Foo.Eight); // Implicit cast from ValueTuple<T,T> to Range<T>
Range range = fooRange.ToRange(); // Throws InvalidCastException
```

## `Index<T>.IsFromEnd`

To obtain the absolute index - the so called offset - from an `Index<T>` or `Range<T>` the `GetOffset()` and `GetLengthAndOffset()` methods can be used.

```csharp
Range<double> doubleRange = new(12.04, 4, true); // 12.04..^4
double startOffset = doubleRange.Start.GetOffset(100.0); // = 12.04
(double offset, double length) = doubleRange.GetOffsetAndLength(100.0); // = (12.04, 96)
```

## Fancy `Range<Enum>.Mask`

Computes a bitmask (`long`) form the `Range<Enum>`.

```csharp
Range<Foo> rangeAll = new(Foo.None, Foo.None, true);

Foo mask = (Foo)rangeAll.Mask(Foo.Eight);

Assert.AreEqual(Foo.All, mask);
```

This example uses the following `Enum`.

```csharp
public enum Foo : byte
{
    None = 0,
    One = 1,
    Two = 2,
    Three = 4,
    Four = 8,
    Five = 16,
    Six = 32,
    Seven = 64,
    Eight = 128,
    All = 255
}
```

## For a more detained documentation

Read the [auto-generated](https://github.com/lijunle/Vsxmd) doc file [here](./src/doc.md).
