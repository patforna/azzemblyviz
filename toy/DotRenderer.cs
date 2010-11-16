using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace toy
{
    public class DotRenderer
    {
        private const string PRE_AMBLE = "digraph G {";
        private const string END = "}";
        private const string INDENT = "  ";

        private StringWriter writer = new StringWriter();

        public virtual string Render(IEnumerable<Azzembly> azzemblies)
        {
            PreAmble();
            EntriesFor(azzemblies);
            End();
            return writer.ToString();
        }

        private void PreAmble()
        {
            writer.WriteLine(PRE_AMBLE);
        }

        private void EntriesFor(IEnumerable<Azzembly> azzemblies)
        {
            azzemblies.ToList().ForEach(EntriesFor);
        }

        private void EntriesFor(Azzembly azzembly)
        {
            NodeAndEdgesFor(azzembly).ToList().ForEach(line => writer.WriteLine("{0}{1}", INDENT, line));
        }

        private IEnumerable<string> NodeAndEdgesFor(Azzembly azzembly)
        {
            if (!azzembly.HasDependencies())
                yield return NodeOnlyFor(azzembly);

            foreach (var dependency in azzembly.Dependencies)
            {
                yield return NodeAndEdgeFor(azzembly, dependency);
            }
        }

        private string NodeOnlyFor(Azzembly azzembly)
        {
            return WrapInQuotes(azzembly.Name);
        }

        private string NodeAndEdgeFor(Azzembly azzembly, Azzembly dependency)
        {
            return string.Format("{0} -> {1}", WrapInQuotes(azzembly.Name), WrapInQuotes(dependency.Name));
        }

        private string WrapInQuotes(string name)
        {
            return "\"" + name + "\"";
        }

        private void End()
        {
            writer.WriteLine(END);
        }
    }
}