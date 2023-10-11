using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class CoordinateItem : ICoordinateItem
    {
        public double Value { get; set; }
        public int Index { get; set; }
        public CoordinateItem()
        {

        }
        public CoordinateItem(double value, int index)
        {
            Value = value;
            Index = index;            
        }
        public CoordinateItem(ICoordinateItem other)
        {
            Value = other.Value;
            Index = other.Index;
        }
        public override string ToString()
        {
            return "value: " + Value.ToString() + " index: " + Index.ToString();
        }
    }
}
