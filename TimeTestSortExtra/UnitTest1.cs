using System;
using Xunit;
using AlgorithmsSort;

namespace TimeSortTestExtra
{
    public class UnitTest1
    {
        static Random random = new();

        static int[] array = new int[1000];
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
        public void Merge()
        {
            Fill(array);
            SortExtra.Merge(array);
            Assert.Equal(Comparer(array, CopySort(array)), true);
        }
        [Fact]
        public void Heap()
        {
            Fill(array);
            SortExtra.Heap(array);
            Assert.Equal(Comparer(array, CopySort(array)), true);
        }
        [Fact]
        public void Quick()
        {
            Fill(array);
            SortExtra.Quick(array);
            Assert.Equal(Comparer(array, CopySort(array)), true);
        }
        [Fact]
        public void Intro()
        {
            Fill(array);
            SortExtra.Intro(array);
            Assert.Equal(Comparer(array, CopySort(array)), true);
        }
        [Fact]
        public void Stooge()
        {
            Fill(array);
            SortExtra.Stooge(array);
            Assert.Equal(Comparer(array, CopySort(array)), true);
        }
    }
}
