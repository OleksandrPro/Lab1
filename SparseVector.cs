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
                Add(new CoordinateItem(item, counter++));
            }
            Dimension = counter;
        }
        public SparseVector(ISparseVector other)
        {           
            this.Dimension = other.Dimension;
            SparseVector castedOther = (SparseVector)other;

            Node current = castedOther._first;
            Node previous = null;

            while(current!=null)
            {
                ICoordinateItem item = new CoordinateItem(current._coordinate);
                Node newNode = new Node(item);
                if (previous==null)
                     _first = newNode;
                else 
                    previous.Next = newNode;
                previous = current;
                current = current.Next;
            }                      
        }
        public void Add(ICoordinateItem item)
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
        public double GetValueByIndex(int index)
        {
            Node current = _first;
            
            while (current._coordinate.Index != index)
            {
                current = current.Next;
            }
            return current._coordinate.Value;
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

        public override string ToString()
        {
            string result = "";

            return base.ToString();
        }

        public ISparseVector Add(ISparseVector otherVector)
        {
            throw new NotImplementedException();
        }

        public ISparseVector Subtract(ISparseVector otherVector)
        {
            throw new NotImplementedException();
        }

        public ISparseVector Multiply(ISparseVector otherVector)
        {
            throw new NotImplementedException();
        }

        public int CalculateMagnitude()
        {
            throw new NotImplementedException();
        }

        public int CalculateDotProduct()
        {
            throw new NotImplementedException();
        }
    }
}
