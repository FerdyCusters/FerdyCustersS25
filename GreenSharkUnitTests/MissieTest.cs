namespace GreenSharkUnitTests
{
    using System;
    using LivePerformanceFerdyCusters;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// TestClass voor de klasse missie
    /// </summary>
    [TestClass]
    public class MissieTest
    {
        /// <summary>
        /// Test data
        /// </summary>
        Missie missie;

        /// <summary>
        /// Initialiseren.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            missie = new Missie(9001, "MissieTest", "(12,15)", "Test", false, "Hope");
        }

        /// <summary>
        /// Testmethode voor ToString() van Missie.
        /// </summary>
        [TestMethod]
        public void TestMissieToString()
        {
            Assert.IsTrue(missie.ToString() == missie.Naam + " " + missie.Locatie + " " + missie.Type);
        }
    }
}
