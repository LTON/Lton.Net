namespace Lton
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    internal class Formatter
    {
        private static readonly IDictionary<TypeCode, string> NumberSuffixes = new Dictionary<TypeCode, string>
        {
            {TypeCode.SByte, "SB"},
            {TypeCode.Byte, "B"},
            {TypeCode.Int16, "S"},
            {TypeCode.UInt16, "US"},
            {TypeCode.Int32, string.Empty},
            {TypeCode.UInt32, "U"},
            {TypeCode.Int64, "L"},
            {TypeCode.UInt64, "UL"},
            {TypeCode.Single, "F"},
            {TypeCode.Double, "D"},
            {TypeCode.Decimal, "M"}
        };

        public string FormatProperty(PropertyInfo property, object obj)
        {
            var value = property.GetValue(obj);
            return Format(property.Name, property.PropertyType, value);
        }

        private string Format(string name, Type type, object value)
        {
            var typeCode = Type.GetTypeCode(type);
            if (typeCode == TypeCode.Object && type == typeof (DateTimeOffset))
            {
                typeCode = TypeCode.DateTime;
            }
            switch (typeCode)
            {
                case TypeCode.Empty:
                    throw new InvalidOperationException();
                case TypeCode.DBNull:
                    return "&" + name + "=&";
                case TypeCode.Boolean:
                    return "?" + name + ((bool) value ? "=1?" : "=0?");
                case TypeCode.Char:
                {
                    return string.Format("'{0}={1}'", name, value);
                }
                case TypeCode.SByte:
                case TypeCode.Byte:
                case TypeCode.Int16:
                case TypeCode.UInt16:
                case TypeCode.Int32:
                case TypeCode.UInt32:
                case TypeCode.Int64:
                case TypeCode.UInt64:
                case TypeCode.Single:
                case TypeCode.Double:
                case TypeCode.Decimal:
                {
                    return FormatNumber(typeCode, name, value);
                }
                case TypeCode.DateTime:
                {
                    return string.Format("/{0}={1:O}/", name, value);
                }
                case TypeCode.String:
                {
                    return string.Format("\"{0}={1}\"", name, LtonString.Escape(value));
                }
                case TypeCode.Object:
                    return FormatObject(name, type, value);
            }
            throw new ArgumentOutOfRangeException();
        }

        private string FormatObject(string name, Type type, object value)
        {
            if (type.IsGenericType)
            {
                var genericType = type.GetGenericTypeDefinition();
                if (genericType == typeof (Nullable<>))
                {
                    return Format(name, type.GetGenericArguments()[0], value);
                }
            }
            throw new NotSupportedException();
        }

        private string FormatNumber(TypeCode typeCode, string name, object obj)
        {
            return string.Format("#{0}={1}{2}#", name, obj, NumberSuffixes[typeCode]);
        }
    }
}