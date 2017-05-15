using System;
using System.Collections.Generic;

namespace SmartEnum
{
    public static partial class EnumExtensions
    {
        private static Dictionary<Enum, string> Descriptions = new Dictionary<Enum, string>();
        private static Dictionary<Type, Dictionary<Enum, string>> AllEnumDescriptions = new Dictionary<Type, Dictionary<Enum, string>>();
    }
}