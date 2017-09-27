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
    }
}