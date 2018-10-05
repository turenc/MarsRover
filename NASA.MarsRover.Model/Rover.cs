using System;
using System.Collections.Generic;
using System.Text;
using NASA.MarsRover.Model.Directions;

namespace NASA.MarsRover.Model {
    public class Rover {

        public Rover(Plateau plateau, Coordinate firstCoordinate, Direction firstDirection) {
            RoverCode = Guid.NewGuid();
            LocatedPlateau = plateau;
            CurrentCoordinate = firstCoordinate;
            Direction = firstDirection;
        }

        public Guid RoverCode { get; }

        public Direction Direction { get; set; }

        public Plateau LocatedPlateau { get; set; }

        public Coordinate CurrentCoordinate { get; set; }

        public Coordinate NextCoordinate
        {
            get
            {
                switch (Direction) {
                    case 'N':
                        return new Coordinate(CurrentCoordinate.X, CurrentCoordinate.Y + 1);
                    case 'S':
                        return new Coordinate(CurrentCoordinate.X, CurrentCoordinate.Y - 1);
                    case 'E':
                        return new Coordinate(CurrentCoordinate.X + 1, CurrentCoordinate.Y);
                    case 'W':
                        return new Coordinate(CurrentCoordinate.X - 1, CurrentCoordinate.Y);
                    default:
                        return CurrentCoordinate;
                }
            }
        }
    }
}
