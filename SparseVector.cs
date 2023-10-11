using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class SparseVector : ISparseVector
    {
        private class Node
        {
            public ICoordinateItem _coordinate;
            public Node Next { get; set; }
            public Node(ICoordinateItem item)
            {
                _coordinate = item;
                Next = null;
            }
        }
        private Node _first;
        public int Dimension { get; set; }

        public SparseVector()
        {
            _first = null;
            Dimension = 0;
        }
        public SparseVector(double[] coordinates)
        {
            int counter = 0;
            foreach (double item in coordinates)
            {
                if (item!=0)
                {
                    AddItem(new CoordinateItem(item, counter));
                }
                counter++;
            }
            Dimension = counter;
        }
        public SparseVector(ISparseVector other)
        {           
            this.Dimension = other.Dimension;
            SparseVector castedOther = other as SparseVector;

            if (castedOther == null) 
            {
                throw new InvalidCastException(nameof(other)+" is wrong type");
            }
            else
            {
                Node current = castedOther._first;

                while (current != null)
                {
                    ICoordinateItem item = new CoordinateItem(current._coordinate);
                    AddItem(item);
                    current = current.Next;
                }
            }                                  
        }
        private void AddItem(ICoordinateItem item)
        {
            Node newNode = new Node(item);
            if (_first == null)
            {
                _first = newNode;
            }                
            else
            {
                Node current = _first;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }
        private double GetValueByIndex(int index)
        {
            Node current = _first;
            double result = 0;
            try
            {
                while (current._coordinate.Index != index)
                {
                    current = current.Next;
                }
            }
            catch (NullReferenceException)
            {
                return result;
            }            
            
            if(current._coordinate != null)
            {
                result = current._coordinate.Value;
            }
            return result;
        }
        public void PrintElement()
        {
            Node current = _first;
            while (current != null)
            {
                Console.WriteLine(current._coordinate);
                current = current.Next;
            }
        }
        public ISparseVector Add(ISparseVector otherVector)
        {
            SparseVector castedOther = otherVector as SparseVector;
            if (castedOther == null)
            {
                throw new InvalidCastException(nameof(otherVector) + " is wrong type");
            }
            if (Dimension!=otherVector.Dimension)
            {
                throw new ArgumentException("Vectors have different dimensions");
            }
            else
            {
                SparseVector result = new SparseVector();
                result.Dimension = Dimension;
                Node current = castedOther._first;
                for (int i = 0; i<Dimension; i++)
                {
                    double value = GetValueByIndex(i) + castedOther.GetValueByIndex(i);
                    if (value != 0)
                    {
                        result.AddItem(new CoordinateItem(value, i));
                    }                    
                }
                return result;
            }            
        }

        public ISparseVector Subtract(ISparseVector otherVector)
        {
            SparseVector castedOther = otherVector as SparseVector;
            if (castedOther == null)
            {
                throw new InvalidCastException(nameof(otherVector) + " is wrong type");
            }
            if (Dimension != otherVector.Dimension)
            {
                throw new ArgumentException("Vectors have different dimensions");
            }
            else
            {
                SparseVector result = new SparseVector();
                result.Dimension = Dimension;
                Node current = castedOther._first;
                for (int i = 0; i < Dimension; i++)
                {
                    double value = GetValueByIndex(i) - castedOther.GetValueByIndex(i);
                    if (value != 0)
                    {
                        result.AddItem(new CoordinateItem(value, i));
                    }
                }
                return result;
            }
        }

        public ISparseVector Multiply(double number)
        {
            SparseVector result = new SparseVector();            
            for (int i = 0; i < Dimension; i++)
            {
                double value = GetValueByIndex(i) * number;
                if (value != 0)
                {
                    result.AddItem(new CoordinateItem(value, i));
                }
            }
            return result;
        }

        public double CalculateMagnitude()
        {
            double result = 0;
            Node current = _first;
            while (current != null) 
            {
                double value = current._coordinate.Value;
                result += value*value;
                current = current.Next;
            }
            return Math.Sqrt(result);
        }

        public double CalculateDotProduct(ISparseVector otherVector)
        {
            SparseVector castedOther = otherVector as SparseVector;
            if (castedOther == null)
            {
                throw new InvalidCastException(nameof(otherVector) + " is wrong type");
            }
            if (Dimension != otherVector.Dimension)
            {
                throw new ArgumentException("Vectors have different dimensions");
            }
            else
            {
                double result = 0;
                for (int i = 0; i < Dimension; i++)
                {
                    double value = GetValueByIndex(i) * castedOther.GetValueByIndex(i);
                    result += value;
                }
                return result;
            }                   
        }

        public override bool Equals(object obj)
        {
            return obj is SparseVector vector &&
                   EqualityComparer<Node>.Default.Equals(_first, vector._first) &&
                   Dimension == vector.Dimension;
        }

        public override int GetHashCode()
        {
            int hashCode = -1121357873;
            hashCode = hashCode * -1521134295 + EqualityComparer<Node>.Default.GetHashCode(_first);
            hashCode = hashCode * -1521134295 + Dimension.GetHashCode();
            return hashCode;
        }
        public override string ToString()
        {
            string result = "";
            for(int i = 0; i < Dimension; i++)
            {
                result += GetValueByIndex(i).ToString() + " ";                
            }
            return result;
        }
    }
}
