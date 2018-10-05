using System;
using System.Linq;
using NASA.Framework.BusinessLogic;
using NASA.MarsRover.Model;
using NASA.MarsRover.Model.Directions;

namespace NASA.MarsRover.BusinessLogic {
    public class PlateauOperations : OperationBase {

        ValidationOperations validationOperations = new ValidationOperations();

        public Plateau CreatePlateau(Coordinate upperRightCorner) {
            if (!validationOperations.IsValidUpperRightCornerLocation(upperRightCorner)) {
                BusinessLogicException businessLogicException = new BusinessLogicException($"Upper right corner coordinate is invalid: {upperRightCorner}");
                throw businessLogicException;
            }
            return new Plateau(upperRightCorner);
        }

        public Plateau AddNewRover(Plateau plateau, Coordinate startCoordinate, Direction startDirection) {
            if (!validationOperations.IsMoveAllow(plateau, startCoordinate)) {
                BusinessLogicException businessLogicException = new BusinessLogicException($"Location is not idle. StartCoordinate: {startCoordinate}");
                throw businessLogicException;
            }
            Rover rover = new Rover(plateau, startCoordinate, startDirection);
            plateau.Rovers.Add(rover);
            plateau.SelectedRover = rover;
            return plateau;
        }
    }
}
