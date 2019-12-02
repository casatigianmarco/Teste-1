using System;

namespace ConsoleAppPalindromo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insira o políndromo para validação:");
            var str = Console.ReadLine().ToString();
            var result = string.Empty;
            if (IsPalindrome(str)) { result = "É um políndromo."; } else { result = "Não é um políndromo."; }
            Console.Clear();
            Console.WriteLine(result);
            Console.ReadKey();
        }
        private static bool IsPalindrome(string str)
        {
            str = str.Replace(" ", string.Empty);
            string first = str.Substring(0, str.Length / 2);
            char[] arr = str.ToCharArray();

            Array.Reverse(arr);

            string temp = new string(arr);
            string second = temp.Substring(0, temp.Length / 2);

            return first.Equals(second);
        }
    }
}
