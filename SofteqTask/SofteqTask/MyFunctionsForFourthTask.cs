using System;
using System.Collections.Generic;
using System.Text;

namespace SofteqTask
{
    class MyFunctionsForFourthTask
    {
        static bool IsAbleJumpOverForRight(int[] arr)
        {
            for (int i = 0; i < arr.Length - 2; i++)
            {
                if (arr[i] == 1 && arr[i + 1] == -1 && arr[i + 2] == 0)
                {
                    return true;
                }
            }
            return false;
        }

        static bool IsAbleJumpOverForLeft(int[] arr)
        {
            for (int i = arr.Length - 1; i > 1; i--)
            {
                if (arr[i] == -1 && arr[i - 1] == 1 && arr[i - 2] == 0)
                {
                    return true;
                }
            }
            return false;
        }

        static void JunpOverForRight(int[] arr, ref int motionCount)
        {
            for (int i = 0; i < arr.Length - 2; i++)
            {
                if (arr[i] == 1 && arr[i + 1] == -1 && arr[i + 2] == 0)
                {
                    int buffer = arr[i + 2];
                    arr[i + 2] = arr[i];
                    arr[i] = buffer;
                    //ViewArr(arr);
                    motionCount++;
                }
            }
        }

        static void JumpOverForLeft(int[] arr, ref int motionCount)
        {
            for (int i = arr.Length - 1; i > 1; i--)
            {
                if (arr[i] == -1 && arr[i - 1] == 1 && arr[i - 2] == 0)
                {
                    int buffer = arr[i - 2];
                    arr[i - 2] = arr[i];
                    arr[i] = buffer;
                    //ViewArr(arr);
                    motionCount++;
                }
            }
        }

        static void GoRight(int[] arr, ref int motionCount)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] == 1 && arr[i + 1] == 0)
                {
                    int buffer = arr[i];
                    arr[i] = arr[i + 1];
                    arr[i + 1] = buffer;
                    //ViewArr(arr);
                    motionCount++;
                }
            }
        }

        static void GoLeft(int[] arr, ref int motionCount)
        {
            for (int i = arr.Length - 1; i > 0; i--)
            {
                if (arr[i] == -1 && arr[i - 1] == 0)
                {
                    int buffer = arr[i];
                    arr[i] = arr[i - 1];
                    arr[i - 1] = buffer;
                    //ViewArr(arr);
                    motionCount++;
                }
            }
        }

        static bool IsLeftMoreOrEqualThanRight(int[] arr)
        {
            int leftCount = 0;
            int rightCount = 0;
            foreach (int x in arr)
            {
                if (x == 1)
                {
                    leftCount++;
                }
                else if (x == -1)
                {
                    rightCount++;
                }
            }
            if (leftCount >= rightCount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool IsDone(int[] arr)
        {
            int indexOfNull = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                {
                    indexOfNull = i;
                }
            }

            for (int i = 0; i < indexOfNull; i++)
            {
                if (arr[i] == 1)
                {
                    return false;
                }
            }
            for (int i = indexOfNull + 1; i < arr.Length; i++)
            {
                if (arr[i] == -1)
                {
                    return false;
                }
            }

            return true;
        }

        public static void SwapSort(int[] arr, ref int motionCount)
        {
            if (IsLeftMoreOrEqualThanRight(arr))
            {
                while (!IsDone(arr))
                {
                    GoRight(arr, ref motionCount);
                    while (IsAbleJumpOverForLeft(arr))
                    {
                        JumpOverForLeft(arr, ref motionCount);
                    }
                    GoLeft(arr, ref motionCount);
                    while (IsAbleJumpOverForRight(arr))
                    {
                        JunpOverForRight(arr, ref motionCount);
                    }
                }
            }
            else
            {
                while (!IsDone(arr))
                {
                    GoLeft(arr, ref motionCount);
                    while (IsAbleJumpOverForRight(arr))
                    {
                        JunpOverForRight(arr, ref motionCount);
                    }
                    GoRight(arr, ref motionCount);
                    while (IsAbleJumpOverForLeft(arr))
                    {
                        JumpOverForLeft(arr, ref motionCount);
                    }
                }
            }
        }

        static void ViewArr(int[] arr)
        {
            char ch1 = (char)1;
            char ch2 = (char)2;
            Console.Write("[");
            foreach (int x in arr)
            {
                if (x == 1)
                {
                    Console.Write(ch2.ToString().PadLeft(3));
                }
                else if (x == -1)
                {
                    Console.Write(ch1.ToString().PadLeft(3));
                }
                else
                {
                    Console.Write("   ");
                }
            }
            Console.Write("]");
            Console.WriteLine();
        }
    }
}

