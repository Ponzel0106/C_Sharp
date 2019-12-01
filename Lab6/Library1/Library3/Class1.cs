using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library1;

namespace Library3
{
    public class KI3_Class_3 : KI3_Class_1
    {
        public double F3 (double x, double y)
        {
            return 6 * F1(x,y) - 3*Library2.KI3_Class_2.F2(x, y);
        }
    }
}
