namespace GreenSharkUnitTests
{
    using System;
    using LivePerformanceFerdyCusters;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Testclass voor Boot
    /// </summary>
    [TestClass]
    public class BootTest
    {
        /// <summary>
        /// Test Data
        /// </summary>
        private Boot boot;

        /// <summary>
        /// Initialiseren.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            boot = new Boot(500, "Test", 60, 30, "(20,80)");
        }

        /// <summary>
        /// Testmethode van Boot.
        /// </summary>
        [TestMethod]
        public void TestCalculate()
        {
            int value = boot.Locatie.IndexOf(",");
            int x = Convert.ToInt32(boot.Locatie.Substring(1, value - 1));
            int y = Convert.ToInt32(boot.Locatie.Substring((value + 1), boot.Locatie.Length - (value + 2)));
            Assert.IsTrue(boot.calculate(x, y, x, y) != 10);
            Assert.IsFalse(boot.calculate(x, y, x, y) < 0);
        }
    }
}
