using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace toy
{
    public class AzzemblyFinder
    {
        private readonly FileFinder fileFinder;
        private readonly AzzemblyCreator azzemblyCreator;

        [Obsolete("here to make moq happy...")]
        protected AzzemblyFinder() {}

        public AzzemblyFinder(FileFinder fileFinder, AzzemblyCreator azzemblyCreator)
        {
            this.fileFinder = fileFinder;
            this.azzemblyCreator = azzemblyCreator;
        }

        public virtual IEnumerable<Azzembly> FindAzzemblies(string searchPath)
        {
            var files = fileFinder.FindRecursively(searchPath, "*.dll");
            return CreateAzzembliesFrom(files);
        }

        private IEnumerable<Azzembly> CreateAzzembliesFrom(IEnumerable<string> azzemblyFiles)
        {
            return azzemblyFiles.Select(file => azzemblyCreator.FromFile(file));
        }
    }
}