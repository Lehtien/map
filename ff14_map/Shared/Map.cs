using System;
using System.Collections.Generic;
using System.Text;

namespace ff14_map.Shared
{
    public class Map
    {
        public string FileName { get; set; }
        public string Area { get; set; }
        public string Point { set; get; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }

    public class WholeMap
    {
        public string FileName { get; set; }
        public string Area { get; set; }
    }

    public class Maps
    {
        public Map Map { get; set; } = new Map();
        public WholeMap WholeMap { get; set; } = new WholeMap();
    }
}
