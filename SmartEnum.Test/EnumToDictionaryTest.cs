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
    public class EnumToDictionaryTest
    {
        [Test]
        public void EnumToDictionary()
        {
            var result = EnumExtensions.EnumToDictionary<Animal>().OrderBy(x => x.Key);

            var expectations = new Dictionary<Animal, string>()
            {
                { Animal.Camel, "Camelo" },
                { Animal.Whale, "Baleia" },
                { Animal.Dragon, "Dragão" },
                { Animal.Bee, "Abelha" },
                { Animal.Elephant, "Elephant" },
            }
            .OrderBy(x => x.Key);

            Assert.That(result, Is.EqualTo(expectations));
        }
    }
}
