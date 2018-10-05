using System;
using NASA.Framework.Service;
using NASA.MarsRover.Model;
using NASA.MarsRover.Service;

namespace NASA.MarsRover.ConsoleUI {
    class Program {

        //TODO:Turenc --> Generate a Windows exe --> //dotnet publish -c Debug -r win10-x64
        static void Main(string[] args) {
            Setup();
            MarsRoverApplication marsRoverApplication = new MarsRoverApplication();
            marsRoverApplication.Run();
        }

        private static void Setup() {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
