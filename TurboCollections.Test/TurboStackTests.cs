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

        public class GivenANewStack
        {
            private static TurboStack<int> stack;
            
            [SetUp]
            public static TurboStack<int> Give()
            {
                return new TurboStack<int>();
            }
            
            [Test]
            public void ItHasACountOfZero()
            {
                Assert.Zero(stack.Count);
            }
            
            public class WhenPushing
            {
                [Test]
                public void IncreasesCount()
                {
                    var stack = Give();
                    stack.Push(3);
                    Assert.AreEqual(1, GivenANewStack.stack.Count);
                }
        
            }
        }
        
        
    }
    
}