using System.Reflection;
using NUnit.Framework;
using System.Linq;

namespace toy
{
    [TestFixture]
    public class AzzemblyCreatorTest
    {
        private static readonly Assembly WRAPPED_ASSEMBLY = Assembly.GetExecutingAssembly();

        private readonly AzzemblyCreator azzemblyCreator = new AzzemblyCreator();

        [Test]
        public void ShouldPopulateName()
        {
            var azzembly = azzemblyCreator.FromFile(WRAPPED_ASSEMBLY.Location);
            Assert.That(azzembly.Name, Is.EqualTo(WRAPPED_ASSEMBLY.FullName));
        }

        [Test]
        public void ShouldPopulateDependencies()
        {
            var azzembly = azzemblyCreator.FromFile(WRAPPED_ASSEMBLY.Location);
            var dependencies = WRAPPED_ASSEMBLY.GetReferencedAssemblies().Select(a => a.FullName);

            Assert.That(azzembly.Dependencies, Is.EqualTo(dependencies));
        }
    }
}