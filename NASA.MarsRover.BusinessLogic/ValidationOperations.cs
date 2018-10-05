using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NASA.Framework.BusinessLogic;
using NASA.MarsRover.Model;

namespace NASA.MarsRover.BusinessLogic {
    public class ValidationOperations :OperationBase {
        
        public bool IsMoveAllow(Plateau plateau, Coordinate coordinate) {
            bool result = IsValidLocation(plateau, coordinate) & IsIdleLocation(plateau, coordinate);
            return result;
        }

        public bool IsValidUpperRightCornerLocation(Coordinate coordinate) {
            if (coordinate == null) {
                NullReferenceException nullReferenceException = new NullReferenceException("IsValidUpperRightCornerLocation parameters: coordinate is null");
                throw nullReferenceException;
            }
            if (coordinate.X > 0 &&
                coordinate.Y > 0 ) {
                return true;
            }
            BusinessLogicException businessLogicException = new BusinessLogicException($"Coordinate is not valid. ({coordinate.X}, {coordinate.Y})");
            throw businessLogicException;
        }

        public bool IsValidLocation(Plateau plateau, Coordinate coordinate) {
            if (plateau == null || coordinate == null) {
                NullReferenceException nullReferenceException = new NullReferenceException("isValidLocationOfPlateau parameters: plateau or coordinate is null");
                throw nullReferenceException;
            }
            if (coordinate.X >= plateau.MinX &&
                coordinate.X <= plateau.MaxX &&
                coordinate.Y >= plateau.MinX &&
                coordinate.Y <= plateau.MaxY) {
                return true;
            }
            BusinessLogicException businessLogicException = new BusinessLogicException($"Coordinate is not found on the plateau.({coordinate.X}, {coordinate.Y})");
            throw businessLogicException;
        }

        public bool IsIdleLocation(Plateau plateau, Coordinate coordinate) {
            if (plateau != null && plateau.Rovers != null && coordinate != null) {
                Rover otherRover = plateau.Rovers.Where(r => r.CurrentCoordinate.X == coordinate.X && r.CurrentCoordinate.Y == coordinate.Y).FirstOrDefault();
                if (otherRover != null) {
                    BusinessLogicException businessLogicException = new BusinessLogicException($"There is other rover ({otherRover.RoverCode}) on this coordinate ({coordinate.X}, {coordinate.Y}).");
                    throw businessLogicException;
                }
                return true;
            }
            NullReferenceException nullReferenceException = new NullReferenceException("isThereAnyRover parameters: plateau, plateau.Rovers or coordinate is null");
            throw nullReferenceException;
        }
    }
}
