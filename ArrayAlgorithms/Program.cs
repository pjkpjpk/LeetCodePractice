using System;
using System.Collections.Generic;
using System.Linq;

namespace ArrayAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 1, 2, 2, 1 };
            int[] array1 = new int[] { 2,2 };
            //int[] res = PlusOne(array);
            //bool res = ContainsDuplicate2(array);
            int[] res = Intersect(array,array1);
            Console.WriteLine(string.Join(",", res));
            Console.WriteLine(array);
            Console.ReadKey();
            Console.WriteLine("Hello World!");
        }

        //去除有序数组的重复元素
        static int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }
            else if (nums.Length == 1)
            {
                return 1;
            }
            else
            {
                int j = 0;
                //int s = nums[0];
                for (int i = 1; i < nums.Length; i++)
                {
                    //int t = nums[i];
                    if (nums[i] != nums[j])
                    {
                        j++;
                        nums[j] = nums[i];
                        //s = nums[i];
                    }
                }
                return j + 1;
            }
        }
        //判断数组是否有重复元素
        static bool ContainsDuplicate(int[] nums)
        {
            if (nums.Length <= 1)
            {
                return false;
            }
            else
            {
                bool res = false;
                for (int j = 0; j < nums.Length; j++)
                {
                    for (int i = j + 1; i < nums.Length; i++)
                    {
                        if (nums[j] == nums[i])
                        {
                            res = true;
                            break;
                        }
                    }
                }
                return res;
            }
        }

        static bool ContainsDuplicate1(int[] nums)
        {
            if (nums.Length <= 1)
            {
                return false;
            }
            else
            {
                bool res = false;
                Dictionary<int, string> pairs = new Dictionary<int, string>();
                for (int j = 0; j < nums.Length; j++)
                {
                    if (!pairs.TryAdd(nums[j], "1"))
                    {
                        res = true;
                    }
                }
                return res;
            }
        }

        static bool ContainsDuplicate2(int[] nums)
        {
            if (nums.Length <= 1)
            {
                return false;
            }
            else
            {
                bool res = false;
                nums = nums.OrderBy(x => x).ToArray();
                for (int i = 1; i < nums.Length; i++)
                {
                    if (nums[i] - nums[i - 1] == 0)
                    {
                        res = true;
                    }
                }
                return res;
            }
        }

        static bool ContainsDuplicate4(int[] nums)
        {
            if (nums.Length <= 1)
            {
                return false;
            }
            else
            {
                var nums1 = nums.Distinct();
                return nums1.Count() < nums.Length;
            }
        }

        static int SingleNumber(int[] nums)
        {
            int j = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                j ^= nums[i];
            }
            return j;
        }

        static int SingleNumber1(int[] nums)
        {
            if (nums.Length == 1)
            {
                return nums[0];
            }
            var sort = nums.OrderBy(x => x).ToList();
            int val = -1;
            for (int i = 0; i < sort.Count; i++)
            {
                if (i == 0)
                {
                    if (sort[i] != sort[i + 1])
                    {
                        val = sort[i];
                        break;
                    }
                }
                else if (i == sort.Count - 1)
                {
                    if(sort[i] != sort[i - 1])
                    {
                        val = sort[i];
                        break;
                    }
                }
                else
                {
                    if(sort[i] != sort[i - 1] && sort[i] != sort[i + 1])
                    {
                        val = sort[i];
                        break;
                    }
                }
            }
            return val;
        }


        static int[] TwoSum(int[] nums, int target)
        {
            int[] res = new int[2];
            for(int i = 0; i < nums.Length; i++)
            {
                int t = target - nums[i];
                for(int j = i + 1; j < nums.Length; j++)
                {
                    if (t == nums[j])
                    {
                        res[0] = i;
                        res[1] = j;
                        break;
                    }
                }
            }
            return res;
        }

        //static int[] TwoSum1(int[] nums, int target)
        //{
        //    int[] res = new int[2];
        //    var num = nums.Select((x, index) => (x,index)).Where(x => x.x <= target).ToList();
        //    for (int i = 0; i < num.Count; i++)
        //    {
        //        int t = target - num[i].x;
        //        for (int j = i + 1; j < num.Count; j++)
        //        {
        //            if (t == num[j].x)
        //            {
        //                res[0] = num[i].index;
        //                res[1] = num[j].index;
        //                break;
        //            }
        //        }
        //    }
        //    return res;
        //}

        static int[] PlusOne(int[] digits)
        {
            if (digits[0] == 0)
            {
                return new int[] { 1 }; 
            }
            else
            {
                int i = digits.Length - 1;
                while (i >= 0 && digits[i] + 1 >= 10)
                {
                    i--;
                }
                if (i < 0)
                {
                    int len = digits.Length + 1;
                    int[] array = new int[len];
                    array[0] = 1;
                    return array;
                }
                else
                {
                    digits[i] += 1;
                    for(int j = i + 1; j < digits.Length; j++)
                    {
                        digits[j] = 0;
                    }
                    return digits;
                }
            }
        }

        static int[] PlusOne1(int[] digits)
        {
            if (digits[0] == 0)
            {
                return new int[] { 1 };
            }
            else
            {
                for(int i = digits.Length - 1; i >= 0; i--)
                {
                    if(digits[i] != 9)
                    {
                        digits[i]++;
                        return digits;
                    }
                    else
                    {
                        digits[i] = 0;
                    }
                }
                int[] array = new int[digits.Length + 1];
                array[0] = 1;
                return array;
            }
        }
        static void MoveZeroes(int[] nums)
        {
            int j = 0;
            for(int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[j] = nums[i];
                    j++;
                }
            }
            while (j < nums.Length)
            {
                nums[j] = 0;
                j++;
            }
        }

        static void MoveZeroes1(int[] nums)
        {
            int j = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    int tmp = nums[j];
                    nums[j] = nums[i];
                    nums[i] = tmp;
                    j++;
                }
            }
        }

        static int[] Intersect(int[] nums1, int[] nums2)
        {
            Array.Sort(nums1);
            Array.Sort(nums2);
            if (nums1.Length > nums2.Length)
            {
                return Intersect(nums2,nums1);
            }
            else
            {
                int i = 0;
                int j = 0;
                List<int> res = new List<int>();
                while (i < nums1.Length && j < nums2.Length)
                {
                    if (nums1[i] < nums2[j])
                    {
                        i++;
                    }
                    else if(nums1[i] > nums2[j])
                    {
                        j++;
                    }
                    else
                    {
                        res.Add(nums2[j]);
                        i++;
                        j++;
                    }
                }
                return res.ToArray();
            }
            //List<int> intersect = new List<int>();
            //for(int i = 0; i < nums1.Length; i++)
            //{
            //    for(int j = 0; j < nums2.Length; j++)
            //    {
            //        if (nums1[i] == nums2[j])
            //        {
            //            intersect.Add(nums1[i]);
            //            break;
            //        }
            //    }
            //}
            //return intersect.ToArray();
        }

        static bool IsValidSudoku(char[][] board)
        {
            char[][] row = new char[9][];//行元素
            char[][] col = new char[9][];//列元素
            char[][] area = new char[9][];//3*3元素
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    row[i][j] = board[i][j];//行
                    col[j][i] = board[j][i];//列
                }
            }
            return true;
        }

    }
}
