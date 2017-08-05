using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumericalIntegration;

namespace IntegrationTest
{
    [TestClass]
    public class TestIntegration
    {
        private static int Steps = 1000;
        private static double UpperBound = 10;
        private static double Tolerance = 1e-4;

        [TestMethod]
        public void TestIntegration1()
        {
            Func<double, double>[] functions = new Func<double, double>[]
            {
                n => n,
                n => Integration.Integrate(x => 1, new Integral1(() => 0, () => n, TestIntegration.Steps))
            };

            TestUtilities.TestFunctions(TestIntegration.UpperBound, TestIntegration.Tolerance, functions);
        }

        [TestMethod]
        public void TestIntegration2()
        {
            Func<double, double>[] functions = new Func<double, double>[]
            {
                n => n * n / 2,
                n => Integration.Integrate(x => x, new Integral1(() => 0, () => n, TestIntegration.Steps)),
                n => Integration.Integrate((x, y) => 1, new Integral1(() => 0, () => n, TestIntegration.Steps), new Integral2(x => 0, x => x, TestIntegration.Steps))
            };

            TestUtilities.TestFunctions(TestIntegration.UpperBound, TestIntegration.Tolerance, functions);
        }

        [TestMethod]
        public void TestIntegration3()
        {
            Func<double, double>[] functions = new Func<double, double>[]
            {
                n => n * n * n / 6,
                n => Integration.Integrate(x => x * x / 2, new Integral1(() => 0, () => n, TestIntegration.Steps)),
                n => Integration.Integrate((x, y) => y, new Integral1(() => 0, () => n, TestIntegration.Steps), new Integral2(x => 0, x => x, TestIntegration.Steps)),
                n => Integration.Integrate((x, y, z) => 1, new Integral1(() => 0, () => n, TestIntegration.Steps), new Integral2(x => 0, x => x, TestIntegration.Steps), new Integral3((x, y) => 0, (x, y) => y, TestIntegration.Steps))
            };

            TestUtilities.TestFunctions(TestIntegration.UpperBound, TestIntegration.Tolerance, functions);
        }
    }
}
