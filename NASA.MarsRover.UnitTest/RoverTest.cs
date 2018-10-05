using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NASA.MarsRover.BusinessLogic;
using NASA.MarsRover.Model;
using NASA.MarsRover.Model.Directions;

namespace NASA.MarsRover.UnitTest {

    [TestClass]
    public class RoverTest {

        PlateauOperations plateauOperations = new PlateauOperations();
        RoverOperations roverOperations = new RoverOperations();

        [TestMethod]
        [DataRow(5, 5, 1, 2, 'N', "LMLMLMLMM", 1, 3, 'N')]
        [DataRow(5, 5, 3, 3, 'E', "MMRMMRMRRM", 5, 1, 'E')]
        public void ExecuteBatchCommandSuccessTest(int plateauUpperRightX, int plateauUpperRightY, int roverX, int roverY, char roverD, string command, int expectedRoverX, int expectedRoverY, int expectedRoverD) {
            Plateau plateau = new Plateau(new Coordinate(plateauUpperRightX, plateauUpperRightY));
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
            plateau = roverOperations.ExecuteBatchCommand(plateau.SelectedRover, command);
            Assert.AreEqual(plateau.SelectedRover.CurrentCoordinate.X, expectedRoverX);
            Assert.AreEqual(plateau.SelectedRover.CurrentCoordinate.Y, expectedRoverY);
            Assert.AreEqual(plateau.SelectedRover.Direction, expectedRoverD);
        }

        [TestMethod]
        [DataRow(-5, 5, 1, 2, 'N', "LMLMLMLMM", 1, 3, 'N')]
        [DataRow(0, 1, 3, 3, 'E', "MMRMMRMRRM", 5, 1, 'E')]
        [DataRow(1, 1, 1, 2, 'N', "LMLMLMLMM", 1, 3, 'N')]
        [DataRow(5, 5, 3, 3, 'A', "MMRMMRMRRM", 5, 1, 'E')]
        public void ExecuteBatchCommandFailTest(int plateauUpperRightX, int plateauUpperRightY, int roverX, int roverY, char roverD, string command, int expectedRoverX, int expectedRoverY, int expectedRoverD) {
            bool isFail = false;
            try {
                Plateau plateau = new Plateau(new Coordinate(plateauUpperRightX, plateauUpperRightY));
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
                plateau = roverOperations.ExecuteBatchCommand(plateau.SelectedRover, command);
                Assert.AreEqual(plateau.SelectedRover.CurrentCoordinate.X, expectedRoverX);
                Assert.AreEqual(plateau.SelectedRover.CurrentCoordinate.Y, expectedRoverY);
                Assert.AreEqual(plateau.SelectedRover.Direction, expectedRoverD);
            }
            catch { isFail = true; }
            Assert.IsTrue(isFail);
        }
    }
}
