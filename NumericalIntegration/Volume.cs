using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalIntegration
{
    public abstract class Volume
    {
        public abstract double IntegrateSurfaceCartesian(Func<double, double, double, double> f, int steps);
        public abstract double IntegrateSurfaceSpherical(Func<double, double, double, double> f, int steps);
    }
}
