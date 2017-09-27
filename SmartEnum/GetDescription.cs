using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Linq;

namespace SmartEnum
{
    public static partial class EnumExtensions
    {
        public static string GetDescription(this Enum e)
        {
            string desc;

            if (Descriptions.TryGetValue(e, out desc))
            {
                return desc;
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
                descriptionDictionary[e] = Descriptions[e] = GetDescriptionFromAttribute(enumType.GetField(e.ToString()));
            }

            return descriptionDictionary;
        }

        private static string GetDescriptionInAttribute(FieldInfo field)
        {
            #if CORE
                
            return field.Name;

            #else  

            return field
                        .GetCustomAttributes(typeof(DescriptionAttribute), false)
                        .OfType<DescriptionAttribute>()
                        .FirstOrDefault()
                       ?.Description ?? field.Name;

            #endif
        }
    }
}
