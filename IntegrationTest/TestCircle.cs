using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumericalIntegration;

namespace IntegrationTest
{
    [TestClass]
    public class TestCircle
    {
        [TestMethod]
        public void TestCircleIntegratePerimeter()
        {
            int steps = 1000;
            double tolerance = 1e-5;

            Func<double, double>[] functions = new Func<double, double>[]
            {
                R => Math.PI * R * 2,
                R => new Circle(R).IntegratePerimeterPolar((r, theta) => 1, steps),
                R => new Circle(R).IntegratePerimeterPolar((x, y) => 1, steps)
            };

            TestUtilities.TestFunctions(1, tolerance, functions);
        }

        [TestMethod]
        public void TestCircleIntegrateArea()
        {
            int steps = 1000;
            double tolerance = 1e-5;

            Func<double, double>[] functions = new Func<double, double>[]
            {
                R => Math.PI * R * R,
                R => new Circle(R).IntegrateAreaPolar((x, y) => 1, steps),
                R => new Circle(R).IntegrateAreaCartesian((x, y) => 1, steps)
            };

            TestUtilities.TestFunctions(10, tolerance, functions);

            functions = new Func<double, double>[]
            {
                R => Math.PI * R * R * R * 2 / 3,
                R => new Circle(R).IntegrateAreaPolar((r, theta) => r, steps),
                R => new Circle(R).IntegrateAreaCartesian((x, y) => Math.Sqrt(x * x + y * y), steps)
            };

            TestUtilities.TestFunctions(1, tolerance, functions);
        }
    }
}
