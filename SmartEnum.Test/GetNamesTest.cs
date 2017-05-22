using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEnum.Test
{
    [TestFixture]
    public class GetNamesTest
    {
        [Test]
        public void GetNames()
        {
            var result = EnumExtensions.GetNames<Animal>();

            var expectations = new[] { "Camel" , "Whale", "Dragon", "Bee", "Elephant" };

            Assert.IsTrue(result.SequenceEqual(expectations));
        }
    }
}
