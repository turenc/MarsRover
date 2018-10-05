using Microsoft.VisualStudio.TestTools.UnitTesting;
using NASA.MarsRover.Model;

namespace NASA.MarsRover.UnitTest {

    [TestClass]
    public class PlateauTest {

        [TestMethod]
        [DataRow(5, 6)]
        [DataRow(1, 6)]
        //[DataRow(-1, 6)]
        //[DataRow(5, -2)]
        //[DataRow(0, 0)]
        //[DataRow(0, 1)]
        //[DataRow(1, 0)]
        public void CreatePlateau(int upperRightCornerX, int upperRightCornerY) {
            Coordinate coordinate = new Coordinate(upperRightCornerX, upperRightCornerY);
            Plateau plateau = new Plateau(coordinate);

            Assert.AreEqual(plateau.MaxX, upperRightCornerX);
            Assert.AreEqual(plateau.MaxY, upperRightCornerY);
            Assert.AreEqual(plateau.MinX, 0);
            Assert.AreEqual(plateau.MinX, 0);

        }
    }
}
