using System;
using System.Linq;

namespace Sorting_Algo
{
    public static class Bubble_Sort
    {
        public static Tuple<string, int> Sort(string unsorted)
        {
            //for counting the number of iterations
            int iCount = 0;
            var iarr = unsorted.Split(',', StringSplitOptions.RemoveEmptyEntries)
               .Select(x => x.Trim())
               .Select(int.Parse).ToArray();



            for (int i = 0; i < iarr.Length; i++)
            {                
                for (int j = 0; j < iarr.Length; j++)
                {       
                    //check if value from loop 1 is less than each value in loop 2 and swap
                    if (iarr[i] < iarr[j])
                    {
                        //in place swap without using additional variable
                        iarr[i] = iarr[j] + iarr[i];
                        iarr[j] = iarr[i] - iarr[j];
                        iarr[i] = iarr[i] - iarr[j];
                    }

                    iCount++;

                }
            }

            //a=1,b=2
            //a=a+b = 3, b = a-b = 1, a = a-b = 2

            return Tuple.Create<string, int>(iarr.Select(x => x.ToString())
                .Aggregate((x, y) => x + "," + y), iCount);
        }
    }
}
