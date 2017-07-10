using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumericalIntegration;

namespace IntegrationTest
{
    [TestClass]
    public class TestIntegration
    {
        [TestMethod]
        public void TestIntegration1()
        {
            for(int i = 0; i < 10; i++)
            {
                Func<double, double>[] functions = new Func<double, double>[]
                {
                    n => n,
                    n => Integration.Integrate(x => 1, new Integral1(() => 0, () => n, 1))
                };

                TestUtilities.TestFunctions(i, functions);
            }
        }

        [TestMethod]
        public void TestIntegration2()
        {
            for (int i = 0; i < 10; i++)
            {
                Func<double, double>[] functions = new Func<double, double>[]
                {
                    n => n * (n + 1) / 2,
                    n => Integration.Integrate(x => x + 1, new Integral1(() => 0, () => n, 1)),
                    n => Integration.Integrate((x, y) => 1, new Integral1(() => 0, () => n, 1), new Integral2(x => 0, x => x + 1, 1))
                };

                TestUtilities.TestFunctions(i, functions);
            }
        }

        [TestMethod]
        public void TestIntegration3()
        {
            for (int i = 0; i < 10; i++)
            {
                Func<double, double>[] functions = new Func<double, double>[]
                {
                    n => n * (n + 1) * (n + 2) / 6,
                    n => Integration.Integrate(x => (x + 1) * (x + 2) / 2, new Integral1(() => 0, () => n, 1)),
                    n => Integration.Integrate((x, y) => y + 1, new Integral1(() => 0, () => n, 1), new Integral2(x => 0, x => x + 1, 1)),
                    n => Integration.Integrate((x, y, z) => 1, new Integral1(() => 0, () => n, 1), new Integral2(x => 0, x => x + 1, 1), new Integral3((x, y) => 0, (x, y) => y + 1, 1))
                };

                TestUtilities.TestFunctions(i, functions);
            }
        }
    }
}
