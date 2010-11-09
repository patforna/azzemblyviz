using System.IO;
using NUnit.Framework;

namespace toy
{
    [TestFixture]
    public class FileFinderTest
    {
        private FileFinder fileFinder = new FileFinder();

        [Test]
        public void ShouldFindAllDlls()
        {
            var directory = Directory.GetCurrentDirectory();
            var dlls = fileFinder.FindRecursively(directory, "*.dll");
            Assert.That(dlls, Has.Count.GreaterThan(0));
            Assert.That(dlls, Has.All.StringEnding(".dll"));
        }
    }
}
