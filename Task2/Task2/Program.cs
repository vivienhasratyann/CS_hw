using System;
using System.Diagnostics;

abstract class SortingAlgorithm<T> where T : IComparable<T>
{
    protected T[] array;

    public SortingAlgorithm(T[] array)
    {
        this.array = array;
    }

    public void Sort()
    {
        Initialize();
        PerformSort();
        Finalize();
    }
    protected virtual void Initialize() { }

    protected abstract void PerformSort();

    protected virtual void Finalize() { }

    public T[] GetSortedArray()
    {
        return array;
    }

    public void PrintArray()
    {
        foreach (var item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}

class BubbleSort<T> : SortingAlgorithm<T> where T : IComparable<T>
{
    public BubbleSort(T[] array) : base(array) { }

    protected override void PerformSort()
    {
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (array[j].CompareTo(array[j + 1]) > 0)
                {
                    T temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }
}

class InsertionSort<T> : SortingAlgorithm<T> where T : IComparable<T>
{
    public InsertionSort(T[] array) : base(array) { }

    protected override void PerformSort()
    {
        int n = array.Length;
        for (int i = 1; i < n; i++)
        {
            T key = array[i];
            int j = i - 1;

            while (j >= 0 && array[j].CompareTo(key) > 0)
            {
                array[j + 1] = array[j];
                j = j - 1;
            }
            array[j + 1] = key;
        }
    }
}

class SelectionSort<T> : SortingAlgorithm<T> where T : IComparable<T>
{
    public SelectionSort(T[] array) : base(array) { }

    protected override void PerformSort()
    {
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                if (array[j].CompareTo(array[minIndex]) < 0)
                {
                    minIndex = j;
                }
            }

            T temp = array[i];
            array[i] = array[minIndex];
            array[minIndex] = temp;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        int[] array = GenerateRandomArray(10000); 

        // Bubble Sort
        int[] bubbleArray = (int[])array.Clone();
        SortingAlgorithm<int> bubbleSort = new BubbleSort<int>(bubbleArray);
        Stopwatch bubbleStopwatch = Stopwatch.StartNew();
        bubbleSort.Sort();
        bubbleStopwatch.Stop();
        Console.WriteLine("Bubble Sort Time: " + bubbleStopwatch.ElapsedMilliseconds + " ms");
        //bubbleSort.PrintArray();

        // Insertion Sort
        int[] insertionArray = (int[])array.Clone();
        SortingAlgorithm<int> insertionSort = new InsertionSort<int>(insertionArray);
        Stopwatch insertionStopwatch = Stopwatch.StartNew();
        insertionSort.Sort();
        insertionStopwatch.Stop();
        Console.WriteLine("Insertion Sort Time: " + insertionStopwatch.ElapsedMilliseconds + " ms");
        //insertionSort.PrintArray();

        // Selection Sort
        int[] selectionArray = (int[])array.Clone();
        SortingAlgorithm<int> selectionSort = new SelectionSort<int>(selectionArray);
        Stopwatch selectionStopwatch = Stopwatch.StartNew();
        selectionSort.Sort();
        selectionStopwatch.Stop();
        Console.WriteLine("Selection Sort Time: " + selectionStopwatch.ElapsedMilliseconds + " ms");
        //selectionSort.PrintArray();
    }

    static int[] GenerateRandomArray(int size)
    {
        Random random = new Random();
        int[] array = new int[size];
        for (int i = 0; i < size; i++)
        {
            array[i] = random.Next(1, size * 2);
        }
        return array;
    }
}