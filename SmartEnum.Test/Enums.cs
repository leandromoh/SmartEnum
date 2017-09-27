using System.ComponentModel;

namespace SmartEnum.Test
{
    public enum Animal
    {
        [DescriptionTest("Camelo")]
        Camel = 1,
        [DescriptionTest("Baleia")]
        Whale = 2,
        [DescriptionTest("Dragão")]
        Dragon = 4,
        [DescriptionTest("Abelha")]
        Bee = 8,
        Elephant = 16,
    }
}
