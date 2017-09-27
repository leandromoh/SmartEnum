using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartEnum
{
    public static partial class EnumExtensions
    {
        public static IEnumerable<KeyValuePair<TEnum, string>> ToDescriptionDictionary<TEnum>()
            where TEnum : struct
        {
            var type = typeof(TEnum);
            if (!type.IsEnum) throw new ArgumentException("T must be an Enum");

            return ToDescriptionDictionary(type)
                .Select(x => new KeyValuePair<TEnum, string>((TEnum)Convert.ChangeType(x.Key, type), x.Value));
        }

        private static Dictionary<Enum, string> ToDescriptionDictionary(Type type)
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
