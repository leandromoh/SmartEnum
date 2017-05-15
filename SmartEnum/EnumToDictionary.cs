using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartEnum
{
    public static partial class EnumExtensions
    {
        public static IEnumerable<KeyValuePair<TEnum, string>> EnumToDictionary<TEnum>()
            where TEnum : struct
        {
            var type = typeof(TEnum);
            if (!type.IsEnum) throw new ArgumentException("T must be an Enum");

            return EnumToDictionary(type)
                .Select(x => new KeyValuePair<TEnum, string>((TEnum)Convert.ChangeType(x.Key, type), x.Value));
        }

        private static Dictionary<Enum, string> EnumToDictionary(Type type)
        {
            Dictionary<Enum, string> dictionary;

            if (AllEnumDescriptions.TryGetValue(type, out dictionary))
            {
                return dictionary;
            }

            return (AllEnumDescriptions[type] = GetDescriptionDictionary(type));
        }
    }
}
