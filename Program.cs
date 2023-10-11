using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] arr = new double[] { 1.11, 2.22, 3.33, 4.44, 5.55, 6.66 };
            double[] arr1 = new double[] { 1.11, 2.22, 3.33 };
            double[] arr2 = new double[] { 1.11, -2.22, 3.33 };
            double[] arr3 = new double[] { 12, -5, 0 };
            //            double[] arr = new double[] { };
            Console.WriteLine(" ");
            SparseVector s3 = new SparseVector(new double[] { 1, 9, 7 });
            s3.PrintElement();
            Console.WriteLine(s3);
            Console.WriteLine(" ");
            ISparseVector s4 = new SparseVector(new double[] { -2, 0, 4 });
            s4.PrintElement();
            Console.WriteLine(s4);
            Console.WriteLine(" ");
            ISparseVector s5 = s4.Add(s3);
            Console.WriteLine(s5);
            s5.PrintElement();
            Console.WriteLine("Dot product");
            double product = s4.CalculateDotProduct(s3);
            Console.WriteLine(product);
        }
    }
}
