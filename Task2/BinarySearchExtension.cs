using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class BinarySearchExtension
    {
        public int BinarySearch<T>(T[] array, T value)
        {
            return BinarySearch(array, value, 0, 0, Comparer<T>.Default);
        }

        public int BinarySearch<T>(T[] array, T value, int index, int length)
        {
            return BinarySearch(array, value, index, length, Comparer<T>.Default);
        }

        public int BinarySearch<T>(T[] array, T value, Comparison<T> comparison)
        {
            return BinarySearch(array, value, 0, 0, Comparer<T>.Create(comparison));
        }

        public int BinarySearch<T>(T[] array, T value, int index, int length, Comparison<T> comparison)
        {
            return BinarySearch(array, value, index, length, Comparer<T>.Create(comparison));
        }

        public int BinarySearch<T>(T[] array, T value, IComparer<T> comparer)
        {
            return BinarySearch(array, value, 0, 0, comparer);
        }

        public int BinarySearch<T>(T[] array, T value, int index, int length, IComparer<T> comparer)
        {
            if (ReferenceEquals(array, null))
                throw new ArgumentNullException($"{nameof(array)} is null.");

            if (ReferenceEquals(comparer, null))
                comparer = Comparer<T>.Default;

            if (ReferenceEquals(value, null))   
                throw new ArgumentNullException($"{nameof(value)} is null.");

            if (index < 0)
                throw new ArgumentOutOfRangeException($"{nameof(index)} less than zero.");

            if (length < 0)
                throw new ArgumentOutOfRangeException($"{nameof(length)} less than zero.");

            if (index + length > array.Length)
                throw new ArgumentOutOfRangeException($"{nameof(length)}.");

            if (array.Length == 0)
                return -1;

            int left = index;
            int right = index + length - 1;

            while (left <= right)
            {
                int middle = (left + right) / 2;

                if (comparer.Compare(value, array[middle]) > 0)
                {
                    left = middle + 1;
                }
                else if (comparer.Compare(value, array[middle]) < 0)
                {
                    right = middle - 1;
                }
                else
                {
                    return middle;
                }
            }

            return -1;

        }
    }
}
