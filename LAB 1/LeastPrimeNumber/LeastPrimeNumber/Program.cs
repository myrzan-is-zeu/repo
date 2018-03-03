using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace LeastPrimeNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = File.ReadAllText(path: @"C:\Users\Myrz\Desktop\least.txt");
            string[] nums = File.ReadAllLines(path: @"C:\Users\Myrz\Desktop\least.txt");
            int n = nums.Length;

            var Prime = new List<int>();
            for(int i = 0; i < n; i++)
            {
                int k = int.Parse(nums[i]);
                if (Class1.IsPrime(k))
                {
                    Prime.Add(k);
                }
            }
            File.WriteAllText(@"C:\Users\Myrz\Desktop\least.txt", Prime.Min().ToString());
        }
    }
}
