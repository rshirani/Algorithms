using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Solution sl = new Solution();
        var ans = sl.FindRelativeRanks(new int[] { 4, 2, 3, 1, 10, 15 });
        Console.ReadKey();
    }

}

public class Solution
{
    public string[] FindRelativeRanks(int[] nums)
    {
        List<User> list = new List<User>();

        for (int i = 0; i < nums.Length; i++)
            list.Add(new User { Rank = nums[i], Index = i });

        // Option 1: Using IComparable
        list.Sort((a, b) => b.CompareTo(a));

        // Option 2: using LINQ
        list = list.OrderByDescending(a => a.Rank).ToList();

        // Option 3: Using IComparer via Comparer object
        list.Sort(new UserComparer());

        // Option 4: Passing a Delegate
        list.Sort(SmartCompare);

        String[] ans = new String[nums.Length];

        for (int i = 0; i < list.Count; i++)
        {
            if (i == 0) ans[list[0].Index] = "Gold Medal";
            else if (i == 1) ans[list[1].Index] = "Silver Medal";
            else if (i == 2) ans[list[2].Index] = "Bronze Medal";
            else ans[list[i].Index] = (i + 1).ToString();
        }

        return ans;
    }

    public int SmartCompare(User user1, User user2)
    {
        if (user1.Rank < user2.Rank)
            return 1;
        else if (user1.Rank > user2.Rank)
            return -1;
        else
            return 0;
    }
}

public class UserComparer : Comparer<User>
{
    public override int Compare(User user1, User user2)
    {
        if (user1.Rank < user2.Rank)
            return 1;
        else if (user1.Rank > user2.Rank)
            return -1;
        else
            return 0;
    }
}

public class User : IComparable<User>
{
    public int Rank { get; set; }
    public int Index { get; set; }

    public int CompareTo(User otherUser)
    {
        if (otherUser != null)
        {
            if (this.Rank > otherUser.Rank)
                return 1;
            else if (this.Rank < otherUser.Rank)
                return -1;
            else
                return 0;
        }
        else
            throw new ArgumentException("Object is not a User");
    }
}
