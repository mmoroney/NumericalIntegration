using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalIntegration
{
    public sealed class Sphere : Volume
    {
        public double Radius { get; private set; }

        public Sphere(double radius)
        {
            this.Radius = radius;
        }

        public override double IntegrateSurfaceCartesian(Func<double, double, double, double> f, int steps)
        {
            return this.IntegrateSurfaceSpherical((r, theta, phi) => f(r * Math.Sin(theta) * Math.Cos(phi),
                r * Math.Sin(theta) * Math.Sin(phi),
                r * Math.Cos(theta)), steps);
        }

        public override double IntegrateSurfaceSpherical(Func<double, double, double, double> f, int steps)
        {
            return Integration.Integrate((theta, phi) => this.Radius * this.Radius * Math.Sin(phi) * f(this.Radius, theta, phi),
                new Integral1(() => 0, () => Math.PI * 2, steps),
                new Integral2(theta => 0, theta => Math.PI, steps));
        }
    }
}
