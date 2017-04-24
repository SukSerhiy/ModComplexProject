using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModComplexProject.Models
{
    public class Table
    {
        public IList<string> headers { get; set; }
        public IEnumerable<IList<string>> data { get; set; }
        public int[] skipIndexes { get; set; }

        public Table()
        {
            skipIndexes = new int[]{ 0 };
        }
    }
}