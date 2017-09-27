using System;

namespace SmartEnum
{
    public static partial class EnumExtensions
    {
        public static TEnum[] GetValues<TEnum>()
            where TEnum : struct
        {
            var type = ThrowIfNotEnum<TEnum>();

            return (TEnum[])Enum.GetValues(type);
        }
    }
}
