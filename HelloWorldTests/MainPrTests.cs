using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace HelloWorldTests
{
    [TestClass]
    public class MainPrTests
    {
        [TestMethod]
        public void MainMethodTest()
        {
            // Arrange: Beállítások és a várt eredmény megadása
            string vartEredm = "Hello World!";

            // Act: Tesztelt metódus meghívása
            StringWriter sw = new StringWriter();
            Console.SetOut(sw); // Console átirányítása az sw változóba
            HelloWorld.Program.Main();
            string kapottEredm = sw.ToString().Trim();

            // Assert: Eredmény kiértékelése
            Assert.AreEqual(vartEredm, kapottEredm);
        }
    }
}
