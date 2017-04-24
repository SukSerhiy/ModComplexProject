using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModComplexProject.Models
{
    public class Table
    {
        public IEnumerable<string> headers { get; set; }
        public IEnumerable<IEnumerable<string>> data { get; set; }
    }
}