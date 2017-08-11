using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumericalIntegration;

namespace IntegrationTest
{
    [TestClass]
    public class TestSphere
    {
        [TestMethod]
        public void TestSphereIntegrateSurface()
        {
            int steps = 1000;
            double tolerance = 1e-4;

            Func<double, double>[] functions = new Func<double, double>[]
            {
                R => Math.PI * R * R * 4,
                R => new Sphere(R).IntegrateSurfaceSpherical((r, theta, phi) => 1, steps),
                R => new Sphere(R).IntegrateSurfaceCartesian((x, y, z) => 1, steps)
            };

            TestUtilities.TestFunctions(1, tolerance, functions);
        }
    }
}
