using System.Collections;
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
                private static TurboStack<int> GiveAndPush(int count)
                {
                    var stack = Give();
                    for (int i = 0; i < count; i++)
                    {
                        stack.Push(3);
                    }

                    return stack;
                }


                [TestCase(1), TestCase(5), TestCase(1337)]
                public void IncreasesCount(int count)
                {
                    var stack = GiveAndPush(count);
                    Assert.AreEqual(count, stack.Count);
                }

                [TestCase(1, -7)]
                [TestCase(5, 0)] 
                [TestCase(1337, 333)]
                public void TheLatestItemCanBePeeked(int count, int item)
                {
                    var stack = GiveAndPush(count);
                   
                    Assert.AreEqual(item, stack.Peek());
                }
                
                [TestCase(1, -7)]
                [TestCase(5, 0)] 
                [TestCase(1337, 333)]
                public void TheLatestItemCanBePopped(int count, int item)
                {
                    var stack = GiveAndPush(count);
                    stack.Push(item);
                    Assert.AreEqual(item, stack.Pop());
                }
        
            }
        }
        
        
    }
    
}