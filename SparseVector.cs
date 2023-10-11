using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class SparseVector : ISparseVector
    {
        private class CoordinateItem : ICoordinateItem
        {
            public double Value { get; set; }
            public int Index { get; set; }
            public ICoordinateItem NextItem { get; set; }
            public CoordinateItem()
            {

            }
            public CoordinateItem(double value, int index)
            {
                Value = value;
                Index = index;
            }
            public override string ToString()
            {
                return "value: " + Value.ToString() + " index: " + Index.ToString();
            }
        }
        private class Coordinates
        {

            public ICoordinateItem _first;
            public Coordinates()
            {
                _first = null;
            }
            public void Add(ICoordinateItem item)
            {
                ICoordinateItem temp = _first;
                _first = item;
                item.NextItem = temp;
            }
            public ICoordinateItem GetFirst()
            {
                return _first;
            }
            public void SetFirst(ICoordinateItem item)
            {
                _first = item;
            }
        }
        private Coordinates _coordinates;

        public int Dimension { get; set; }

        public SparseVector()
        {
            _coordinates = new Coordinates();
            Dimension = 0;
        }
        public SparseVector(double[] coordinates)
        {
            _coordinates = new Coordinates();
            for (int i = 0; i < coordinates.Length; i++)
            {
                if (coordinates[i] != 0)
                    _coordinates.Add(new CoordinateItem(coordinates[i], i));
            }
            Dimension = coordinates.Length;
        }
        public double GetValueByIndex(int index)
        {
            ICoordinateItem current = _coordinates.GetFirst();
            while (current.Index != index)
            {
                current = current.NextItem;
            }
            return current.Value;
        }
        public void PrintElement()
        {
            while (_coordinates.GetFirst() != null)
            {
                Console.WriteLine(_coordinates.GetFirst());
                CoordinateItem temp = new CoordinateItem();
                temp.NextItem = _coordinates.GetFirst().NextItem;
                _coordinates.SetFirst(temp.NextItem);
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
