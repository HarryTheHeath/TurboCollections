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

        [Test]
        public void AnAddedElementCanBeGet()
        {
            var list = new TurboList<int>();
            list.Add(1337);
            Assert.AreEqual(1337, list.Get(0));

        }
        
        [Test]
        public void MultipleAddedElementsCanBeGotten()
        {
            var (numbers, list) = CreateTestData();
            foreach (var number in numbers)
            {
                list.Add(number);
            }
            
            GetListValue();
        }
        
        [Test]
        public void ExistingItemsCanBeOverwrittenBySetting(int item)
        {
            // discount operator used as only interested in List
            var (_, list) = CreateTestData();
            
            // replace value with 666
            list.Set(2, item);
            Assert.AreEqual(item, list.Get(2));
        }
        
        [Test]
        public void ArrayCanBeExtendedBySetting()
        {
            const int setIndex = 100;
            // discount operator used as only interested in List
            var (_, list) = CreateTestData();
            Assert.Throws<IndexOutOfRangeException>(() => list.Set(setIndex, 666));
        }

        [Test]
        public void IsEmptyAfterClearing()
        {
            var (_, list) = CreateTestData();
            list.Clear();
            Assert.Zero(list.Count);
        }

        (int[] numbers, TurboList<int>) CreateTestData()
        {
            int[] numbers = {4, 13, 27, -88, 9, 39, 2};
            var list = new TurboList<int>();
            foreach (var number in numbers)
                list.Add(number);

            return (numbers, list);
        }

        public void GetListValue()
        {
            var (numbers, list) = CreateTestData();
            for (int i = 0; i < numbers.Length; i++)
            {
                Assert.AreEqual(numbers[i], list.Get(i));
            }
        }
    }
}
