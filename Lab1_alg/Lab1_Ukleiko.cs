using System;

namespace Lab1_Ukleiko
{
    public static class TasksLab1
    {
        static void Main(string[] args)
        {
            bool isInt = false;
            do
            {
                try
                {
                    Console.Title = ("MENU");
                    Console.Write("Lab 1, Ukleiko Ekaterina, 2 group, 3 course\n\n");
                    Console.Write("MENU\n\n");
                    Console.Write("Enter 1 - Task 1: hybrid sort (quickSort + insertionSort)\n");
                    Console.Write("Enter 2 - Task 2: hybrid sort (mergeSort + insertionSort)\n");
                    Console.Write("Enter 3 - Task 3: calculate the number of elementary operations in insertionSort\n\n");
                    Console.Write("Enter integer number, please: ");
                    int userChoice = Int32.Parse(Console.ReadLine());
                    Console.Clear();
                    switch (userChoice)
                    {
                        case 1:
                            try
                            {
                                Console.Title = ("TASK 1");
                                Console.Write("Enter N - array length: ");
                                int N1 = int.Parse(Console.ReadLine());

                                Console.Write("Enter R - number of arrays: ");
                                int R1 = int.Parse(Console.ReadLine());

                                Console.Write("Enter M - the upper limit of numbers in array: ");
                                int M1 = int.Parse(Console.ReadLine());

                                int[][] arrs1 = BasicMethods.GenerateRandArrs(N1, R1, M1);

                                Console.WriteLine("\nSorce arrays: ");
                                BasicMethods.Print(arrs1);

                                HybridSortTask1.HybridSort1(arrs1);

                                Console.WriteLine("\nSorted arrays:");
                                BasicMethods.Print(arrs1);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("ERROR: " + e.Message);
                            }
                            break;

                        case 2:
                            try
                            {
                                Console.Title = ("TASK 2");
                                Console.Write("Enter N - array length: ");
                                int N2 = int.Parse(Console.ReadLine());

                                Console.Write("Enter R - number of arrays: ");
                                int R2 = int.Parse(Console.ReadLine());

                                Console.Write("Enter M - the upper limit of numbers in array: ");
                                int M2 = int.Parse(Console.ReadLine());

                                int[][] arrs2 = BasicMethods.GenerateRandArrs(N2, R2, M2);

                                Console.WriteLine("\nSorce arrays: ");
                                BasicMethods.Print(arrs2);

                                HybridSortTask2.HybridSort2(arrs2);

                                Console.WriteLine("\nSorted arrays: ");
                                BasicMethods.Print(arrs2);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("ERROR: " + e.Message);
                            }
                            break;
                        case 3:
                            try
                            {
                                Console.Title = ("TASK 3");
                                Console.Write("Enter N - array length: ");
                                int N3 = int.Parse(Console.ReadLine());

                                Console.Write("Enter M - the upper limit of numbers in array: ");
                                int M3 = int.Parse(Console.ReadLine());

                                int[] arr3 = BasicMethods.GenerateRandArr(N3, M3);
                               
                                Console.WriteLine("\nSource array: " + string.Join(", ", arr3));

                                int numOfElOps = InsertionSortTask3.FindNumElOpTask3(arr3);
                                Console.WriteLine("\nSorted array: " + string.Join(", ", arr3));
                                Console.WriteLine("\nNumber of elementary operations: " + numOfElOps);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("ERROR: " + e.Message);
                            }
                            break;
                    }
                    Console.ReadKey();
                    isInt = true;
                }
                catch
                {
                    Console.Write("You've entered not an integer number! Try again!\n");
                }
            } while (!isInt);
        }
        public static class BasicMethods
        {
            public static int[] GenerateRandArr(int N, int M)
            {
                int[] arr = new int[N];
                Random rand = new Random();

                for (int i = 0; i < N; i++)
                {
                    arr[i] = rand.Next(0, M + 1);
                }

                return arr;
            }
            public static int[][] GenerateRandArrs(int N, int R, int M)
            {
                int[][] arrs = new int[R][];
                Random rand = new Random();

                for (int i = 0; i < R; i++)
                {
                    int[] arr = new int[N];
                    for (int j = 0; j < N; j++)
                    {
                        arr[j] = rand.Next(0, M + 1);
                    }
                    arrs[i] = arr;
                }

                return arrs;
            }
            public static void Print(int[][] arrs)
            {
                for (int i = 0; i < arrs.Length; i++)
                {
                    Console.WriteLine(string.Join(", ", arrs[i]));
                }
            }
            public static void Swap(int[] arr, int a, int b)
            {
                int tmp = arr[a];
                arr[a] = arr[b];
                arr[b] = tmp;
            }
        }

        public static class Sorts
        {
            private static int k = 10;
            public static void InsertionSort(int[] arr, int leftSide, int rightSide)
            {
                for (int i = leftSide + 1; i <= rightSide; i++)
                {
                    int el = arr[i];
                    int j = i - 1;

                    while (j >= leftSide && arr[j] > el)
                    {
                        arr[j + 1] = arr[j];
                        j--;
                    }

                    arr[j + 1] = el;
                }
            }
            public static void QuickSort(int[] arr, int leftSide, int rightSide)
            {
                if (leftSide < rightSide)
                {
                    if (rightSide - leftSide <= k)
                    {
                        InsertionSort(arr, leftSide, rightSide);
                    }
                    else
                    {
                        int p = Partition(arr, leftSide, rightSide);
                        QuickSort(arr, leftSide, p - 1);
                        QuickSort(arr, p + 1, rightSide);
                    }
                }
            }
            public static void MergeSort(int[] arr, int leftSide, int rightSide)
            {
                if (leftSide < rightSide)
                {
                    if (rightSide - leftSide <= k)
                    {
                        Sorts.InsertionSort(arr, leftSide, rightSide);
                    }
                    else
                    {
                        int middle = (leftSide + rightSide) / 2;
                        MergeSort(arr, leftSide, middle);
                        MergeSort(arr, middle + 1, rightSide);
                        Merge(arr, leftSide, middle, rightSide);
                    }
                }
            }
            private static void Merge(int[] arr, int leftSide, int middle, int rightSide)
            {
                int[] tmp = new int[arr.Length];
                for (int i = leftSide; i <= rightSide; i++)
                {
                    tmp[i] = arr[i];
                }

                int p = leftSide;
                int q = middle + 1;
                int l = leftSide;

                while (p <= middle && q <= rightSide)
                {
                    if (tmp[p] <= tmp[q])
                    {
                        arr[l] = tmp[p];
                        p++;
                    }
                    else
                    {
                        arr[l] = tmp[q];
                        q++;
                    }
                    l++;
                }

                while (p <= middle)
                {
                    arr[l] = tmp[p];
                    l++;
                    p++;
                }
            }
            private static int Partition(int[] array, int left, int right)
            {
                int p = array[right];
                int i = left - 1;

                for (int j = left; j < right; j++)
                {
                    if (array[j] < p)
                    {
                        i++;
                        BasicMethods.Swap(array, i, j);
                    }
                }

                BasicMethods.Swap(array, i + 1, right);

                return i + 1;
            }
        }
        public static class HybridSortTask1
        {
            public static void HybridSort1(int[][] arrs)
            {
                for (int i = 0; i < arrs.Length; i++)
                {
                    Sorts.QuickSort(arrs[i], 0, arrs[i].Length - 1);
                }
            }
        }
        public static class HybridSortTask2
        {
            public static void HybridSort2(int[][] arrs)
            {
                for (int i = 0; i < arrs.Length; i++)
                {
                    Sorts.MergeSort(arrs[i], 0, arrs[i].Length - 1);
                }
            }
        }
        public static class InsertionSortTask3
        {
            public static int FindNumElOpTask3(int[] arr)
            {
                int numOfElOps = 0;

                for (int i = 1; i < arr.Length; i++)
                {
                    int el = arr[i];
                    int j = i - 1;

                    while (j >= 0 && arr[j] > el)
                    {
                        arr[j + 1] = arr[j];
                        j--;
                        numOfElOps += 3;
                    }

                    arr[j + 1] = el;
                    numOfElOps += 2;
                }

                return numOfElOps;
            }
        }
    }
}