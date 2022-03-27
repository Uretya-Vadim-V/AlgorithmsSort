using System;
using System.Collections.Generic;

namespace AlgorithmsSort
{
    public class SortExtra
    {
        // (!) - заного пройти алгоритм
        // (?) - понять работу алгоритма
        static void Swap(int[] array, int i, int j)
        {
            int swap = array[i];
            array[i] = array[j];
            array[j] = swap;
        }
        // -------- Алгоритмы устойчивой сортировки --------
        // Сортировка слиянием (!)
        public static void Merge(int[] array)
        {
            Mergesort(array, 0, array.Length - 1);
            void Mergesort(int[] arr, int low, int high)
            {
                if (low < high)
                {
                    int mid = (low + high) / 2;
                    Mergesort(arr, low, mid);
                    Mergesort(arr, mid + 1, high);
                    if (arr[mid] > arr[mid + 1])
                        Copy(arr, low, mid, high);

                }
            }
            void Copy(int[] arr, int low, int mid, int high)
            {
                int i = low, j = mid + 1, k = 0;
                int[] temp = new int[high - low + 1];
                while ((i <= mid) && (j <= high))
                    if (arr[i] < arr[j])
                        temp[k++] = arr[i++];
                    else
                        temp[k++] = arr[j++];
                while (j <= high) // if (i> mid)
                    temp[k++] = arr[j++];
                while (i <= mid) // j> высокий
                    temp[k++] = arr[i++];
                // копировать temp [] в arr []
                for (i = low, k = 0; i <= high; i++, k++)
                    arr[i] = temp[k];
            }
        }
        // Сортировка с помощью двоичного дерева (?)
        public static void Tree(int[] array)
        {

        }
        // -------- Алгоритмы неустойчивой сортировки --------
        // Пирамидальная сортировка (!)
        public static void Heap(int[] array)
        {
            int lenght = array.Length - 1, index = lenght / 2;
            while (index >= 0)
            {
                Heapify(array, lenght, index);
                index--;
            }
            index = lenght;
            while (index >= 0)
            {
                Swap(array, 0, index);
                Heapify(array, index, 0);
                index--;
            }
        }
        private static void Heapify(int[] array, int n, int index)
        {
            int largest = index,
            left = 2 * index + 1,
            right = 2 * index + 2;
            if (left < n && array[left] > array[largest])
                largest = left;
            if (right < n && array[right] > array[largest])
                largest = right;
            if (largest != index)
            {
                Swap(array, index, largest);
                Heapify(array, n, largest);
            }
        }
        // Плавная сортировка (https://github.com/elluscinia/smoothsort/blob/master/smoothsort.py) (?)
        // Быстрая сортировка (!)
        public static void Quick(int[] array)
        {
            Quicksort(array, 0, array.Length - 1);
            void Quicksort(int[] array, int start, int end)
            {
                if (start >= end)
                {
                    return;
                }
                int pivot = Partition(array, start, end);
                Quicksort(array, start, pivot - 1);
                Quicksort(array, pivot + 1, end);
            }
        }
        private static int Partition(int[] array, int start, int end)
        {
            int marker = start, index = start;
            while (index <= end)
            {
                if (array[index] <= array[end])
                {
                    Swap(array, marker, index);
                    marker++;
                }
                index++;
            }
            return marker - 1;
        }
        // Интроспективная сортировка (!)
        public static void Intro(int[] array)
        {
            int n = array.Length;
            int depthLimit = (int)(2 * Math.Floor(Math.Log(n) / Math.Log(2)));
            sortDataUtil(array, 0, n - 1, depthLimit);

            void insertionSort(int[] array, int left, int right)
            {
                int i = left;
                while (i <= right)
                {
                    int key = array[i];
                    int j = i;
                    while (j > left && array[j - 1] > key)
                    {
                        array[j] = array[j - 1];
                        j--;
                    }
                    array[j] = key;
                    i++;
                }
            }
            int findPivot(int[] array, int a1, int b1, int c1)
            {
                int max = Math.Max(Math.Max(array[a1], array[b1]), array[c1]);
                int min = Math.Min(Math.Min(array[a1], array[b1]), array[c1]);
                int median = max ^ min ^ array[a1] ^ array[b1] ^ array[c1];
                if (median == array[a1])
                    return a1;
                if (median == array[b1])
                    return b1;
                return c1;
            }
            void sortDataUtil(int[] array, int begin, int end, int depthLimit)
            {
                if (end - begin > 16)
                {
                    if (depthLimit == 0)
                    {
                        Heapify(array, begin, end);
                        return;
                    }
                    depthLimit = depthLimit - 1;
                    int pivot = findPivot(array, begin, begin + ((end - begin) / 2) + 1, end);
                    Swap(array, pivot, end);
                    int p = Partition(array, begin, end);
                    sortDataUtil(array, begin, p - 1, depthLimit);
                    sortDataUtil(array, p + 1, end, depthLimit);
                }
                else
                {
                    insertionSort(array, begin, end);
                }
            }
        }
        // Придурковатая сортировка
        public static void Stooge(int[] array)
        {
            int left = 0, right = array.Length - 1;
            StoogeSort(array, left, right);
            void StoogeSort(int[] array, int left, int right)
            {
                if (left >= right)
                    return;
                if (array[left] > array[right])
                    Swap(array, left, right);
                if (right - left + 1 > 2)
                {
                    int slot = (right - left + 1) / 3;
                    StoogeSort(array, left, right - slot);
                    StoogeSort(array, left + slot, right);
                    StoogeSort(array, left, right - slot);
                }
            }
        }
    }
}
