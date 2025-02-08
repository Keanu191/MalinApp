using System.Collections.Generic;
using System.Linq;

namespace MalinApp.Services
{
    /// <summary>
    /// Provides sorting and searching algorithms for sensor data.
    /// </summary>
    public static class SortingHelper
    {
        /// <summary>
        /// Performs a selection sort on the provided linked list.
        /// </summary>
        /// <param name="list">The linked list to sort.</param>
        /// <returns>True if sorting completes successfully.</returns>
        public static bool SelectionSort(LinkedList<double> list)
        {
            int count = list.Count;
            for (int i = 0; i < count - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < count; j++)
                {
                    if (list.ElementAt(j) < list.ElementAt(minIndex))
                    {
                        minIndex = j;
                    }
                }

                var nodeI = list.Find(list.ElementAt(i));
                var nodeMin = list.Find(list.ElementAt(minIndex));
                double temp = nodeI.Value;
                nodeI.Value = nodeMin.Value;
                nodeMin.Value = temp;
            }
            return true;
        }

        /// <summary>
        /// Performs an insertion sort on the provided linked list.
        /// </summary>
        /// <param name="list">The linked list to sort.</param>
        /// <returns>True if sorting completes successfully.</returns>
        public static bool InsertionSort(LinkedList<double> list)
        {
            int count = list.Count;
            for (int i = 0; i < count - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (list.ElementAt(j - 1) > list.ElementAt(j))
                    {
                        var currentNode = list.Find(list.ElementAt(j));
                        double temp = list.ElementAt(j - 1);
                        currentNode.Previous.Value = list.ElementAt(j);
                        currentNode.Value = temp;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Performs an iterative binary search on the provided sorted linked list.
        /// </summary>
        /// <param name="list">The sorted linked list to search.</param>
        /// <param name="searchValue">The value to search for.</param>
        /// <param name="minimum">The starting index of the search range.</param>
        /// <param name="maximum">The ending index of the search range.</param>
        /// <returns>The index of the found element or the nearest neighbor index.</returns>
        public static int BinarySearchIterative(LinkedList<double> list, int searchValue, int minimum, int maximum)
        {
            while (minimum <= maximum - 1)
            {
                int middle = (minimum + maximum) / 2;
                double middleValue = list.ElementAt(middle);

                if (searchValue == middleValue)
                {
                    return middle + 1;
                }
                else if (searchValue < middleValue)
                {
                    maximum = middle - 1;
                }
                else
                {
                    minimum = middle + 1;
                }
            }
            return minimum - 1;
        }

        /// <summary>
        /// Performs a recursive binary search on the provided sorted linked list.
        /// </summary>
        /// <param name="list">The sorted linked list to search.</param>
        /// <param name="searchValue">The value to search for.</param>
        /// <param name="minimum">The starting index of the search range.</param>
        /// <param name="maximum">The ending index of the search range.</param>
        /// <returns>The index of the found element or the nearest neighbor index.</returns>
        public static int BinarySearchRecursive(LinkedList<double> list, int searchValue, int minimum, int maximum)
        {
            if (minimum <= maximum - 1)
            {
                int middle = (minimum + maximum) / 2;
                double middleValue = list.ElementAt(middle);

                if (searchValue == middleValue)
                {
                    return minimum;
                }
                else if (searchValue < middleValue)
                {
                    return BinarySearchRecursive(list, searchValue, minimum, middle - 1);
                }
                else
                {
                    return BinarySearchRecursive(list, searchValue, middle + 1, maximum);
                }
            }
            return minimum;
        }
    }
}
