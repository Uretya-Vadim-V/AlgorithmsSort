using System;
using Xunit;
using AlgorithmsSort;

namespace SortTest
{
    public class Test
    {
        delegate void Func(int[] array);
        static Random random = new();
        static void Fill(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, 1000);
            }
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

        [Fact]
        public void Test1()
        {
            int[] array = new int[1000];
            foreach (Func func in new Func[] { Sort.Stupid, Sort.Bubble, Sort.Cocktail, Sort.Insertion,
            Sort.Gnome, Sort.SelectionMinimum, Sort.SelectionMaximum, Sort.DoubleSidedSelection,
            Sort.Comb, Sort.Shell})
            {
                Fill(array);
                func(array);
                Assert.Equal(Comparer(array, CopySort(array)), true);
            }
        }
    }
}
