﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public interface ICoordinateItem
    {
        int Index { get; set; }
        double Value { get; set; }
        ICoordinateItem NextItem { get; set; }
    }
}
