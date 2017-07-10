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
            double result = 0;

            double lower = integral1.Lower();
            double upper = integral1.Upper();

            for(double x = lower; x < upper; x += integral1.Delta)
                result += f(x) * integral1.Delta;

            return result;
        }

        public static double Integrate(Func<double, double, double> f, Integral1 integral1, Integral2 integral2)
        {
            return Integration.Integrate(x => Integration.Integrate(y => f(x, y),
                new Integral1(
                    () => integral2.Lower(x),
                    () => integral2.Upper(x),
                    integral2.Delta)),
                integral1);
        }

        public static double Integrate(Func<double, double, double, double> f, Integral1 integral1, Integral2 integral2, Integral3 integral3)
        {
            return Integration.Integrate(
                (x, y) => Integration.Integrate(z => f(x, y, z),
                new Integral1(
                    () => integral3.Lower(x, y),
                    () => integral3.Upper(x, y),
                    integral3.Delta)),
                integral1, integral2);
        }
    }
}
