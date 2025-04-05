using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Sorter sorter = new BubbleSorter();
        sorter.DoSort();
        Console.WriteLine();

        sorter = new InsertionSorter();
        sorter.DoSort();
        Console.WriteLine();

        sorter = new SelectionSorter();
        sorter.DoSort();
        Console.WriteLine();
    }
}

abstract class Sorter
{
    protected int N = 19;
    protected int[] ar;

    public void init()
    {
        ar = new int[N];
        Random r = new Random();
        for (int i = 0; i < N; i++)
            ar[i] = r.Next(1, 99);
        for (int i = 0; i < N; i++)
            Console.Write(ar[i] + " ");
        Console.WriteLine();
    }

    public void output()
    {
        for (int i = 0; i < N; i++)
            Console.Write(ar[i] + " ");
        Console.WriteLine();
    }

    public void DoSort()
    {
        Console.WriteLine("Before Sorting:");
        init();

        Stopwatch stopwatch = Stopwatch.StartNew();
        Sort();
        stopwatch.Stop();

        Console.WriteLine("After Sorting:");
        output();
        Console.WriteLine("Time Taken: " + stopwatch.ElapsedTicks / (Stopwatch.Frequency / 1_000_000.0) + " ms\n");
    }

    protected void Swap(int i, int j)
    {
        int temp = ar[i];
        ar[i] = ar[j];
        ar[j] = temp;
    }

    protected abstract void Sort();
}

class BubbleSorter : Sorter
{
    protected override void Sort()
    {
        for (int j = N - 1; j > 0; j--)
            for (int i = 0; i < j; i++)
                if (ar[i] > ar[i + 1])
                    Swap(i, i + 1);
    }
}

class InsertionSorter : Sorter
{
    protected override void Sort()
    {
        for (int i = 1; i < N; i++)
        {
            int key = ar[i];
            int j = i - 1;
            while (j >= 0 && ar[j] > key)
            {
                ar[j + 1] = ar[j];
                j--;
            }
            ar[j + 1] = key;
        }
    }
}

class SelectionSorter : Sorter
{
    protected override void Sort()
    {
        for (int i = 0; i < N - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < N; j++)
                if (ar[j] < ar[minIndex])
                    minIndex = j;
            Swap(i, minIndex);
        }
    }
}
