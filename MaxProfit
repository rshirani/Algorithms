In a daily share trading, a buyer buys shares in the morning and sells it on same day. If the trader is allowed to make at most 2 transactions in a day, where as second transaction can only start after first one is complete (Sell->buy->sell->buy). 
Given stock prices throughout day, find out maximum profit that a share trader could have made.

public class Program
    {
        public static int MaxProfit(int[] arr)
        {
            int profit = 0;
            if (arr.Length < 2) return 0;

            for(int i =0; i<arr.Length; i++)
            {
                if(arr[i] <= ( i < arr.Length - 1 ? arr[i+1] : Int32.MaxValue)) 
                {
                    int j = i + 1;

                    while(j < arr.Length && arr[j] > arr[j-1])
                        j++;

                    profit += arr[j-1] - arr[i];
                    i = j-1;
                }
            }

            return profit;
        }
    }
