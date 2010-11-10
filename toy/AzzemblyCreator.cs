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
            return new Azzembly(SimpleNameOf(assembly), DependenciesFor(assembly));
        }

        private IEnumerable<Azzembly> DependenciesFor(Assembly assembly)
        {
            return assembly.GetReferencedAssemblies().Select(a => new Azzembly(SimpleNameOf(a)));
        }

        private string SimpleNameOf(Assembly assembly)
        {
            return SimpleNameOf(assembly.GetName());
        }

        private string SimpleNameOf(AssemblyName assemblyName)
        {
            return assemblyName.Name;
        }
    }
}