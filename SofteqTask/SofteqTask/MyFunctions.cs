using System;
using System.Collections.Generic;
using System.Text;

namespace SofteqTask
{
    class MyFunctions
    {
        public static char[] ToCharArray(string str)
        {
            char[] arr = new char[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                arr[i] = str[i];
            }
            return arr;
        }
        public static string[] ToStringArray(char[] arr, int wordsCount)
        {
            string[] words = new string[wordsCount];
            string buffer = "";
            for (int i = 0, iForNumbers = 0; i < arr.Length; i++)
            {
                if (i == arr.Length - 1 && arr[i] != ' ' && arr[i] != '\n')
                {
                    buffer += arr[i];
                    words[iForNumbers] = buffer;
                    iForNumbers++;
                    buffer = "";
                }
                else if (arr[i] != ' ' && arr[i] != '\n')
                {
                    buffer += arr[i];
                }
                else if (i > 0 && (arr[i] == ' ' || arr[i] == '\n') && arr[i - 1] != ' ' && arr[i - 1] != '\n')
                {
                    words[iForNumbers] = buffer;
                    iForNumbers++;
                    buffer = "";
                }
            }
            return words;
        }
        public static int WordCountInFirstLine(char[] arr)
        {
            int wordsCount = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                if(arr[i] == '\n' && arr[i - 1] != ' ')
                {
                    wordsCount++;
                    break;
                }
                else if(arr[i] == '\n' && arr[i - 1] == ' ')
                {
                    break;
                }
                else if (i == arr.Length - 1 && arr[i] != ' ')
                {
                    wordsCount++;
                }
                else if (arr[i] == ' ' && arr[i - 1] != ' ')
                {
                    wordsCount++;
                }
            }
            return wordsCount;
        }

        public static int WordCount(char[] arr)
        {
            int wordsCount = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                if (i == arr.Length - 1 && (arr[i] != ' ' || arr[i] == '\n'))
                {
                    wordsCount++;
                }
                else if ((arr[i] == ' ' || arr[i] == '\n') && arr[i - 1] != ' ' && arr[i - 1] != '\n')
                {
                    wordsCount++;
                }
            }
            return wordsCount;
        }

        public static double GetResultInThirdTask(int A, int B, int N)
        {
            int n1;
            for (int i = 0; ; i++)
            {
                if (i * A >= N)
                {
                    n1 = i;
                    break;
                }
            }

            double result = 0;
            for (int i = n1 - 1; i >= 0; i--)
            {
                for (int j = -n1; (i * A) + ((n1 - i + j) * B) <= N; j++)
                {
                    if ((i * A) + ((n1 - i + j) * B) == N)
                    {
                        if (Math.Pow(A, i) * Math.Pow(B, (n1 - i + j)) > result)
                        {
                            result = Math.Pow(A, i) * Math.Pow(B, (n1 - i + j));
                        }
                        break;
                    }
                }
                if (result != 0)
                {
                    break;
                }
            }

            return result;
        }

        public static int GetResultInFourthTask(int whiteRotsCount, int blackRotsCount)
        {
            int[] arr = new int[whiteRotsCount + blackRotsCount + 1];
            for (int i = 0; i < whiteRotsCount; i++)
            {
                arr[i] = 1;
            }
            for (int i = whiteRotsCount + blackRotsCount; i > whiteRotsCount; i--)
            {
                arr[i] = -1;
            }

            int motionCount = 0;
            MyFunctionsForFourthTask.SwapSort(arr, ref motionCount);
            return motionCount;
        }
    }
}
