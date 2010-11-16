using System;
using NUnit.Framework;

namespace toy
{
    [TestFixture]
    public class DotRendererTest
    {
        [Test]
        public void ShouldRenderAssemblyWithoutDependencies()
        {
            var azzembly = new Azzembly("Foo");
            Assert.That(Render(azzembly), DigraphContaining("Foo"));
        }

        [Test]
        public void ShouldRenderAssemblyWithOneDependency()
        {
            var azzembly = new Azzembly("Foo").WithDependencies("Bar");
            Assert.That(Render(azzembly), DigraphContaining("Foo", "Bar"));
        }
        
        [Test]
        public void ShouldRenderAssemblyWithMultipleDependency()
        {
            var azzembly = new Azzembly("Foo").WithDependencies("Bar", "Baz");
            Assert.That(Render(azzembly), DigraphContaining("Foo", "Bar"));
            Assert.That(Render(azzembly), DigraphContaining("Foo", "Baz"));
        }

        [Test]
        public void ShouldRenderMultipleAssembliesWithMultipleDependency()
        {
            var azzemblies = new []
            {
                new Azzembly("Cow").WithDependencies("Grass", "Air"),
                new Azzembly("Fish").WithDependencies("Plankton", "Water")
            };
            Assert.That(Render(azzemblies), DigraphContaining("Cow", "Grass"));
            Assert.That(Render(azzemblies), DigraphContaining("Cow", "Air"));
            Assert.That(Render(azzemblies), DigraphContaining("Fish", "Plankton"));
            Assert.That(Render(azzemblies), DigraphContaining("Fish", "Water"));
        }

        private String Render(params Azzembly[] azzemblies)
        {
            return new DotRenderer().Render(azzemblies);
        }

        private static DigraphContaining DigraphContaining(params string[] nodes)
        {
            return new DigraphContaining(nodes);
        }
    }
}