using System;
using System.Collections.Generic;
using System.Text;
using NASA.Framework.Service;
using NASA.MarsRover.Model;

namespace NASA.MarsRover.ConsoleUI.Stages {
    public class RoverDefinitionStage : LoopStage {

        protected override void BeforeExecute() {
            Message.Info(@"
--- ROVER DEFINITION STAGE ---");
        }

        protected override void ExecuteLoop() {
            Message.Info("d (direction) char parameter value list: 'E'(East) 'W'(West) 'N'(North) 'S'(South)");
            Console.WriteLine("Please enter a rover coordinate and direction. >> Input format: x y d ");
            command = Console.ReadLine();

            bool valid = true;
            string[] paramList = command.Split(" ");
            if(paramList.Length != 3) {
                Message.Error("Parameter format is wrong. Input format must: x y d ");
                valid = false;
            }

            int roverX = 0;
            int roverY = 0;
            char direction = ' ';

            if (valid) {
                valid = int.TryParse(paramList[0], out roverX);
                if (!valid) {
                    Message.Error("X parameter must integer.");
                }
            }
            if (valid) {
                valid = int.TryParse(paramList[1], out roverY);
                if (!valid) {
                    Message.Error("Y parameter must integer.");
                }
            }
            if (valid) {
                if (paramList[2].Length != 1) {
                    Message.Error("d parameter must a char.");
                    valid = false;
                }
            }
            if (valid) {
                direction = paramList[2][0];
            }
            if (valid) {
                ServiceResult<Plateau> result = plateauService.AddNewRover(Storage.Plateau, roverX, roverY, direction);
                if (result.ResultStatus != ServiceResultStatus.Success && result.ErrorMessage != null) {
                    Message.Error(result.ErrorMessage);
                }
                else if (result.Response != null) {
                    Storage.Plateau = result.Response;
                    Message.Success($"Rover located succesfully on plateau. x:{roverX}, y:{roverY}, d:{Storage.Plateau.SelectedRover.Direction.Text} successfully.");
                    ExitLoop();
                }
            }
        }
    }
}
