﻿using System;
using System.ComponentModel;
using System.Globalization;

namespace GenericRange.TypeConverters
{
    public class RangeTypeConverter<T> : TypeConverter where T : unmanaged, IComparable
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(string) || base.CanConvertTo(context, destinationType);
        }

        public override object? ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            return value is string serialized ? RangeConverter<T>.Parse(serialized) : base.ConvertFrom(context, culture, value);
        }

        public override object? ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            var range = (Range<T>)value!;
            return destinationType == typeof(string) ? RangeConverter<T>.ToString(range) : base.ConvertTo(context, culture, value, destinationType);
        }
    }
}