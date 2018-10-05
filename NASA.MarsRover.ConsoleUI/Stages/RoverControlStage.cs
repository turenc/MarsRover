using System;
using System.Collections.Generic;
using System.Text;
using NASA.Framework.Service;
using NASA.MarsRover.Model;

namespace NASA.MarsRover.ConsoleUI.Stages {
    public class RoverControlStage : LoopStage {

        protected override bool LoopCondition() {
            return true;
        }

        protected override void BeforeExecute() {
            Message.Info(@"
--- ROVER CONTROL STAGE ---");
        }

        protected override void ExecuteLoop() {
            Console.WriteLine();
            Console.WriteLine($"Active rover code: {Storage.Plateau.SelectedRover.RoverCode}.");
            Console.WriteLine($"It's location: x:{Storage.Plateau.SelectedRover.CurrentCoordinate.X} y:{Storage.Plateau.SelectedRover.CurrentCoordinate.Y} d:{Storage.Plateau.SelectedRover.Direction.Text} ");
            Console.WriteLine("Please enter a rover commad array. >> Input format: Simple string of letters.");
            Console.WriteLine(" The possible letters are 'L' (Left), 'R' (Right) and 'M' (Move). ");
            command = Console.ReadLine();
            if (string.IsNullOrEmpty(command)) {
                ExitLoop();
            }
            else {
                ServiceResult<Plateau> result = roverService.SendCommandArrayToRover(Storage.Plateau.SelectedRover, command);
                if (result.ResultStatus != ServiceResultStatus.Success && result.ErrorMessage != null) {
                    Message.Error(result.ErrorMessage);
                }
                else if (result.Response != null) {
                    Storage.Plateau = result.Response;
                    Message.Success($"Rover location changed succesfully on plateau. x:{Storage.Plateau.SelectedRover.CurrentCoordinate.X}, y:{Storage.Plateau.SelectedRover.CurrentCoordinate.Y}, d:{Storage.Plateau.SelectedRover.Direction.Text}.");
                    ExitLoop();
                }
            }
        }
    }
}
