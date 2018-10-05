using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NASA.MarsRover.BusinessLogic;
using NASA.MarsRover.Model;
using NASA.MarsRover.Model.Directions;

namespace NASA.MarsRover.UnitTest {

    [TestClass]
    public class PlateauTest {
        
        PlateauOperations plateauOperations = new PlateauOperations();

        public PlateauTest() {
        }

        [TestMethod]
        [DataRow(5, 6)]
        [DataRow(1, 6)]
        [DataRow(514, 623)]
        [DataRow(25624, 43566)]
        public void CreatePlateauSuccessTest(int upperRightCornerX, int upperRightCornerY) {
            Coordinate upperRightCorner = new Coordinate(upperRightCornerX, upperRightCornerY);
            Plateau plateau = plateauOperations.CreatePlateau(upperRightCorner);
            Assert.IsNotNull(plateau);
            Assert.AreEqual(plateau.MinX, 0);
            Assert.AreEqual(plateau.MinY, 0);
            Assert.AreEqual(plateau.MaxX, upperRightCornerX);
            Assert.AreEqual(plateau.MaxY, upperRightCornerY);
            Assert.IsNotNull(plateau.Rovers);
            Assert.IsNotNull(plateau.PlateauCode);
            Assert.IsNull(plateau.SelectedRover);
        }

        [TestMethod]
        [DataRow(-1, 6)]
        [DataRow(5, -2)]
        [DataRow(0, 0)]
        [DataRow(0, 1)]
        [DataRow(1, 0)]
        public void CreatePlateauFailTest(int upperRightCornerX, int upperRightCornerY) {
            Coordinate upperRightCorner = new Coordinate(upperRightCornerX, upperRightCornerY);
            bool isFail = false;
            try {
                Plateau plateau = plateauOperations.CreatePlateau(upperRightCorner);
            }
            catch { isFail = true; }
            Assert.IsTrue(isFail);
        }
        
        [TestMethod]
        [DataRow(1, 2, 'E')]
        [DataRow(3, 2, 'W')]
        [DataRow(2, 2, 'N')]
        [DataRow(4, 2, 'S')]
        public void AddNewRoverSuccessTest(int roverX, int roverY, char roverD) {
            Plateau plateau = new Plateau(new Coordinate(50, 50));
            Assert.IsNotNull(plateau);
            Assert.IsNotNull(plateau.Rovers);
            Coordinate coordinate = new Coordinate(roverX, roverY);
            Direction direction = DirectionCreator.Create(roverD);
            plateau = plateauOperations.AddNewRover(plateau, coordinate, direction);
            Assert.IsNotNull(plateau);
            Assert.IsNotNull(plateau.SelectedRover);
            Assert.IsNotNull(plateau.SelectedRover.CurrentCoordinate);
            Assert.IsTrue(plateau.SelectedRover.CurrentCoordinate.X >= plateau.MinX && plateau.SelectedRover.CurrentCoordinate.X <= plateau.MaxX);
            Assert.IsTrue(plateau.SelectedRover.CurrentCoordinate.Y >= plateau.MinY && plateau.SelectedRover.CurrentCoordinate.Y <= plateau.MaxY);
            Assert.AreSame(plateau.SelectedRover.CurrentCoordinate, coordinate);
        }

        [TestMethod]
        [DataRow(1, 2, 'X')]
        [DataRow(3, 2, ' ')]
        [DataRow(2, -2, 'N')]
        [DataRow(100, 2, 'S')]
        public void AddNewRoverFailTest(int roverX, int roverY, char roverD) {
            Plateau plateau = new Plateau(new Coordinate(50, 50));
            Assert.IsNotNull(plateau);
            Assert.IsNotNull(plateau.Rovers);
            Coordinate coordinate = new Coordinate(roverX, roverY);
            bool isFail = false;
            try {
                Direction direction = DirectionCreator.Create(roverD);
                plateau = plateauOperations.AddNewRover(plateau, coordinate, direction);
            }
            catch { isFail = true; }
            Assert.IsTrue(isFail);
        }
    }
}
