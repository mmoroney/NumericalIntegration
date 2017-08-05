using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalIntegration
{
    public class Integral3
    {
        public Func<double, double, double> Lower { get; private set; }
        public Func<double, double, double> Upper { get; private set; }
        public int Steps { get; private set; }

        public Integral3(Func<double, double, double> lower, Func<double, double, double> upper, int steps)
        {
            this.Lower = lower;
            this.Upper = upper;
            this.Steps = steps;
        }
    }
}
