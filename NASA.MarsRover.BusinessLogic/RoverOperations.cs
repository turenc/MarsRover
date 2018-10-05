using System;
using System.Collections.Generic;
using System.Text;
using NASA.Framework.BusinessLogic;
using NASA.MarsRover.Model;

namespace NASA.MarsRover.BusinessLogic {
    public class RoverOperations : OperationBase {
        ValidationOperations validationOperations = new ValidationOperations();

        void TurnLeft(Rover rover) {
            rover.Direction = rover.Direction.Left;
        }

        void TurnRight(Rover rover) {
            rover.Direction = rover.Direction.Right;
        }

        void Move(Rover rover) {
            Coordinate coordinate = rover.NextCoordinate;
            if(validationOperations.IsMoveAllow(rover.LocatedPlateau, coordinate))
            {
                rover.CurrentCoordinate = coordinate;
            }
        }

        void ExecuteCommand(Rover rover, char command) {
            switch (command.ToString().ToUpper()[0]) {
                case 'L':
                    TurnLeft(rover);
                    return;
                case 'R':
                    TurnRight(rover);
                    return;
                case 'M':
                    Move(rover);
                    return;
                default:
                    throw new BusinessLogicException("Invalid command character. Command character can be only R (Right), L(Left) or M(Move) in string command array.");
            }
        }

        public Plateau ExecuteBatchCommand(Rover rover, string commandList) {
            foreach (char command in commandList) {
                ExecuteCommand(rover, command);
            }
            return rover.LocatedPlateau;
        }
    }
}
