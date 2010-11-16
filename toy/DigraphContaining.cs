using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework.Constraints;

namespace toy
{
    public class DigraphContaining : Constraint
    {
        private readonly string expectedLine;

        public DigraphContaining(params string[] nodes)
        {
            this.expectedLine = string.Join(" -> ", nodes.Select(x => WrapInQuotes(x)).ToArray());
        }

        private string WrapInQuotes(string s)
        {
            return "\"" + s + "\"";
        }

        public override bool Matches(object actual)
        {
            this.actual = actual;
            var allLines = ReadAllLinesFrom(actual);

            if (allLines.Count() < 1)
                return false;

            if (!HasCorrectStartAndEndClause(allLines))
                return false;

            return allLines.Any(line => line.Trim().Equals(expectedLine));
        }

        private bool HasCorrectStartAndEndClause(IEnumerable<string> allLines)
        {
            if (!allLines.First().Equals("digraph G {"))
                return false;

            if (!allLines.Last().Equals("}"))
                return false;

            return true;
        }

        private IEnumerable<string> ReadAllLinesFrom(object actual)
        {
            var reader = new StringReader(Convert.ToString(actual));
            string line;
            while ((line = reader.ReadLine()) != null) 
                yield return line;
        }

        public override void WriteDescriptionTo(MessageWriter writer)
        {
            writer.WriteExpectedValue(String.Format("\ndigraph G {{\n  ...\n  {0}\n  ...\n}}", expectedLine));
        }
    }
}