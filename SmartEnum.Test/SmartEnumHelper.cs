using System.Linq;
using System.Reflection;
using NUnit.Framework;
using SmartEnum.Test;
using SmartEnum;
using System;

//namespace NUnit.Tests
//{
    [SetUpFixture]
    public class SmartEnumHelper
    {
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            EnumExtensions.GetDescriptionFromField = (FieldInfo field) =>
            {
                var customAttributes = field
                                        .GetCustomAttributes(typeof(DescriptionTestAttribute), false)
                                        .Cast<DescriptionTestAttribute>()
                                        .ToList();

                return customAttributes.FirstOrDefault()?.Description ?? "teste";
            };
        }
    }
//}
