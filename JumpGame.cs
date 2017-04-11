/*
Given an array of non-negative integers, you are initially positioned at the first index of the array.

Each element in the array represents your maximum jump length at that position.

Determine if you are able to reach the last index.

For example:
A = [2,3,1,1,4], return true.

A = [3,2,1,0,4], return false.
*/

public class Solution {
    public bool CanJump(int[] nums) {
        if(nums.Length <= 1) return true;
        
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            if (nums[i] == 0)
            {
                int j = i - 1;
                bool skip = false;

                while (j >= 0)
                {
                    if (nums[j] > i - j ||(nums[j] == i - j && i == nums.Length - 1))
                    {
                        i = j;
                        skip = true;
                        break;
                    }
                    else
                    {
                        j--;
                    }
                }

                if(!skip) return false;
            }
        }

        return true;
    }
}
