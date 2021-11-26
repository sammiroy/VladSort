using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace VladSort
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // LOAD DATA FILES INTO ARRAYS
            int[] randomData = loadDataArray(@"F:\Visual Studio 2022\Projects\VladSort\data-files\random-values.txt");
            int[] reversedData = loadDataArray(@"F:\Visual Studio 2022\Projects\VladSort\data-files\reversed-values.txt");
            int[] nearlySortedData = loadDataArray(@"F:\Visual Studio 2022\Projects\VladSort\data-files\nearly-sorted-values.txt");
            int[] fewUniqueData = loadDataArray(@"F:\Visual Studio 2022\Projects\VladSort\data-files\few-unique-values.txt");

            // VERIFY LOADED DATA BY PRINTING 50 ELEMENTS
            printIntArray(randomData, 0, 50);
            printIntArray(reversedData, 0, 50);
            printIntArray(nearlySortedData, 0, 50);
            printIntArray(fewUniqueData, 0, 50);
        }

        #region Sorting Methods

        public static void BubbleSort(int[] anArray)
        {
            // Loop through the array, shrinking the search feild each time
            for (int numComp = anArray.Length - 1; numComp > 0; numComp--)
            {
                for (int i = 0; i < numComp; i++)
                {
                    if (anArray[i] > anArray[i + 1])
                    {
                        int temp = anArray[i];
                        anArray[i] = anArray[i + 1];
                        anArray[i + 1] = temp;

                    }
                }
            }
        }

        public static void SelectionSort(int[] anArray)
        {

            for (int fillSlot = 0; fillSlot < anArray.Length - 1; fillSlot++)
            {
                int minPos = fillSlot;
                for (int i = minPos + 1; i < anArray.Length; i++)
                {
                    if (anArray[i] < anArray[minPos])
                    {
                        // Rearrange vaslues based on index variables
                        int temp = anArray[i];
                        anArray[i] = anArray[minPos];
                        anArray[minPos] = temp;
                    }
                }
            }
        }

        public static void InsertionSort(int[] anArray)
        {
            // Each element starting at the second position moving to the end, save the value to insert, save the insert position 
            for (int i = 1; i < anArray.Length; i++)
            {
                int insertVal = anArray[i];
                int insertPos = i;

                // If there is an index to the right of the current position and it is bigger than the current position's value
                while ((insertPos - 1) >= 0 && anArray[insertPos - 1] > insertVal)
                {
                    // Move the desired index's value over to the right, then move the insertPos down
                    anArray[insertPos] = anArray[insertPos - 1];
                    insertPos--;
                }

                // Insert the value into the new position
                anArray[insertPos] = insertVal;
            }
        }

        #endregion

        #region Utility Methods

        // Function to create an array of integers from provided data file
        public static int[] loadDataArray(string fileName)
        {
            // Read Text File by Line 
            string[] lines = File.ReadAllLines(fileName);

            // Create Array of Integers
            int[] tempData = new int[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                tempData[i] = Convert.ToInt32(lines[i]);
            }

            // Return Array of Integers
            return tempData;
        }

        public static void printIntArray(int[] array, int start, int stop)
        {
            // Print out array elements at index values from start to stop 
            for (int i = start; i < stop; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        #endregion
    }
}