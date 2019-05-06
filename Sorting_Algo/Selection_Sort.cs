using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace Sorting_Algo
{
    public static class Selection_Sort
    {
        public static Tuple<string, int> Sort(string unsorted)
        {
            //for counting the number of iterations
            int iCount = 0;
            var iarr = unsorted.Split(',', StringSplitOptions.RemoveEmptyEntries)
               .Select(x => x.Trim())
               .Select(int.Parse).ToArray();

            for (int i = 0; i < iarr.Length-1; i++)
            {
                var m = i;
                for (int j = i; j < iarr.Length; j++)
                {
                    if (iarr[j] < iarr[m])
                    {
                        m = j;
                    }
                    iCount++;
                }

                //swap without using additional variable
                var swap = iarr[i];
                iarr[i] = iarr[m];                
                iarr[m] = swap;                
            }

            //a=1,b=2
            //a=a+b = 3, b = a-b = 1, a = a-b = 2

            return Tuple.Create<string, int>(iarr.Select(x => x.ToString())
                .Aggregate((x, y) => x + "," + y), iCount);
        }

    }
}
