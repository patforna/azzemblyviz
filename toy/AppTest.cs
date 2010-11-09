using System;
using Moq;
using NUnit.Framework;

namespace toy
{
    [TestFixture]
    public class AppTest
    {
        private const string PATH = "PATH.to.a.dir";
        private const string RENDERED_OUTPUT = "something like: digraph G { foo -> bar }";

        [Test]
        public void ShouldUseAzzemblyFinderAndDotRendererToProduceOutput()
        {
            Assert.That(App().ProduceDotFrom(PATH), Is.EqualTo(RENDERED_OUTPUT));
        }

        private App App()
        {
            var azzemblyFinder = new Mock<AzzemblyFinder>();
            var azzemblies = new[] { new Azzembly("Foo"),  };
            azzemblyFinder.Setup(m => m.FindAzzemblies(PATH)).Returns(azzemblies);

            var dotRenderer = new Mock<DotRenderer>();
            dotRenderer.Setup(m => m.Render(azzemblies)).Returns(RENDERED_OUTPUT);

            return new App(azzemblyFinder.Object, dotRenderer.Object);
        }
    }
}