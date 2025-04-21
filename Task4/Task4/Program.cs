using System;
using System.Collections.Generic;

namespace Task4
{
    internal class Program
    {
        const int Size = 8;
        static int[,] boardState = new int[Size, Size];
        static List<(int, int)> kentavrPositions = new List<(int, int)>();

        static void Main(string[] args)
        {
            Console.Write("Initial row (0-7): ");
            int startRow = int.Parse(Console.ReadLine());
            Console.Write("Initial column (0-7): ");
            int startCol = int.Parse(Console.ReadLine());

            AddKentavr(startRow, startCol);
            PrintAttackMatrix();
            PrintScoreMatrix();

            while (true)
            {
                var next = SelectNextPlacement();
                if (next.row == -1) break;

                AddKentavr(next.row, next.col);
                Console.WriteLine($"\nNew Kentavr placed at ({next.row}, {next.col}) — protected {next.score} free zones.");
                PrintAttackMatrix();
                PrintScoreMatrix();
            }

            Console.WriteLine("\nAll Kentavr placements:");
            foreach (var (r, c) in kentavrPositions)
            {
                Console.WriteLine($"Kentavr at ({r}, {c})");
            }
        }

        static void AddKentavr(int row, int col)
        {
            kentavrPositions.Add((row, col));
            boardState[row, col] = 1;

            for (int i = 0; i < Size; i++)
            {
                boardState[row, i] = 1;
                boardState[i, col] = 1;
            }

            int[] dx = { -2, -1, 1, 2, 2, 1, -1, -2 };
            int[] dy = { 1, 2, 2, 1, -1, -2, -2, -1 };

            for (int i = 0; i < 8; i++)
            {
                int r = row + dx[i];
                int c = col + dy[i];
                if (WithinBounds(r, c))
                {
                    boardState[r, c] = 1;
                }
            }
        }

        static (int row, int col, int score) SelectNextPlacement()
        {
            int maxCoverage = -1;
            int optimalRow = -1, optimalCol = -1;

            for (int r = 0; r < Size; r++)
            {
                for (int c = 0; c < Size; c++)
                {
                    if (boardState[r, c] == 0)
                    {
                        int coverage = EstimatePlacementImpact(r, c);
                        if (coverage > maxCoverage)
                        {
                            maxCoverage = coverage;
                            optimalRow = r;
                            optimalCol = c;
                        }
                    }
                }
            }

            return (optimalRow, optimalCol, maxCoverage);
        }

        static int EstimatePlacementImpact(int row, int col)
        {
            bool[,] temp = new bool[Size, Size];

            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    temp[i, j] = boardState[i, j] == 1;

            for (int i = 0; i < Size; i++)
            {
                temp[row, i] = true;
                temp[i, col] = true;
            }

            int[] dx = { -2, -1, 1, 2, 2, 1, -1, -2 };
            int[] dy = { 1, 2, 2, 1, -1, -2, -2, -1 };

            temp[row, col] = true;

            for (int i = 0; i < 8; i++)
            {
                int newRow = row + dx[i];
                int newCol = col + dy[i];
                if (WithinBounds(newRow, newCol))
                {
                    temp[newRow, newCol] = true;
                }
            }

            int freeCount = 0;
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    if (!temp[i, j])
                        freeCount++;

            return freeCount;
        }

        static void PrintAttackMatrix()
        {
            Console.WriteLine("\nCurrent board coverage:");
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                    Console.Write(boardState[i, j] + " ");
                Console.WriteLine();
            }
        }

        static void PrintScoreMatrix()
        {
            Console.WriteLine("\nNext move coverage forecast:");
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (boardState[i, j] == 1)
                        Console.Write(" x ");
                    else
                    {
                        int score = EstimatePlacementImpact(i, j);
                        Console.Write(score.ToString().PadLeft(2) + " ");
                    }
                }
                Console.WriteLine();
            }
        }

        static bool WithinBounds(int r, int c)
        {
            return r >= 0 && r < Size && c >= 0 && c < Size;
        }
    }
}
