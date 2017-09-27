using System;

namespace SmartEnum
{
    public static partial class EnumExtensions
    {
        public static string[] GetNames<TEnum>()
            where TEnum : struct
        {
            var type = ThrowIfNotEnum<TEnum>();

            return Enum.GetNames(type);
        }
    }
}
