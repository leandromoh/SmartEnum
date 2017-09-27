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
        public SmartEnumHelper()
        {

        }

        public static string GetDescriptionFromDescriptionTestAttribute(FieldInfo field)
        {
            var customAttributes = field
                                       .GetCustomAttributes(typeof(DescriptionTestAttribute), false)
                                       .Cast<DescriptionTestAttribute>()
                                       .ToList();

            return customAttributes.FirstOrDefault()?.Description ?? "teste";
        }

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            EnumExtensions.GetDescriptionFromField = SmartEnumHelper.GetDescriptionFromDescriptionTestAttribute;
        }
    }
//}
