using System;
using NUnit.Framework;

namespace TurboCollections.Test
{
    public class TurboListTests
    {
        [Test]
        public void NewListIsEmpty()
        {
            var list = new TurboList<int>();
            Assert.Zero(list.Count);
        }

        public class WhenAdding
        {
            [Test]
            public void AddingAnElementIncreasesCountsToOne()
            {
                var list = new TurboList<int>();
                list.Add(5);
                Assert.AreEqual(1,list.Count);
            }
        
            [Test, TestCase(5), TestCase(7)]
            public void AddingMultipleElementIncreasesTheCount(int numberOfElements)
            {
                var list = new TurboList<int>();
                for (int i = 0; i < numberOfElements; i++)
                    list.Add(5);
                Assert.AreEqual(numberOfElements,list.Count);
            }
        }

        public class WhenGetting
        {
            [Test]
            public void AddedElementsAreFound()
            {
                var list = new TurboList<int>();
                list.Add(1337);
                Assert.AreEqual(1337, list.Get(0));

            }
        
            [Test]
            public void MultipleAddedElementsAreFound()
            {
                var (numbers, list) = CreateTestData();
                foreach (var number in numbers)
                {
                    list.Add(number);
                }
                GetListValue();
            }
        }
        
        public class WhenSetting
        {
            [Test]
            public void ExistingItemsAreOverwritten(int item)
            {
                // discount operator used as only interested in List
                var (_, list) = CreateTestData();
            
                // replace value with 666
                list.Set(2, item);
                Assert.AreEqual(item, list.Get(2));
            }
        
            [Test]
            public void ArrayIsExtended()
            {
                const int setIndex = 100;
                // discount operator used as only interested in List
                var (_, list) = CreateTestData();
                Assert.Throws<IndexOutOfRangeException>(() => list.Set(setIndex, 666));
            }

        }
        
        public class WhenClearing
        {
            [Test]
            public void ItIsEmptied()
            {
                var (_, list) = CreateTestData();
                list.Clear();
                Assert.Zero(list.Count);
            }
        
            [Test]
            public void AddingBeginsAtZeroIndex()
            {
                var (_, list) = CreateTestData();
                list.Clear();
                list.Add(5);
                Assert.AreEqual(1, list.Count);
                Assert.AreEqual(5, list.Get(0));
            }
        
            [Test]
            public void ItemsClearedAndResetToDefault()
            {
                // given 
                var (_numbers, list) = CreateTestData();
            
                // when
                list.Clear();
            
                // then
                for (int i = 0; i < _numbers.Length; i++)
                {
                    Assert.Zero(list.Get(i));
                }
            }
        }

        public class WhenRemoving
        {
            [Test]
            public void CountIsReduced()
            {
                var (_numbers, list) = CreateTestData();

                list.RemoveAt(2);
            
                Assert.AreEqual(_numbers.Length-1, list.Count);
            }
        
            [Test]
            public void ItemsAreMovedForward()
            {
                var (_numbers, list) = CreateTestData();

                list.RemoveAt(2);

                for (int i = 2; i <_numbers.Length-1; i++)
                {
                    Assert.AreEqual(_numbers[i+1], list.Get(i), $"Wrong item at index {i}");
                }
            }
        }
        

        public static (int[] numbers, TurboList<int>) CreateTestData()
        {
            int[] numbers = {4, 13, 27, -88, 9, 39, 2};
            var list = new TurboList<int>();
            foreach (var number in numbers)
                list.Add(number);

            return (numbers, list);
        }

        public static void GetListValue()
        {
            var (numbers, list) = CreateTestData();
            for (int i = 0; i < numbers.Length; i++)
            {
                Assert.AreEqual(numbers[i], list.Get(i));
            }
        }
    }
}
