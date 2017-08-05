using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalIntegration
{
    public static class Integration
    {
        public static double Integrate(Func<double, double> f, Integral1 integral1)
        {
            double lower = integral1.Lower();
            double upper = integral1.Upper();
            double width = (upper - lower) / integral1.Steps;

            double result = width * (f(lower) + f(upper)) / 2;

            for (int i = 1; i < integral1.Steps; i++)
                result += width * f(lower + (upper - lower) * i / integral1.Steps);

            return result;
        }

        public static double Integrate(Func<double, double, double> f, Integral1 integral1, Integral2 integral2)
        {
            return Integration.Integrate(x => Integration.Integrate(y => f(x, y),
                new Integral1(
                    () => integral2.Lower(x),
                    () => integral2.Upper(x),
                    integral2.Steps)),
                integral1);
        }

        public static double Integrate(Func<double, double, double, double> f, Integral1 integral1, Integral2 integral2, Integral3 integral3)
        {
            return Integration.Integrate(
                (x, y) => Integration.Integrate(z => f(x, y, z),
                new Integral1(
                    () => integral3.Lower(x, y),
                    () => integral3.Upper(x, y),
                    integral3.Steps)),
                integral1, integral2);
        }
    }
}
