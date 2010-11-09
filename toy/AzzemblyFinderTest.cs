using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace toy
{
    [TestFixture]
    public class AzzemblyFinderTest
    {
        private const string SEARCH_PATH = "search.path";
        private const string FILE_NAME = "file.name";
        private static readonly Azzembly AZZEMBLY = new Azzembly("Foo");

        [Test]
        public void ShouldLoadAzzembliesUsingFileFinder()
        {
            var azzemblyFinder = new AzzemblyFinder(FileFinder(), AzzemblyCreator());
            Assert.That(azzemblyFinder.FindAzzemblies(SEARCH_PATH), Has.Member(AZZEMBLY));
        }

        private FileFinder FileFinder()
        {
            var fileFinder = new Mock<FileFinder>();
            fileFinder.Setup(m => m.FindRecursively(SEARCH_PATH, "*.dll")).Returns(new List<string> {FILE_NAME});
            return fileFinder.Object;
        }

        private AzzemblyCreator AzzemblyCreator()
        {
            var azzemblyCreator = new Mock<AzzemblyCreator>();
            azzemblyCreator.Setup(m => m.FromFile(FILE_NAME)).Returns(AZZEMBLY);
            return azzemblyCreator.Object;
        }
    }
}