using System;

namespace SmartEnum
{
    public static partial class EnumExtensions
    {
        public static TEnum[] GetValues<TEnum>()
            where TEnum : struct
        {
            var type = typeof(TEnum);
            if (!type.IsEnum) throw new ArgumentException("T must be an Enum");

            return (TEnum[])Enum.GetValues(type);
        }
    }
}
