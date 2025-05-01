using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    internal class task3
    {
        static void Main(string[] args)
        {
            string word = "man is sinam";
            if(IsPalindrome(word))
            {
                Console.WriteLine($"{word} is Palindrome");
            }
            else
            {
                Console.WriteLine($"{word} is NOT Palindrome");
            }
        }
        public static bool IsPalindrome(string word)
        {
            string text = word.Replace(" ", "").ToLower();
            int left = 0;
            int right = text.Length - 1;

            while(left < right)
            {
                if (text[left] != text[right])
                {
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }
    }
}
