using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_2
{
    internal class ArraySorter
    {
        List<int> _sortedList;

        public ArraySorter() 
        {
            _sortedList = new();
        }

        public ArraySorter(params int[][] arrays)
        {
            _sortedList = new();

            if (arrays is null)
            {
                throw new ArgumentNullException(nameof(arrays), "Arrays parameter cannot be null.");
            }

            foreach (int[] arrayRange in arrays)
            {
                _sortedList.AddRange(arrayRange);
            }

            _sortedList.Sort();
        }

        public IEnumerable<int> GetSortedArray()
        {
            for (int i = 0; i < _sortedList.Count; i++)
            {
                yield return _sortedList[i];
            }
        }
    }
}
