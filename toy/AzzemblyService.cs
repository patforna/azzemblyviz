using System;
using System.Collections.Generic;
using System.Linq;

namespace toy
{
    public class AzzemblyService
    {
        private readonly AzzemblyFinder azzemblyFinder;

        [Obsolete("Just here to make Moq happy")]
        protected AzzemblyService() {}

        public AzzemblyService(AzzemblyFinder azzemblyFinder)
        {
            this.azzemblyFinder = azzemblyFinder;
        }

        public virtual IEnumerable<Azzembly> FindAzzemblies(string searchPath)
        {
            return DeDuplicate(azzemblyFinder.FindAzzemblies(searchPath));
        }

        private IEnumerable<Azzembly> DeDuplicate(IEnumerable<Azzembly> azzemblies)
        {
            return azzemblies.Distinct();
        }
    }
}
