using System;

using NUnit.Framework;

namespace GenericRange.Tests
{
    [TestFixture]
    public class Tests
    {
        public const char Max = (char)127;
        public Range<char> chs = new('a', 'z');

        [Test]
        public void TestEquality()
        {
            var chs2 = chs;
            Assert.AreEqual(chs, chs2);
            Assert.AreEqual(chs.GetHashCode(), chs2.GetHashCode());
            Assert.IsTrue(chs == chs2);
            Assert.IsFalse(chs != chs2);
        }

        [Test]
        public void TestInequality()
        {
            Range<char> chs2 = new('0', '9');
            Assert.AreNotEqual(chs, chs2);
            Assert.AreNotEqual(chs.GetHashCode(), chs2.GetHashCode());
            Assert.IsFalse(chs == chs2);
            Assert.IsTrue(chs != chs2);
        }

        [Test]
        public void TestOffset()
        {
            var olFix = chs.GetOffsetAndLength(Max);
            var olVar = chs.GetOffsetAndLength();
            Assert.AreEqual(olFix, olVar);
            Assert.AreEqual(olFix.Offset, 'a');
            Assert.AreEqual(olFix.Length, 'z' - 'a');
        }
        
        [Test]
        public void TestIntersects()
        {
            Range<char> intersects = new('f', '|');
            Assert.IsTrue(chs.Intersects(intersects, Max));
            Assert.IsTrue(chs.Intersects(intersects));
        }
        
        [Test]
        public void TestEncompasses()
        {
            Assert.IsTrue(chs.Encompasses(chs, Max));
            Range<char> encompasses = new('a', 'c');
            Assert.IsTrue(chs.Intersects(encompasses, Max));
            Assert.IsTrue(chs.Encompasses(encompasses, Max));
            Assert.IsTrue(chs.Encompasses(encompasses));
        }

        [Test]
        public void TestImplicitFromTuple()
        {
            Range<char> chs2 = ('a', 'z');
            Assert.AreEqual(chs, chs2);
            Assert.AreEqual(chs.GetHashCode(), chs2.GetHashCode());
            Assert.IsTrue(chs == chs2);
            Assert.IsFalse(chs != chs2);
        }

        [Test]
        public void TestComparison()
        {
            Assert.IsTrue(chs.Start.CompareTo(chs.End, Max) < 0);
            Assert.IsTrue(chs.Start.CompareTo('g') <= 0);
            Assert.IsTrue(chs.End.CompareTo('g') >= 0);
            Assert.IsTrue(chs.Contains('g'));
            Assert.IsFalse(chs.Contains('|'));
        }
    }
}
