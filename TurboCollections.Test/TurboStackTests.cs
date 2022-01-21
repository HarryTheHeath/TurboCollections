using NUnit.Framework;

namespace TurboCollections.Test
{
    [TestFixture]
    public class TurboStackTests
    {
        [Test]
        public void HasEmptyConstructor()
        {
            new TurboStack<int>();
            Assert.Pass();
        }

        public class ANewStack
        {
            private TurboStack<int> stack;
            
            [SetUp]
            public void SetUp()
            {
                this.stack = new TurboStack<int>();
            }
            
            [Test]
            public void HasACountOfZero()
            {
                Assert.Zero(stack.Count);
            }
        }
    }
}