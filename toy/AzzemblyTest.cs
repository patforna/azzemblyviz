using NUnit.Framework;

namespace toy
{
    [TestFixture]
    public class AzzemblyTest
    {
        [Test]
        public void ShouldNotHaveDependencies()
        {
            Assert.That(new Azzembly("Foo").HasDependencies(), Is.False);
        }

        [Test]
        public void ShouldBeEqualIfSameNameAndNoDependencies()
        {
            Assert.That(new Azzembly("Foo"), Is.EqualTo(new Azzembly("Foo")));
        }

        [Test]
        public void ShouldHaveSameHashCodeIfSameNameAndNoDependencies()
        {
            Assert.That(new Azzembly("Foo").GetHashCode(), Is.EqualTo(new Azzembly("Foo").GetHashCode()));
        }
    }
}