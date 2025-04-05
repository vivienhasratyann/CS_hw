using System;
using System.Diagnostics;


abstract class Strategy
{
    public abstract void Sort(ref int[] array);
}


class SelectionSort : Strategy
{
    public override void Sort(ref int[] array)
    {
        Console.WriteLine("SelectionSort");
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            int k = i;
            for (int j = i + 1; j < n; j++)
                if (array[k] > array[j])
                    k = j;
            if (k != i)
            {
                int temp = array[k];
                array[k] = array[i];
                array[i] = temp;
            }
        }
    }
}


class InsertionSort : Strategy
{
    public override void Sort(ref int[] array)
    {
        Console.WriteLine("InsertionSort");
        int n = array.Length;
        for (int i = 1; i < n; i++)
        {
            int key = array[i];
            int j = i - 1;
            while (j >= 0 && array[j] > key)
            {
                array[j + 1] = array[j];
                j--;
            }
            array[j + 1] = key;
        }
    }
}


class MergeSortStrategy : Strategy
{
    public override void Sort(ref int[] array)
    {
        Console.WriteLine("MergeSort");
        MergeSortHelper(array, 0, array.Length - 1);
    }

    private void MergeSortHelper(int[] array, int left, int right)
    {
        if (left < right)
        {
            int middle = left + (right - left) / 2;
            MergeSortHelper(array, left, middle);
            MergeSortHelper(array, middle + 1, right);
            Merge(array, left, middle, right);
        }
    }

    private void Merge(int[] array, int left, int middle, int right)
    {
        int n1 = middle - left + 1;
        int n2 = right - middle;

        int[] leftArray = new int[n1];
        int[] rightArray = new int[n2];

        Array.Copy(array, left, leftArray, 0, n1);
        Array.Copy(array, middle + 1, rightArray, 0, n2);

        int i = 0, j = 0, k = left;

        while (i < n1 && j < n2)
        {
            if (leftArray[i] <= rightArray[j])
            {
                array[k] = leftArray[i];
                i++;
            }
            else
            {
                array[k] = rightArray[j];
                j++;
            }
            k++;
        }

        while (i < n1)
        {
            array[k] = leftArray[i];
            i++;
            k++;
        }

        while (j < n2)
        {
            array[k] = rightArray[j];
            j++;
            k++;
        }
    }
}


class ShellSortStrategy : Strategy
{
    public override void Sort(ref int[] array)
    {
        Console.WriteLine("ShellSort");
        int n = array.Length;
        for (int gap = n / 2; gap > 0; gap /= 2)
        {
            for (int i = gap; i < n; i++)
            {
                int temp = array[i];
                int j;
                for (j = i; j >= gap && array[j - gap] > temp; j -= gap)
                {
                    array[j] = array[j - gap];
                }
                array[j] = temp;
            }
        }
    }
}


class Context
{
    Strategy strategy;
    public int[] array; // Հանրային դարձնում ենք զանգվածը

    public Context(Strategy strategy, int[] data) // Կոնստրուկտորին փոխանցում ենք տվյալները
    {
        this.strategy = strategy;
        this.array = (int[])data.Clone(); // Ստեղծում ենք տվյալների պատճենը
    }

    public void Sort()
    {
        strategy.Sort(ref array);
    }

    public void PrintArray()
    {
        for (int i = 0; i < array.Length; i++)
            Console.Write(array[i] + " ");
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        int arraySize = 20000; // Ավելի մեծ զանգվածի չափ
        int[] initialData = new int[arraySize];
        Random random = new Random();
        for (int i = 0; i < arraySize; i++)
        {
            initialData[i] = random.Next(1, 100000); // Պատահական մեծ թվեր
        }

        Strategy sort;
        Context context;
        Stopwatch stopwatch = new Stopwatch();

        // Selection Sort
        sort = new SelectionSort();
        context = new Context(sort, initialData);
        Console.WriteLine("--- Selection Sort ---");
        stopwatch.Start();
        context.Sort();
        stopwatch.Stop();
        Console.WriteLine($"Execution Time: {stopwatch.ElapsedMilliseconds} ms");
        //context.PrintArray();

        // Insertion Sort
        sort = new InsertionSort();
        context = new Context(sort, initialData);
        Console.WriteLine("\n--- Insertion Sort ---");
        stopwatch.Start();
        context.Sort();
        stopwatch.Stop();
        Console.WriteLine($"Execution Time: {stopwatch.ElapsedMilliseconds} ms");
        //context.PrintArray();

        // Merge Sort
        sort = new MergeSortStrategy();
        context = new Context(sort, initialData);
        Console.WriteLine("\n--- Merge Sort ---");
        stopwatch.Start();
        context.Sort();
        stopwatch.Stop();
        Console.WriteLine($"Execution Time: {stopwatch.ElapsedMilliseconds} ms");
        //context.PrintArray();

        // Shell Sort
        sort = new ShellSortStrategy();
        context = new Context(sort, initialData);
        Console.WriteLine("\n--- Shell Sort ---");
        stopwatch.Start();
        context.Sort();
        stopwatch.Stop();
        Console.WriteLine($"Execution Time: {stopwatch.ElapsedMilliseconds} ms");
        //context.PrintArray();
    }
}