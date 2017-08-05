using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumericalIntegration;

namespace IntegrationTest
{
    [TestClass]
    public class TestCoordinateSystems
    {
        [TestMethod]
        public void TestPolar()
        {
            int steps = 100;
            int radii = 5;
            int angles = 6;

            for (int i = 0; i <= radii; i++)
            {
                for(int j = 0; j <= angles; j++)
                {
                    Func<double, double, double>[] functions = new Func<double, double, double>[]
                    {
                        (rMax, thetaMax) => rMax * rMax * thetaMax / 2.0,
                        (rMax, thetaMax) => Integration.Polar(
                            (r, theta) => 1,
                            new Integral1(() => 0, () => rMax, steps),
                            new Integral2(r => 0, r => thetaMax, steps))
                    };

                    TestUtilities.TestFunctions(1.0 * i / radii, 2.0 * Math.PI * j / angles, 1e-4, functions);
                }
            }
        }

        [TestMethod]
        public void TestCylindrical()
        {
            int steps = 100;
            int radii = 5;
            int angles = 6;
            int heights = 5;

            for (int i = 0; i < radii; i++)
            {
                for (int j = 0; j <= angles; j++)
                {
                    for (int k = 0; k <= heights; k++)
                    {
                        Func<double, double, double, double>[] functions = new Func<double, double, double, double>[]
                        {
                            (rMax, thetaMax, zMax) => rMax * rMax * thetaMax / 2.0 * zMax,
                            (rMax, thetaMax, zMax) => Integration.Cylindrical(
                            (r, theta, z) => 1,
                            new Integral1(() => 0, () => rMax, steps),
                            new Integral2(r => 0, r => thetaMax, steps),
                            new Integral3((r, theta) => 0, (r, theta) => zMax, steps))
                        };

                        TestUtilities.TestFunctions(1.0 * i / radii, 2.0 * Math.PI * j / angles, 1.0 * k / heights, 1e-3, functions);
                    }
                }
            }
        }

        [TestMethod]
        public void TestSpherical()
        {
            int steps = 100;
            int radii = 5;

            for (int i = 0; i <= radii; i++)
            {
                Func<double, double>[] functions = new Func<double, double>[]
                {
                    rMax => 4 * Math.PI / 3 * rMax * rMax * rMax,
                    rMax => Integration.Spherical(
                    (r, theta, z) => 1,
                    new Integral1(() => 0, () => rMax, steps),
                    new Integral2(r => 0, r => Math.PI, steps),
                    new Integral3((r, theta) => 0, (r, theta) => 2.0 * Math.PI, steps))
                };

                TestUtilities.TestFunctions(1.0 * i / radii, 1e-2, functions);
            }

        }
    }
}
