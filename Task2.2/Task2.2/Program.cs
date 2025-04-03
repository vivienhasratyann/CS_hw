using System;

int N_Original = 22;
int[] A_Original = new int[N_Original];
Random r_Original = new Random();
for (int i_Original = 0; i_Original < N_Original; i_Original++)
    A_Original[i_Original] = r_Original.Next(1, 99);
for (int i_Original = 0; i_Original < N_Original; i_Original++)
    Console.Write(A_Original[i_Original] + " ");
Console.WriteLine();
int max_Original = A_Original[0];
for (int j_Original = N_Original - 1; j_Original > 0; j_Original--)
    for (int i_Original = 0; i_Original < j_Original; i_Original++)
        if (A_Original[i_Original] > A_Original[i_Original + 1])
        {
            max_Original = A_Original[i_Original];
            A_Original[i_Original] = A_Original[i_Original + 1];
            A_Original[i_Original + 1] = max_Original;
        }
for (int i_Original = 0; i_Original < N_Original; i_Original++)
    Console.Write(A_Original[i_Original] + " ");
Console.WriteLine("\n");

Sorter ob_bubble = new bubbleSorter();
Console.WriteLine("Bubble Sort (Template Method):");
ob_bubble.DoSort();

Sorter ob_insertion = new insertionSorter();
Console.WriteLine("Insertion Sort (Template Method):");
ob_insertion.DoSort();

Sorter ob_selection = new selectionSorter();
Console.WriteLine("Selection Sort (Template Method):");
ob_selection.DoSort();

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
        init();
        Console.WriteLine();
        Sort();
        output();
        Console.WriteLine();
    }
    protected abstract void Sort();
}

class bubbleSorter : Sorter
{
    protected override void Sort()
    {
        for (int j = N - 1; j > 0; j--)
            for (int i = 0; i < j; i++)
                if (ar[i] > ar[i + 1])
                {
                    int temp = ar[i];
                    ar[i] = ar[i + 1];
                    ar[i + 1] = temp;
                }
    }
}

class insertionSorter : Sorter
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

class selectionSorter : Sorter
{
    protected override void Sort()
    {
        for (int i = 0; i < N - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < N; j++)
            {
                if (ar[j] < ar[minIndex])
                {
                    minIndex = j;
                }
            }
            int temp = ar[minIndex];
            ar[minIndex] = ar[i];
            ar[i] = temp;
        }
    }
}