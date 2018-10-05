using System;
using System.Collections.Generic;
using System.Text;
using NASA.Framework.Service;
using NASA.MarsRover.Model;

namespace NASA.MarsRover.ConsoleUI.Stages {
    public class PlateauDefinitionStage : LoopStage {

        protected override bool LoopCondition() {
            return (Storage.Plateau == null);
        }

        protected override void BeforeExecute() {
            Message.Info(@"
--- PLATEAU DEFINITION STAGE ---");
        }

        protected override void ExecuteLoop() {
            Console.WriteLine("Please enter upper right coordinate of the plateau. >> Input format: x y");
            command = Console.ReadLine();
            string[] coordinates = command.TrimStart().TrimEnd().Split(" ");
            if (coordinates == null || coordinates.Length != 2) {
                Message.Error("Coordinate format is wrong. Input format must: x y ");
            }
            else {
                if (int.TryParse(coordinates[0], out int x) && int.TryParse(coordinates[1], out int y)) {
                    ServiceResult<Plateau> result = plateauService.CreatePlateau(x, y);
                    if (result.ResultStatus != ServiceResultStatus.Success && result.ErrorMessage != null) {
                        Message.Error(result.ErrorMessage);
                    }
                    else if (result.Response != null) {
                        Storage.Plateau = result.Response;
                        Message.Success("Plateau created successfully.");
                    }
                }
                else {
                    Message.Error("Coordinate values must be integer.");
                }
            }
        }
    }
}
