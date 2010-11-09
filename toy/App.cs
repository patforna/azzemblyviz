namespace toy
{
    public class App
    {
        private readonly AzzemblyFinder azzemblyFinder;
        private readonly DotRenderer renderer;

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