using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalIntegration
{
    public class Integral1
    {
        public Func<double> Lower { get; private set; }
        public Func<double> Upper { get; private set; }
        public int Steps { get; private set; }

        public Integral1(Func<double> lower, Func<double> upper, int steps)
        {
            this.Lower = lower;
            this.Upper = upper;
            this.Steps = steps;
        }
    }
}
