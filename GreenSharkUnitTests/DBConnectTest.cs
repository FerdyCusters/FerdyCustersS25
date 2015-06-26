namespace GreenSharkUnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using LivePerformanceFerdyCusters;

    /// <summary>
    /// Test klasse voor DBConnect.
    /// </summary>
    [TestClass]
    public class DBConnectTest
    {
        /// <summary>
        /// Testen voor connectie.
        /// </summary>
        [TestMethod]
        public void TestConnectionTest()
        {
            DBConnect.InitializeConnection();
            Assert.IsTrue(DBConnect.TestConnection() == true);
        }
    }
}
