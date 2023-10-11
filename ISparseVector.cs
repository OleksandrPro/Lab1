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
//        ICoordinateItem First { get; set; }
        ISparseVector Add(ISparseVector otherVector);
        ISparseVector Subtract(ISparseVector otherVector);
        ISparseVector Multiply(ISparseVector otherVector);
        int CalculateMagnitude();
        int CalculateDotProduct();
        void PrintElement();
    }
}

