using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new[] { 0, 1, 5, 76, 234 };
            var target = 5;

            Console.WriteLine(BinarySearch(array, target));

            double[] arr = new double[] { 1, 1, 5, 4, 9, 9.8 };
            Console.WriteLine(SumArray(arr));
            Console.ReadLine();
        }
        public static int BinarySearch(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
                return -1;

            int left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                // Prevent (left + right) overflow
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            // End Condition: left > right
            return -1;
        }
        public static double SumArray(double[] array)
        {
            double sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array.Length > 0)
                {
                    return sum += array[i];
                }
                else
                {
                    return 0;
                }
            }
            return sum;
        }
        
    }
}
