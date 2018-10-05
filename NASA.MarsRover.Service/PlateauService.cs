using System;
using NASA.Framework.Service;
using NASA.MarsRover.BusinessLogic;
using NASA.MarsRover.Model;
using NASA.MarsRover.Model.Directions;

namespace NASA.MarsRover.Service {
    public class PlateauService : ServiceBase {

        PlateauOperations plateauOperations = new PlateauOperations();
        public ServiceResult<Plateau> CreatePlateau(int upperRightCornerX, int upperRightCornerY) {
            ServiceResult<Plateau> result = new ServiceResult<Plateau>();
            try {
                Coordinate upperRightCorner = new Coordinate(upperRightCornerX, upperRightCornerY);
                Plateau plateau = plateauOperations.CreatePlateau(upperRightCorner);
                result.Response = plateau;
            }
            catch(Exception ex) {
                result.ResultStatus = ServiceResultStatus.Failed;
                result.ErrorMessage = $"Plateau not created. x:{upperRightCornerX}, y:{upperRightCornerY}";
                logger.ErrorLog(ex, result.ErrorMessage);
            }
            return result;
        }

        public ServiceResult<Plateau> AddNewRover(Plateau plateau, int roverX, int roverY, char direction) {
            ServiceResult<Plateau> result = new ServiceResult<Plateau>();
            try {
                Coordinate startCoordinate = new Coordinate(roverX, roverY);
                Direction startDirection = DirectionCreator.Create(direction);
                if (startDirection == null) {
                    result.ErrorMessage = $"Start direction parameter is invalid. Param value:{direction}";
                    result.ResultStatus = ServiceResultStatus.NotValid;
                    logger.ErrorLog(new ServiceException(result.ErrorMessage), result.ErrorMessage);
                }
                else {
                    plateau = plateauOperations.AddNewRover(plateau, startCoordinate, startDirection);
                    result.Response = plateau;
                }
            }
            catch (Exception ex) {
                result.ResultStatus = ServiceResultStatus.Failed;
                result.ErrorMessage = $"AddNewRover function error: Please check your input. x:{roverX}, y:{roverY}, d:{direction}";
                logger.ErrorLog(ex, result.ErrorMessage);
            }
            return result;
        }
    }
}
