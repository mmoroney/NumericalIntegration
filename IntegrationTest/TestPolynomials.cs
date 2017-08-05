using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumericalIntegration;

namespace IntegrationTest
{
    [TestClass]
    public class TestPolynomials
    {
        private static int Steps = 100;

        [TestMethod]
        public void TestPolynomial1()
        {
            Func<double, double>[] functions = new Func<double, double>[]
            {
                n => n,
                n => Integration.Integrate(x => 1, new Integral1(() => 0, () => n, TestPolynomials.Steps))
            };

            TestUtilities.TestFunctions(100, 1e-5, functions);
        }

        [TestMethod]
        public void TestPolynomial2()
        {
            Func<double, double>[] functions = new Func<double, double>[]
            {
                n => n * n / 2,
                n => Integration.Integrate(x => x, new Integral1(() => 0, () => n, TestPolynomials.Steps)),
                n => Integration.Integrate((x, y) => 1, new Integral1(() => 0, () => n, TestPolynomials.Steps), new Integral2(x => 0, x => x, TestPolynomials.Steps))
            };

            TestUtilities.TestFunctions(10, 1e-4, functions);
        }

        [TestMethod]
        public void TestPolynomial3()
        {
            Func<double, double>[] functions = new Func<double, double>[]
            {
                n => n * n * n / 6,
                n => Integration.Integrate(x => x * x / 2, new Integral1(() => 0, () => n, TestPolynomials.Steps)),
                n => Integration.Integrate((x, y) => y, new Integral1(() => 0, () => n, TestPolynomials.Steps), new Integral2(x => 0, x => x, TestPolynomials.Steps)),
                n => Integration.Integrate((x, y, z) => 1, new Integral1(() => 0, () => n, TestPolynomials.Steps), new Integral2(x => 0, x => x, TestPolynomials.Steps), new Integral3((x, y) => 0, (x, y) => y, TestPolynomials.Steps))
            };

            TestUtilities.TestFunctions(1, 1e-3, functions);
        }
    }
}
