using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //TASK 1 Stuff
            //string filepath = "C:/Users/Edwar/OneDrive - Swinburne University/Diploma/PRG/week 16/weekly task - algorithms/unsorted_numbers.csv";
            //int[] unsortednums = ReadFile(filepath);
            //DateTime startTime = DateTime.Now;
            //int[] sortednums=insertionSort(unsortednums);
            //Console.WriteLine("insertion sort duration:");
            //DateTime endTime = DateTime.Now;
            //TimeSpan Duration = endTime.TimeOfDay - startTime.TimeOfDay;
            //WriteFile("C:/Users/Edwar/OneDrive - Swinburne University/Diploma/PRG/week 16/weekly task - algorithms/sorted_numbers.csv", sortednums);
            //Console.WriteLine(Duration);
            //Console.ReadLine();

            int[] sortedNums = ReadFile("C:/Users/Edwar/OneDrive - Swinburne University/Diploma/PRG/week 16/weekly task - algorithms/sorted_numbers.csv");
            TimeSpan start = DateTime.Now.TimeOfDay;
            Console.ReadLine();
            start = DateTime.Now.TimeOfDay;
            Console.WriteLine(linear(sortedNums, 999912));
            Console.WriteLine("Linear search for max number duration:"+(DateTime.Now.TimeOfDay-start).ToString());
            Console.ReadLine();
            start = DateTime.Now.TimeOfDay;
            Console.WriteLine(linear(sortedNums, 99059));
            Console.WriteLine(linear(sortedNums, 200999));
            Console.WriteLine(linear(sortedNums, 300861));
            Console.WriteLine(linear(sortedNums, 398536));
            Console.WriteLine(linear(sortedNums, 498874));
            Console.WriteLine(linear(sortedNums, 595591));
            Console.WriteLine(linear(sortedNums, 696143));
            Console.WriteLine(linear(sortedNums, 799567));
            Console.WriteLine(linear(sortedNums, 899016));
            Console.WriteLine(linear(sortedNums, 999912));
            Console.WriteLine("Linear search for every 1500th number duration:" + (DateTime.Now.TimeOfDay - start).ToString());
            Console.ReadLine();
            start = DateTime.Now.TimeOfDay;
            //int[] testnums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 };
            //Console.WriteLine(binary(testnums, 24));
            //Console.WriteLine("binary Sort for test number duration:" + (DateTime.Now.TimeOfDay - start).ToString());
            //Console.ReadLine();
            Console.WriteLine(binary(sortedNums, 999912));
            Console.WriteLine("binary search for max number duration:" + (DateTime.Now.TimeOfDay - start).ToString());
            Console.ReadLine();
            start = DateTime.Now.TimeOfDay;
            Console.WriteLine(binary(sortedNums, 99059));
            Console.WriteLine(binary(sortedNums, 200999));
            Console.WriteLine(binary(sortedNums, 300861));
            Console.WriteLine(binary(sortedNums, 398536));
            Console.WriteLine(binary(sortedNums, 498874));
            Console.WriteLine(binary(sortedNums, 595591));
            Console.WriteLine(binary(sortedNums, 696143));
            Console.WriteLine(binary(sortedNums, 799567));
            Console.WriteLine(binary(sortedNums, 899016));
            Console.WriteLine(binary(sortedNums, 999912));
            Console.WriteLine("binary search for every 1500th number duration:" + (DateTime.Now.TimeOfDay - start).ToString());
            Console.ReadLine();
        }

        /// <summary>
        /// Reads a file returning each line in a list.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static int[] ReadFile(string filePath)
        {
            string[] strings = System.IO.File.ReadAllLines(filePath).Cast<string>().ToArray();
            int[] lines = Array.ConvertAll(strings, int.Parse);
            return lines;
        }

        /// <summary>
        /// Takes a list of a list of data.  Writes to file, using delimeter to seperate data.  Always overwrites.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="delimeter"></param>
        /// <param name="rows"></param>
        public static void WriteFile(string filePath, int[] numbers)
        {
            foreach(int i in numbers)
            {
                using (System.IO.StreamWriter file =
new System.IO.StreamWriter(filePath, true))
                {
                    file.Write(i);
                    file.Write(file.NewLine);
                }
            }
        }

        public static int[] insertionSort(int[] arr)
        {
            int N = arr.Length;

            for (int i = 1; i < N; i++)
            {
                int j = i - 1;
                int temp = arr[i];

                while (j >= 0 && temp < arr[j])
                {
                    arr[j + 1] = arr[j];
                    j--; ;
                }

                arr[j + 1] = temp;
                Console.Write("After pass " + i + "  : ");
                //Printing array after pass
                Console.WriteLine(String.Join(" ", arr));
                
            }
            return arr;
        }

        public static void shellsort(int[] arr)
        {
            int N = arr.Length;
            int h = N / 3;
            int pass = 1;

            while (h > 0)
            {
                for (int i = h; i < N; i++)
                {
                    int temp = arr[i], j;

                    for (j = i; j >= h && arr[j - h] > temp; j -= h)
                    {
                        arr[j] = arr[j - h];
                    }

                    arr[j] = temp;
                }

                Console.Write("After pass " + pass + "  : ");
                //Printing array after pass
                Console.WriteLine(String.Join(" ", arr));
                pass++;
                h /= 2;
            }
        }

        public static int linear(int[] nums,int target)
        {
            for(int i=0;i<nums.Count();i++)
            {
                if(nums[i]==target)
                { return i; }
            }
            return - 1;
        }

        public static int binary(int[] nums, int target)
        {
            int mid;
            bool solved = false;
            while (!solved)
            {
                if (nums.Count() % 2 == 0)
                {
                    mid = nums.Count() / 2;    
                }
                else
                {
                    mid = (nums.Count() + 1) / 2;
                }

                if (nums[mid-1] == target)
                {
                    solved = true;
                    return mid;
                }
                else if (nums[mid-1] < target)
                {
                    nums = nums.Skip(mid).ToArray();
                    
                }
                else if (nums[mid-1] > target)
                {
                    nums = nums.Take(mid).ToArray();
                }

                //Console.WriteLine(nums.Count());
                //foreach (int i in nums)
                //{ Console.WriteLine(i); }
                //Console.ReadLine();
            }
            return -1;
        }


    }

}

