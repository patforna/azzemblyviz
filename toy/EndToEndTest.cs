using System.IO;
using NUnit.Framework;

namespace toy
{
    [TestFixture]
    public class EndToEndTest
    {
        [Test]
        public void ShouldProduceDotOutput()
        {
            var path = string.Join("/", new[] {Directory.GetCurrentDirectory()});
            Assert.That(App().ProduceDotFrom(path), DigraphContaining("toy -> nunit.framework"));
        }

        private App App()
        {
            return new App(new AzzemblyFinder(new FileFinder(), new AzzemblyCreator()), new DotRenderer());
        }

        private static DigraphContaining DigraphContaining(string line)
        {
            return new DigraphContaining(line);
        }
    }
}