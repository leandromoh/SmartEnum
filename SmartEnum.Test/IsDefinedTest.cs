using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEnum.Test
{
    [TestFixture]
    public class IsDefinedTest
    {
        [TestCase(Animal.Camel, true)]
        [TestCase((Animal)1, true)]
        [TestCase((Animal) 99, false)]
        [TestCase(Animal.Bee | Animal.Camel, false)]
        public void IsDefined(Animal e, bool expect)
        {
            Assert.AreEqual(e.IsDefined(), expect);
        }
    }
}
