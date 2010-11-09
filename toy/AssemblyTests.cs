using System;
using System.Reflection;
using NUnit.Framework;

namespace toy
{
    [TestFixture]
    public class AssemblyTests
    {
        [Test]
        public void ShouldListReferencedAssemblies()
        {
            var name = @"C:\itv\Mercury\Batch\BondStreet\Source\Itv.BB.Mercury.Common\bin\Debug\Itv.BB.Bloom.Core.dll";
            
            foreach (var referencedAssembly in Assembly.LoadFile(name).GetReferencedAssemblies())
            {
                Console.WriteLine(referencedAssembly.Name);
            }
        }
    }
}