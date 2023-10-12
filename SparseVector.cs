using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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
            if (coordinates == null)
            {
                _first = null;
                Dimension = 0;
            }
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
            CastExceptionCheck(castedOther);
            Node current = castedOther._first;
            while (current != null)
            {
                ICoordinateItem item = new CoordinateItem(current._coordinate);
                AddItem(item);
                current = current.Next;
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
        private void CastExceptionCheck(SparseVector casted)
        {
            if (casted == null)
            {
                throw new InvalidCastException(nameof(casted) + " is wrong type");
            }
        }
        private void EqualDimansionCheck(ISparseVector vector)
        {
            if (Dimension != vector.Dimension)
            {
                throw new ArgumentException("Vectors have different dimensions");
            }
        }
        private enum OperationType
        {
            Add, Subtract
        }
        private ISparseVector UtilAdditionSubtractionFunction(ISparseVector vector, OperationType type)
        {
            SparseVector castedOther = vector as SparseVector;
            CastExceptionCheck(castedOther);
            EqualDimansionCheck(vector);
            SparseVector result = new SparseVector();
            result.Dimension = Dimension;
            Node current = castedOther._first;
            for (int i = 0; i < Dimension; i++)
            {
                double value = 0;
                int expressionCoefficient = 1;
                if (type==OperationType.Add)
                {
                    expressionCoefficient = 1;
                }
                else if (type == OperationType.Subtract)
                {
                    expressionCoefficient = -1;
                }
                value = GetValueByIndex(i) + expressionCoefficient * castedOther.GetValueByIndex(i);
                if (value != 0)
                {
                    result.AddItem(new CoordinateItem(value, i));
                }
            }
            return result;
        }
        public ISparseVector Add(ISparseVector otherVector)
        {
            ISparseVector result = new SparseVector();
            result = UtilAdditionSubtractionFunction(otherVector, OperationType.Add);
            return result;
        }
        public ISparseVector Subtract(ISparseVector otherVector)
        {
            ISparseVector result = new SparseVector();
            result = UtilAdditionSubtractionFunction(otherVector, OperationType.Subtract);
            return result;
        }
        public ISparseVector Multiply(double number)
        {
            SparseVector result = new SparseVector(); 
            result.Dimension = Dimension;
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
            CastExceptionCheck(castedOther);
            EqualDimansionCheck(otherVector);
            double result = 0;
            for (int i = 0; i < Dimension; i++)
            {
                double value = GetValueByIndex(i) * castedOther.GetValueByIndex(i);
                result += value;
            }
            return result;
        }
        public override bool Equals(object obj)
        {
            bool result = false;
            Node currentThis = _first;
            SparseVector castedOther = obj as SparseVector;
            if (castedOther == null)
            {
                return result;
            }
            Node currentOther = castedOther._first;
            if (currentThis == null && currentOther==null)
            {
                result = true;
                return result;
            }
            if (Dimension != castedOther.Dimension)
            {
                return false;
            }
            while (currentThis!=null && currentOther!=null)
            {
                if(currentThis._coordinate.Value != currentOther._coordinate.Value || currentThis._coordinate.Index != currentOther._coordinate.Index)
                {
                    return result;
                }
                currentThis = currentThis.Next;
                currentOther = currentOther.Next;
            }
            result = true;
            return result;
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
