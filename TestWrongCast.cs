﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class TestWrongCast : ISparseVector
    {
        public int Dimension { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ISparseVector Add(ISparseVector otherVector)
        {
            throw new NotImplementedException();
        }

        public double CalculateDotProduct(ISparseVector otherVector)
        {
            throw new NotImplementedException();
        }

        public double CalculateMagnitude()
        {
            throw new NotImplementedException();
        }

        public ISparseVector Multiply(double number)
        {
            throw new NotImplementedException();
        }

        public void PrintElement()
        {
            throw new NotImplementedException();
        }

        public ISparseVector Subtract(ISparseVector otherVector)
        {
            throw new NotImplementedException();
        }
    }
}
