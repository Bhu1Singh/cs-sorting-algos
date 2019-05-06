using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace Sorting_Algo
{
    public static class Radix_Sort
    {
        public static Tuple<string, int> Sort(string unsorted)
        {
            //for counting the number of iterations
            int iCount = 0;
            var iarr = unsorted.Split(',', StringSplitOptions.RemoveEmptyEntries)
               .Select(x => x.Trim())
               .Select(int.Parse).ToArray();

            return Tuple.Create<string, int>(iarr.Select(x => x.ToString())
                   .Aggregate((x, y) => x + "," + y), iCount);
        }
    }
}
