using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalIntegration
{
    public class Square : Area
    {
        public double Size { get; private set; }
        public Square(double size)
        {
            this.Size = size;
        }

        public override double IntegrateAreaCartesian(Func<double, double, double> f, int steps)
        {
            return Integration.Integrate(f, new Integral1(() => 0, () => this.Size, steps),
                new Integral2(x => 0, x => this.Size, steps));
        }

        public override double IntegrateAreaPolar(Func<double, double, double> f, int steps)
        {
            return IntegrateAreaCartesian((x, y) => f(Math.Sqrt(x * x + y * y), x == 0 ? Math.PI / 2 : Math.Atan(y / x)), steps);
        }
    }
}
