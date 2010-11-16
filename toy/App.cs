using System;
using System.Linq;

namespace toy
{
    public class App
    {
        private readonly AzzemblyService azzemblyService;

        private readonly DotRenderer renderer;

        public static void Main(params string[] args)
        {
            var path = args.First();
            Console.WriteLine(WireUpApp().ProduceDotFrom(path));
        }

        private static App WireUpApp()
        {
            return new App(new AzzemblyService(new AzzemblyFinder(new FileFinder(), new AzzemblyCreator())), new DotRenderer());
        }

        public App(AzzemblyService azzemblyService, DotRenderer renderer)
        {
            this.azzemblyService = azzemblyService;
            this.renderer = renderer;
        }

        public string ProduceDotFrom(string path)
        {
            return renderer.Render(azzemblyService.FindAzzemblies(path));
        }
    }
}