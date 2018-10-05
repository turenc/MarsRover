using System;
using System.Collections.Generic;
using System.Text;
using NASA.Framework.Service;
using NASA.MarsRover.BusinessLogic;
using NASA.MarsRover.Model;

namespace NASA.MarsRover.Service {
    public class RoverService : ServiceBase{
        RoverOperations roverOperations = new RoverOperations();
        public ServiceResult<Plateau> SendCommandArrayToRover(Rover rover, string command) {
            ServiceResult<Plateau> result = new ServiceResult<Plateau>();
            try {
                if (rover == null) {
                    result.ErrorMessage = $"Rover not found.";
                    result.ResultStatus = ServiceResultStatus.NotValid;
                    logger.ErrorLog(new NullReferenceException(result.ErrorMessage), result.ErrorMessage);
                }
                else if (String.IsNullOrWhiteSpace(command)) {
                    result.ErrorMessage = $"Command is null or Empty";
                    result.ResultStatus = ServiceResultStatus.NotValid;
                    logger.ErrorLog(new NullReferenceException(result.ErrorMessage), result.ErrorMessage);
                }
                else {
                    Plateau plateau = roverOperations.ExecuteBatchCommand(rover, command);
                    result.Response = plateau;
                }
            }
            catch (Exception ex) {
                result.ResultStatus = ServiceResultStatus.Failed;
                result.ErrorMessage = $"SendCommandArrayToRover function error: Please check your input. Rover Code:{rover.RoverCode} Command:{command}";
                logger.ErrorLog(ex, result.ErrorMessage);
            }
            return result;
        }
    }
}
