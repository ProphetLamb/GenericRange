using System;

using NUnit.Framework;

namespace GenericRange.Tests
{
    [TestFixture]
    public class IntersectionTests
    {
        [Test]
        public void TestClamp()
        {
            Range<int> r = new(20, 65);
            
            Range<int> a = new(0, 30);
            Assert.IsTrue(new Range<int>(20, 30).Equals(r.Clamp(a)));
            Assert.IsTrue(new Range<int>(20, 30).Equals(r.Clamp(a), 100));
            
            Range<int> b = new(30, 80);
            Assert.IsTrue(new Range<int>(30, 65).Equals(r.Clamp(b)));
            Assert.IsTrue(new Range<int>(30, 65).Equals(r.Clamp(b), 100));

            Range<int> c = new(0, 70);
            Assert.IsTrue(r.Equals(r.Clamp(c)));
            Assert.IsTrue(r.Equals(r.Clamp(c), 100));

            Range<int> d = new(30, 50);
            Assert.IsTrue(d.Equals(r.Clamp(d)));
            Assert.IsTrue(d.Equals(r.Clamp(d), 100));

            Assert.Throws<ArgumentOutOfRangeException>(() => _ = r.Union(new(98, 99)));
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = r.Union(new(98, 99), 100));
        }
        
        [Test]
        public void TestClampFromEndFromEnd()
        {
            int len = 100;
            Range<int> r = new(80, true, 35, true);
            
            Range<int> a = new(100, true, 70, true);
            Assert.IsTrue(new Range<int>(20, 30).Equals(r.Clamp(a, len), len));
            
            Range<int> b = new(70, true, 20, true);
            Assert.IsTrue(new Range<int>(30, 65).Equals(r.Clamp(b, len), len));

            Range<int> c = new(100, true, 30, true);
            Assert.IsTrue(r.Equals(r.Clamp(c, len), len));
            
            Range<int> d = new(70, true, 50, true);
            Assert.IsTrue(d.Equals(r.Clamp(d, len), len));
            
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = r.Union(new(2, true, 1, true), len));
        }
        
        [Test]
        public void TestClampFromStartFromEnd()
        {
            int len = 100;
            Range<int> r = new(20, 35, true);
            
            Range<int> a = new(0, 70, true);
            Assert.IsTrue(new Range<int>(20, 30).Equals(r.Clamp(a, len), len));
            
            Range<int> b = new(30, 20, true);
            Assert.IsTrue(new Range<int>(30, 65).Equals(r.Clamp(b, len), len));

            Range<int> c = new(0, 30, true);
            Assert.IsTrue(r.Equals(r.Clamp(c, len), len));

            Range<int> d = new(30, 50, true);
            Assert.IsTrue(d.Equals(r.Clamp(d, len), len));
            
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = r.Union(new(98, 1, true), len));
        }
        
        [Test]
        public void TestClampFromEndFromStart()
        {
            int len = 100;
            Range<int> r = new(80, true, 65);
            
            Range<int> a = new(100, true, 30);
            Assert.IsTrue(new Range<int>(20, 30).Equals(r.Clamp(a, len), len));
            
            Range<int> b = new(70, true, 80);
            Assert.IsTrue(new Range<int>(30, 65).Equals(r.Clamp(b, len), len));

            Range<int> c = new(100, true, 70);
            Assert.IsTrue(r.Equals(r.Clamp(c, len), len));

            Range<int> d = new(70, true, 50);
            Assert.IsTrue(d.Equals(r.Clamp(d, len), len));
            
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = r.Union(new(2, true, 99), len));
        }
    }
}
