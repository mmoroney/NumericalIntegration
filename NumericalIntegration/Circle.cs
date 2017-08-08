using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalIntegration
{
    public sealed class Circle : Area
    {
        public double Radius { get; private set; }
        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public override double IntegrateAreaCartesian(Func<double, double, double> f, int steps)
        {
            return this.IntegrateAreaPolar((r, theta) => f(r * Math.Cos(theta), r * Math.Sin(theta)), steps);
        }

        public override double IntegrateAreaPolar(Func<double, double, double> f, int steps)
        {
            return Integration.Integrate((r, theta) => r * f(r, theta), new Integral1(() => 0, () => this.Radius, steps),
                new Integral2(r => 0, r => Math.PI * 2, steps));
        }
    }
}
