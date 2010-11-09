using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace toy
{
    public class Azzembly
    {
        private readonly string name;
        private readonly IEnumerable<Azzembly> dependencies;

        public Azzembly(string name, IEnumerable<Azzembly> dependencies) : this(name, dependencies.ToArray()) {}

        public Azzembly(string name, params Azzembly[] dependencies)
        {
            this.name = name;
            this.dependencies = dependencies;
        }

        public string Name
        {
            get { return name; }
        }

        public IEnumerable<Azzembly> Dependencies
        {
            get { return dependencies; }
        }

        public Azzembly WithDependencies(params string[] dependencyNames)
        {
            var dependencies = this.dependencies.Concat(dependencyNames.Select(name => new Azzembly(name)));
            return new Azzembly(this.name, dependencies);
        }

        public bool HasDependencies()
        {
            return dependencies.Count() > 0;
        }

        public override bool Equals(object other)
        {
            var otherAzzembly = other as Azzembly;
            return name.Equals(otherAzzembly.name);
        }

        public override int GetHashCode()
        {
            return name.GetHashCode();
        }
    }
}