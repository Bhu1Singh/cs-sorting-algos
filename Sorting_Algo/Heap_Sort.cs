using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace Sorting_Algo
{
    public static class Heap_Sort
    {
        public static Tuple<string, int> Sort(string unsorted)
        {
            //for counting the number of iterations
           int iCount = 0;
            var iarr = unsorted.Split(',', StringSplitOptions.RemoveEmptyEntries)
               .Select(x => x.Trim())
               .Select(int.Parse).ToArray();

            for (int i = (iarr.Length / 2) - 1; i >= 0; i--)
            {
                Heapify(iarr, iarr.Length, i, ref iCount);
                iCount++;
            }

            for (int i = iarr.Length - 1; i >= 0; i--)
            {
                var temp = iarr[0];
                iarr[0] = iarr[i];
                iarr[i] = temp;

                Heapify(iarr, i, 0, ref iCount);
                iCount++;
            }


            return Tuple.Create<string, int>(iarr.Select(x => x.ToString())
                   .Aggregate((x, y) => x + "," + y), iCount);
        }

        private static void Heapify(int[] arr, int al, int root, ref int iCount)
        {
            iCount++;

            var largest = root;
            var left = 2 * root + 1;
            var right = 2 * root + 2;

            if (left < al && arr[left] > arr[largest])
            {
                largest = left;
            }

            if (right < al && arr[right] > arr[largest])
            {
                largest = right;
            }

            if (largest != root)
            {
                var temp = arr[root];
                arr[root] = arr[largest];
                arr[largest] = temp;

                Heapify(arr, al, largest, ref iCount);
            }
        }


    }
}
