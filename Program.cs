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
 //            double[] arr = new double[] { 1, 2, 3.33, 4.44, 5.55, 6.66 };
            double[] arr = new double[] { 1, 2, 3.33 };
            ISparseVector s2 = new SparseVector(arr);
            s2.PrintElement();
            Console.WriteLine(" ");
//            Console.WriteLine(s2.GetValueByIndex(3));
            //ISparseVector s3 = new SparseVector(s2);
            //s3.PrintElement();
            //Console.WriteLine(" ");
            //s3._coordinates._first.Value = 100.0;
            //s2.PrintElement();
            //Console.WriteLine(" ");
            //s3.PrintElement();
            //Console.WriteLine(" ");
        }
    }
}
