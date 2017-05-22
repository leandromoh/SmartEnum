using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEnum.Test
{
    [TestFixture]
    public class GetDescriptionTest
    {
        [Test]
        public void GetDescription()
        {
            var result = Animal.Bee.GetDescription();

            Assert.That(result, Is.EqualTo("Abelha"));
        }

        [Test]
        public void GetDescriptionWithoutDescriptionAttribute()
        {
            var result = Animal.Elephant.GetDescription();

            Assert.That(result, Is.EqualTo("Elephant"));
        }
    }
}
