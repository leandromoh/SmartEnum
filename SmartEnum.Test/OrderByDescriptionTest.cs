using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEnum.Test
{
    [TestFixture]
    public class OrderByDescriptionTest
    {
        [Test]
        public void OrderByDescription()
        {
            var expression = EnumExtensions.OrderByDescription((Animal x) => x);

            var func = expression.Compile();

            var result = EnumExtensions.GetValues<Animal>().OrderBy(func);

            var expectations = EnumExtensions.ToDescriptionDictionary<Animal>().OrderBy(x => x.Value).Select(x => x.Key);

            Assert.That(result, Is.EqualTo(expectations));
        }
    }
}
