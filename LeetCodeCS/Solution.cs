using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeCS;

public class Solution
{


    #region RomanToIntRegion
    /// <summary>
    /// Runtime: 56 ms, Memory:48.2
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static int RomanToInt(string s)
    {
        int sum = 0;
        Dictionary<char, int> romanNumbersDictionary = new()
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 }
            };
        for (int i = 0; i < s.Length; i++)
        {
            romanNumbersDictionary.TryGetValue(s[i], out int num);
            if (i + 1 < s.Length)
            {
                romanNumbersDictionary.TryGetValue(s[i + 1], out int num2);
                if (num < num2)
                {
                    sum -= num;
                    continue;
                }
            }
            sum += num;
        }
        return sum;
    }

    /// <summary>
    /// Runtime: 61 ms, Memory:48.1
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static int RomanToInt1(string s)
    {
        int sum = 0;
        Dictionary<char, int> dict = new()
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 }
            };
        //iterate through all the letters of the string
        for (int i = 0; i < s.Length; i++)
        {
            //get the numerical value of the current letter
            int num = dict[s[i]];
            //if there is a next char, get the value
            if (i + 1 < s.Length)
            {
                int num2 = dict[s[i + 1]];
                //when the current char is less than the next char, in roman, the value is subtracted.
                if (num < num2)
                {
                    sum -= num;
                    continue;
                }
            }
            //if there is no next char or its greater than the current, add the value to sum. 
            sum += num;
        }
        return sum;
    }
    #endregion

    public static bool IsPalindrome(int num)
    {
        if (num < 0) return false;
        if (num < 10) return true;
        if (num % 10 == 0) return false;


        int newNum = 0;
        //once the newNum is equal to or greater than the num, no need to check the remaining digits
        while (num > newNum)
        {
            newNum = newNum * 10; // multiply current num by 10 to add last digit. 
            int z = num % 10; // get the next digit with modular division and add it to the new number
            newNum += z;
            num /= 10; //remove last digit from x
        }

        //after checking half of the digits, if the numbers are equal, it means is a palindrome
        if (num == newNum)
            return true;
        //if the number of digits of num is odd, means one aditional number was added to new num, 
        //divide by 10 to remove it and see if then see if they are equal - since this number would be at the middle, it would be in both, the new and old num.
        newNum /= 10;
        return (num == newNum);
    }
}
