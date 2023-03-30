using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sikidomok;
using System;

namespace SikidomokTests
{
    [TestClass]
    public class NegyzetTests
    {
        [TestMethod]
        public void NegyzetOsztalyTest()
        {
            // Arrange - Elõkészítés
            int oldal = 10;
            Negyzet negyzet = new Negyzet(oldal);
            int vartEredm = 40;

            // Act - Végrehajtás
            int kapottEredm = negyzet.getKerulet();

            // Assert - Ellenõrzés
            Assert.AreEqual(vartEredm, kapottEredm);
        }

        [TestMethod]
        public void KonstruktorTest()
        {
            // Arrange - Elõkészítés
            double oldal = 10.5;
            Negyzet negyzet = new Negyzet(oldal);
        }

        [TestMethod]
        public void TeruletTest()
        {
            // Arrange
            int oldal = 10;
            int vartEredm = 100;
            Negyzet negyzet = new Negyzet(oldal);

            // Act
            int kapottEredm = negyzet.getTerulet();

            // Assert
            Assert.AreEqual(vartEredm, kapottEredm);
        }

        [TestMethod]
        public void TeruletTest2()
        {
            // Arrange
            int oldal = 23;
            int vartEredm = 100;
            Negyzet negyzet = new Negyzet(oldal);

            // Act
            int kapottEredm = negyzet.getTerulet();

            // Assert
            Assert.AreNotEqual(vartEredm, kapottEredm);
        }

        [TestMethod]
        public void TeruletDoubleTest()
        {
            // Arrange
            double oldal = 23;
            double vartEredm = 529;
            Negyzet negyzet = new Negyzet(oldal);

            // Act
            double kapottEredm = negyzet.getTeruletDouble();

            // Assert
            Assert.AreEqual(vartEredm, kapottEredm);
        }

        [TestMethod]
        public void AtloTest()
        {
            // Arrange
            int oldal = 23;
            double vartEredm = 32.53;
            Negyzet negyzet = new Negyzet(oldal);

            // Act
            double kapottEredm = negyzet.getAtlo();

            // Assert
            Assert.AreEqual(vartEredm, kapottEredm);
        }
    }
}
