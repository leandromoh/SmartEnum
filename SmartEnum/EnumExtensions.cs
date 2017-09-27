using System;
using System.Collections.Generic;
using System.Reflection;

namespace SmartEnum
{
    public static partial class EnumExtensions
    {
        private static Dictionary<Enum, string> Descriptions;
        private static Dictionary<Type, Dictionary<Enum, string>> AllEnumDescriptions;

        private static Func<FieldInfo, string> _GetDescriptionFromField;
        public static Func<FieldInfo, string> GetDescriptionFromField
        {
            get => _GetDescriptionFromField;
            set 
            {
                _GetDescriptionFromField = value ?? throw new ArgumentNullException(nameof(GetDescriptionFromField));
                Descriptions.Clear();
                AllEnumDescriptions.Clear();
            }
        }

        static EnumExtensions()
        {
            Descriptions = new Dictionary<Enum, string>();
            AllEnumDescriptions = new Dictionary<Type, Dictionary<Enum, string>>();
            GetDescriptionFromField = GetDescriptionInAttribute;
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