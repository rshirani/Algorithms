
/*
Longest Increasing Subsequence

Find the longest increasing subsequence of a given sequence / array.

In other words, find a subsequence of array in which the subsequence’s elements are in strictly increasing order, and in which the subsequence is as long as possible. 
This subsequence is not necessarily contiguous, or unique.
In this case, we only care about the length of the longest increasing subsequence.

Example :

Input : [0, 8, 4, 12, 2, 10, 6, 14, 1, 9, 5, 13, 3, 11, 7, 15]
Output : 6
The sequence : [0, 2, 6, 9, 13, 15] or [0, 4, 6, 9, 11, 15] or [0, 4, 6, 9, 13, 15]
*/

class Solution
{
    List<int> res = new List<int>();

    public int lis(List<int> A)
    {
        if(A== null || A.Length == 0) return 0;
        
        for(int i = 0; i<A.Length; i++) { res[i]=1;}
        
        for(int i=0; i<A.Length; i++)
        {
            lis(A, i);
        }
        
        int ans = 0;
        
        for(int i = 0; i< A.Length; i++)
        {
           if(res[i]>ans)
           {
               ans = res[i];
           }
        }
        
        return ans;
    }
    
    public void lis(List<int> A, int index)
    {
        if(index == 0)
        {
            res[0]=1;
        }
        
        for(int i=0; i<index; i++)
        {
            if(A[i] < A[index])
            {
                if(res[i]+1> res[index])
                {
                    res[index] = res[i]+1;
                }
            }
        }
    }
}
