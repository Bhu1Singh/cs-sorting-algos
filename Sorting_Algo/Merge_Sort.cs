using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Sorting_Algo
{
    public static class Merge_Sort
    {
        public static Tuple<string, int> Sort(string unsorted)
        {
            //for counting the number of iterations
            int iCount = 0;
            var iarr = unsorted.Split(',', StringSplitOptions.RemoveEmptyEntries)
               .Select(x => x.Trim())
               .Select(int.Parse).ToArray();

            MergeSort(iarr, 0, iarr.Length - 1, ref iCount);


            return Tuple.Create<string, int>(iarr.Select(x => x.ToString())
                   .Aggregate((x, y) => x + "," + y), iCount);
        }

        private static void MergeSort(int[] iarr, int start, int end, ref int iCount)
        {
            if (start < end)
            {
                var half = (start + end) / 2;

                MergeSort(iarr, start, half, ref iCount);
                MergeSort(iarr, half + 1, end, ref iCount);

                Merge(iarr, start, half, end, ref iCount);
            }
        }

        private static void Merge(int[] iarr, int start, int half, int end, ref int iCount)
        {
            var arr1len = half - start + 1;
            var arr2len = end - half;

            int[] arr1 = new int[arr1len];
            int[] arr2 = new int[arr2len];

            for (int i = 0; i < arr1len; i++)
            {
                arr1[i] = iarr[start + i];
            }
            for (int i = 0; i < arr2len; i++)
            {
                arr2[i] = iarr[half + 1 + i];
            }

            var x = 0;
            var y = 0;
            var k = start;

            while (x < arr1len && y < arr2len)
            {
                if (arr1[x] < arr2[y])
                {
                    iarr[k] = arr1[x];
                    x++;

                }
                else
                {
                    iarr[k] = arr2[y];
                    y++;
                }
                k++;
                iCount++;
            }

            while (x < arr1len)
            {
                iarr[k] = arr1[x];
                x++;
                k++;
                iCount++;
            }
            while (y < arr2len)
            {
                iarr[k] = arr2[y];
                y++;
                k++;
                iCount++;
            }
        }
    }
}
