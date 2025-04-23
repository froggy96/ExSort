using System;

namespace ExSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //
            Console.WriteLine("Quick Sort");
            FillArrayRandom();
            PrintNums();
            QuickSortMain();
            PrintNums();

            //
            Console.WriteLine("Bubble Sort");
            FillArrayRandom();
            PrintNums();
            BubbleSort();
            PrintNums();

            //
            Console.WriteLine("Selection Sort");
            FillArrayRandom();
            PrintNums();
            SelectionSort();
            PrintNums();
        }

        static int[] nums = new int[20] { 15, 15, 69, 95, 13, 7, 41, 13, 56, 31, 31, 75, 58, 35, 35, 31, 52, 89, 77, 46 };
        //static int[] nums = new int[] { 15, 15, 69, 95, 13 };

        static void PrintNums()
        {
            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write($"{nums[i]} ");
            }

            Console.WriteLine();
        }

        static void FillArrayRandom()
        {
            var rand = new Random();

            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = rand.Next(100) + 7;
            }
        }


        /*
         * Quick Sort Algo:
         * 
         * https://gmlwjd9405.github.io/2018/05/10/algorithm-quick-sort.html
         * 
         */


        //
        // pivot 값은 nums[s] 로 선택
        // low = s + 1
        // high = e
        // low 를 증가시키면서 pivot 보다 작지 않으면 스톱
        // high 를 감소시키면서 pivot 보다 크지 않으면 스톱
        // low < high 이면, 두 값을 스왑
        // 위의 내용을 low >= high 가 될 때까지 반복
        // 반복 루프 빠져나온 후, nums[high] 와 pivot 값을 교환하면, pivot 값이 있는 위치를 기준으로 왼쪽과 오른쪽으로 나뉜다.
        //
        static int QuickSortPartition(int[] nums, int s, int e)
        {

            int pivot_value = nums[s];
            int low = s + 1;
            int high = e;

            while (true)
            {
                //
                while (true)
                {
                    if (pivot_value < nums[low]) break;

                    low++;
                    if (low >= e) break;
                }

                //
                while (true)
                {
                    if (pivot_value > nums[high]) break;

                    high--;
                    if (high <= s) break;
                }

                //
                if (low < high)
                {
                    // swap
                    int temp = nums[high];
                    nums[high] = nums[low];
                    nums[low] = temp;
                }
                else
                {
                    break;
                }
            }

            nums[s] = nums[high];
            nums[high] = pivot_value;

            return high;
        }

        static void QuickSort(int[] nums, int s, int e)
        {
            if (s < e)
            {
                int p = QuickSortPartition(nums, s, e);
                QuickSort(nums, s, p - 1);
                QuickSort(nums, p + 1, e);
            }

            //
            PrintNums();
        }

        static void QuickSortMain()
        {
            QuickSort(nums, 0, nums.Length - 1);
        }

        //
        static void BubbleSort()
        {
            var cnt = nums.Length;

            do
            {
                for (int i = 0; i < cnt - 1; i++)
                {
                    if (nums[i] > nums[i + 1])
                    {
                        // swap
                        var temp = nums[i];
                        nums[i] = nums[i + 1];
                        nums[i + 1] = temp;
                    }
                }
                cnt--;
            }
            while(cnt > 0);
        }



        //
        static void SelectionSort()
        {
            for (int i = 0; i < nums.Length; i++)
            {
                int max_index = MinValueIndex(i);
                if(max_index != i)
                {
                    // swap
                    int temp = nums[i];
                    nums[i] = nums[max_index];
                    nums[max_index] = temp;
                }
            }
        }

        static int MinValueIndex(int s)
        {
            int min_value = nums[s];
            int min_index = s;
            for(int i = s; i <  nums.Length; i++)
            {
                if(min_value > nums[i])
                {
                    min_value = nums[i];
                    min_index = i;
                }
            }

            return min_index;
        }
    }
}
