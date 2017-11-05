using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Factorials
    {
        public static async Task<int> FactorialDigitSum(int n)
        {
            return await Task.Run(() => DigitSum(Factorial(n)));
        }

        public static int Factorial(int n)
        {
            int fact = 1;
            for (int i = 1; i <= n; i++)
            {
                fact = fact * i;
            }
            return fact;
        }

        private static int DigitSum(int n)
        {
            int sum = 0;
            for (int i = n; i > 0; i /= 10)
            {
                sum += i % 10;
            }
            return sum;
        }
    }
}
