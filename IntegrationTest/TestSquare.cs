using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumericalIntegration;

namespace IntegrationTest
{
    [TestClass]
    public class TestSquare
    {
        [TestMethod]
        public void TestSquareIntegratePerimeter()
        {
            int steps = 1000;
            double tolerance = 1e-5;

            Func<double, double>[] functions = new Func<double, double>[]
            {
                S => S * 4,
                S => new Square(S).IntegratePerimeterCartesian((x, y) => 1, steps),
                S => new Square(S).IntegratePerimeterPolar((r, theta) => 1, steps)
            };

            TestUtilities.TestFunctions(1, tolerance, functions);
        }

        [TestMethod]
        public void TestSquareIntegrateArea()
        {
            int steps = 1000;
            double tolerance = 1e-5;

            Func<double, double>[] functions = new Func<double, double>[]
            {
                S => S * S,
                S => new Square(S).IntegrateAreaCartesian((x, y) => 1, steps),
                S => new Square(S).IntegrateAreaPolar((r, theta) => 1, steps)
            };

            TestUtilities.TestFunctions(10, tolerance, functions);

            functions = new Func<double, double>[]
            {
                S => S * S * S * S / 4,
                S => new Square(S).IntegrateAreaCartesian((x, y) => x * y, steps),
                S => new Square(S).IntegrateAreaPolar((r, theta) => r * r * Math.Cos(theta) * Math.Sin(theta), steps)
            };

            TestUtilities.TestFunctions(1, tolerance, functions);
        }
    }
}
