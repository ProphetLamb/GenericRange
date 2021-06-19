using System;

using NUnit.Framework;

namespace GenericRange.Tests
{
    [TestFixture]
    public class EnumTests
    {
        private Range<Foo> all = new(Foo.None, Foo.None, true);

        [Test]
        public void TestFoo()
        {
            var foos = Enum.GetValues<Foo>();
            foreach (Foo foo in foos)
            {
                Assert.IsTrue(all.Contains(foo, Foo.All));
            }
        }
    }
}
