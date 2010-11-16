using System;
using System.Linq;

namespace toy
{
    public class App
    {
        private readonly AzzemblyFinder azzemblyFinder;

        private readonly DotRenderer renderer;

        public static void Main(params string[] args)
        {
            var path = args.First();
            Console.WriteLine(WireUpApp().ProduceDotFrom(path));
        }

        private static App WireUpApp()
        {
            return new App(new AzzemblyFinder(new FileFinder(), new AzzemblyCreator()), new DotRenderer());
        }

        public App(AzzemblyFinder azzemblyFinder, DotRenderer renderer)
        {
            this.azzemblyFinder = azzemblyFinder;
            this.renderer = renderer;
        }

        public string ProduceDotFrom(string path)
        {
            return renderer.Render(azzemblyFinder.FindAzzemblies(path));
        }
    }
}