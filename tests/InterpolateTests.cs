using GenericRange.Extensions;

using NUnit.Framework;

namespace GenericRange.Tests
{
    [TestFixture]
    public class InterpolateTests
    {
        [Test]
        public void TestInterpolate()
        {
            Range<int> r = new(20, 80);
            Assert.AreEqual(20, r.Interpolate(0));
            Assert.AreEqual(80, r.Interpolate(1));
            Assert.AreEqual(50, r.Interpolate(.5));
        }
    }
}
