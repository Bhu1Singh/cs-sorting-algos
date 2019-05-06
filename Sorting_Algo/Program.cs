using System;
using System.Collections.Generic;
using System.Linq;

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
                    Console.Clear();
                }
            }
        }

        public static void Sort(Tuple<int, string> sortargs)
        {
            switch (sortargs.Item1)
            {
                case 1:
                    var bubble = Bubble_Sort.Sort(sortargs.Item2);
                    DisplayResult("Bubble", bubble);
                    break;
                case 2:
                    var selection = Selection_Sort.Sort(sortargs.Item2);
                    DisplayResult("Selection", selection);
                    break;
                case 3:
                    var insertion = Insertion_Sort.Sort(sortargs.Item2);
                    DisplayResult("Insertion", insertion); break;
                case 4:
                    var quick = Quick_Sort.Sort(sortargs.Item2);
                    DisplayResult("Quick", quick); break;
                case 5:
                    var heap = Heap_Sort.Sort(sortargs.Item2);
                    DisplayResult("Heap", heap);
                    break;
                case 6:
                    var merge = Merge_Sort.Sort(sortargs.Item2);
                    DisplayResult("Merge", merge);
                    break;
                case 7:
                    var radix = Radix_Sort.Sort(sortargs.Item2);
                    DisplayResult("Radix", radix);
                    break;
                case 8:
                    List<(string, int, string)> all = new List<(string, int, string)>();
                    bubble = Bubble_Sort.Sort(sortargs.Item2);
                    selection = Selection_Sort.Sort(sortargs.Item2);
                    insertion = Insertion_Sort.Sort(sortargs.Item2);
                    quick = Quick_Sort.Sort(sortargs.Item2);
                    heap = Heap_Sort.Sort(sortargs.Item2);
                    merge = Merge_Sort.Sort(sortargs.Item2);
                    radix = Radix_Sort.Sort(sortargs.Item2);

                    all.Add(ValueTuple.Create<string, int, string>("Bubble Sort", bubble.Item2, bubble.Item1));
                    all.Add(ValueTuple.Create<string, int, string>("Selection Sort", selection.Item2, selection.Item1));
                    all.Add(ValueTuple.Create<string, int, string>("Insertion Sort", insertion.Item2, insertion.Item1));
                    all.Add(ValueTuple.Create<string, int, string>("Quick Sort", quick.Item2, quick.Item1));
                    all.Add(ValueTuple.Create<string, int, string>("Heap Sort", heap.Item2, heap.Item1));
                    all.Add(ValueTuple.Create<string, int, string>("Merge Sort", merge.Item2, merge.Item1));
                    all.Add(ValueTuple.Create<string, int, string>("Radix Sort", radix.Item2, radix.Item1));

                    DisplayResult(all);
                    break;
                default:
                    break;

            }
        }

        public static Tuple<int, string> DefaultScreen()
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
            var algo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Enter the comma separated unsorted numbers:");
            var arr = Console.ReadLine();
            return Tuple.Create<int, string>(algo, arr);
        }

        public static string Close()
        {
            Console.WriteLine();
            Console.WriteLine("Continue(C) or Exit(E). Enter your choice: ");
            return Console.ReadLine().ToUpper();
        }

        public static void DisplayResult(string sort_algo, Tuple<string, int> result)
        {
            Console.WriteLine();
            Console.WriteLine("******************************");
            Console.WriteLine($"{sort_algo} Sort Results-->");
            Console.WriteLine($"Number of operations: {result.Item2}");
            Console.WriteLine($"Sorted array: {result.Item1}");
            Console.WriteLine("******************************");

        }

        public static void DisplayResult(List<(string, int, string)> result)
        {
            Console.WriteLine();
            Console.WriteLine("******************************");
            Console.WriteLine("Comparison Results");
            Console.WriteLine("_______________________________________________________________");
            Console.WriteLine("Sort Algo                Iteration Count                 Result");
            Console.WriteLine("---------------------------------------------------------------");
            foreach (var res in result)
            {
                Console.WriteLine($"{res.Item1.PadRight(20)}                {res.Item2.ToString().PadRight(5)}                {res.Item3}");
            }
        }
    }
}
