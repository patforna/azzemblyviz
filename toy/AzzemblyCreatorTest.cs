using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace toy
{
    [TestFixture]
    public class AzzemblyCreatorTest
    {
        private static readonly Assembly WRAPPED_ASSEMBLY = Assembly.GetExecutingAssembly();

        private readonly AzzemblyCreator azzemblyCreator = new AzzemblyCreator();

        [Test]
        public void ShouldPopulateNameUsingSimpleName()
        {
            Azzembly azzembly = azzemblyCreator.FromFile(WRAPPED_ASSEMBLY.Location);
            Assert.That(azzembly.Name, Is.EqualTo(WRAPPED_ASSEMBLY.GetName().Name));
        }

        [Test]
        public void ShouldPopulateDependenciesUsingSimpleNameOfReferencedAssemblies()
        {
            Azzembly azzembly = azzemblyCreator.FromFile(WRAPPED_ASSEMBLY.Location);
            IEnumerable<string> dependencyNames = WRAPPED_ASSEMBLY.GetReferencedAssemblies().Select(a => a.Name);

            Assert.That(azzembly.Dependencies.Select(d => d.Name), Is.EqualTo(dependencyNames));
        }
    }
}