using System;

using NUnit.Framework;

namespace GenericRange.Tests
{
    [TestFixture]
    public class UnionTests
    {
        [Test]
        public void TestUnion()
        {
            Range<int> r = new(20, 65);
            
            Range<int> a = new(0, 30);
            Assert.IsTrue(new Range<int>(0, 65).Equals(r.Union(a)));
            
            Range<int> b = new(30, 80);
            Assert.IsTrue(new Range<int>(20, 80).Equals(r.Union(b)));

            Range<int> c = new(0, 70);
            Assert.IsTrue(c.Equals(r.Union(c)));

            Range<int> d = new(30, 50);
            Assert.IsTrue(r.Equals(r.Union(d)));
        }
        
        [Test]
        public void TestUnionFromEndFromEnd()
        {
            int len = 100;
            Range<int> r = new(80, true, 35, true);
            
            Range<int> a = new(100, true, 70, true);
            Assert.IsTrue(new Range<int>(0, 65).Equals(r.Union(a, len), len));
            
            Range<int> b = new(70, true, 20, true);
            Assert.IsTrue(new Range<int>(20, 80).Equals(r.Union(b, len), len));

            Range<int> c = new(100, true, 30, true);
            Assert.IsTrue(c.Equals(r.Union(c, len), len));
            
            Range<int> d = new(70, true, 50, true);
            Assert.IsTrue(r.Equals(r.Union(d, len), len));
        }
        
        [Test]
        public void TestUnionFromStartFromEnd()
        {
            int len = 100;
            Range<int> r = new(20, 35, true);
            
            Range<int> a = new(0, 70, true);
            Assert.IsTrue(new Range<int>(0, 65).Equals(r.Union(a, len), len));
            
            Range<int> b = new(30, 20, true);
            Assert.IsTrue(new Range<int>(20, 80).Equals(r.Union(b, len), len));

            Range<int> c = new(0, 30, true);
            Assert.IsTrue(c.Equals(r.Union(c, len), len));

            Range<int> d = new(30, 50, true);
            Assert.IsTrue(r.Equals(r.Union(d, len), len));
        }
        
        [Test]
        public void TestUnionFromEndFromStart()
        {
            int len = 100;
            Range<int> r = new(80, true, 65);
            
            Range<int> a = new(100, true, 30);
            Assert.IsTrue(new Range<int>(0, 65).Equals(r.Union(a, len), len));
            
            Range<int> b = new(70, true, 80);
            Assert.IsTrue(new Range<int>(20, 80).Equals(r.Union(b, len), len));

            Range<int> c = new(100, true, 70);
            Assert.IsTrue(c.Equals(r.Union(c, len), len));

            Range<int> d = new(70, true, 50);
            Assert.IsTrue(r.Equals(r.Union(d, len), len));
        }
    }
}
