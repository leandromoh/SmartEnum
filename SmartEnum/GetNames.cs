using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEnum
{
    public static partial class EnumExtensions
    {
        public static string[] GetNames<TEnum>()
            where TEnum : struct
        {
            var type = typeof(TEnum);
            if (!type.IsEnum) throw new ArgumentException("T must be an Enum");

            return Enum.GetNames(type);
        }
    }
}
