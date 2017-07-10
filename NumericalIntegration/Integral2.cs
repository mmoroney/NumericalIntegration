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
        public double Delta { get; private set; }

        public Integral2(Func<double, double> lower, Func<double, double> upper, double delta)
        {
            this.Lower = lower;
            this.Upper = upper;
            this.Delta = delta;
        }
    }
}
