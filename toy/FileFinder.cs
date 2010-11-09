using System.Collections.Generic;
using System.IO;

namespace toy
{
    public class FileFinder
    {
        public virtual List<string> FindRecursively(string searchPath, string pattern)
        {
            var result = new List<string>();
            var stack = new Stack<string>();

            stack.Push(searchPath);
            while (stack.Count > 0)
            {
                var dir = stack.Pop();
                result.AddRange(Directory.GetFiles(dir, pattern));
                foreach (var dn in Directory.GetDirectories(dir))
                {
                    stack.Push(dn);
                }
            }
            return result;
        }
    }
}