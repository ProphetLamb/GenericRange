﻿using System;

using NUnit.Framework;

namespace GenericRange.Tests
{
    [TestFixture]
    public class TestRange
    {
        public string HelloWorld = null!;
        public Range HelloRange;
        public Range WorldRange;
        public Range<int> HelloIntRange;
        public Range<int> WorldIntRange;

        [SetUp]
        public void SetUp()
        {
            HelloWorld = "Hello World";
            HelloRange = new Range(0, 5);
            WorldRange = new Range(^5, ^0);
            HelloIntRange = HelloRange.ToRange();
            WorldIntRange = WorldRange.ToRange();       
        }
        
        
        [Test]
        public void TestSubstring()
        {
            var hello = HelloWorld[HelloRange];
            var world = HelloWorld[WorldRange];
            Assert.AreEqual(hello, HelloWorld[HelloIntRange.ToRange()]);
            Assert.AreEqual(world, HelloWorld[WorldIntRange.ToRange()]);
        }

        [Test]
        public void TestOffset()
        {
            var olHelloRange = HelloRange.GetOffsetAndLength(HelloWorld.Length);
            var olWorldRange = WorldRange.GetOffsetAndLength(HelloWorld.Length);
            Assert.AreEqual(olHelloRange, HelloIntRange.GetOffsetAndLength(HelloWorld.Length));
            Assert.AreEqual(olWorldRange, WorldIntRange.GetOffsetAndLength(HelloWorld.Length));
            
            Assert.DoesNotThrow(() => HelloIntRange.GetOffsetAndLength());
            // Assert.Throws<???>(() => WorldIntRange.GetOffsetAndLength());
        }
    }
}