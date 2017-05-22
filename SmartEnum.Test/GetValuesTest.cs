using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEnum.Test
{
    [TestFixture]
    public class GetValuesTest
    {
        [Test]
        public void GetValues()
        {
            var result = EnumExtensions.GetValues<Animal>();

            var expectations = new[] { Animal.Camel , Animal.Whale , Animal.Dragon , Animal.Bee , Animal.Elephant };

            Assert.IsTrue(result.SequenceEqual(expectations));
        }
    }
}
