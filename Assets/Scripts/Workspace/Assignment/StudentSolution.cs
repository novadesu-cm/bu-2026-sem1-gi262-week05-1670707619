using UnityEngine;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Assignment
{
    public class StudentSolution : IAssignment
    {
        #region Lecture
        public int[] LCT01_SelectionSortAscending(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i; j < numbers.Length; j++)
                {
                    if (numbers[j] < numbers[minIndex])
                    {
                        minIndex = j;
                    }
                }

                // int temp = numbers[minIndex];
                // numbers[minIndex] = numbers[i];
                // numbers[i] = temp;

                (numbers[i], numbers[minIndex]) = (numbers[minIndex], numbers[i]);
            }
            return numbers;
        }

        public int[] LCT02_BubbleSortAscending(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = 0; j < numbers.Length - i - 1; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        (numbers[j], numbers[j + 1]) = (numbers[j + 1], numbers[j]);
                    }
                }
            }
            return numbers;
        }

        public int[] LCT03_InsertionSortAscending(int[] numbers)
        {
            int n = numbers.Length;
            for (int i = 1; i < n; i++)
            {
                int key = numbers[i];
                int j = i - 1;
                while (j >= 0 && numbers[j] > key)
                {
                    numbers[j + 1] = numbers[j];
                    j--;
                }
                numbers[j + 1] = key;
            }
            return numbers;
        }

        #endregion

        #region Assignment

        public int[] AS01_SelectionSortDescending(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                int maxIndex = i;
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[j] > numbers[maxIndex])
                    {
                        maxIndex = j;
                    }
                }
                (numbers[i], numbers[maxIndex]) = (numbers[maxIndex], numbers[i]);
            }
            return numbers;
        }

        public int[] AS02_BubbleSortDescending(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = 0; j < numbers.Length - i - 1; j++)
                {
                    if (numbers[j] < numbers[j + 1])
                    {
                        (numbers[j], numbers[j + 1]) = (numbers[j + 1], numbers[j]);
                    }
                }
            }
            return numbers;
        }

        public int[] AS03_InsertionSortDescending(int[] numbers)
        {
            for (int i = 1; i < numbers.Length; i++)
            {
                int key = numbers[i];
                int j = i - 1;

                while (j >= 0 && numbers[j] < key)
                {
                    numbers[j + 1] = numbers[j];
                    j--;
                }
                numbers[j + 1] = key;
            }
            return numbers;
        }

        public int AS04_FindTheSecondLargestNumber(int[] numbers)
        {
            if (numbers == null || numbers.Length < 2) return 0;

            int largest = int.MinValue;
            int secondLargest = int.MinValue;

            foreach (int num in numbers)
            {
                if (num > largest)
                {
                    secondLargest = largest;
                    largest = num;
                }
                else if (num > secondLargest && num != largest)
                {
                    secondLargest = num;
                }
            }
            return secondLargest == int.MinValue ? largest : secondLargest;
        }

        #endregion

        #region Extra

        public int EX01_FindLongestConsecutiveSequence(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0) return 0;

            HashSet<int> numSet = new HashSet<int>(numbers);
            int longestStreak = 0;

            foreach (int num in numSet)
            {
                if (!numSet.Contains(num - 1))
                {
                    int currentNum = num;
                    int currentStreak = 1;

                    while (numSet.Contains(currentNum + 1))
                    {
                        currentNum += 1;
                        currentStreak += 1;
                    }

                    if (currentStreak > longestStreak)
                    {
                        longestStreak = currentStreak;
                    }
                }
            }
            return longestStreak;
        }

        #endregion
    }
}