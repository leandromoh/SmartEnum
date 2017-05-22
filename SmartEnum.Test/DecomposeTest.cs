using NUnit.Framework;
using SmartEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEnum.Test
{
    [TestFixture]
    public class DecomposeTest
    {
        [Test]
        public void Decompose()
        {
            var result = (Animal.Camel | Animal.Dragon | Animal.Bee).Decompose().OrderBy(x => x);

            var expectations = new[] { Animal.Camel, Animal.Dragon, Animal.Bee }.OrderBy(x => x);

            Assert.That(result, Is.EqualTo(expectations));
        }

        [Test]
        public void DecomposeWithSingleValue()
        {
            var result = Animal.Dragon.Decompose();

            var expectations = new[] { Animal.Dragon };

            Assert.That(result, Is.EqualTo(expectations));
        }
    }
}
