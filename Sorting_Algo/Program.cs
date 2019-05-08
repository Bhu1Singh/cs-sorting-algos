using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace Sorting_Algo
{
    class Program
    {

        static void Main(string[] args)
        {
            while (true)
            {
                var sortargs = DefaultScreen();
                Sort(sortargs);


                var nxt = Close();

                if (nxt == "E")
                {
                    break;
                }
                else
                {
                    //Console.Clear();
                }
            }
        }

        public static void Sort(Tuple<int, string> sortargs)
        {
            switch (sortargs.Item1)
            {
                case 1:
                    var bubble = Performance<string, Tuple<string, int>>(Bubble_Sort.Sort, sortargs.Item2);
                    DisplayResult("Bubble", bubble);
                    break;
                case 2:
                    var selection = Performance<string, Tuple<string, int>>(Selection_Sort.Sort, sortargs.Item2);
                    DisplayResult("Selection", selection);
                    break;
                case 3:
                    var insertion = Performance<string, Tuple<string, int>>(Insertion_Sort.Sort, sortargs.Item2);
                    DisplayResult("Insertion", insertion); break;
                case 4:
                    var quick = Performance<string, Tuple<string, int>>(Quick_Sort.Sort, sortargs.Item2);
                    DisplayResult("Quick", quick); break;
                case 5:
                    var heap = Performance<string, Tuple<string, int>>(Heap_Sort.Sort, sortargs.Item2);
                    DisplayResult("Heap", heap);
                    break;
                case 6:
                    var merge = Performance<string, Tuple<string, int>>(Merge_Sort.Sort, sortargs.Item2);
                    DisplayResult("Merge", merge);
                    break;
                case 7:
                    var radix = Performance<string, Tuple<string, int>>(Radix_Sort.Sort, sortargs.Item2);
                    DisplayResult("Radix", radix);
                    break;
                case 8:
                    List<(string, int, string)> all = new List<(string, int, string)>();
                    bubble = Performance<string, Tuple<string, int>>(Bubble_Sort.Sort, sortargs.Item2);
                    selection = Performance<string, Tuple<string, int>>(Selection_Sort.Sort, sortargs.Item2);
                    insertion = Performance<string, Tuple<string, int>>(Insertion_Sort.Sort, sortargs.Item2);
                    quick = Performance<string, Tuple<string, int>>(Quick_Sort.Sort, sortargs.Item2);
                    heap = Performance<string, Tuple<string, int>>(Heap_Sort.Sort, sortargs.Item2);
                    merge = Performance<string, Tuple<string, int>>(Merge_Sort.Sort, sortargs.Item2);
                    radix = Performance<string, Tuple<string, int>>(Radix_Sort.Sort, sortargs.Item2);

                    all.Add(ValueTuple.Create<string, int, string>("Bubble Sort", bubble.Item1.Item2, bubble.Item2));
                    all.Add(ValueTuple.Create<string, int, string>("Selection Sort", selection.Item1.Item2, selection.Item2));
                    all.Add(ValueTuple.Create<string, int, string>("Insertion Sort", insertion.Item1.Item2, insertion.Item2));
                    all.Add(ValueTuple.Create<string, int, string>("Quick Sort", quick.Item1.Item2, quick.Item2));
                    all.Add(ValueTuple.Create<string, int, string>("Heap Sort", heap.Item1.Item2, heap.Item2));
                    all.Add(ValueTuple.Create<string, int, string>("Merge Sort", merge.Item1.Item2, merge.Item2));
                    all.Add(ValueTuple.Create<string, int, string>("Radix Sort", radix.Item1.Item2, radix.Item2));

                    DisplayResult(all);
                    break;
                default:
                    break;

            }
        }

        public static (TR, string) Performance<T, TR>(Func<T, TR> function, T arg)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var result = function(arg);
            sw.Stop();
            return (result, sw.ElapsedMilliseconds.ToString());
        }

        public static Tuple<int, string> DefaultScreen(string message = "")
        {
            Console.WriteLine();
            Console.WriteLine("**********Sorting Algorithm Comparer**********");
            Console.WriteLine("Enter the number to select the algorithm:");
            Console.WriteLine("1. Bubble Sort");
            Console.WriteLine("2. Selection Sort");
            Console.WriteLine("3. Insertion Sort");
            Console.WriteLine("4. Quick Sort");
            Console.WriteLine("5. Heap Sort");
            Console.WriteLine("6. Merge Sort");
            Console.WriteLine("7. Radix Sort");
            Console.WriteLine("8. Compare All Sorts");

            Console.WriteLine();
            Console.Write("Choose Algo:");

            var algo = 0;
            while (true)
            {
                int.TryParse(Console.ReadLine(), out algo);
                if (algo <= 0 || algo > 8)
                {
                    Console.WriteLine("Invalid Choice.Try again.");
                }
                else
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("Enter the number of unsorted numbers to chose:");

            var numarr = 0;

            while (true)
            {
                int.TryParse(Console.ReadLine(), out numarr);
                if (numarr <= 0)
                {
                    Console.WriteLine("Enter a number greater than zero");
                }
                else
                    break;
            }

            string arr = "";
            Random rnd = new Random(31);
            while (numarr > 0)
            {
                arr += rnd.Next(1, 10000).ToString() + ",";
                numarr--;
            }
            Console.WriteLine(arr);
            return Tuple.Create<int, string>(algo, arr);
        }

        public static string Close()
        {
            Console.WriteLine();
            Console.WriteLine("Continue(C) or Exit(E). Enter your choice: ");
            return Console.ReadLine().ToUpper();
        }

        public static void DisplayResult(string sort_algo, (Tuple<string, int>, string) result)
        {
            Console.WriteLine();
            Console.WriteLine("******************************");
            Console.WriteLine($"{sort_algo} Sort Results-->");
            Console.WriteLine($"Number of operations: {result.Item1.Item2}");
            Console.WriteLine($"Operation time: {result.Item2}");
            Console.WriteLine($"Sorted Array: {result.Item1.Item1}");
            Console.WriteLine("******************************");

        }

        public static void DisplayResult(List<(string, int, string)> result)
        {
            Console.WriteLine();
            Console.WriteLine("******************************");
            Console.WriteLine("Comparison Results");
            Console.WriteLine("__________________________________________________________________________");
            Console.WriteLine("Sort Algo                Iteration Count                Operation Time(ms)");
            Console.WriteLine("--------------------------------------------------------------------------");
            foreach (var res in result)
            {
                Console.WriteLine($"{res.Item1.PadRight(15)}                {res.Item2.ToString().PadRight(10)}                {res.Item3}");
            }
        }
    }
}
