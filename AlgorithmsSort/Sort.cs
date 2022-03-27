using System;


namespace AlgorithmsSort
{
    public class Sort
    {
        static void Swap(int[] array, int i, int j)
        {
            int swap = array[i];
            array[i] = array[j];
            array[j] = swap;
        }
        // -------- Алгоритмы устойчивой сортировки --------
        // Глупая сортировка 
        public static void Stupid(int[] array)
        {
            int index = 0, length = array.Length - 1;
            while (index < length)
            {
                if (array[index] > array[index + 1])
                {
                    Swap(array, index + 1, index);
                    index = 0;
                }
                else
                    index++;
            }
        }
        // Пузырьковая сортировка
        public static void Bubble(int[] array)
        {
            int index, length = array.Length - 1;
            while (length > 0)
            {
                index = 0;
                while (index < length)
                {
                    if (array[index] > array[index + 1])
                    {
                        Swap(array, index + 1, index);
                        index++;
                    }
                    else
                        index++;
                }
                length--;
            }
        }
        // Коктейльная сортировка
        public static void Cocktail(int[] array)
        {
            int index = 0, slot, length = array.Length - 1;
            while (index < length)
            {
                slot = index;
                while (slot < length)
                {
                    if (array[slot] > array[slot + 1])
                        Swap(array, slot, slot + 1);
                    slot++;
                }
                length--;
                slot = length;
                while (slot > index)
                {
                    if (array[slot] < array[slot - 1])
                        Swap(array, slot - 1, slot);
                    slot--;
                }
                index++;
            }
        }
        // Сортировка простыми вставками
        public static void Insertion(int[] array)
        {
            int index = 1, buffer, j, length = array.Length;
            while (index < length)
            {
                buffer = array[index];
                j = index;
                while (j > 0 && array[j - 1] > buffer)
                {
                    array[j] = array[j - 1];
                    array[j - 1] = buffer;
                    j--;
                }
                index++;
            }
        }
        // Гномья сортировка
        public static void Gnome(int[] array)
        {
            int index = 1, slot, length = array.Length;
            while (index < length)
            {
                slot = index;
                while (slot > 0 && array[slot - 1] > array[slot])
                {
                    Swap(array, slot - 1, slot);
                    slot--;
                }
                index++;
            }
        }
        // -------- Алгоритмы неустойчивой сортировки --------
        // Сортировка выбором по минимуму
        public static void SelectionMinimum(int[] array)
        {
            int index, minIndex = 0, length = array.Length, minimum, j = 0;
            while (j < length)
            {
                minimum = Int32.MaxValue;
                index = j;
                while (index < length)
                {
                    if (array[index] <= minimum)
                    {
                        minimum = array[index];
                        minIndex = index;
                    }
                    index++;
                }
                Swap(array, minIndex, j);
                j++;
            }
        }
        // Сортировка выбором по максимому
        public static void SelectionMaximum(int[] array)
        {
            int index, maxIndex = 0, length = array.Length, maximum;
            while (0 < length)
            {
                maximum = 0;
                index = 0;
                while (index < length)
                {
                    if (array[index] > maximum)
                    {
                        maximum = array[index];
                        maxIndex = index;
                    }
                    index++;
                }
                Swap(array, maxIndex, length - 1);
                length--;
            }
        }
        // Двухсторонняя сортировка выбором
        public static void DoubleSidedSelection(int[] array)
        {
            int index, maxIndex = 0, minIndex = 0, length = array.Length,
            minimum, maximum, j = 0;
            while (j < length / 2)
            {
                maximum = 0;
                minimum = Int32.MaxValue;
                index = j;
                while (index < length - j)
                {
                    if (array[index] > maximum)
                    {
                        maximum = array[index];
                        maxIndex = index;
                    }
                    if (array[index] <= minimum)
                    {
                        minimum = array[index];
                        minIndex = index;
                    }
                    index++;
                }
                if (maxIndex == j)
                    maxIndex = minIndex;
                Swap(array, j, minIndex);
                Swap(array, length - j - 1, maxIndex);
                j++;
            }
        }
        // Сортировка расчёской
        public static void Comb(int[] array)
        {
            int index, length = array.Length - 1, q;
            while (length > 0)
            {
                index = 0;
                q = length;
                while (index < q && q <= array.Length - 1)
                {
                    if (array[index] > array[q])
                    {
                        Swap(array, q, index);
                        index++; q++;
                    }
                    else
                    {
                        index++; q++;
                    }
                }
                length--;
            }
        }
        // Сортировка Шелла
        public static void Shell(int[] array)
        {
            int index, buffer, j, length = array.Length - 1, d = length;
            while (d > 0)
            {
                j = 0;
                while (j + d <= length)
                {
                    index = j;
                    while (index >= 0 && array[index] > array[index + d])
                    {
                        buffer = array[index + d];
                        array[index + d] = array[index];
                        array[index] = buffer;
                        index -= d;
                    }
                    j++;
                }
                d /= 2;
            }
        }
    }   
}
