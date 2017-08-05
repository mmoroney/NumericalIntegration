using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalIntegration
{
    public class Integral2
    {
        public Func<double, double> Lower { get; private set; }
        public Func<double, double> Upper { get; private set; }
        public int Steps { get; private set; }

        public Integral2(Func<double, double> lower, Func<double, double> upper, int steps)
        {
            this.Lower = lower;
            this.Upper = upper;
            this.Steps = steps;
        }
    }
}
