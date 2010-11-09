using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace toy
{
    public class AzzemblyCreator
    {
        public virtual Azzembly FromFile(string fileName)
        {
            var assembly = Assembly.LoadFrom(fileName);
            return new Azzembly(assembly.FullName, DependenciesFor(assembly));
        }

        private IEnumerable<Azzembly> DependenciesFor(Assembly assembly)
        {
            return assembly.GetReferencedAssemblies().Select(a => new Azzembly(a.FullName));
        }
    }
}