using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace Sorting_Algo
{
    public static class Quick_Sort
    {
        public static Tuple<string, int> Sort(string unsorted)
        {
            //for counting the number of iterations
            int iCount = 0;
            var iarr = unsorted.Split(new char[] { ',', '.' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(x => x.Trim())
               .Select(int.Parse).ToArray();

            QuickSort(iarr, 0, iarr.Length - 1, ref iCount);

            return Tuple.Create<string, int>(iarr.Select(x => x.ToString())
                   .Aggregate((x, y) => x + "," + y), iCount);
        }

        private static void QuickSort(int[] iarr, int low, int high, ref int iCount)
        {
            if (low < high)
            {

                int pivot = Partition(iarr, low, high, ref iCount);

                QuickSort(iarr, low, pivot - 1, ref iCount);
                QuickSort(iarr, pivot + 1, high, ref iCount);

            }
        }

        private static int Partition(int[] iarr, int low, int pivot, ref int iCount)
        {
            int newpivot = low - 1;
            var swap = 0;

            for (int i = low; i <= pivot - 1; i++)
            {
                if (iarr[i] < iarr[pivot])
                {
                    newpivot++;
                    //swap i and newpivot
                    swap = iarr[newpivot];
                    iarr[newpivot] = iarr[i];
                    iarr[i] = swap;
                }
                iCount++;
            }

            //swap pivot and newpivot-1
            swap = iarr[pivot];
            iarr[pivot] = iarr[newpivot + 1];
            iarr[newpivot + 1] = swap;

            return newpivot + 1;

        }
    }
}
