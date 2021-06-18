using System;

using NUnit.Framework;

namespace GenericRange.Tests
{
    [TestFixture]
    public class TestEnum
    {
        private Range<Foo> all = new(Foo.None, Foo.None, true);

        [Test]
        public void TestFoo()
        {
            var foos = Enum.GetValues<Foo>();
            foreach (Foo foo in foos)
            {
                if (foo == Foo.All)
                    Assert.IsFalse(all.Contains(foo, Foo.All));
                else
                    Assert.IsTrue(all.Contains(foo, Foo.All));
            }
        }
    }
}
