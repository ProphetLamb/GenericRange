using System;

using GenericRange.TypeConverters;

using NUnit.Framework;

namespace GenericRange.Tests
{
    [TestFixture]
    public class TestConverters
    {
        [Test]
        public void TestDeserializeFloat()
        {
            string range = "^12.04..4";

            var floatRange = Range<float>.Parse(range);
            Assert.IsTrue(new Range<float>(12.04f, true, 4).Equals(floatRange));

            var doubleRange = Range<double>.Parse(range);
            Assert.IsTrue(new Range<double>(12.04, true, 4).Equals(doubleRange));

            var decimalRange = Range<decimal>.Parse(range);
            Assert.IsTrue(new Range<decimal>(12.04m, true, 4).Equals(decimalRange));
        }
    
        [Test]
        public void TestSerializeFloat()
        {
            string range = "^12.04..4";
            
            Range<double> doubleRange = new(12.04, true, 4);
            Assert.AreEqual(range, doubleRange.ToString());
            
            var floatRange = doubleRange.ToRange<float>();
            Assert.AreEqual(range, floatRange.ToString());
            
            var decimalRange = doubleRange.ToRange<decimal>();
            Assert.AreEqual(range, decimalRange.ToString());
        }
        
        [Test]
        public void TestDeserializeInteger()
        {
            string range = "^12..4";

            var floatRange = Range<int>.Parse(range);
            Assert.IsTrue(new Range<int>(12, true, 4).Equals(floatRange));

            var doubleRange = Range<uint>.Parse(range);
            Assert.IsTrue(new Range<uint>(12, true, 4).Equals(doubleRange));

            var decimalRange = Range<long>.Parse(range);
            Assert.IsTrue(new Range<long>(12, true, 4).Equals(decimalRange));
        }
    
        [Test]
        public void TestSerializeInteger()
        {
            string range = "^12..4";
            
            Range<long> doubleRange = new(12, true, 4);
            Assert.AreEqual(range, doubleRange.ToString());
            
            var floatRange = doubleRange.ToRange<int>();
            Assert.AreEqual(range, floatRange.ToString());
            
            var decimalRange = doubleRange.ToRange<uint>();
            Assert.AreEqual(range, decimalRange.ToString());
        }
        
        [Test]
        public void TestDeserializeEnum()
        {
            string range = "^Eight..One";

            Range<Foo> fooRange = Range<Foo>.Parse(range);
            Assert.IsTrue(new Range<Foo>(Foo.Eight, true, Foo.One).Equals(fooRange));
        }
    
        [Test]
        public void TestSerializeEnum()
        {
            string range = "^Eight..One";
            
            Range<Foo> fooRange = new(Foo.Eight, true, Foo.One);
            Assert.AreEqual(range, fooRange.ToString());
        }

        [Test]
        public void TestConvertEnum()
        {
            Range<Foo> fooRange = new(Foo.Eight, true, Foo.One);
            Range<byte> byteRange = fooRange.ToRange<byte>();
        }

        [Test]
        public void TestTimeSpan()
        {
            Range<TimeSpan> timeRange = new Range<TimeSpan>(TimeSpan.Zero, TimeSpan.FromMinutes(4));
            
            string serialized = timeRange.ToString();
            Assert.IsTrue(timeRange.Equals(Range<TimeSpan>.Parse(serialized)));
        }
    }
}
