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

        public override double IntegratePerimeterCartesian(Func<double, double, double> f, int steps)
        {
            Integral1 integral1 = new Integral1(() => 0, () => this.Size, steps);
            return Integration.Integrate(x => f(x, 0), integral1)
                + Integration.Integrate(y => f(this.Size, y), integral1)
                + Integration.Integrate(x => f(x, this.Size), integral1)
                + Integration.Integrate(y => f(0, y), integral1);
        }

        public override double IntegratePerimeterPolar(Func<double, double, double> f, int steps)
        {
            return IntegratePerimeterCartesian((x, y) => f(Math.Sqrt(x * x + y * y), x == 0 ? Math.PI / 2 : Math.Atan(y / x)), steps);
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
