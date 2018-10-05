using System;
using System.Collections.Generic;
using System.Text;

namespace NASA.MarsRover.ConsoleUI.Stages {
    public class RoversListStage : IStage {
        
        public void Execute() {

            if (Storage.Plateau == null || Storage.Plateau.Rovers == null || Storage.Plateau.Rovers.Count == 0) return;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(@"
--- PLATEAU INFO ---");

            Message.Animation();
            Console.WriteLine($"Plateau Code:{Storage.Plateau.PlateauCode} min x:{Storage.Plateau.MinX} min y:{Storage.Plateau.MinY} max x:{Storage.Plateau.MaxX} max y:{Storage.Plateau.MaxY}");
            Message.Animation();

            Console.WriteLine(@"
--- ROVER LIST ---");

            Message.Animation();
            Storage.Plateau.Rovers.ForEach
                (rover => {
                Console.WriteLine($"Rover Code:{rover.RoverCode} x:{rover.CurrentCoordinate.X} y:{rover.CurrentCoordinate.Y} d:{rover.Direction.Text}");
                });
            Message.Animation();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
