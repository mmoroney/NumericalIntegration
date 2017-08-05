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
                TestUtilities.AssertAreClose(results[0], results[i], tolerance);
            }
        }

        public static void TestFunctions(double p1, double p2, double tolerance, params Func<double, double, double>[] functions)
        {
            double[] results = new double[functions.Length];

            for (int i = 0; i < results.Length; i++)
            {
                results[i] = functions[i](p1, p2);
                TestUtilities.AssertAreClose(results[0], results[i], tolerance);
            }
        }

        public static void TestFunctions(double p1, double p2, double p3, double tolerance, params Func<double, double, double, double>[] functions)
        {
            double[] results = new double[functions.Length];

            for (int i = 0; i < results.Length; i++)
            {
                results[i] = functions[i](p1, p2, p3);
                TestUtilities.AssertAreClose(results[0], results[i], tolerance);
            }
        }

        private static void AssertAreClose(double expected, double actual, double tolerance)
        {
            Assert.IsTrue(TestUtilities.AreClose(expected, actual, tolerance),
                string.Format("Expected: {0} Actual: {1} Tolerance: {2}", expected, actual, tolerance));
        }

        private static bool AreClose(double expected, double actual, double tolerance)
        {
            return Math.Abs(actual - expected) < tolerance;
        }
    }
}
