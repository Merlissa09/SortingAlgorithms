using System.Diagnostics;
using System.Net.NetworkInformation;

namespace SortingAlgorithms
{
    public class Program
    {
        static void Main(string[] args)
        {
            // ctl k + c
            //int[] arr1 = { 6, 1, 7, 4, 2, 9, 8, 5, 3 };
            //int[] arr2 = { 6, 1, 7, 4, 2, 9, 8, 5, 3 };
            //int[] arr3 = { 6, 1, 7, 4, 2, 9, 8, 5, 3 };
            //int[] arrSorted1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //int[] arrSorted2 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //int[] arrSorted3 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();
            //InsertionSort(arrSorted1);
            //stopwatch.Stop();
            //Console.WriteLine($"Elapsed time for Insertion Sort: {stopwatch.ElapsedTicks}");

            //stopwatch.Restart();
            //stopwatch.Start();
            //BubbleSort(arrSorted2);
            //stopwatch.Stop();
            //Console.WriteLine($"Elapsed time for Bubble Sort: {stopwatch.ElapsedTicks}");

            //stopwatch.Restart();
            //stopwatch.Start();
            //SelectionSort(arrSorted3);
            //stopwatch.Stop();
            //Console.WriteLine($"Elapsed time for Selection Sort: {stopwatch.ElapsedTicks}");

            //Console.WriteLine("Please select a sorting algorithm");
            //Console.WriteLine("1: Bubble Sort");
            //Console.WriteLine("2: Selection Sort");
            //Console.WriteLine("3: Insertion Sort");

            //string? userSelection = Console.ReadLine();

            //Student student1 = new Student("Melissa", 4.0);
            //Student student2 = new Student("Rich", 3.0);
            //Student student3 = new Student("Adam", 3.8);

            //Student[] students = { student1, student2, student3 };

            //switch (userSelection)
            //{
            //    case "1":
            //        BubbleSort(students);
            //        break;
            //    case "2":
            //        // call selection sort method
            //        break;
            //    case "3":
            //        // call insertion sort method
            //        break;
            //    default:
            //        // none of the cases matched
            //        break;
            //}

            //PrintArray(students);

            int[] mergeArray = { 3, 2, 5, 6, 7, 4, 1, 0 };
            //MergeSort(mergeArray);
            //Console.WriteLine();
            QuickSort(mergeArray);
        }

        public static void QuickSort(int[] arr)
        {
            if (arr == null) return;
            if (arr.Length == 0) return;
            QuickSortHelper(arr, 0, arr.Length - 1);
        }


        /// <summary>
        /// Utilizes a quick sort algorithm to sort the passed in array
        /// </summary>
        /// <param name="arr"> the array which should be sorted </param>
        /// <param name="low"> the smaller index of the (sub)array </param>
        /// <param name="high"> the larger index of the (sub)array </param>
        public static void QuickSortHelper(int[] arr, int low, int high)
        {
            if (low < high)
            {
                // Partition return pivot location to us
                int pivotIndex = Partition(arr, low, high);

                // Call QuickSort again on the new subarrays pased on pivots position
                QuickSortHelper(arr, low, pivotIndex - 1);
                QuickSortHelper(arr, pivotIndex + 1, high);
            }
        }

        public static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high]; // setting pivot to be the last value in the array
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }

            Swap(arr, ++i, high);
            return i;
        }

        public static void Swap(int[] arr, int i, int j)
        {
            // swap - could also move this into a helper method
            int temp = arr[j];
            arr[j] = arr[i];
            arr[i] = temp;
        }


        // Responsible for splitting the array up and eventually merging it together
        // Calls itself recursively
        public static void MergeSort(int[] arr)
        {
            if (arr.Length <= 1) return; // example of an early return

            int mid = arr.Length / 2;
            int[] leftSubArray = new int[mid];
            int[] rightSubArray = new int[arr.Length - mid];

            for (int i = 0; i < mid; i++)
            {
                leftSubArray[i] = arr[i];
            }

            for (int i = mid; i < arr.Length; i++)
            {
                rightSubArray[i - mid] = arr[i];
            }

            MergeSort(leftSubArray);
            MergeSort(rightSubArray);
            Merge(arr, leftSubArray, rightSubArray);
        }

        public static void Merge(int[] arr, int[] leftArr, int[] rightArr)
        {
            int arrIndex = 0, leftIndex = 0, rightIndex = 0;

            // while the leftArr has values and the right array has values 
            // we will evaluate which value is lesser - and make assignments
            while (leftIndex < leftArr.Length && rightIndex < rightArr.Length)
            {
                if (leftArr[leftIndex] <= rightArr[rightIndex])
                {
                    arr[arrIndex++] = leftArr[leftIndex++];
                }
                else
                {
                    arr[arrIndex++] = rightArr[rightIndex++];
                }
            }

            // copy remaining elements from left array, if any
            while (leftIndex < leftArr.Length)
            {
                arr[arrIndex++] = leftArr[leftIndex++];
            }

            // copy remaining elements from right array, if any
            while (rightIndex < rightArr.Length)
            {
                arr[arrIndex++] = rightArr[rightIndex++];
            }
        }

        public static void PrintArray(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        public static void PrintArray(Student[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write($"{item.name}: {item.gpa} ");
            }
            Console.WriteLine();
        }

        public static void InsertionSort(int[] arr)
        {

            // Overall worst case scenario: O(n^2)
            // Best case scenario: O(n)
            for (int i = 1; i < arr.Length; i++)  // O(n)
            {
                int temp = arr[i]; // store the current element - as it might be overwritten
                int priorIndex = i - 1; // start comparing with the element before the current one

                // if our prior element is greater than our stored element
                // and we have not reached the end of the array
                while (priorIndex >= 0 && arr[priorIndex] > temp) // O(n)
                {
                    arr[priorIndex + 1] = arr[priorIndex];
                    priorIndex--;
                }

                // need to an assignment
                arr[priorIndex + 1] = temp;

            }

        }

        public static void BubbleSort(int[] arrToSort)
        {
            int temp;
            for (int i = 0; i < arrToSort.Length - 1; i++) // how many times we need to go though the unsorted array  
            {
                for (int j = 0; j < arrToSort.Length - 1 - i; j++)
                {
                    // we need to swap  
                    if (arrToSort[j] > arrToSort[j + 1])
                    {
                        temp = arrToSort[j];
                        arrToSort[j] = arrToSort[j + 1];
                        arrToSort[j + 1] = temp;
                    }
                }
            }
        }

        public static void BubbleSort(Student[] arrToSort)
        {
            Student temp;
            for (int i = 0; i < arrToSort.Length - 1; i++) // how many times we need to go though the unsorted array  
            {
                for (int j = 0; j < arrToSort.Length - 1 - i; j++)
                {
                    // we need to swap  
                    if (arrToSort[j].gpa < arrToSort[j + 1].gpa)
                    {
                        temp = arrToSort[j];
                        arrToSort[j] = arrToSort[j + 1];
                        arrToSort[j + 1] = temp;
                    }
                }
            }
        }

        public static void SelectionSort(int[] arrToSort)
        {
            // minIndex keeps track of the smallest index in each iteration  
            // temp is used as temporary storage  
            int minIndex, temp;

            // O(n) how many times we need to go though the unsorted array  
            for (int i = 0; i < arrToSort.Length; i++)
            {
                minIndex = i; // set the minIdex equal to current smallest index  
                for (int j = i; j < arrToSort.Length; j++) // loop through each element starting at i  
                {
                    // if the element is smaller than the current minIndex  
                    if (arrToSort[j] < arrToSort[minIndex])
                    {
                        // swap  
                        minIndex = j;
                    }
                }

                // swap elements  
                // swap current i (which is smallest position with the smallest/min element)  
                temp = arrToSort[i];
                arrToSort[i] = arrToSort[minIndex];
                arrToSort[minIndex] = temp;
            }
        }
    }
}
