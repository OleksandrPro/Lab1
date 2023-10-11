using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public interface ISparseVector
    {
        int Dimension { get; set; }
        ISparseVector Add(ISparseVector otherVector);
        ISparseVector Subtract(ISparseVector otherVector);
        ISparseVector Multiply(double number);
        double CalculateMagnitude();
        double CalculateDotProduct(ISparseVector otherVector);
        void PrintElement();
    }
}

