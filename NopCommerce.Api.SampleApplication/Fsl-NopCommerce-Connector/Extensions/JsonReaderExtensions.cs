using Newtonsoft.Json;
using System;

namespace Fsl.NopCommerce.Api.Connector.Extensions
{
    static class JsonReaderExtensions
    {
        public static bool ValueAsDateTimeOffset(this JsonReader reader, out DateTimeOffset value)
        {
            if (reader.ValueType.Equals(typeof(string)))
            {
                return DateTimeOffset.TryParse(reader.Value as string, out value);
            }

            var type = reader.ValueType;
            var dto = reader.Value as DateTimeOffset?;

            value = dto.GetValueOrDefault();

            return dto.HasValue;
        }

        public static bool ValueAsDateTime(this JsonReader reader, out DateTime value)
        {
            if (reader.ValueType.Equals(typeof(string)))
            {
                return DateTime.TryParse(reader.Value as string, out value);
            }

            var dt = reader.Value as DateTime?;

            value = dt.GetValueOrDefault();

            return dt.HasValue;
        }

        public static bool ValueAsInt32(this JsonReader reader, out int value)
        {
            var i = reader.Value as int?;

            value = i.GetValueOrDefault();

            return i.HasValue;
        }

        public static bool ValueAsInt64(this JsonReader reader, out long value)
        {
            var l = reader.Value as long?;

            value = l.GetValueOrDefault();

            return l.HasValue;
        }

        public static bool ValueAsSingle(this JsonReader reader, out float value)
        {
            if (reader.ValueType.Equals(typeof(string)))
            {
                return float.TryParse(reader.Value as string, out value);
            }

            var f = reader.Value as float?;

            value = f.GetValueOrDefault();

            return f.HasValue;
        }

        public static bool ValueAsDouble(this JsonReader reader, out double value)
        {
            if (reader.ValueType.Equals(typeof(string)))
            {
                return double.TryParse(reader.Value as string, out value);
            }

            var d = reader.Value as double?;

            value = d.GetValueOrDefault();

            return d.HasValue;
        }

        public static bool ValueAsBool(this JsonReader reader, out bool value)
        {
            var b = reader.Value as bool?;

            value = b.GetValueOrDefault();

            return b.HasValue;
        }
    }
}
