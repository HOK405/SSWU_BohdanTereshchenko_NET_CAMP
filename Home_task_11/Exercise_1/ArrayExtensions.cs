using System;
namespace Exercise_1
{
    public static class ArrayExtensions
    {
        private static Random rng = new Random();

        public static T[] QuickSortFirst<T>(this T[] sourceArray, bool ascending = true) where T : IComparable
        {
            return QuickSort(sourceArray, (arr, low, high) => low, ascending);
        }

        public static T[] QuickSortRandom<T>(this T[] sourceArray, bool ascending = true) where T : IComparable
        {
            return QuickSort(sourceArray, (arr, low, high) => rng.Next(low, high + 1), ascending);
        }

        public static T[] QuickSortMedian<T>(this T[] sourceArray, bool ascending = true) where T : IComparable
        {
            return QuickSort(sourceArray, (arr, low, high) => MedianOfThree(arr, low, high), ascending);
        }

        private static T[] QuickSort<T>(T[] sourceArray, Func<T[], int, int, int> pivotFunc, bool ascending) where T : IComparable
        {
            T[] copyArr = new T[sourceArray.Length];
            sourceArray.CopyTo(copyArr, 0);

            QuickSort(copyArr, 0, copyArr.Length - 1, pivotFunc, ascending);
            return copyArr;
        }

        private static void QuickSort<T>(T[] arr, int low, int high, Func<T[], int, int, int> pivotFunc, bool ascending) where T : IComparable
        {
            if (low < high)
            {
                int pi = Partition(arr, low, high, pivotFunc, ascending);

                QuickSort(arr, low, pi - 1, pivotFunc, ascending);
                QuickSort(arr, pi + 1, high, pivotFunc, ascending);
            }
        }

        private static int Partition<T>(T[] arr, int low, int high, Func<T[], int, int, int> pivotFunc, bool ascending) where T : IComparable
        {
            int pivotIndex = pivotFunc(arr, low, high);
            T pivotValue = arr[pivotIndex];

            (arr[pivotIndex], arr[high]) = (arr[high], arr[pivotIndex]);

            int i = low;

            for (int j = low; j <= high; j++)
            {
                if ((ascending && arr[j].CompareTo(pivotValue) < 0) || (!ascending && arr[j].CompareTo(pivotValue) > 0))
                {
                    (arr[i], arr[j]) = (arr[j], arr[i]);
                    i++;
                }
            }
            (arr[i], arr[high]) = (arr[high], arr[i]);

            return i;
        }

        private static int MedianOfThree<T>(T[] arr, int low, int high) where T : IComparable
        {
            int mid = low + ((high - low) / 2);
            T a = arr[low];
            T b = arr[mid];
            T c = arr[high];

            if (a.CompareTo(b) > 0)
            {
                if (b.CompareTo(c) > 0) return mid;
                else if (a.CompareTo(c) > 0) return high;
                else return low;
            }
            else
            {
                if (a.CompareTo(c) > 0) return low;
                else if (b.CompareTo(c) > 0) return high;
                else return mid;
            }
        }
    }
}
