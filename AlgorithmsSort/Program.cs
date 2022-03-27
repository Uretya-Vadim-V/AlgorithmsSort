using System;

namespace AlgorithmsSort
{
    class Program
    {
        delegate void Func(int[] array);
        static Random random = new();
        static void Fill(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, 100);
            }
        }
        static void GetString(int[] array)
        {
            foreach (int i in array)
                Console.Write("{0} ", i.ToString());
            Console.WriteLine();
        }
        static bool Comparer(int[] array, int[] arraySort)
        {
            for (int i = 0; i < array.Length; i++)
                if (array[i] != arraySort[i])
                    return false;
            return true;
        }
        static int[] CopySort(int[] array)
        {
            int[] copy = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
                copy[i] = array[i];
            Array.Sort(copy);
            return copy;
        }
        static void Main(string[] args)
        {
            int[] array = new int[20];
            Console.WriteLine("Глупая сортировка ");
            {
                Fill(array);
                GetString(array);
                Sort.Stupid(array);
                GetString(array);
                Console.WriteLine(Comparer(array, CopySort(array)));
            }
            Console.WriteLine("\nПузырьковая сортировка");
            {
                Fill(array);
                GetString(array);
                Sort.Bubble(array);
                GetString(array);
                Console.WriteLine(Comparer(array, CopySort(array)));
            }
            Console.WriteLine("\nКоктейльная сортировка");
            {
                Fill(array);
                GetString(array);
                Sort.Cocktail(array);
                GetString(array);
                Console.WriteLine(Comparer(array, CopySort(array)));
            }
            Console.WriteLine("\nСортировка простыми вставками");
            {
                Fill(array);
                GetString(array);
                Sort.Insertion(array);
                GetString(array);
                Console.WriteLine(Comparer(array, CopySort(array)));
            }
            Console.WriteLine("\nГномья сортировка");
            {
                Fill(array);
                GetString(array);
                Sort.Gnome(array);
                GetString(array);
                Console.WriteLine(Comparer(array, CopySort(array)));
            }
            Console.WriteLine("\nСортировка выбором по минимуму");
            {
                Fill(array);
                GetString(array);
                Sort.SelectionMinimum(array);
                GetString(array);
                Console.WriteLine(Comparer(array, CopySort(array)));
            }
            Console.WriteLine("\nСортировка выбором по максимому");
            {
                Fill(array);
                GetString(array);
                Sort.SelectionMaximum(array);
                GetString(array);
                Console.WriteLine(Comparer(array, CopySort(array)));
            }
            Console.WriteLine("\nДвухсторонняя сортировка выбором");
            {
                Fill(array);
                GetString(array);
                Sort.DoubleSidedSelection(array);
                GetString(array);
                Console.WriteLine(Comparer(array, CopySort(array)));
            }
            Console.WriteLine("\nСортировка расчёской");
            {
                Fill(array);
                GetString(array);
                Sort.Comb(array);
                GetString(array);
                Console.WriteLine(Comparer(array, CopySort(array)));
            }
            Console.WriteLine("\nСортировка Шелла");
            {
                Fill(array);
                GetString(array);
                Sort.Shell(array);
                GetString(array);
                Console.WriteLine(Comparer(array, CopySort(array)));
            }
            Console.WriteLine("\nПирамидальная сортировка");
            {
                Fill(array);
                GetString(array);
                SortExtra.Heap(array);
                GetString(array);
                Console.WriteLine(Comparer(array, CopySort(array)));
            }
            Console.WriteLine("\nБыстрая сортировка");
            {
                Fill(array);
                GetString(array);
                SortExtra.Quick(array);
                GetString(array);
                Console.WriteLine(Comparer(array, CopySort(array)));
            }
            Console.WriteLine("\nИнтроспективная сортировка");
            {
                Fill(array);
                GetString(array);
                SortExtra.Intro(array);
                GetString(array);
                Console.WriteLine(Comparer(array, CopySort(array)));
            }
            Console.WriteLine("\nПридурковатая сортировка");
            {
                Fill(array);
                GetString(array);
                SortExtra.Stooge(array);
                GetString(array);
                Console.WriteLine(Comparer(array, CopySort(array)));
            }
            Console.WriteLine("\nСортировка слиянием");
            {
                Fill(array);
                GetString(array);
                SortExtra.Merge(array);
                GetString(array);
                Console.WriteLine(Comparer(array, CopySort(array)));
            }
        }
    }
}
