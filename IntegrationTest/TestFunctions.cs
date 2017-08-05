using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumericalIntegration;

namespace IntegrationTest
{
    [TestClass]
    public class TestFunctions
    {
        private static int Count = 50;
        private static int StepFactor = 10;
        private static double Tolerance = 1e-4;

        [TestMethod]
        public void TestSin()
        {
            for (int i = 0; i <= TestFunctions.Count; i++)
            {
                Func<double, double>[] functions = new Func<double, double>[]
                {
                    x => 1.0 - Math.Cos(x),
                    x => Integration.Integrate(y => Math.Sin(y), new Integral1(() => 0, () => x, i * TestFunctions.StepFactor))
                };

                TestUtilities.TestFunctions(Math.PI * 2 * i / TestFunctions.Count, TestFunctions.Tolerance, functions);
            }
        }

        [TestMethod]
        public void TestCos()
        {
            for (int i = 0; i <= TestFunctions.Count; i++)
            {
                Func<double, double>[] functions = new Func<double, double>[]
                {
                    x => Math.Sin(x),
                    x => Integration.Integrate(y => Math.Cos(y), new Integral1(() => 0, () => x, i * TestFunctions.StepFactor))
                };

                TestUtilities.TestFunctions(Math.PI * 2 * i / TestFunctions.Count, TestFunctions.Tolerance, functions);
            }
        }

        [TestMethod]
        public void TestExponential()
        {
            for (int i = 0; i <= TestFunctions.Count; i++)
            {
                Func<double, double>[] functions = new Func<double, double>[]
                {
                    x => Math.Exp(x) - 1.0,
                    x => Integration.Integrate(y => Math.Exp(y), new Integral1(() => 0, () => x, i * TestFunctions.StepFactor))
                };

                TestUtilities.TestFunctions(Math.Exp(1) * i / TestFunctions.Count, TestFunctions.Tolerance, functions);
            }
        }

        [TestMethod]
        public void TestLogarithm()
        {
            for (int i = 0; i <= TestFunctions.Count; i++)
            {
                Func<double, double>[] functions = new Func<double, double>[]
                {
                    x => Math.Log(x),
                    x => Integration.Integrate(y => 1.0 / y, new Integral1(() => 1, () => x, i * TestFunctions.StepFactor))
                };

                TestUtilities.TestFunctions(1.0 + Math.Exp(2) * i / TestFunctions.Count, TestFunctions.Tolerance, functions);
            }
        }
    }
}
