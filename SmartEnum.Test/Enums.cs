using System.ComponentModel;

namespace SmartEnum.Test
{
    public enum Animal
    {
        [Description("Camelo")]
        Camel = 1,
        [Description("Baleia")]
        Whale = 2,
        [Description("Dragão")]
        Dragon = 4,
        [Description("Abelha")]
        Bee = 8,
        Elephant = 16,
    }
}
