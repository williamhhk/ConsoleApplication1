using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareDate
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime adDate = new DateTime(1601, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            DateTime utcDate = DateTime.FromFileTimeUtc(0);
            bool equal = adDate == utcDate;
        }
    }
}
