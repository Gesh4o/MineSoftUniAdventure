namespace CustomLinkedListTest
{
    using System;
    using CustomLinkedList;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Test
    {
        private DynamicList<int> integersList;

        [TestInitialize]
        public void Initialize_NewLinkList_ShouldHaveCountSetToZero()
        {
            this.integersList = new DynamicList<int>();
        }

        [TestMethod]
        public void EmptyList_ShouldHaveCountZero()
        {
            int expectedValue = 0;
            Assert.AreEqual(expectedValue, this.integersList.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_NullElementInExistingList_ShouldThrowExcepion()
        {
            var stringList = new DynamicList<string>();
            stringList.Add("Pesho");
            stringList.Add(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_NullElementInEmptyList_ShouldThrowExcepion()
        {
            var stringList = new DynamicList<string>();
            stringList.Add(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IndexOf_NullElementInExistingList_ShouldThrowExcepion()
        {
            var stringList = new DynamicList<string>();
            stringList.Add("Pesho");
            stringList.IndexOf(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Contains_NullElementInExistingList_ShouldThrowExcepion()
        {
            var stringList = new DynamicList<string>();
            stringList.Add("Pesho");
            stringList.Contains(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Remove_NullElementInExistingList_ShouldThrowExcepion()
        {
            var stringList = new DynamicList<string>();
            stringList.Add("Pesho");
            stringList.Remove(null);
        }

        [TestMethod]
        public void Add_NewItemToAnEmptyList_ShouldIncrementCount()
        {
            int numberToAdd = 3;

            this.integersList.Add(numberToAdd);

            Assert.AreEqual(1, this.integersList.Count);
        }

        [TestMethod]
        public void Remove_AnExistingItem_ShouldDecrementCount()
        {
            int valueToAdd = 5;
            this.integersList.Add(valueToAdd);
            int removedValueIndex = this.integersList.Remove(valueToAdd);

            Assert.AreEqual(0, this.integersList.Count, "List's count is not valid!");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Index_WithNegativeValue_ShouldThrowException()
        {
            int element = this.integersList[-3];
        }

        [TestMethod]
        public void Index_AnExistingElement_ShouldReturnElementValue()
        {
            int numberToAdd = 7;
            this.integersList.Add(numberToAdd);

            int expectedNumber = numberToAdd;
            int actualNumber = this.integersList[0];

            Assert.AreEqual(expectedNumber, actualNumber, "Indexing does not return proper element value!");
        }

        [TestMethod]
        public void Set_AValueOnExistingElementThroughIndex_ShouldSetNewValue()
        {
            int numberToAdd = 7;
            this.integersList.Add(numberToAdd);
            int valueToChangeWith = 4;
            this.integersList[0] = valueToChangeWith;

            int expectedNumber = valueToChangeWith;
            int actualNumber = this.integersList[0];

            Assert.AreEqual(expectedNumber, actualNumber, "Indexing after changed element value does not return proper element value!");
        }

        [TestMethod]
        public void Index_WithProperValue_ShouldReturnProperElement()
        {
            int numberToAdd = 5;
            this.integersList.Add(numberToAdd);

            int expectedNumber = 10;
            this.integersList.Add(expectedNumber);

            int actualNumber = this.integersList[1];

            Assert.AreEqual(expectedNumber, actualNumber, "Indexing an element in list does not return proper value");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Remove_AnExistingElement_ShouldRemoveElement()
        {
            int valueToAdd = 5;
            int secondValueToAdd = 10;
            this.integersList.Add(valueToAdd);
            this.integersList.Add(secondValueToAdd);

            int removedValueIndex = this.integersList.Remove(valueToAdd);

            for (int i = 0; i <= this.integersList.Count; i++)
            {
                int expectedValue = this.integersList[i]; // Expected exception here on last loop.
            }
        }

        [TestMethod]
        public void Remove_AnElementWhichExistsMoreThenOneTimeInList_ShouldRemoveFirstEncounteredElement()
        {
            int valueToAdd = 5;
            this.integersList.Add(valueToAdd);
            this.integersList.Add(valueToAdd);

            int actualValueIndex = this.integersList.Remove(valueToAdd);

            int expectedValueIndex = 0;

            Assert.AreEqual(expectedValueIndex, actualValueIndex, "Proper element was not removed!");
        }

        [TestMethod]
        public void Remove_AnElementWhichExistsMoreThenOneTimeInList_ShouldRemoveOnlyOneElement()
        {
            int valueToAdd = 5;
            this.integersList.Add(valueToAdd);
            this.integersList.Add(valueToAdd);

            this.integersList.Remove(valueToAdd);

            int expectedListCount = 1;

            Assert.AreEqual(
                expectedListCount,
                this.integersList.Count,
                "Count value is not proper after removing an element which exist more then once in list!");
        }

        [TestMethod]
        public void Remove_AnExistingItem_ShouldReturnExpectedRemovedValueIndex()
        {
            int valueToAdd = 5;
            this.integersList.Add(valueToAdd);
            int removedValueIndex = this.integersList.Remove(valueToAdd);

            Assert.AreEqual(0, removedValueIndex, "Index of removed item is not valid!");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Remove_AnElementInEmptyList_ShouldThrowException()
        {
            this.integersList.Remove(3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveAt_AnElementInEmptyList_ShouldThrowException()
        {
            int returnedValue = this.integersList.RemoveAt(0);
        }

        [TestMethod]
        public void RemoveAt_ExistingIndex_ShouldReturn_TheValueOfRemovedElement()
        {
            int numberToAdd = -3;

            this.integersList.Add(numberToAdd);
            int actualValue = this.integersList.RemoveAt(0);
            int expectedValue = numberToAdd;

            Assert.AreEqual(expectedValue, actualValue, "RemovedAt did not removed proper element!");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Remove_NonExistingElement_InNonEmptyList_ShouldThrowException()
        {
            this.integersList.Add(3);
            this.integersList.Remove(4);
        }

        [TestMethod]
        public void Index_AnExistingElement_ShouldReturnExpectedValueIndex()
        {
            int expectedElement = 4;
            this.integersList.Add(3);
            this.integersList.Add(expectedElement);

            int actualElement = this.integersList[1];

            Assert.AreEqual(expectedElement, actualElement, "Indexer does not return expected element.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Index_AtOutOfRangeIndex_ShouldThrowException()
        {
            this.integersList.Add(4);
            this.integersList.Add(9);

            int returnedElement = this.integersList[13];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveAt_IndexBiggerThenCount_ShouldThrowException()
        {
            this.integersList.Add(3);
            this.integersList.Add(2);
            this.integersList.Add(1);
            this.integersList.RemoveAt(4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IndexOf_NonExistingItem_ShouldThrowException()
        {
            this.integersList.Add(13);
            int index = this.integersList.IndexOf(4);
        }

        [TestMethod]
        public void IndexOf_AnExistingItem_ShouldReturnExpectedIndex()
        {
            this.integersList.Add(2);
            this.integersList.Add(3);

            int expectedIndex = 1;
            int actualIndex = this.integersList.IndexOf(3);

            Assert.AreEqual(expectedIndex, actualIndex, "IndexOf does not return expected index.");
        }

        [TestMethod]
        public void Contains_NonExistingElementInNonEmptyList_ShouldReturnFalse()
        {
            this.integersList.Add(3);

            bool result = this.integersList.Contains(4);

            Assert.IsFalse(result, "Non-existing element in list cannot be contained by the same list at the same time!");
        }

        [TestMethod]
        public void Contains_NonExistingElementInEmptyList_ShouldReturnFalse()
        {
            bool result = this.integersList.Contains(4);

            Assert.IsFalse(result, "An empty list cannot contain an element!");
        }

        [TestMethod]
        public void Contains_AnElementInEmptyList_ShouldReturnFalse()
        {
            bool result = this.integersList.Contains(4);
            Assert.IsFalse(result, "Element is not existing in current list!");
        }

        [TestMethod]
        public void Contains_AnExistingElementInNonEmptyList_ShouldReturnTrue()
        {
            this.integersList.Add(3);

            bool result = this.integersList.Contains(3);

            Assert.IsTrue(result, "Containing an existing element should return true!");
        }
    }
}
