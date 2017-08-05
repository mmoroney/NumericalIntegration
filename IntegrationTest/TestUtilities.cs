using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTest
{
    public static class TestUtilities
    {
        public static void TestFunctions(double p1, double tolerance, params Func<double, double>[] functions)
        {
            double[] results = new double[functions.Length];

            for (int i = 0; i < results.Length; i++)
            {
                results[i] = functions[i](p1);
                Assert.IsTrue(TestUtilities.AreClose(results[0], results[i], tolerance));
            }
        }

        private static bool AreClose(double expected, double actual, double tolerance)
        {
            return Math.Abs(actual - expected) < tolerance;
        }
    }
}
