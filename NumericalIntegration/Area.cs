using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalIntegration
{
    public abstract class Area
    {
        public abstract double IntegratePerimeterCartesian(Func<double, double, double> f, int steps);
        public abstract double IntegratePerimeterPolar(Func<double, double, double> f, int steps);
        public abstract double IntegrateAreaCartesian(Func<double, double, double> f, int steps);
        public abstract double IntegrateAreaPolar(Func<double, double, double> f, int steps);
    }
}
