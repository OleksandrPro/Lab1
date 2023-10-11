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
//            double[] arr = new double[] { 1, 2, 3.33 };
//            double[] arr = new double[] { };
            ISparseVector s2 = new SparseVector(arr);
            s2.PrintElement();
            Console.WriteLine(" ");
            SparseVector s3 = new SparseVector(s2);
            s3.PrintElement();
        }
    }
}
