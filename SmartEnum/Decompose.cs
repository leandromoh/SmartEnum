﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartEnum
{
    public static partial class EnumExtensions
    {
        public static IEnumerable<TEnum> Decompose<TEnum>(this TEnum e)
            where TEnum : struct
        {
            var type = ThrowIfNotEnum<TEnum>();

            var val = e as Enum;

            return GetValues<TEnum>().Where(x => (Convert.ToInt64(val) & Convert.ToInt64(x)) != 0);
        }
    }
}
