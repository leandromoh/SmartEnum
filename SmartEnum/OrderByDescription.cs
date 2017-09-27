using System;
using System.Linq;
using System.Linq.Expressions;

namespace SmartEnum
{
    public static partial class EnumExtensions
    {
        public static Expression<Func<TSource, int>> OrderByDescription<TSource, TEnum>(this Expression<Func<TSource, TEnum>> source)
            where TEnum : struct
        {
            return OrderByDescription(source, EnumExtensions.GetDescription);
        }

        public static Expression<Func<TSource, int>> OrderByDescription<TSource, TEnum>(this Expression<Func<TSource, TEnum>> source, Func<Enum, string> func)
            where TEnum : struct
        {
            var type = ThrowIfNotEnum<TEnum>();

            var body = ((TEnum[])Enum.GetValues(type))
                .OrderBy(value => func(value as Enum))
                .Select((value, ordinal) => new { value, ordinal })
                .Aggregate((Expression)null, (next, item) => next == null ? (Expression)
                    Expression.Constant(item.ordinal) :
                    Expression.Condition(
                        Expression.Equal(source.Body, Expression.Constant(item.value)),
                        Expression.Constant(item.ordinal),
                        next));

            return Expression.Lambda<Func<TSource, int>>(body, source.Parameters[0]);
        }
    }
}
