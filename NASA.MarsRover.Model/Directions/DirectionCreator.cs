using System;
using System.Collections.Generic;
using System.Text;

namespace NASA.MarsRover.Model.Directions {

    public static class DirectionCreator {
        public static Direction Create(char direction) {
            switch (direction.ToString().ToUpper()[0]) {
                case 'N':
                    return new North();
                case 'S':
                    return new South();
                case 'E':
                    return new East();
                case 'W':
                    return new West();
                default:
                    return null;
            }
        }
    }
}
