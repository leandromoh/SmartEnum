using System;
using System.Collections.Generic;
using System.Reflection;

namespace SmartEnum
{
    public static partial class EnumExtensions
    {
        private static Dictionary<Enum, string> Descriptions = new Dictionary<Enum, string>();
        private static Dictionary<Type, Dictionary<Enum, string>> AllEnumDescriptions = new Dictionary<Type, Dictionary<Enum, string>>();
        public static Func<FieldInfo, string> GetDescriptionFromAttribute;

        static EnumExtensions()
        {
            GetDescriptionFromAttribute = GetDescriptionInAttribute;
        }

        private static Type ThrowIfNotEnum<TEnum>()
        {
            var type = typeof(TEnum);

            #if CORE
                if (type.GetTypeInfo().IsEnum) throw new ArgumentException("T must be an Enum");
            #else  
                if (!type.IsEnum) throw new ArgumentException("T must be an Enum");
            #endif

            return type;
        }
    }
}