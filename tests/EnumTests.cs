using System;

using GenericRange.Extensions;

using NUnit.Framework;

namespace GenericRange.Tests
{
    [TestFixture]
    public class EnumTests
    {
        [Test]
        public void TestFoo()
        {
            Range<Foo> rangeAll = new(Foo.None, Foo.None, true);
            var foos = Enum.GetValues<Foo>();
            foreach (Foo foo in foos)
            {
                Assert.IsTrue(rangeAll.Contains(foo, Foo.All));
            }
        }

        [Test]
        public void TestMask()
        {
            Range<Foo> rangeAll = new(Foo.None, Foo.None, true);

            Foo mask = (Foo)rangeAll.Mask(Foo.Eight);
            
            Assert.AreEqual(Foo.All, mask);
        }

        [Test]
        public void TestCast()
        {
            Range range = 0..^1;
            Assert.Throws<InvalidCastException>(() => _ = (Range<Foo>)range);
        }
    }
}
