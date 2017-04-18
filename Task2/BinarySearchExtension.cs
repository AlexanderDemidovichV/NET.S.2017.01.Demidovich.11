using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    /// <summary>
    /// Provides extension methods for searching arrays
    /// </summary>
    public static class BinarySearchExtension
    {

        #region Public Methods

        /// <summary>
        /// Searches an entire one-dimensional sorted array for a specific element.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="array">The sorted one-dimensional array to search.</param>
        /// <param name="value">The object to search for.</param>
        /// <returns>The index of the specified value in the specified array, if value is found. If
        /// value is not found a negative number.</returns>
        public static int BinarySearch<T>(this T[] array, T value) 
            => BinarySearch(array, value, 0, array.Length, Comparer<T>.Default);

        /// <summary>
        /// Searches an entire one-dimensional sorted array for a specific element.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="array">The sorted one-dimensional array to search.</param>
        /// <param name="index">The starting index of the range to search.</param>
        /// <param name="length">The length of the range to search.</param>
        /// <param name="value">The object to search for.</param>
        /// <returns>The index of the specified value in the specified array, if value is found. If
        /// value is not found a negative number.</returns>
        public static int BinarySearch<T>(this T[] array, T value, int index, int length) 
            => BinarySearch(array, value, index, length, Comparer<T>.Default);

        /// <summary>
        /// Searches an entire one-dimensional sorted array for a specific element, using the Comparasion delegate.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="array">The sorted one-dimensional array to search.</param>
        /// <param name="value">The object to search for.</param>
        /// <param name="comparison">The Comparison to use when comparing elements.</param>
        /// <returns>The index of the specified value in the specified array, if value is found. If
        /// value is not found a negative number.</returns>
        public static int BinarySearch<T>(this T[] array, T value, Comparison<T> comparison) 
            => BinarySearch(array, value, 0, array.Length, Comparer<T>.Create(comparison));

        /// <summary>
        /// Searches an entire one-dimensional sorted array for a specific element, using the Comparasion delegate.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="array">The sorted one-dimensional array to search.</param>
        /// <param name="index">The starting index of the range to search.</param>
        /// <param name="length">The length of the range to search.</param>
        /// <param name="value">The object to search for.</param>
        /// <param name="comparison">The Comparison to use when comparing elements.</param>
        /// <returns>The index of the specified value in the specified array, if value is found. If
        /// value is not found a negative number.</returns>
        public static int BinarySearch<T>(this T[] array, T value, int index, int length, Comparison<T> comparison) 
            => BinarySearch(array, value, index, length, Comparer<T>.Create(comparison));

        /// <summary>
        /// Searches an entire one-dimensional sorted array for a specific element, using the specified IComparer generic interface.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="array">The sorted one-dimensional array to search.</param>
        /// <param name="value">The object to search for.</param>
        /// <param name="comparer">The IComparer generic interface implementation to use when comparing elements, 
        /// or null to use the IComparable generic interface implementation of each element.</param>
        /// <returns>The index of the specified value in the specified array, if value is found. If
        /// value is not found a negative number.</returns>
        public static int BinarySearch<T>(this T[] array, T value, IComparer<T> comparer) 
            => BinarySearch(array, value, 0, array.Length, comparer);

        /// <summary>
        /// Searches an entire one-dimensional sorted array for a specific element, using the specified IComparer generic interface.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="array">The sorted one-dimensional array to search.</param>
        /// <param name="index">The starting index of the range to search.</param>
        /// <param name="length">The length of the range to search.</param>
        /// <param name="value">The object to search for.</param>
        /// <param name="comparer">The IComparer generic interface implementation to use when comparing elements, 
        /// or null to use the IComparable generic interface implementation of each element.</param>
        /// <returns>The index of the specified value in the specified array, if value is found. If
        /// value is not found a negative number.</returns>
        public static int BinarySearch<T>(this T[] array, T value, int index, int length, IComparer<T> comparer)
        {
            if (ReferenceEquals(array, null))
                throw new ArgumentNullException($"{nameof(array)} is null.");

            if (value.Equals(default(T)))   
                throw new ArgumentNullException($"{nameof(value)} is null.");

            if (ReferenceEquals(comparer, null))
                throw new ArgumentNullException($"{nameof(comparer)} is null.");

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

        #endregion

    }
}
