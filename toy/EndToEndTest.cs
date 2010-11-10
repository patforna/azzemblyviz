using System;
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
            var output = App().ProduceDotFrom(path);
            Assert.That(output, DigraphContaining("toy -> nunit.framework"));
            Assert.That(output, DigraphContaining("toy -> Moq"));

            Console.WriteLine(output);
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