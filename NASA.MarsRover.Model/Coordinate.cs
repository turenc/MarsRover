using System;

namespace NASA.MarsRover.Model {
    public class Coordinate {

        public Coordinate(int x, int y) {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public static implicit operator string(Coordinate coordinate) {
            return $"({coordinate.X},{coordinate.Y})";
        }
    }
}
