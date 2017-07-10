using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTest
{
    public static class TestUtilities
    {
        public static void TestFunctions<T, U>(T p1, params Func<T, U>[] functions)
        {
            U[] results = new U[functions.Length];

            for (int i = 0; i < results.Length; i++)
            {
                results[i] = functions[i](p1);
                Assert.AreEqual(results[0], results[i]);
            }
        }
    }
}
