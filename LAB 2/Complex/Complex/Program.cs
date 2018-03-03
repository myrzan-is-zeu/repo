using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Complex
{


    class Program
    {
        public static int a;
        public static int b;
        public static int c;
        public static int d;
        static void Main(string[] args)
        {

            string s = Console.ReadLine();
            string[] num1 = s.Split(' ');
            string[] n1 = num1[0].Split('/');
            string[] n2 = num1[1].Split('/');

            a = int.Parse(n1[0]);
            b = int.Parse(n1[1]);
            c = int.Parse(n1[0]);
            d = int.Parse(n1[1]);

            Console.WriteLine(d + "/" + b + "      " + c + "/" + a);

            Complex c1 = new Complex(a, b);
            Complex c2 = new Complex(c, d);
            Complex mul = c1 * c2;
            Complex div = c1 / c2;
            Complex sum = c1 + c2;
            Complex sub = c1 - c2;


            Console.WriteLine("Multiplication of these two numbers: " + mul);
            Console.WriteLine("Division of these two numbers: " + div);
            Console.WriteLine("Sum of these two numbers: " + sum);
            Console.WriteLine("Subtraction of these two numbers: " + sub);

        }
    }
}