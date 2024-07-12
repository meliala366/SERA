using System;

namespace PalindromeChecker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Masukkan kata yang ingin dicheck: ");
            string input = Console.ReadLine();

            bool isPalindrome = IsPalindrome(input);

            Console.WriteLine($"Apakah \"{input}\" palindrome? {isPalindrome}");
        }

        public static bool IsPalindrome(string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;

            int left = 0;
            int right = input.Length - 1;

            while (left < right)
            {
                if (char.ToLower(input[left]) != char.ToLower(input[right]))
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
