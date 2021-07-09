<a name='assembly'></a>
# GenericRange

## Contents

- [Index\`1](#T-GenericRange-Index`1 'GenericRange.Index`1')
  - [#ctor(value,fromEnd)](#M-GenericRange-Index`1-#ctor-`0@,System-Boolean- 'GenericRange.Index`1.#ctor(`0@,System.Boolean)')
  - [#ctor(value)](#M-GenericRange-Index`1-#ctor-`0@- 'GenericRange.Index`1.#ctor(`0@)')
  - [IsFromEnd](#P-GenericRange-Index`1-IsFromEnd 'GenericRange.Index`1.IsFromEnd')
  - [Value](#P-GenericRange-Index`1-Value 'GenericRange.Index`1.Value')
  - [CompareTo(other,length)](#M-GenericRange-Index`1-CompareTo-GenericRange-Index{`0}@,`0@- 'GenericRange.Index`1.CompareTo(GenericRange.Index{`0}@,`0@)')
  - [ConvertMarshaledValue\`\`1()](#M-GenericRange-Index`1-ConvertMarshaledValue``1-`0- 'GenericRange.Index`1.ConvertMarshaledValue``1(`0)')
  - [ConvertMarshaledValue\`\`1()](#M-GenericRange-Index`1-ConvertMarshaledValue``1-``0- 'GenericRange.Index`1.ConvertMarshaledValue``1(``0)')
  - [Equals(other,length)](#M-GenericRange-Index`1-Equals-GenericRange-Index{`0}@,`0@- 'GenericRange.Index`1.Equals(GenericRange.Index{`0}@,`0@)')
  - [GetOffset(length)](#M-GenericRange-Index`1-GetOffset-`0@- 'GenericRange.Index`1.GetOffset(`0@)')
  - [Max(left,right,length)](#M-GenericRange-Index`1-Max-GenericRange-Index{`0}@,GenericRange-Index{`0}@,`0@- 'GenericRange.Index`1.Max(GenericRange.Index{`0}@,GenericRange.Index{`0}@,`0@)')
  - [Max(left,right)](#M-GenericRange-Index`1-Max-GenericRange-Index{`0}@,GenericRange-Index{`0}@- 'GenericRange.Index`1.Max(GenericRange.Index{`0}@,GenericRange.Index{`0}@)')
  - [Min(left,right,length)](#M-GenericRange-Index`1-Min-GenericRange-Index{`0}@,GenericRange-Index{`0}@,`0@- 'GenericRange.Index`1.Min(GenericRange.Index{`0}@,GenericRange.Index{`0}@,`0@)')
  - [Min(left,right)](#M-GenericRange-Index`1-Min-GenericRange-Index{`0}@,GenericRange-Index{`0}@- 'GenericRange.Index`1.Min(GenericRange.Index{`0}@,GenericRange.Index{`0}@)')
  - [ToIndex\`\`1()](#M-GenericRange-Index`1-ToIndex``1 'GenericRange.Index`1.ToIndex``1')
  - [op_Explicit()](#M-GenericRange-Index`1-op_Explicit-System-Index@-~GenericRange-Index{`0} 'GenericRange.Index`1.op_Explicit(System.Index@)~GenericRange.Index{`0}')
- [RangeExtensions](#T-GenericRange-Extensions-RangeExtensions 'GenericRange.Extensions.RangeExtensions')
  - [Enumerate(range,length)](#M-GenericRange-Extensions-RangeExtensions-Enumerate-GenericRange-Range{System-Int64},System-Int64- 'GenericRange.Extensions.RangeExtensions.Enumerate(GenericRange.Range{System.Int64},System.Int64)')
  - [Enumerate(range,length)](#M-GenericRange-Extensions-RangeExtensions-Enumerate-GenericRange-Range{System-Int64}- 'GenericRange.Extensions.RangeExtensions.Enumerate(GenericRange.Range{System.Int64})')
  - [Enumerate(range,length)](#M-GenericRange-Extensions-RangeExtensions-Enumerate-GenericRange-Range{System-Int32},System-Int32- 'GenericRange.Extensions.RangeExtensions.Enumerate(GenericRange.Range{System.Int32},System.Int32)')
  - [Enumerate(range)](#M-GenericRange-Extensions-RangeExtensions-Enumerate-GenericRange-Range{System-Int32}- 'GenericRange.Extensions.RangeExtensions.Enumerate(GenericRange.Range{System.Int32})')
  - [Interpolate(range,length,percentage)](#M-GenericRange-Extensions-RangeExtensions-Interpolate-GenericRange-Range{System-Decimal},System-Decimal,System-Decimal- 'GenericRange.Extensions.RangeExtensions.Interpolate(GenericRange.Range{System.Decimal},System.Decimal,System.Decimal)')
  - [Interpolate(range,percentage)](#M-GenericRange-Extensions-RangeExtensions-Interpolate-GenericRange-Range{System-Decimal},System-Decimal- 'GenericRange.Extensions.RangeExtensions.Interpolate(GenericRange.Range{System.Decimal},System.Decimal)')
  - [Interpolate(range,length,percentage)](#M-GenericRange-Extensions-RangeExtensions-Interpolate-GenericRange-Range{System-Double},System-Double,System-Double- 'GenericRange.Extensions.RangeExtensions.Interpolate(GenericRange.Range{System.Double},System.Double,System.Double)')
  - [Interpolate(range,percentage)](#M-GenericRange-Extensions-RangeExtensions-Interpolate-GenericRange-Range{System-Double},System-Double- 'GenericRange.Extensions.RangeExtensions.Interpolate(GenericRange.Range{System.Double},System.Double)')
  - [Interpolate(range,percentage,length)](#M-GenericRange-Extensions-RangeExtensions-Interpolate-GenericRange-Range{System-Single},System-Single,System-Single- 'GenericRange.Extensions.RangeExtensions.Interpolate(GenericRange.Range{System.Single},System.Single,System.Single)')
  - [Interpolate(range,percentage)](#M-GenericRange-Extensions-RangeExtensions-Interpolate-GenericRange-Range{System-Single},System-Single- 'GenericRange.Extensions.RangeExtensions.Interpolate(GenericRange.Range{System.Single},System.Single)')
  - [Interpolate(range,percentage,length)](#M-GenericRange-Extensions-RangeExtensions-Interpolate-GenericRange-Range{System-Int32},System-Double,System-Int32- 'GenericRange.Extensions.RangeExtensions.Interpolate(GenericRange.Range{System.Int32},System.Double,System.Int32)')
  - [Interpolate(range,percentage)](#M-GenericRange-Extensions-RangeExtensions-Interpolate-GenericRange-Range{System-Int32},System-Double- 'GenericRange.Extensions.RangeExtensions.Interpolate(GenericRange.Range{System.Int32},System.Double)')
  - [Interpolate(range,percentage,length)](#M-GenericRange-Extensions-RangeExtensions-Interpolate-GenericRange-Range{System-Int64},System-Double,System-Int64- 'GenericRange.Extensions.RangeExtensions.Interpolate(GenericRange.Range{System.Int64},System.Double,System.Int64)')
  - [Interpolate(range,percentage)](#M-GenericRange-Extensions-RangeExtensions-Interpolate-GenericRange-Range{System-Int64},System-Double- 'GenericRange.Extensions.RangeExtensions.Interpolate(GenericRange.Range{System.Int64},System.Double)')
  - [Map(source,sourceLength,target,targetLength,value)](#M-GenericRange-Extensions-RangeExtensions-Map-GenericRange-Range{System-Decimal},System-Decimal,GenericRange-Range{System-Decimal}@,System-Decimal,GenericRange-Index{System-Decimal}@- 'GenericRange.Extensions.RangeExtensions.Map(GenericRange.Range{System.Decimal},System.Decimal,GenericRange.Range{System.Decimal}@,System.Decimal,GenericRange.Index{System.Decimal}@)')
  - [Map(source,target,value)](#M-GenericRange-Extensions-RangeExtensions-Map-GenericRange-Range{System-Decimal},GenericRange-Range{System-Decimal}@,GenericRange-Index{System-Decimal}@- 'GenericRange.Extensions.RangeExtensions.Map(GenericRange.Range{System.Decimal},GenericRange.Range{System.Decimal}@,GenericRange.Index{System.Decimal}@)')
  - [Map(source,sourceLength,target,targetLength,value)](#M-GenericRange-Extensions-RangeExtensions-Map-GenericRange-Range{System-Double},System-Double,GenericRange-Range{System-Double}@,System-Double,GenericRange-Index{System-Double}@- 'GenericRange.Extensions.RangeExtensions.Map(GenericRange.Range{System.Double},System.Double,GenericRange.Range{System.Double}@,System.Double,GenericRange.Index{System.Double}@)')
  - [Map(source,target,value)](#M-GenericRange-Extensions-RangeExtensions-Map-GenericRange-Range{System-Double},GenericRange-Range{System-Double}@,GenericRange-Index{System-Double}@- 'GenericRange.Extensions.RangeExtensions.Map(GenericRange.Range{System.Double},GenericRange.Range{System.Double}@,GenericRange.Index{System.Double}@)')
  - [Map(source,sourceLength,target,targetLength,value)](#M-GenericRange-Extensions-RangeExtensions-Map-GenericRange-Range{System-Single},System-Single,GenericRange-Range{System-Single}@,System-Single,GenericRange-Index{System-Single}@- 'GenericRange.Extensions.RangeExtensions.Map(GenericRange.Range{System.Single},System.Single,GenericRange.Range{System.Single}@,System.Single,GenericRange.Index{System.Single}@)')
  - [Map(source,target,value)](#M-GenericRange-Extensions-RangeExtensions-Map-GenericRange-Range{System-Single},GenericRange-Range{System-Single}@,GenericRange-Index{System-Single}@- 'GenericRange.Extensions.RangeExtensions.Map(GenericRange.Range{System.Single},GenericRange.Range{System.Single}@,GenericRange.Index{System.Single}@)')
  - [Map(source,sourceLength,target,targetLength,value)](#M-GenericRange-Extensions-RangeExtensions-Map-GenericRange-Range{System-Int64},System-Int64,GenericRange-Range{System-Int64}@,System-Int64,GenericRange-Index{System-Int64}@- 'GenericRange.Extensions.RangeExtensions.Map(GenericRange.Range{System.Int64},System.Int64,GenericRange.Range{System.Int64}@,System.Int64,GenericRange.Index{System.Int64}@)')
  - [Map(source,target,value)](#M-GenericRange-Extensions-RangeExtensions-Map-GenericRange-Range{System-Int64},GenericRange-Range{System-Int64}@,GenericRange-Index{System-Int64}@- 'GenericRange.Extensions.RangeExtensions.Map(GenericRange.Range{System.Int64},GenericRange.Range{System.Int64}@,GenericRange.Index{System.Int64}@)')
  - [Map(source,sourceLength,target,targetLength,value,rounding)](#M-GenericRange-Extensions-RangeExtensions-Map-GenericRange-Range{System-Int64},System-Int64,GenericRange-Range{System-Int64}@,System-Int64,GenericRange-Index{System-Int64}@,System-MidpointRounding- 'GenericRange.Extensions.RangeExtensions.Map(GenericRange.Range{System.Int64},System.Int64,GenericRange.Range{System.Int64}@,System.Int64,GenericRange.Index{System.Int64}@,System.MidpointRounding)')
  - [Map(source,target,value,rounding)](#M-GenericRange-Extensions-RangeExtensions-Map-GenericRange-Range{System-Int64},GenericRange-Range{System-Int64}@,GenericRange-Index{System-Int64}@,System-MidpointRounding- 'GenericRange.Extensions.RangeExtensions.Map(GenericRange.Range{System.Int64},GenericRange.Range{System.Int64}@,GenericRange.Index{System.Int64}@,System.MidpointRounding)')
  - [Map(source,sourceLength,target,targetLength,value)](#M-GenericRange-Extensions-RangeExtensions-Map-GenericRange-Range{System-Int32},System-Int32,GenericRange-Range{System-Int32}@,System-Int32,GenericRange-Index{System-Int32}@- 'GenericRange.Extensions.RangeExtensions.Map(GenericRange.Range{System.Int32},System.Int32,GenericRange.Range{System.Int32}@,System.Int32,GenericRange.Index{System.Int32}@)')
  - [Map(source,target,value)](#M-GenericRange-Extensions-RangeExtensions-Map-GenericRange-Range{System-Int32},GenericRange-Range{System-Int32}@,GenericRange-Index{System-Int32}@- 'GenericRange.Extensions.RangeExtensions.Map(GenericRange.Range{System.Int32},GenericRange.Range{System.Int32}@,GenericRange.Index{System.Int32}@)')
  - [Map(source,sourceLength,target,targetLength,value,rounding)](#M-GenericRange-Extensions-RangeExtensions-Map-GenericRange-Range{System-Int32},System-Int32,GenericRange-Range{System-Int32}@,System-Int32,GenericRange-Index{System-Int32}@,System-MidpointRounding- 'GenericRange.Extensions.RangeExtensions.Map(GenericRange.Range{System.Int32},System.Int32,GenericRange.Range{System.Int32}@,System.Int32,GenericRange.Index{System.Int32}@,System.MidpointRounding)')
  - [Map(source,target,value,rounding)](#M-GenericRange-Extensions-RangeExtensions-Map-GenericRange-Range{System-Int32},GenericRange-Range{System-Int32}@,GenericRange-Index{System-Int32}@,System-MidpointRounding- 'GenericRange.Extensions.RangeExtensions.Map(GenericRange.Range{System.Int32},GenericRange.Range{System.Int32}@,GenericRange.Index{System.Int32}@,System.MidpointRounding)')
  - [Mask\`\`1(range)](#M-GenericRange-Extensions-RangeExtensions-Mask``1-GenericRange-Range{``0}- 'GenericRange.Extensions.RangeExtensions.Mask``1(GenericRange.Range{``0})')
  - [Mask\`\`1(range,maximum)](#M-GenericRange-Extensions-RangeExtensions-Mask``1-GenericRange-Range{``0},``0- 'GenericRange.Extensions.RangeExtensions.Mask``1(GenericRange.Range{``0},``0)')
  - [PercentageOf(range,value,length)](#M-GenericRange-Extensions-RangeExtensions-PercentageOf-GenericRange-Range{System-Decimal},GenericRange-Index{System-Decimal}@,System-Decimal- 'GenericRange.Extensions.RangeExtensions.PercentageOf(GenericRange.Range{System.Decimal},GenericRange.Index{System.Decimal}@,System.Decimal)')
  - [PercentageOf(range,value)](#M-GenericRange-Extensions-RangeExtensions-PercentageOf-GenericRange-Range{System-Decimal},GenericRange-Index{System-Decimal}@- 'GenericRange.Extensions.RangeExtensions.PercentageOf(GenericRange.Range{System.Decimal},GenericRange.Index{System.Decimal}@)')
  - [PercentageOf(range,value,length)](#M-GenericRange-Extensions-RangeExtensions-PercentageOf-GenericRange-Range{System-Double},GenericRange-Index{System-Double}@,System-Double- 'GenericRange.Extensions.RangeExtensions.PercentageOf(GenericRange.Range{System.Double},GenericRange.Index{System.Double}@,System.Double)')
  - [PercentageOf(range,value)](#M-GenericRange-Extensions-RangeExtensions-PercentageOf-GenericRange-Range{System-Double},GenericRange-Index{System-Double}@- 'GenericRange.Extensions.RangeExtensions.PercentageOf(GenericRange.Range{System.Double},GenericRange.Index{System.Double}@)')
  - [PercentageOf(range,value,length)](#M-GenericRange-Extensions-RangeExtensions-PercentageOf-GenericRange-Range{System-Single},GenericRange-Index{System-Single}@,System-Single- 'GenericRange.Extensions.RangeExtensions.PercentageOf(GenericRange.Range{System.Single},GenericRange.Index{System.Single}@,System.Single)')
  - [PercentageOf(range,value)](#M-GenericRange-Extensions-RangeExtensions-PercentageOf-GenericRange-Range{System-Single},GenericRange-Index{System-Single}@- 'GenericRange.Extensions.RangeExtensions.PercentageOf(GenericRange.Range{System.Single},GenericRange.Index{System.Single}@)')
  - [PercentageOf(range,value,length)](#M-GenericRange-Extensions-RangeExtensions-PercentageOf-GenericRange-Range{System-Int64},GenericRange-Index{System-Int64}@,System-Int64- 'GenericRange.Extensions.RangeExtensions.PercentageOf(GenericRange.Range{System.Int64},GenericRange.Index{System.Int64}@,System.Int64)')
  - [PercentageOf(range,value)](#M-GenericRange-Extensions-RangeExtensions-PercentageOf-GenericRange-Range{System-Int64},GenericRange-Index{System-Int64}@- 'GenericRange.Extensions.RangeExtensions.PercentageOf(GenericRange.Range{System.Int64},GenericRange.Index{System.Int64}@)')
  - [PercentageOf(range,value,length)](#M-GenericRange-Extensions-RangeExtensions-PercentageOf-GenericRange-Range{System-Int32},GenericRange-Index{System-Int32}@,System-Int32- 'GenericRange.Extensions.RangeExtensions.PercentageOf(GenericRange.Range{System.Int32},GenericRange.Index{System.Int32}@,System.Int32)')
  - [PercentageOf(range,value)](#M-GenericRange-Extensions-RangeExtensions-PercentageOf-GenericRange-Range{System-Int32},GenericRange-Index{System-Int32}@- 'GenericRange.Extensions.RangeExtensions.PercentageOf(GenericRange.Range{System.Int32},GenericRange.Index{System.Int32}@)')
  - [ToIndex\`\`1(index)](#M-GenericRange-Extensions-RangeExtensions-ToIndex``1-GenericRange-Index{``0}- 'GenericRange.Extensions.RangeExtensions.ToIndex``1(GenericRange.Index{``0})')
  - [ToRange\`\`1(range)](#M-GenericRange-Extensions-RangeExtensions-ToRange``1-GenericRange-Range{``0}- 'GenericRange.Extensions.RangeExtensions.ToRange``1(GenericRange.Range{``0})')
- [Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1')
  - [#ctor(start,end)](#M-GenericRange-Range`1-#ctor-GenericRange-Index{`0}@,GenericRange-Index{`0}@- 'GenericRange.Range`1.#ctor(GenericRange.Index{`0}@,GenericRange.Index{`0}@)')
  - [#ctor(start,startFromEnd,end,endFromEnd)](#M-GenericRange-Range`1-#ctor-`0@,System-Boolean,`0@,System-Boolean- 'GenericRange.Range`1.#ctor(`0@,System.Boolean,`0@,System.Boolean)')
  - [#ctor(start,startFromEnd,end)](#M-GenericRange-Range`1-#ctor-`0@,System-Boolean,`0@- 'GenericRange.Range`1.#ctor(`0@,System.Boolean,`0@)')
  - [#ctor(start,end,endFromEnd)](#M-GenericRange-Range`1-#ctor-`0@,`0@,System-Boolean- 'GenericRange.Range`1.#ctor(`0@,`0@,System.Boolean)')
  - [End](#P-GenericRange-Range`1-End 'GenericRange.Range`1.End')
  - [Start](#P-GenericRange-Range`1-Start 'GenericRange.Range`1.Start')
  - [Clamp(other,length)](#M-GenericRange-Range`1-Clamp-GenericRange-Range{`0}@,`0@- 'GenericRange.Range`1.Clamp(GenericRange.Range{`0}@,`0@)')
  - [Clamp(other)](#M-GenericRange-Range`1-Clamp-GenericRange-Range{`0}@- 'GenericRange.Range`1.Clamp(GenericRange.Range{`0}@)')
  - [Contains(value,length)](#M-GenericRange-Range`1-Contains-GenericRange-Index{`0}@,`0@- 'GenericRange.Range`1.Contains(GenericRange.Index{`0}@,`0@)')
  - [Contains(value)](#M-GenericRange-Range`1-Contains-GenericRange-Index{`0}@- 'GenericRange.Range`1.Contains(GenericRange.Index{`0}@)')
  - [Encompasses(other,length)](#M-GenericRange-Range`1-Encompasses-GenericRange-Range{`0}@,`0@- 'GenericRange.Range`1.Encompasses(GenericRange.Range{`0}@,`0@)')
  - [Encompasses(other)](#M-GenericRange-Range`1-Encompasses-GenericRange-Range{`0}@- 'GenericRange.Range`1.Encompasses(GenericRange.Range{`0}@)')
  - [Equals(other,length)](#M-GenericRange-Range`1-Equals-GenericRange-Range{`0}@,`0@- 'GenericRange.Range`1.Equals(GenericRange.Range{`0}@,`0@)')
  - [GetLeftPart(endIndex)](#M-GenericRange-Range`1-GetLeftPart-GenericRange-Index{`0}@- 'GenericRange.Range`1.GetLeftPart(GenericRange.Index{`0}@)')
  - [GetOffsetAndLength(length)](#M-GenericRange-Range`1-GetOffsetAndLength-`0@- 'GenericRange.Range`1.GetOffsetAndLength(`0@)')
  - [GetOffsetAndLength()](#M-GenericRange-Range`1-GetOffsetAndLength 'GenericRange.Range`1.GetOffsetAndLength')
  - [GetRightPart(startIndex)](#M-GenericRange-Range`1-GetRightPart-GenericRange-Index{`0}@- 'GenericRange.Range`1.GetRightPart(GenericRange.Index{`0}@)')
  - [Intersects(other,length)](#M-GenericRange-Range`1-Intersects-GenericRange-Range{`0}@,`0@- 'GenericRange.Range`1.Intersects(GenericRange.Range{`0}@,`0@)')
  - [Intersects(other)](#M-GenericRange-Range`1-Intersects-GenericRange-Range{`0}@- 'GenericRange.Range`1.Intersects(GenericRange.Range{`0}@)')
  - [Span(other,length)](#M-GenericRange-Range`1-Span-GenericRange-Range{`0}@,`0@- 'GenericRange.Range`1.Span(GenericRange.Range{`0}@,`0@)')
  - [Span(other)](#M-GenericRange-Range`1-Span-GenericRange-Range{`0}@- 'GenericRange.Range`1.Span(GenericRange.Range{`0}@)')
  - [ToRange\`\`1()](#M-GenericRange-Range`1-ToRange``1 'GenericRange.Range`1.ToRange``1')
  - [Union(other,length)](#M-GenericRange-Range`1-Union-GenericRange-Range{`0}@,`0@- 'GenericRange.Range`1.Union(GenericRange.Range{`0}@,`0@)')
  - [Union(other)](#M-GenericRange-Range`1-Union-GenericRange-Range{`0}@- 'GenericRange.Range`1.Union(GenericRange.Range{`0}@)')
  - [op_Explicit()](#M-GenericRange-Range`1-op_Explicit-System-Range@-~GenericRange-Range{`0} 'GenericRange.Range`1.op_Explicit(System.Range@)~GenericRange.Range{`0}')
- [ValueStringBuilder](#T-GenericRange-Utility-ValueStringBuilder 'GenericRange.Utility.ValueStringBuilder')
  - [RawChars](#P-GenericRange-Utility-ValueStringBuilder-RawChars 'GenericRange.Utility.ValueStringBuilder.RawChars')
  - [AsSpan(terminate)](#M-GenericRange-Utility-ValueStringBuilder-AsSpan-System-Boolean- 'GenericRange.Utility.ValueStringBuilder.AsSpan(System.Boolean)')
  - [GetPinnableReference()](#M-GenericRange-Utility-ValueStringBuilder-GetPinnableReference 'GenericRange.Utility.ValueStringBuilder.GetPinnableReference')
  - [GetPinnableReference(terminate)](#M-GenericRange-Utility-ValueStringBuilder-GetPinnableReference-System-Boolean- 'GenericRange.Utility.ValueStringBuilder.GetPinnableReference(System.Boolean)')
  - [Grow(additionalCapacityBeyondPos)](#M-GenericRange-Utility-ValueStringBuilder-Grow-System-Int32- 'GenericRange.Utility.ValueStringBuilder.Grow(System.Int32)')

<a name='T-GenericRange-Index`1'></a>
## Index\`1 `type`

##### Namespace

GenericRange

##### Summary

Represents a type that can be used to index a collection either from the start or the end.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The primitive type of the index, one of `sbyte`, `byte`, `short`, `ushort`, `int`,
    `uint`, `long`, `ulong`, `float`, `double`, `decimal`, `char`,
    `TimeSpan`, or any [Enum](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Enum 'System.Enum') type with one of the aforementioned as underlying type. |

<a name='M-GenericRange-Index`1-#ctor-`0@,System-Boolean-'></a>
### #ctor(value,fromEnd) `constructor`

##### Summary

Construct an [Index\`1](#T-GenericRange-Index`1 'GenericRange.Index`1') using a value and indicating if the index is from the start or from the end.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [\`0@](#T-`0@ '`0@') | The index value. |
| fromEnd | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Indicating if the index is from the start or from the end. |

##### Remarks

If the [Index\`1](#T-GenericRange-Index`1 'GenericRange.Index`1') constructed from the end, index value 1 means pointing at the last element and index value 0 means pointing at beyond last element.

<a name='M-GenericRange-Index`1-#ctor-`0@-'></a>
### #ctor(value) `constructor`

##### Summary

Construct an [Index\`1](#T-GenericRange-Index`1 'GenericRange.Index`1') from the start using a value.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [\`0@](#T-`0@ '`0@') | The index value. |

<a name='P-GenericRange-Index`1-IsFromEnd'></a>
### IsFromEnd `property`

##### Summary

Indicates whether the index is from the start or the end.

<a name='P-GenericRange-Index`1-Value'></a>
### Value `property`

##### Summary

Returns the index value.

<a name='M-GenericRange-Index`1-CompareTo-GenericRange-Index{`0}@,`0@-'></a>
### CompareTo(other,length) `method`

##### Summary

Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes,
    follows, or occurs in the same position in the sort order as the other object.

##### Returns

A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance precedes
    other in the sort order. Zero This instance occurs in the same position in the sort order as other. Greater than zero This instance follows other in the sort order.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| other | [GenericRange.Index{\`0}@](#T-GenericRange-Index{`0}@ 'GenericRange.Index{`0}@') | An object to compare with this instance. |
| length | [\`0@](#T-`0@ '`0@') | The length of the set. |

<a name='M-GenericRange-Index`1-ConvertMarshaledValue``1-`0-'></a>
### ConvertMarshaledValue\`\`1() `method`

##### Summary

Ensure that T is TOut or IConvertible.

##### Parameters

This method has no parameters.

<a name='M-GenericRange-Index`1-ConvertMarshaledValue``1-``0-'></a>
### ConvertMarshaledValue\`\`1() `method`

##### Summary

Ensure that T is TIn or IConvertible.

##### Parameters

This method has no parameters.

<a name='M-GenericRange-Index`1-Equals-GenericRange-Index{`0}@,`0@-'></a>
### Equals(other,length) `method`

##### Summary

Indicates whether the [Index\`1](#T-GenericRange-Index`1 'GenericRange.Index`1') points to the same element in a set.

##### Returns

`true` if the current object is equal to the other parameter; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| other | [GenericRange.Index{\`0}@](#T-GenericRange-Index{`0}@ 'GenericRange.Index{`0}@') | An object to compare with this object. |
| length | [\`0@](#T-`0@ '`0@') | The length of the collection. |

<a name='M-GenericRange-Index`1-GetOffset-`0@-'></a>
### GetOffset(length) `method`

##### Summary

Returns the offset from the start of a set.

##### Returns

The offset from the start of a set.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| length | [\`0@](#T-`0@ '`0@') | The length of the set. |

<a name='M-GenericRange-Index`1-Max-GenericRange-Index{`0}@,GenericRange-Index{`0}@,`0@-'></a>
### Max(left,right,length) `method`

##### Summary

Returns the [Index\`1](#T-GenericRange-Index`1 'GenericRange.Index`1') that points to the element with the higher index of two indices.

##### Returns

The greater [Index\`1](#T-GenericRange-Index`1 'GenericRange.Index`1').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [GenericRange.Index{\`0}@](#T-GenericRange-Index{`0}@ 'GenericRange.Index{`0}@') | The first index. |
| right | [GenericRange.Index{\`0}@](#T-GenericRange-Index{`0}@ 'GenericRange.Index{`0}@') | The second index. |
| length | [\`0@](#T-`0@ '`0@') | The length of the set. |

<a name='M-GenericRange-Index`1-Max-GenericRange-Index{`0}@,GenericRange-Index{`0}@-'></a>
### Max(left,right) `method`

##### Summary

Returns the greater of the two indices.

##### Returns

The greater [Index\`1](#T-GenericRange-Index`1 'GenericRange.Index`1').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [GenericRange.Index{\`0}@](#T-GenericRange-Index{`0}@ 'GenericRange.Index{`0}@') | The first index. |
| right | [GenericRange.Index{\`0}@](#T-GenericRange-Index{`0}@ 'GenericRange.Index{`0}@') | The second index. |

##### Remarks

Disallows [IsFromEnd](#P-GenericRange-Index`1-IsFromEnd 'GenericRange.Index`1.IsFromEnd') in favour of performance.

<a name='M-GenericRange-Index`1-Min-GenericRange-Index{`0}@,GenericRange-Index{`0}@,`0@-'></a>
### Min(left,right,length) `method`

##### Summary

Returns the [Index\`1](#T-GenericRange-Index`1 'GenericRange.Index`1') that points to the element with the lower index of two indices.

##### Returns

The smaller [Index\`1](#T-GenericRange-Index`1 'GenericRange.Index`1').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [GenericRange.Index{\`0}@](#T-GenericRange-Index{`0}@ 'GenericRange.Index{`0}@') | The first index. |
| right | [GenericRange.Index{\`0}@](#T-GenericRange-Index{`0}@ 'GenericRange.Index{`0}@') | The second index. |
| length | [\`0@](#T-`0@ '`0@') | The length of the set. |

<a name='M-GenericRange-Index`1-Min-GenericRange-Index{`0}@,GenericRange-Index{`0}@-'></a>
### Min(left,right) `method`

##### Summary

Returns the smaller of the two indices.

##### Returns

The smaller [Index\`1](#T-GenericRange-Index`1 'GenericRange.Index`1').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| left | [GenericRange.Index{\`0}@](#T-GenericRange-Index{`0}@ 'GenericRange.Index{`0}@') | The first index. |
| right | [GenericRange.Index{\`0}@](#T-GenericRange-Index{`0}@ 'GenericRange.Index{`0}@') | The second index. |

##### Remarks

Disallows [IsFromEnd](#P-GenericRange-Index`1-IsFromEnd 'GenericRange.Index`1.IsFromEnd') in favour of performance.

<a name='M-GenericRange-Index`1-ToIndex``1'></a>
### ToIndex\`\`1() `method`

##### Summary

Converts the [Value](#P-GenericRange-Index`1-Value 'GenericRange.Index`1.Value') to the specified type.

##### Returns

A new [Index\`1](#T-GenericRange-Index`1 'GenericRange.Index`1') of the desired type.

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TOut | The type to convert to. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.InvalidCastException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidCastException 'System.InvalidCastException') | This conversion is not supported. -or- value is null and conversionType is a value type. -or- value does not implement the IConvertible interface. |

##### Remarks

Uses [ChangeType](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Convert.ChangeType 'System.Convert.ChangeType(System.Object,System.Type)'), but the generic constraints do not ensure that the Types are IConvertible use at own discretion.

<a name='M-GenericRange-Index`1-op_Explicit-System-Index@-~GenericRange-Index{`0}'></a>
### op_Explicit() `method`

##### Summary

Uses [ChangeType](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Convert.ChangeType 'System.Convert.ChangeType(System.Object,System.Type)') to convert the index to the specific generic type.

##### Parameters

This method has no parameters.

<a name='T-GenericRange-Extensions-RangeExtensions'></a>
## RangeExtensions `type`

##### Namespace

GenericRange.Extensions

<a name='M-GenericRange-Extensions-RangeExtensions-Enumerate-GenericRange-Range{System-Int64},System-Int64-'></a>
### Enumerate(range,length) `method`

##### Summary

Enumerates all integers in the [Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1'), from start inclusive and end inclusive.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| range | [GenericRange.Range{System.Int64}](#T-GenericRange-Range{System-Int64} 'GenericRange.Range{System.Int64}') | The range. |
| length | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | The length. |

<a name='M-GenericRange-Extensions-RangeExtensions-Enumerate-GenericRange-Range{System-Int64}-'></a>
### Enumerate(range,length) `method`

##### Summary

Enumerates all integers in the [Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1'), from start inclusive and end inclusive.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| range | [GenericRange.Range{System.Int64}](#T-GenericRange-Range{System-Int64} 'GenericRange.Range{System.Int64}') | The range. |

##### Remarks

Disallows [IsFromEnd](#P-GenericRange-Index`1-IsFromEnd 'GenericRange.Index`1.IsFromEnd') in favour of performance.

<a name='M-GenericRange-Extensions-RangeExtensions-Enumerate-GenericRange-Range{System-Int32},System-Int32-'></a>
### Enumerate(range,length) `method`

##### Summary

Enumerates all integers in the [Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1'), from start inclusive and end inclusive.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| range | [GenericRange.Range{System.Int32}](#T-GenericRange-Range{System-Int32} 'GenericRange.Range{System.Int32}') | The range. |
| length | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The length. |

<a name='M-GenericRange-Extensions-RangeExtensions-Enumerate-GenericRange-Range{System-Int32}-'></a>
### Enumerate(range) `method`

##### Summary

Enumerates all integers in the [Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1'), from start inclusive and end inclusive.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| range | [GenericRange.Range{System.Int32}](#T-GenericRange-Range{System-Int32} 'GenericRange.Range{System.Int32}') | The range. |

##### Remarks

Disallows [IsFromEnd](#P-GenericRange-Index`1-IsFromEnd 'GenericRange.Index`1.IsFromEnd') in favour of performance.

<a name='M-GenericRange-Extensions-RangeExtensions-Interpolate-GenericRange-Range{System-Decimal},System-Decimal,System-Decimal-'></a>
### Interpolate(range,length,percentage) `method`

##### Summary

Interpolates the `range` linearly by a `percentage`.

##### Returns

The interpolated value.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| range | [GenericRange.Range{System.Decimal}](#T-GenericRange-Range{System-Decimal} 'GenericRange.Range{System.Decimal}') | The range. |
| length | [System.Decimal](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Decimal 'System.Decimal') | The length of the collection. |
| percentage | [System.Decimal](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Decimal 'System.Decimal') | The percentage to interpolate with, 0.00 returns [Start](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Range.Start 'System.Range.Start'), and 1.00 returns [End](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Range.End 'System.Range.End'). |

<a name='M-GenericRange-Extensions-RangeExtensions-Interpolate-GenericRange-Range{System-Decimal},System-Decimal-'></a>
### Interpolate(range,percentage) `method`

##### Summary

Interpolates the `range` linearly by a `percentage`.

##### Returns

The interpolated value.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| range | [GenericRange.Range{System.Decimal}](#T-GenericRange-Range{System-Decimal} 'GenericRange.Range{System.Decimal}') | The range. |
| percentage | [System.Decimal](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Decimal 'System.Decimal') | The percentage to interpolate with, 0.00 returns [Start](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Range.Start 'System.Range.Start'), and 1.00 returns [End](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Range.End 'System.Range.End'). |

##### Remarks

Disallows [IsFromEnd](#P-GenericRange-Index`1-IsFromEnd 'GenericRange.Index`1.IsFromEnd') in favour of performance.

<a name='M-GenericRange-Extensions-RangeExtensions-Interpolate-GenericRange-Range{System-Double},System-Double,System-Double-'></a>
### Interpolate(range,length,percentage) `method`

##### Summary

Interpolates the `range` linearly by a `percentage`.

##### Returns

The interpolated value.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| range | [GenericRange.Range{System.Double}](#T-GenericRange-Range{System-Double} 'GenericRange.Range{System.Double}') | The range. |
| length | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') | The length of the collection. |
| percentage | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') | The percentage to interpolate with, 0.00 returns [Start](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Range.Start 'System.Range.Start'), and 1.00 returns [End](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Range.End 'System.Range.End'). |

<a name='M-GenericRange-Extensions-RangeExtensions-Interpolate-GenericRange-Range{System-Double},System-Double-'></a>
### Interpolate(range,percentage) `method`

##### Summary

Interpolates the `range` linearly by a `percentage`.

##### Returns

The interpolated value.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| range | [GenericRange.Range{System.Double}](#T-GenericRange-Range{System-Double} 'GenericRange.Range{System.Double}') | The range. |
| percentage | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') | The percentage to interpolate with, 0.00 returns [Start](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Range.Start 'System.Range.Start'), and 1.00 returns [End](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Range.End 'System.Range.End'). |

##### Remarks

Disallows [IsFromEnd](#P-GenericRange-Index`1-IsFromEnd 'GenericRange.Index`1.IsFromEnd') in favour of performance.

<a name='M-GenericRange-Extensions-RangeExtensions-Interpolate-GenericRange-Range{System-Single},System-Single,System-Single-'></a>
### Interpolate(range,percentage,length) `method`

##### Summary

Interpolates the `range` linearly by a `percentage`.

##### Returns

The interpolated value.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| range | [GenericRange.Range{System.Single}](#T-GenericRange-Range{System-Single} 'GenericRange.Range{System.Single}') | The range. |
| percentage | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') | The percentage to interpolate with, 0.00 returns [Start](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Range.Start 'System.Range.Start'), and 1.00 returns [End](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Range.End 'System.Range.End'). |
| length | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') | The length of the collection. |

<a name='M-GenericRange-Extensions-RangeExtensions-Interpolate-GenericRange-Range{System-Single},System-Single-'></a>
### Interpolate(range,percentage) `method`

##### Summary

Interpolates the `range` linearly by a `percentage`.

##### Returns

The interpolated value.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| range | [GenericRange.Range{System.Single}](#T-GenericRange-Range{System-Single} 'GenericRange.Range{System.Single}') | The range. |
| percentage | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') | The percentage to interpolate with, 0.00 returns [Start](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Range.Start 'System.Range.Start'), and 1.00 returns [End](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Range.End 'System.Range.End'). |

##### Remarks

Disallows [IsFromEnd](#P-GenericRange-Index`1-IsFromEnd 'GenericRange.Index`1.IsFromEnd') in favour of performance.

<a name='M-GenericRange-Extensions-RangeExtensions-Interpolate-GenericRange-Range{System-Int32},System-Double,System-Int32-'></a>
### Interpolate(range,percentage,length) `method`

##### Summary

Interpolates the `range` linearly by a `percentage`.

##### Returns

The interpolated value.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| range | [GenericRange.Range{System.Int32}](#T-GenericRange-Range{System-Int32} 'GenericRange.Range{System.Int32}') | The range. |
| percentage | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') | The percentage to interpolate with, 0.00 returns [Start](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Range.Start 'System.Range.Start'), and 1.00 returns [End](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Range.End 'System.Range.End'). |
| length | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The length of the collection. |

<a name='M-GenericRange-Extensions-RangeExtensions-Interpolate-GenericRange-Range{System-Int32},System-Double-'></a>
### Interpolate(range,percentage) `method`

##### Summary

Interpolates the `range` linearly by a `percentage`.

##### Returns

The interpolated value.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| range | [GenericRange.Range{System.Int32}](#T-GenericRange-Range{System-Int32} 'GenericRange.Range{System.Int32}') | The range. |
| percentage | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') | The percentage to interpolate with, 0.00 returns [Start](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Range.Start 'System.Range.Start'), and 1.00 returns [End](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Range.End 'System.Range.End'). |

##### Remarks

Disallows [IsFromEnd](#P-GenericRange-Index`1-IsFromEnd 'GenericRange.Index`1.IsFromEnd') in favour of performance.

<a name='M-GenericRange-Extensions-RangeExtensions-Interpolate-GenericRange-Range{System-Int64},System-Double,System-Int64-'></a>
### Interpolate(range,percentage,length) `method`

##### Summary

Interpolates the `range` linearly by a `percentage`.

##### Returns

The interpolated value.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| range | [GenericRange.Range{System.Int64}](#T-GenericRange-Range{System-Int64} 'GenericRange.Range{System.Int64}') | The range. |
| percentage | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') | The percentage to interpolate with, 0.00 returns [Start](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Range.Start 'System.Range.Start'), and 1.00 returns [End](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Range.End 'System.Range.End'). |
| length | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | The length of the collection. |

<a name='M-GenericRange-Extensions-RangeExtensions-Interpolate-GenericRange-Range{System-Int64},System-Double-'></a>
### Interpolate(range,percentage) `method`

##### Summary

Interpolates the `range` linearly by a `percentage`.

##### Returns

The interpolated value.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| range | [GenericRange.Range{System.Int64}](#T-GenericRange-Range{System-Int64} 'GenericRange.Range{System.Int64}') | The range. |
| percentage | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') | The percentage to interpolate with, 0.00 returns [Start](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Range.Start 'System.Range.Start'), and 1.00 returns [End](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Range.End 'System.Range.End'). |

##### Remarks

Disallows [IsFromEnd](#P-GenericRange-Index`1-IsFromEnd 'GenericRange.Index`1.IsFromEnd') in favour of performance.

<a name='M-GenericRange-Extensions-RangeExtensions-Map-GenericRange-Range{System-Decimal},System-Decimal,GenericRange-Range{System-Decimal}@,System-Decimal,GenericRange-Index{System-Decimal}@-'></a>
### Map(source,sourceLength,target,targetLength,value) `method`

##### Summary

Interpolates the value from the `source`[Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1') to the [](#!-target 'target') range.

##### Returns

The `value` mapped to the `target` range.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [GenericRange.Range{System.Decimal}](#T-GenericRange-Range{System-Decimal} 'GenericRange.Range{System.Decimal}') | The range within the `value` exists. |
| sourceLength | [System.Decimal](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Decimal 'System.Decimal') | The length of the source set. |
| target | [GenericRange.Range{System.Decimal}@](#T-GenericRange-Range{System-Decimal}@ 'GenericRange.Range{System.Decimal}@') | The range to map the `value` to. |
| targetLength | [System.Decimal](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Decimal 'System.Decimal') | The length of the target set. |
| value | [GenericRange.Index{System.Decimal}@](#T-GenericRange-Index{System-Decimal}@ 'GenericRange.Index{System.Decimal}@') | The value. |

<a name='M-GenericRange-Extensions-RangeExtensions-Map-GenericRange-Range{System-Decimal},GenericRange-Range{System-Decimal}@,GenericRange-Index{System-Decimal}@-'></a>
### Map(source,target,value) `method`

##### Summary

Interpolates the value from the `source`[Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1') to the [](#!-target 'target') range.

##### Returns

The `value` mapped to the `target` range.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [GenericRange.Range{System.Decimal}](#T-GenericRange-Range{System-Decimal} 'GenericRange.Range{System.Decimal}') | The range within the `value` exists. |
| target | [GenericRange.Range{System.Decimal}@](#T-GenericRange-Range{System-Decimal}@ 'GenericRange.Range{System.Decimal}@') | The range to map the `value` to. |
| value | [GenericRange.Index{System.Decimal}@](#T-GenericRange-Index{System-Decimal}@ 'GenericRange.Index{System.Decimal}@') | The value. |

##### Remarks

Disallows [IsFromEnd](#P-GenericRange-Index`1-IsFromEnd 'GenericRange.Index`1.IsFromEnd') in favour of performance.

<a name='M-GenericRange-Extensions-RangeExtensions-Map-GenericRange-Range{System-Double},System-Double,GenericRange-Range{System-Double}@,System-Double,GenericRange-Index{System-Double}@-'></a>
### Map(source,sourceLength,target,targetLength,value) `method`

##### Summary

Interpolates the value from the `source`[Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1') to the [](#!-target 'target') range.

##### Returns

The `value` mapped to the `target` range.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [GenericRange.Range{System.Double}](#T-GenericRange-Range{System-Double} 'GenericRange.Range{System.Double}') | The range within the `value` exists. |
| sourceLength | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') | The length of the source set. |
| target | [GenericRange.Range{System.Double}@](#T-GenericRange-Range{System-Double}@ 'GenericRange.Range{System.Double}@') | The range to map the `value` to. |
| targetLength | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') | The length of the target set. |
| value | [GenericRange.Index{System.Double}@](#T-GenericRange-Index{System-Double}@ 'GenericRange.Index{System.Double}@') | The value. |

<a name='M-GenericRange-Extensions-RangeExtensions-Map-GenericRange-Range{System-Double},GenericRange-Range{System-Double}@,GenericRange-Index{System-Double}@-'></a>
### Map(source,target,value) `method`

##### Summary

Interpolates the value from the `source`[Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1') to the [](#!-target 'target') range.

##### Returns

The `value` mapped to the `target` range.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [GenericRange.Range{System.Double}](#T-GenericRange-Range{System-Double} 'GenericRange.Range{System.Double}') | The range within the `value` exists. |
| target | [GenericRange.Range{System.Double}@](#T-GenericRange-Range{System-Double}@ 'GenericRange.Range{System.Double}@') | The range to map the `value` to. |
| value | [GenericRange.Index{System.Double}@](#T-GenericRange-Index{System-Double}@ 'GenericRange.Index{System.Double}@') | The value. |

##### Remarks

Disallows [IsFromEnd](#P-GenericRange-Index`1-IsFromEnd 'GenericRange.Index`1.IsFromEnd') in favour of performance.

<a name='M-GenericRange-Extensions-RangeExtensions-Map-GenericRange-Range{System-Single},System-Single,GenericRange-Range{System-Single}@,System-Single,GenericRange-Index{System-Single}@-'></a>
### Map(source,sourceLength,target,targetLength,value) `method`

##### Summary

Interpolates the value from the `source`[Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1') to the [](#!-target 'target') range.

##### Returns

The `value` mapped to the `target` range.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [GenericRange.Range{System.Single}](#T-GenericRange-Range{System-Single} 'GenericRange.Range{System.Single}') | The range within the `value` exists. |
| sourceLength | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') | The length of the source set. |
| target | [GenericRange.Range{System.Single}@](#T-GenericRange-Range{System-Single}@ 'GenericRange.Range{System.Single}@') | The range to map the `value` to. |
| targetLength | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') | The length of the target set. |
| value | [GenericRange.Index{System.Single}@](#T-GenericRange-Index{System-Single}@ 'GenericRange.Index{System.Single}@') | The value. |

<a name='M-GenericRange-Extensions-RangeExtensions-Map-GenericRange-Range{System-Single},GenericRange-Range{System-Single}@,GenericRange-Index{System-Single}@-'></a>
### Map(source,target,value) `method`

##### Summary

Interpolates the value from the `source`[Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1') to the [](#!-target 'target') range.

##### Returns

The `value` mapped to the `target` range.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [GenericRange.Range{System.Single}](#T-GenericRange-Range{System-Single} 'GenericRange.Range{System.Single}') | The range within the `value` exists. |
| target | [GenericRange.Range{System.Single}@](#T-GenericRange-Range{System-Single}@ 'GenericRange.Range{System.Single}@') | The range to map the `value` to. |
| value | [GenericRange.Index{System.Single}@](#T-GenericRange-Index{System-Single}@ 'GenericRange.Index{System.Single}@') | The value. |

##### Remarks

Disallows [IsFromEnd](#P-GenericRange-Index`1-IsFromEnd 'GenericRange.Index`1.IsFromEnd') in favour of performance.

<a name='M-GenericRange-Extensions-RangeExtensions-Map-GenericRange-Range{System-Int64},System-Int64,GenericRange-Range{System-Int64}@,System-Int64,GenericRange-Index{System-Int64}@-'></a>
### Map(source,sourceLength,target,targetLength,value) `method`

##### Summary

Interpolates the value from the `source`[Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1') to the [](#!-target 'target') range.

##### Returns

The `value` mapped to the `target` range.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [GenericRange.Range{System.Int64}](#T-GenericRange-Range{System-Int64} 'GenericRange.Range{System.Int64}') | The range within the `value` exists. |
| sourceLength | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | The length of the source set. |
| target | [GenericRange.Range{System.Int64}@](#T-GenericRange-Range{System-Int64}@ 'GenericRange.Range{System.Int64}@') | The range to map the `value` to. |
| targetLength | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | The length of the target set. |
| value | [GenericRange.Index{System.Int64}@](#T-GenericRange-Index{System-Int64}@ 'GenericRange.Index{System.Int64}@') | The value. |

<a name='M-GenericRange-Extensions-RangeExtensions-Map-GenericRange-Range{System-Int64},GenericRange-Range{System-Int64}@,GenericRange-Index{System-Int64}@-'></a>
### Map(source,target,value) `method`

##### Summary

Interpolates the value from the `source`[Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1') to the [](#!-target 'target') range.

##### Returns

The `value` mapped to the `target` range.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [GenericRange.Range{System.Int64}](#T-GenericRange-Range{System-Int64} 'GenericRange.Range{System.Int64}') | The range within the `value` exists. |
| target | [GenericRange.Range{System.Int64}@](#T-GenericRange-Range{System-Int64}@ 'GenericRange.Range{System.Int64}@') | The range to map the `value` to. |
| value | [GenericRange.Index{System.Int64}@](#T-GenericRange-Index{System-Int64}@ 'GenericRange.Index{System.Int64}@') | The value. |

##### Remarks

Disallows [IsFromEnd](#P-GenericRange-Index`1-IsFromEnd 'GenericRange.Index`1.IsFromEnd') in favour of performance.

<a name='M-GenericRange-Extensions-RangeExtensions-Map-GenericRange-Range{System-Int64},System-Int64,GenericRange-Range{System-Int64}@,System-Int64,GenericRange-Index{System-Int64}@,System-MidpointRounding-'></a>
### Map(source,sourceLength,target,targetLength,value,rounding) `method`

##### Summary

Interpolates the value from the `source`[Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1') to the [](#!-target 'target') range.

##### Returns

The `value` mapped to the `target` range.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [GenericRange.Range{System.Int64}](#T-GenericRange-Range{System-Int64} 'GenericRange.Range{System.Int64}') | The range within the `value` exists. |
| sourceLength | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | The length of the source set. |
| target | [GenericRange.Range{System.Int64}@](#T-GenericRange-Range{System-Int64}@ 'GenericRange.Range{System.Int64}@') | The range to map the `value` to. |
| targetLength | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | The length of the target set. |
| value | [GenericRange.Index{System.Int64}@](#T-GenericRange-Index{System-Int64}@ 'GenericRange.Index{System.Int64}@') | The value. |
| rounding | [System.MidpointRounding](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.MidpointRounding 'System.MidpointRounding') | Rounding mode. |

<a name='M-GenericRange-Extensions-RangeExtensions-Map-GenericRange-Range{System-Int64},GenericRange-Range{System-Int64}@,GenericRange-Index{System-Int64}@,System-MidpointRounding-'></a>
### Map(source,target,value,rounding) `method`

##### Summary

Interpolates the value from the `source`[Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1') to the [](#!-target 'target') range.

##### Returns

The `value` mapped to the `target` range.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [GenericRange.Range{System.Int64}](#T-GenericRange-Range{System-Int64} 'GenericRange.Range{System.Int64}') | The range within the `value` exists. |
| target | [GenericRange.Range{System.Int64}@](#T-GenericRange-Range{System-Int64}@ 'GenericRange.Range{System.Int64}@') | The range to map the `value` to. |
| value | [GenericRange.Index{System.Int64}@](#T-GenericRange-Index{System-Int64}@ 'GenericRange.Index{System.Int64}@') | The value. |
| rounding | [System.MidpointRounding](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.MidpointRounding 'System.MidpointRounding') | Rounding mode. |

##### Remarks

Disallows [IsFromEnd](#P-GenericRange-Index`1-IsFromEnd 'GenericRange.Index`1.IsFromEnd') in favour of performance.

<a name='M-GenericRange-Extensions-RangeExtensions-Map-GenericRange-Range{System-Int32},System-Int32,GenericRange-Range{System-Int32}@,System-Int32,GenericRange-Index{System-Int32}@-'></a>
### Map(source,sourceLength,target,targetLength,value) `method`

##### Summary

Interpolates the value from the `source`[Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1') to the [](#!-target 'target') range.

##### Returns

The `value` mapped to the `target` range.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [GenericRange.Range{System.Int32}](#T-GenericRange-Range{System-Int32} 'GenericRange.Range{System.Int32}') | The range within the `value` exists. |
| sourceLength | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The length of the source set. |
| target | [GenericRange.Range{System.Int32}@](#T-GenericRange-Range{System-Int32}@ 'GenericRange.Range{System.Int32}@') | The range to map the `value` to. |
| targetLength | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The length of the target set. |
| value | [GenericRange.Index{System.Int32}@](#T-GenericRange-Index{System-Int32}@ 'GenericRange.Index{System.Int32}@') | The value. |

<a name='M-GenericRange-Extensions-RangeExtensions-Map-GenericRange-Range{System-Int32},GenericRange-Range{System-Int32}@,GenericRange-Index{System-Int32}@-'></a>
### Map(source,target,value) `method`

##### Summary

Interpolates the value from the `source`[Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1') to the [](#!-target 'target') range.

##### Returns

The `value` mapped to the `target` range.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [GenericRange.Range{System.Int32}](#T-GenericRange-Range{System-Int32} 'GenericRange.Range{System.Int32}') | The range within the `value` exists. |
| target | [GenericRange.Range{System.Int32}@](#T-GenericRange-Range{System-Int32}@ 'GenericRange.Range{System.Int32}@') | The range to map the `value` to. |
| value | [GenericRange.Index{System.Int32}@](#T-GenericRange-Index{System-Int32}@ 'GenericRange.Index{System.Int32}@') | The value. |

##### Remarks

Disallows [IsFromEnd](#P-GenericRange-Index`1-IsFromEnd 'GenericRange.Index`1.IsFromEnd') in favour of performance.

<a name='M-GenericRange-Extensions-RangeExtensions-Map-GenericRange-Range{System-Int32},System-Int32,GenericRange-Range{System-Int32}@,System-Int32,GenericRange-Index{System-Int32}@,System-MidpointRounding-'></a>
### Map(source,sourceLength,target,targetLength,value,rounding) `method`

##### Summary

Interpolates the value from the `source`[Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1') to the [](#!-target 'target') range.

##### Returns

The `value` mapped to the `target` range.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [GenericRange.Range{System.Int32}](#T-GenericRange-Range{System-Int32} 'GenericRange.Range{System.Int32}') | The range within the `value` exists. |
| sourceLength | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The length of the source set. |
| target | [GenericRange.Range{System.Int32}@](#T-GenericRange-Range{System-Int32}@ 'GenericRange.Range{System.Int32}@') | The range to map the `value` to. |
| targetLength | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The length of the target set. |
| value | [GenericRange.Index{System.Int32}@](#T-GenericRange-Index{System-Int32}@ 'GenericRange.Index{System.Int32}@') | The value. |
| rounding | [System.MidpointRounding](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.MidpointRounding 'System.MidpointRounding') | Rounding mode. |

<a name='M-GenericRange-Extensions-RangeExtensions-Map-GenericRange-Range{System-Int32},GenericRange-Range{System-Int32}@,GenericRange-Index{System-Int32}@,System-MidpointRounding-'></a>
### Map(source,target,value,rounding) `method`

##### Summary

Interpolates the value from the `source`[Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1') to the [](#!-target 'target') range.

##### Returns

The `value` mapped to the `target` range.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [GenericRange.Range{System.Int32}](#T-GenericRange-Range{System-Int32} 'GenericRange.Range{System.Int32}') | The range within the `value` exists. |
| target | [GenericRange.Range{System.Int32}@](#T-GenericRange-Range{System-Int32}@ 'GenericRange.Range{System.Int32}@') | The range to map the `value` to. |
| value | [GenericRange.Index{System.Int32}@](#T-GenericRange-Index{System-Int32}@ 'GenericRange.Index{System.Int32}@') | The value. |
| rounding | [System.MidpointRounding](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.MidpointRounding 'System.MidpointRounding') | Rounding mode. |

##### Remarks

Disallows [IsFromEnd](#P-GenericRange-Index`1-IsFromEnd 'GenericRange.Index`1.IsFromEnd') in favour of performance.

<a name='M-GenericRange-Extensions-RangeExtensions-Mask``1-GenericRange-Range{``0}-'></a>
### Mask\`\`1(range) `method`

##### Summary

Or\`s values of the enum in the range to create a bit-mask.

##### Returns

The signed 64-bit integer representing the created mask.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| range | [GenericRange.Range{\`\`0}](#T-GenericRange-Range{``0} 'GenericRange.Range{``0}') | The [Enum](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Enum 'System.Enum') range. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The [Enum](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Enum 'System.Enum') type. |

##### Remarks

Do not use, if your enum has non-flag, non-zero values, such as `All` where all bits are set.
    
    In that case use [Mask\`\`1](#M-GenericRange-Extensions-RangeExtensions-Mask``1-GenericRange-Range{``0},``0- 'GenericRange.Extensions.RangeExtensions.Mask``1(GenericRange.Range{``0},``0)') with the highest bit-flag.

<a name='M-GenericRange-Extensions-RangeExtensions-Mask``1-GenericRange-Range{``0},``0-'></a>
### Mask\`\`1(range,maximum) `method`

##### Summary

Or\`s values of the enum in the range to create a bit-mask.

##### Returns

The signed 64-bit integer representing the created mask.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| range | [GenericRange.Range{\`\`0}](#T-GenericRange-Range{``0} 'GenericRange.Range{``0}') | The [Enum](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Enum 'System.Enum') range. |
| maximum | [\`\`0](#T-``0 '``0') | The flag with the highest bit. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The [Enum](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Enum 'System.Enum') type. |

<a name='M-GenericRange-Extensions-RangeExtensions-PercentageOf-GenericRange-Range{System-Decimal},GenericRange-Index{System-Decimal}@,System-Decimal-'></a>
### PercentageOf(range,value,length) `method`

##### Summary

Returns the percentage of the [](#!-value 'value') within the [Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1').

##### Returns

The percentage of the [](#!-value 'value') within the [Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| range | [GenericRange.Range{System.Decimal}](#T-GenericRange-Range{System-Decimal} 'GenericRange.Range{System.Decimal}') | The range. |
| value | [GenericRange.Index{System.Decimal}@](#T-GenericRange-Index{System-Decimal}@ 'GenericRange.Index{System.Decimal}@') | The value inside the set. |
| length | [System.Decimal](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Decimal 'System.Decimal') | The length of the set. |

##### Remarks

`0.0` if the `value` is equal to [Start](#P-GenericRange-Range`1-Start 'GenericRange.Range`1.Start'),`1.0` if the `value` is equal to [End](#P-GenericRange-Range`1-End 'GenericRange.Range`1.End').

<a name='M-GenericRange-Extensions-RangeExtensions-PercentageOf-GenericRange-Range{System-Decimal},GenericRange-Index{System-Decimal}@-'></a>
### PercentageOf(range,value) `method`

##### Summary

Returns the percentage of the [](#!-value 'value') within the [Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1').

##### Returns

The percentage of the [](#!-value 'value') within the [Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| range | [GenericRange.Range{System.Decimal}](#T-GenericRange-Range{System-Decimal} 'GenericRange.Range{System.Decimal}') | The range. |
| value | [GenericRange.Index{System.Decimal}@](#T-GenericRange-Index{System-Decimal}@ 'GenericRange.Index{System.Decimal}@') | The value inside the set. |

##### Remarks

`0.0` if the `value` is equal to [Start](#P-GenericRange-Range`1-Start 'GenericRange.Range`1.Start'),`1.0` if the `value` is equal to [End](#P-GenericRange-Range`1-End 'GenericRange.Range`1.End').

<a name='M-GenericRange-Extensions-RangeExtensions-PercentageOf-GenericRange-Range{System-Double},GenericRange-Index{System-Double}@,System-Double-'></a>
### PercentageOf(range,value,length) `method`

##### Summary

Returns the percentage of the [](#!-value 'value') within the [Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1').

##### Returns

The percentage of the [](#!-value 'value') within the [Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| range | [GenericRange.Range{System.Double}](#T-GenericRange-Range{System-Double} 'GenericRange.Range{System.Double}') | The range. |
| value | [GenericRange.Index{System.Double}@](#T-GenericRange-Index{System-Double}@ 'GenericRange.Index{System.Double}@') | The value inside the set. |
| length | [System.Double](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Double 'System.Double') | The length of the set. |

##### Remarks

`0.0` if the `value` is equal to [Start](#P-GenericRange-Range`1-Start 'GenericRange.Range`1.Start'),`1.0` if the `value` is equal to [End](#P-GenericRange-Range`1-End 'GenericRange.Range`1.End').

<a name='M-GenericRange-Extensions-RangeExtensions-PercentageOf-GenericRange-Range{System-Double},GenericRange-Index{System-Double}@-'></a>
### PercentageOf(range,value) `method`

##### Summary

Returns the percentage of the [](#!-value 'value') within the [Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1').

##### Returns

The percentage of the [](#!-value 'value') within the [Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| range | [GenericRange.Range{System.Double}](#T-GenericRange-Range{System-Double} 'GenericRange.Range{System.Double}') | The range. |
| value | [GenericRange.Index{System.Double}@](#T-GenericRange-Index{System-Double}@ 'GenericRange.Index{System.Double}@') | The value inside the set. |

##### Remarks

`0.0` if the `value` is equal to [Start](#P-GenericRange-Range`1-Start 'GenericRange.Range`1.Start'),`1.0` if the `value` is equal to [End](#P-GenericRange-Range`1-End 'GenericRange.Range`1.End').

<a name='M-GenericRange-Extensions-RangeExtensions-PercentageOf-GenericRange-Range{System-Single},GenericRange-Index{System-Single}@,System-Single-'></a>
### PercentageOf(range,value,length) `method`

##### Summary

Returns the percentage of the [](#!-value 'value') within the [Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1').

##### Returns

The percentage of the [](#!-value 'value') within the [Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| range | [GenericRange.Range{System.Single}](#T-GenericRange-Range{System-Single} 'GenericRange.Range{System.Single}') | The range. |
| value | [GenericRange.Index{System.Single}@](#T-GenericRange-Index{System-Single}@ 'GenericRange.Index{System.Single}@') | The value inside the set. |
| length | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') | The length of the set. |

##### Remarks

`0.0` if the `value` is equal to [Start](#P-GenericRange-Range`1-Start 'GenericRange.Range`1.Start'),`1.0` if the `value` is equal to [End](#P-GenericRange-Range`1-End 'GenericRange.Range`1.End').

<a name='M-GenericRange-Extensions-RangeExtensions-PercentageOf-GenericRange-Range{System-Single},GenericRange-Index{System-Single}@-'></a>
### PercentageOf(range,value) `method`

##### Summary

Returns the percentage of the [](#!-value 'value') within the [Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1').

##### Returns

The percentage of the [](#!-value 'value') within the [Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| range | [GenericRange.Range{System.Single}](#T-GenericRange-Range{System-Single} 'GenericRange.Range{System.Single}') | The range. |
| value | [GenericRange.Index{System.Single}@](#T-GenericRange-Index{System-Single}@ 'GenericRange.Index{System.Single}@') | The value inside the set. |

##### Remarks

`0.0` if the `value` is equal to [Start](#P-GenericRange-Range`1-Start 'GenericRange.Range`1.Start'),`1.0` if the `value` is equal to [End](#P-GenericRange-Range`1-End 'GenericRange.Range`1.End').

<a name='M-GenericRange-Extensions-RangeExtensions-PercentageOf-GenericRange-Range{System-Int64},GenericRange-Index{System-Int64}@,System-Int64-'></a>
### PercentageOf(range,value,length) `method`

##### Summary

Returns the percentage of the [](#!-value 'value') within the [Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1').

##### Returns

The percentage of the [](#!-value 'value') within the [Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| range | [GenericRange.Range{System.Int64}](#T-GenericRange-Range{System-Int64} 'GenericRange.Range{System.Int64}') | The range. |
| value | [GenericRange.Index{System.Int64}@](#T-GenericRange-Index{System-Int64}@ 'GenericRange.Index{System.Int64}@') | The value inside the set. |
| length | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | The length of the set. |

##### Remarks

`0.0` if the `value` is equal to [Start](#P-GenericRange-Range`1-Start 'GenericRange.Range`1.Start'),`1.0` if the `value` is equal to [End](#P-GenericRange-Range`1-End 'GenericRange.Range`1.End').

<a name='M-GenericRange-Extensions-RangeExtensions-PercentageOf-GenericRange-Range{System-Int64},GenericRange-Index{System-Int64}@-'></a>
### PercentageOf(range,value) `method`

##### Summary

Returns the percentage of the [](#!-value 'value') within the [Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1').

##### Returns

The percentage of the [](#!-value 'value') within the [Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| range | [GenericRange.Range{System.Int64}](#T-GenericRange-Range{System-Int64} 'GenericRange.Range{System.Int64}') | The range. |
| value | [GenericRange.Index{System.Int64}@](#T-GenericRange-Index{System-Int64}@ 'GenericRange.Index{System.Int64}@') | The value inside the set. |

##### Remarks

`0.0` if the `value` is equal to [Start](#P-GenericRange-Range`1-Start 'GenericRange.Range`1.Start'),`1.0` if the `value` is equal to [End](#P-GenericRange-Range`1-End 'GenericRange.Range`1.End').

<a name='M-GenericRange-Extensions-RangeExtensions-PercentageOf-GenericRange-Range{System-Int32},GenericRange-Index{System-Int32}@,System-Int32-'></a>
### PercentageOf(range,value,length) `method`

##### Summary

Returns the percentage of the [](#!-value 'value') within the [Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1').

##### Returns

The percentage of the [](#!-value 'value') within the [Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| range | [GenericRange.Range{System.Int32}](#T-GenericRange-Range{System-Int32} 'GenericRange.Range{System.Int32}') | The range. |
| value | [GenericRange.Index{System.Int32}@](#T-GenericRange-Index{System-Int32}@ 'GenericRange.Index{System.Int32}@') | The value inside the set. |
| length | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The length of the set. |

##### Remarks

`0.0` if the `value` is equal to [Start](#P-GenericRange-Range`1-Start 'GenericRange.Range`1.Start'),`1.0` if the `value` is equal to [End](#P-GenericRange-Range`1-End 'GenericRange.Range`1.End').

<a name='M-GenericRange-Extensions-RangeExtensions-PercentageOf-GenericRange-Range{System-Int32},GenericRange-Index{System-Int32}@-'></a>
### PercentageOf(range,value) `method`

##### Summary

Returns the percentage of the [](#!-value 'value') within the [Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1').

##### Returns

The percentage of the [](#!-value 'value') within the [Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| range | [GenericRange.Range{System.Int32}](#T-GenericRange-Range{System-Int32} 'GenericRange.Range{System.Int32}') | The range. |
| value | [GenericRange.Index{System.Int32}@](#T-GenericRange-Index{System-Int32}@ 'GenericRange.Index{System.Int32}@') | The value inside the set. |

##### Remarks

`0.0` if the `value` is equal to [Start](#P-GenericRange-Range`1-Start 'GenericRange.Range`1.Start'),`1.0` if the `value` is equal to [End](#P-GenericRange-Range`1-End 'GenericRange.Range`1.End').

<a name='M-GenericRange-Extensions-RangeExtensions-ToIndex``1-GenericRange-Index{``0}-'></a>
### ToIndex\`\`1(index) `method`

##### Summary

Converts the generic index to a integer [Index](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Index 'System.Index').

##### Returns

The [Index](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Index 'System.Index') equivalent to the `index`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| index | [GenericRange.Index{\`\`0}](#T-GenericRange-Index{``0} 'GenericRange.Index{``0}') | The IConvertible index. |

<a name='M-GenericRange-Extensions-RangeExtensions-ToRange``1-GenericRange-Range{``0}-'></a>
### ToRange\`\`1(range) `method`

##### Summary

Converts the generic range to a integer [Range](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Range 'System.Range').

##### Returns

The [Range](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Range 'System.Range') equivalent to the `range`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| range | [GenericRange.Range{\`\`0}](#T-GenericRange-Range{``0} 'GenericRange.Range{``0}') | The IConvertible range. |

<a name='T-GenericRange-Range`1'></a>
## Range\`1 `type`

##### Namespace

GenericRange

##### Summary

Represents a range that has start and end indices.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The primitive type of the index, one of `sbyte`, `byte`, `short`, `ushort`, `int`,
    `uint`, `long`, `ulong`, `float`, `double`, `decimal`, `char`,
    `TimeSpan`, or any [Enum](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Enum 'System.Enum') type with one of the aforementioned as underlying type. |

<a name='M-GenericRange-Range`1-#ctor-GenericRange-Index{`0}@,GenericRange-Index{`0}@-'></a>
### #ctor(start,end) `constructor`

##### Summary

Constructs a [Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1') with the specified `start`, and `end` indices.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| start | [GenericRange.Index{\`0}@](#T-GenericRange-Index{`0}@ 'GenericRange.Index{`0}@') | The start index. |
| end | [GenericRange.Index{\`0}@](#T-GenericRange-Index{`0}@ 'GenericRange.Index{`0}@') | The end index. |

<a name='M-GenericRange-Range`1-#ctor-`0@,System-Boolean,`0@,System-Boolean-'></a>
### #ctor(start,startFromEnd,end,endFromEnd) `constructor`

##### Summary

Constructs a [Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1') with the specified `start`, and `end` indices.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| start | [\`0@](#T-`0@ '`0@') | The start index. |
| startFromEnd | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Whether the start index is from the end. |
| end | [\`0@](#T-`0@ '`0@') | The end index. |
| endFromEnd | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Whether the end index is from the end. |

<a name='M-GenericRange-Range`1-#ctor-`0@,System-Boolean,`0@-'></a>
### #ctor(start,startFromEnd,end) `constructor`

##### Summary

Constructs a [Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1') with the specified `start`, and `end` indices.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| start | [\`0@](#T-`0@ '`0@') | The start index. |
| startFromEnd | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Whether the start index is from the end. |
| end | [\`0@](#T-`0@ '`0@') | The end index. |

<a name='M-GenericRange-Range`1-#ctor-`0@,`0@,System-Boolean-'></a>
### #ctor(start,end,endFromEnd) `constructor`

##### Summary

Constructs a [Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1') with the specified `start`, and `end` indices.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| start | [\`0@](#T-`0@ '`0@') | The start index. |
| end | [\`0@](#T-`0@ '`0@') | The end index. |
| endFromEnd | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Whether the end index is from the end. |

<a name='P-GenericRange-Range`1-End'></a>
### End `property`

##### Summary

The end index of the [Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1').

<a name='P-GenericRange-Range`1-Start'></a>
### Start `property`

##### Summary

The inclusive start index of the [Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1').

<a name='M-GenericRange-Range`1-Clamp-GenericRange-Range{`0}@,`0@-'></a>
### Clamp(other,length) `method`

##### Summary

Returns the intersection with an`other` range in a set of a given `length`.

##### Returns

The intersection between `this` and the `other`[Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| other | [GenericRange.Range{\`0}@](#T-GenericRange-Range{`0}@ 'GenericRange.Range{`0}@') | The range to unify with. |
| length | [\`0@](#T-`0@ '`0@') | The length of the set. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | `!this.Intersects(other, length)` |

<a name='M-GenericRange-Range`1-Clamp-GenericRange-Range{`0}@-'></a>
### Clamp(other) `method`

##### Summary

Returns the intersection with an`other` range in an arbitrary set.

##### Returns

The intersection between `this` and the `other`[Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| other | [GenericRange.Range{\`0}@](#T-GenericRange-Range{`0}@ 'GenericRange.Range{`0}@') | The range to unify with. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | `!this.Intersects(other, length)` |

##### Remarks

Disallows indices [IsFromEnd](#P-GenericRange-Index`1-IsFromEnd 'GenericRange.Index`1.IsFromEnd') in favour of performance.

<a name='M-GenericRange-Range`1-Contains-GenericRange-Index{`0}@,`0@-'></a>
### Contains(value,length) `method`

##### Summary

Indicates whether a specified value is within the range.

##### Returns

`true` if the `value` is within the range, otherwise; `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [GenericRange.Index{\`0}@](#T-GenericRange-Index{`0}@ 'GenericRange.Index{`0}@') | The value to seek. |
| length | [\`0@](#T-`0@ '`0@') | The value that represents the length of the set that the range will be used with. |

<a name='M-GenericRange-Range`1-Contains-GenericRange-Index{`0}@-'></a>
### Contains(value) `method`

##### Summary

Indicates whether a specified value is within the range.

##### Returns

`true` if the `value` is within the range, otherwise; `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| value | [GenericRange.Index{\`0}@](#T-GenericRange-Index{`0}@ 'GenericRange.Index{`0}@') | The value to seek. |

##### Remarks

Disallows indices [IsFromEnd](#P-GenericRange-Index`1-IsFromEnd 'GenericRange.Index`1.IsFromEnd') in favour of performance.

<a name='M-GenericRange-Range`1-Encompasses-GenericRange-Range{`0}@,`0@-'></a>
### Encompasses(other,length) `method`

##### Summary

Indicates whether a [Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1') is completely contained within the range.

##### Returns

`true` if the `other` range completely contained within the range, otherwise; `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| other | [GenericRange.Range{\`0}@](#T-GenericRange-Range{`0}@ 'GenericRange.Range{`0}@') | The other range. |
| length | [\`0@](#T-`0@ '`0@') | The value that represents the length of the set that the range will be used with. |

<a name='M-GenericRange-Range`1-Encompasses-GenericRange-Range{`0}@-'></a>
### Encompasses(other) `method`

##### Summary

Indicates whether a [Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1') is completely contained within the range.

##### Returns

`true` if the `other` range completely contained within the range, otherwise; `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| other | [GenericRange.Range{\`0}@](#T-GenericRange-Range{`0}@ 'GenericRange.Range{`0}@') | The other range. |

##### Remarks

Disallows indices [IsFromEnd](#P-GenericRange-Index`1-IsFromEnd 'GenericRange.Index`1.IsFromEnd') in favour of performance.

<a name='M-GenericRange-Range`1-Equals-GenericRange-Range{`0}@,`0@-'></a>
### Equals(other,length) `method`

##### Summary

Indicates whether the indices inside a set of a specific `length` of the [Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1') are equal to another.

##### Returns

`true` if the current object is equal to the other parameter; otherwise, `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| other | [GenericRange.Range{\`0}@](#T-GenericRange-Range{`0}@ 'GenericRange.Range{`0}@') | The other [Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1'). |
| length | [\`0@](#T-`0@ '`0@') | The length of the set. |

<a name='M-GenericRange-Range`1-GetLeftPart-GenericRange-Index{`0}@-'></a>
### GetLeftPart(endIndex) `method`

##### Summary

Returns a new [Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1') with a start-index equal to [Start](#P-GenericRange-Range`1-Start 'GenericRange.Range`1.Start') and the provided end-index.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| endIndex | [GenericRange.Index{\`0}@](#T-GenericRange-Index{`0}@ 'GenericRange.Index{`0}@') | The end-index. |

<a name='M-GenericRange-Range`1-GetOffsetAndLength-`0@-'></a>
### GetOffsetAndLength(length) `method`

##### Summary

Returns the start offset and length of the [Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1') object using a set length.

##### Returns

The start offset and length of the range.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| length | [\`0@](#T-`0@ '`0@') | The value that represents the length of the set that the range will be used with. |

<a name='M-GenericRange-Range`1-GetOffsetAndLength'></a>
### GetOffsetAndLength() `method`

##### Summary

Returns the start offset and length of the [Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1') object using a set length.

##### Returns

The start offset and length of the range.

##### Parameters

This method has no parameters.

##### Remarks

Disallows indices [IsFromEnd](#P-GenericRange-Index`1-IsFromEnd 'GenericRange.Index`1.IsFromEnd') in favour of performance.

<a name='M-GenericRange-Range`1-GetRightPart-GenericRange-Index{`0}@-'></a>
### GetRightPart(startIndex) `method`

##### Summary

Returns a new [Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1') with a the provided start-index and end-index equal to [End](#P-GenericRange-Range`1-End 'GenericRange.Range`1.End').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| startIndex | [GenericRange.Index{\`0}@](#T-GenericRange-Index{`0}@ 'GenericRange.Index{`0}@') | The end-index. |

<a name='M-GenericRange-Range`1-Intersects-GenericRange-Range{`0}@,`0@-'></a>
### Intersects(other,length) `method`

##### Summary

Indicates whether a [Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1') is intersects with the range.

##### Returns

`true` if the `other` range intersects with the range, otherwise; `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| other | [GenericRange.Range{\`0}@](#T-GenericRange-Range{`0}@ 'GenericRange.Range{`0}@') | The other range. |
| length | [\`0@](#T-`0@ '`0@') | The value that represents the length of the set that the range will be used with. |

<a name='M-GenericRange-Range`1-Intersects-GenericRange-Range{`0}@-'></a>
### Intersects(other) `method`

##### Summary

Indicates whether a [Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1') is intersects with the range.

##### Returns

`true` if the `other` range intersects with the range, otherwise; `false`.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| other | [GenericRange.Range{\`0}@](#T-GenericRange-Range{`0}@ 'GenericRange.Range{`0}@') | The other range. |

##### Remarks

Disallows indices [IsFromEnd](#P-GenericRange-Index`1-IsFromEnd 'GenericRange.Index`1.IsFromEnd') in favour of performance.

<a name='M-GenericRange-Range`1-Span-GenericRange-Range{`0}@,`0@-'></a>
### Span(other,length) `method`

##### Summary

Returns the expanded-union with an`other` range in a set of a given `length`.

##### Returns

The expanded-union between `this` and the `other`[Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| other | [GenericRange.Range{\`0}@](#T-GenericRange-Range{`0}@ 'GenericRange.Range{`0}@') | The range to unify with. |
| length | [\`0@](#T-`0@ '`0@') | The length of the set. |

<a name='M-GenericRange-Range`1-Span-GenericRange-Range{`0}@-'></a>
### Span(other) `method`

##### Summary

Returns the expanded-union with an`other` range in an arbitrary set.

##### Returns

The expanded-union between `this` and the `other`[Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| other | [GenericRange.Range{\`0}@](#T-GenericRange-Range{`0}@ 'GenericRange.Range{`0}@') | The range to unify with. |

##### Remarks

Disallows indices [IsFromEnd](#P-GenericRange-Index`1-IsFromEnd 'GenericRange.Index`1.IsFromEnd') in favour of performance.

<a name='M-GenericRange-Range`1-ToRange``1'></a>
### ToRange\`\`1() `method`

##### Summary

Converts the [](#!-Value 'Value') to the specified type.

##### Returns

A new [Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1') of the desired type.

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TOut | The type to convert to. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.InvalidCastException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.InvalidCastException 'System.InvalidCastException') | This conversion is not supported. -or- value is null and conversionType is a value type. -or- value does not implement the IConvertible interface. |

##### Remarks

Uses [ChangeType](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Convert.ChangeType 'System.Convert.ChangeType(System.Object,System.Type)'), but the generic constraints do not ensure that the Types are IConvertible use at own discretion.

<a name='M-GenericRange-Range`1-Union-GenericRange-Range{`0}@,`0@-'></a>
### Union(other,length) `method`

##### Summary

Returns the continuous union with an`other` range in a set of a given `length`.

##### Returns

The continuous union between `this` and the `other`[Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| other | [GenericRange.Range{\`0}@](#T-GenericRange-Range{`0}@ 'GenericRange.Range{`0}@') | The range to unify with. |
| length | [\`0@](#T-`0@ '`0@') | The length of the set. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | The [Start](#P-GenericRange-Range`1-Start 'GenericRange.Range`1.Start') of the `other` range is greather then the [End](#P-GenericRange-Range`1-End 'GenericRange.Range`1.End') of the range. |

##### Remarks

Same as [Span\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Span`1 'System.Span`1') but requires the union to be continues.

<a name='M-GenericRange-Range`1-Union-GenericRange-Range{`0}@-'></a>
### Union(other) `method`

##### Summary

Returns the continuous union with an`other` range in an arbitrary set.

##### Returns

The continuous union between `this` and the `other`[Range\`1](#T-GenericRange-Range`1 'GenericRange.Range`1').

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| other | [GenericRange.Range{\`0}@](#T-GenericRange-Range{`0}@ 'GenericRange.Range{`0}@') | The range to unify with. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') | The [Start](#P-GenericRange-Range`1-Start 'GenericRange.Range`1.Start') of the `other` range is greather then the [End](#P-GenericRange-Range`1-End 'GenericRange.Range`1.End') of the range. |

##### Remarks

Same as [Span\`1](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Span`1 'System.Span`1') but requires the union to be continues.
    
    Disallows indices [IsFromEnd](#P-GenericRange-Index`1-IsFromEnd 'GenericRange.Index`1.IsFromEnd') in favour of performance.

<a name='M-GenericRange-Range`1-op_Explicit-System-Range@-~GenericRange-Range{`0}'></a>
### op_Explicit() `method`

##### Summary

Uses [ChangeType](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Convert.ChangeType 'System.Convert.ChangeType(System.Object,System.Type)') to convert the range to the specific generic type.

##### Parameters

This method has no parameters.

##### Remarks

Warning: does not work for not [IConvertible](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IConvertible 'System.IConvertible')'s such as [Enum](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Enum 'System.Enum') types.

<a name='T-GenericRange-Utility-ValueStringBuilder'></a>
## ValueStringBuilder `type`

##### Namespace

GenericRange.Utility

<a name='P-GenericRange-Utility-ValueStringBuilder-RawChars'></a>
### RawChars `property`

##### Summary

Returns the underlying storage of the builder.

<a name='M-GenericRange-Utility-ValueStringBuilder-AsSpan-System-Boolean-'></a>
### AsSpan(terminate) `method`

##### Summary

Returns a span around the contents of the builder.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| terminate | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Ensures that the builder has a null char after [Length](#P-GenericRange-Utility-ValueStringBuilder-Length 'GenericRange.Utility.ValueStringBuilder.Length') |

<a name='M-GenericRange-Utility-ValueStringBuilder-GetPinnableReference'></a>
### GetPinnableReference() `method`

##### Summary

Get a pinnable reference to the builder.
    Does not ensure there is a null char after [Length](#P-GenericRange-Utility-ValueStringBuilder-Length 'GenericRange.Utility.ValueStringBuilder.Length')
    This overload is pattern matched in the C# 7.3+ compiler so you can omit
    the explicit method call, and write eg "fixed (char* c = builder)"

##### Parameters

This method has no parameters.

<a name='M-GenericRange-Utility-ValueStringBuilder-GetPinnableReference-System-Boolean-'></a>
### GetPinnableReference(terminate) `method`

##### Summary

Get a pinnable reference to the builder.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| terminate | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Ensures that the builder has a null char after [Length](#P-GenericRange-Utility-ValueStringBuilder-Length 'GenericRange.Utility.ValueStringBuilder.Length') |

<a name='M-GenericRange-Utility-ValueStringBuilder-Grow-System-Int32-'></a>
### Grow(additionalCapacityBeyondPos) `method`

##### Summary

Resize the internal buffer either by doubling current buffer size or
    by adding `additionalCapacityBeyondPos` to
    [_pos](#F-GenericRange-Utility-ValueStringBuilder-_pos 'GenericRange.Utility.ValueStringBuilder._pos') whichever is greater.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| additionalCapacityBeyondPos | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Number of chars requested beyond current position. |
