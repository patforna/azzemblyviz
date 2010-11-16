using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace toy
{
    [TestFixture]
    public class AzzemblyServiceTest
    {
        private IEnumerable<Azzembly> azzemblies;
        private const string PATH = "search.PATH";

        [Test]
        public void ShouldLoadAzzembliesUsingAzzemblyFinder()
        {
            azzemblies = new[] {new Azzembly("Foo")};
            var service = new AzzemblyService(AzzemblyFinder());
            Assert.That(service.FindAzzemblies(PATH), Has.Member(new Azzembly("Foo")));
        }

        [Test]
        public void ShouldDiscardDuplicates()
        {
            azzemblies = new[] { new Azzembly("Foo"), new Azzembly("Foo"),  };
            var service = new AzzemblyService(AzzemblyFinder());
            Assert.That(service.FindAzzemblies(PATH).Count(), Is.EqualTo(1));
        }

        private AzzemblyFinder AzzemblyFinder()
        {
            var azzemblyFinder = new Mock<AzzemblyFinder>();
            azzemblyFinder.Setup(m => m.FindAzzemblies(PATH)).Returns(azzemblies);
            return azzemblyFinder.Object;
        }
    }
}