using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_of_prime_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine()/* сандарды енгізу */;
            string[] arr = line.Split(' ')/* string - ді массивке айналдырамыз */;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 2; j <= int.Parse(arr[i]); j++)
                {
                    if (int.Parse(arr[i]) % j == 0)
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine(arr[i]);
                    } /* жай сандарды табу алгоритмі */
                }
            }
            Console.ReadKey(); /* программаны жабу */
        }
    }
}
