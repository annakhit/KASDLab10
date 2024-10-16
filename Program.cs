using System;

namespace KASDLab10
{
    internal class Program
    {
        static void Main()
        {
            int[] array = { 19, 100, 36, 17, 3, 25, 1, 2, 7 };
            MyHeap<int> heap = new MyHeap<int>(array);
            heap.Print();

            Console.WriteLine(heap.Max());

            heap.RemoveMax();

            heap.Print();
            Console.WriteLine(heap.Max());

            heap.ReplaceValue(3, 8);
            heap.Print();

            heap.Insert(15);
            heap.Print();

            int[] array2 = { 18, 52, 32 };
            MyHeap<int> heap2 = new MyHeap<int>(array2);
            heap2.Print();

            heap.Merge(heap2);
            heap.Print();

            Console.ReadKey();
        }
    }
}
