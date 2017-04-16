using System.Collections.Generic;
using NUnit.Framework;
using System;

namespace Task2.Tests
{
    public class BinarySearchTest
    {
        public IEnumerable<TestCaseData> DefaultTestData
        {
            get
            {
                yield return new TestCaseData(new int[] { 1, 2, 3, 4, 5, 6 }, 6).Returns(5);
                yield return new TestCaseData(new int[] { 1, 2, 3, 4, 5, 6 }, 1).Returns(0);
                yield return new TestCaseData(new int[] { 1, 2, 3, 4, 5, 6 }, 3).Returns(2);
                yield return new TestCaseData(new int[] { 1, 2, 3, 4, 5, 6 }, 7).Returns(-1);
            }
        }

        [Test, TestCaseSource("DefaultTestData")]
        public static int BinarySearch_Comparer_Test_Yeild<T>(T[] array, T value)
        {
            return array.BinarySearch(value);
        }

        public class IntComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return x - y;
            }
        }

        public IEnumerable<TestCaseData> ComparerTestData
        {
            get
            {
                IComparer<int> comp = new IntComparer();

                yield return new TestCaseData(new int[] { 1, 2, 3, 4, 5, 6 }, 6, comp).Returns(5);
                yield return new TestCaseData(new int[] { 1, 2, 3, 4, 5, 6 }, 1, comp).Returns(0);
                yield return new TestCaseData(new int[] { 1, 2, 3, 4, 5, 6 }, 3, comp).Returns(2);
                yield return new TestCaseData(new int[] { 1, 2, 3, 4, 5, 6 }, 7, comp).Returns(-1);
            }
        }

        [Test, TestCaseSource("ComparerTestData")]
        public static int BinarySearch_Comparer_Test_Yeild<T>(T[] array, T value, IComparer<T> comparer)
        {
            return array.BinarySearch(value, comparer);
        }

        public IEnumerable<TestCaseData> ComparerRangeTestData
        {
            get
            {
                IComparer<int> comp = new IntComparer();

                yield return new TestCaseData(new int[] { 1, 2, 3, 4, 5, 6 }, 0, 6, 6, comp).Returns(5);
                yield return new TestCaseData(new int[] { 1, 2, 3, 4, 5, 6 }, 0, 6, 1, comp).Returns(0);
                yield return new TestCaseData(new int[] { 1, 2, 3, 4, 5, 6 }, 0, 6, 3, comp).Returns(2);
                yield return new TestCaseData(new int[] { 1, 2, 3, 4, 5, 6 }, 0, 6, 7, comp).Returns(-1);
                yield return new TestCaseData(new int[] { 1, 2, 3, 4, 5, 6 }, 1, 5, 1, comp).Returns(-1);
            }
        }

        [Test, TestCaseSource("ComparerRangeTestData")]
        public static int BinarySearch_Comparer_Test_Yeild<T>(T[] array, int index, int length, T value, IComparer<T> comparer)
        {
            return array.BinarySearch(value, index, length, comparer);
        }



        public IEnumerable<TestCaseData> ComparisonTestData
        {
            get
            {
                Comparison<int> comp = (a, b) => a - b;

                yield return new TestCaseData(new int[] { 1, 2, 3, 4, 5, 6 }, 6, comp).Returns(5);
                yield return new TestCaseData(new int[] { 1, 2, 3, 4, 5, 6 }, 1, comp).Returns(0);
                yield return new TestCaseData(new int[] { 1, 2, 3, 4, 5, 6 }, 3, comp).Returns(2);
                yield return new TestCaseData(new int[] { 1, 2, 3, 4, 5, 6 }, 7, comp).Returns(-1);
            }
        }

        [Test, TestCaseSource("ComparisonTestData")]
        public static int BinarySearch_Comparison_Test_Yeild<T>(T[] array, T value, Comparison<T> comparasion)
        {
            return array.BinarySearch(value, comparasion);
        }

        public IEnumerable<TestCaseData> ComparisonRangeTestData
        {
            get
            {
                Comparison<int> comp = (a, b) => a - b;

                yield return new TestCaseData(new int[] { 1, 2, 3, 4, 5, 6 }, 0, 6, 6, comp).Returns(5);
                yield return new TestCaseData(new int[] { 1, 2, 3, 4, 5, 6 }, 0, 6, 1, comp).Returns(0);
                yield return new TestCaseData(new int[] { 1, 2, 3, 4, 5, 6 }, 0, 6, 3, comp).Returns(2);
                yield return new TestCaseData(new int[] { 1, 2, 3, 4, 5, 6 }, 0, 6, 7, comp).Returns(-1);
                yield return new TestCaseData(new int[] { 1, 2, 3, 4, 5, 6 }, 1, 5, 1, comp).Returns(-1);
            }
        }

        [Test, TestCaseSource("ComparisonRangeTestData")]
        public static int BinarySearch_Comparison_Test_Yeild<T>(T[] array, int index, int length, T value, Comparison<T> comparasion)
        {
            return array.BinarySearch(value, index, length, comparasion);
        }
    }
}
