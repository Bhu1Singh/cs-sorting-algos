using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace Sorting_Algo
{
    public static class Insertion_Sort
    {
        public static Tuple<string, int> Sort(string unsorted)
        {
            //for counting the number of iterations
            int iCount = 0;
            var iarr = unsorted.Split(',', StringSplitOptions.RemoveEmptyEntries)
               .Select(x => x.Trim())
               .Select(int.Parse).ToArray();

            for (int i = 1; i < iarr.Length; i++)
            {
                var num = iarr[i];
                int j;

                for (j = i-1; j >= 0; j--)
                {
                    if (iarr[j] > num)
                    {
                        iarr[j + 1] = iarr[j];
                    }
                    else
                    {
                        break;
                    }
                    iCount++;
                }
                iarr[j + 1] = num;

            }
            //10,9,8
            // num = 9
            // 9,10,8



            return Tuple.Create<string, int>(iarr.Select(x => x.ToString())
                   .Aggregate((x, y) => x + "," + y), iCount);
        }
    }
}
