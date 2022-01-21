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
            public static TurboStack<int> Give()
            {
                return new TurboStack<int>();
            }
            
            [Test]
            public void ItHasACountOfZero()
            {
                Assert.Zero(Give().Count);
            }
            
            public class WhenPushing
            {
                [TestCase(1), TestCase(5), TestCase(1337)]
                public void IncreasesCount(int count)
                {
                    var stack = Give();
                    for (int i = 0; i < count; i++)
                    {
                        stack.Push(3);
                    }
                    Assert.AreEqual(1, stack.Count);
                }
        
            }
        }
        
        
    }
    
}