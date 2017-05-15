using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace SmartEnum
{
    public static partial class EnumExtensions
    {
        public static string GetDescription(this Enum e)
        {
            string value;

            if (Descriptions.TryGetValue(e, out value))
            {
                return value;
            }

            Type type = e.GetType();

            AllEnumDescriptions[type] = GetDescriptionDictionary(type);

            return Descriptions[e];
        }

        private static Dictionary<Enum, string> GetDescriptionDictionary(Type enumType)
        {
            var descriptionDictionary = new Dictionary<Enum, string>();

            foreach (Enum e in Enum.GetValues(enumType))
            {
                descriptionDictionary[e] = Descriptions[e] = e.GetDescriptionInAttribute(enumType);
            }

            return descriptionDictionary;
        }

        private static string GetDescriptionInAttribute(this Enum e, Type enumType)
        {
            FieldInfo field = enumType.GetField(e.ToString());
            object[] customAttributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return customAttributes.Length > 0 ? (customAttributes[0] as DescriptionAttribute).Description : e.ToString();
        }
    }
}
