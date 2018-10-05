using System;
using System.Collections.Generic;
using System.Text;
using NASA.Framework.Service;
using NASA.MarsRover.ConsoleUI.Stages;
using NASA.MarsRover.Model;
using NASA.MarsRover.Service;

namespace NASA.MarsRover.ConsoleUI {
    public class MarsRoverApplication {
        
        public void Run() {
            Message.Info(@"Welcome to NASA Mars Rover Application
A squad of robotic rovers are to be landed by NASA on a plateau on Mars. This plateau, which is curiously rectangular, must be navigated by the rovers so that their on board cameras can get a complete view of the surrounding terrain to send back to Earth. 
A rover's position and location is represented by a combination of x and y co-ordinates and a letter representing one of the four cardinal compass points. The plateau is divided up into a grid to simplify navigation. An example position might be 0, 0, N, which means the rover is in the bottom left corner and facing North. 
In order to control a rover, NASA sends a simple string of letters. The possible letters are 'L', 'R' and 'M'. 'L' and 'R' makes the rover spin 90 degrees left or right respectively, without moving from its current spot. 'M' means move forward one grid point, and maintain the same heading. 
Assume that the square directly North from (x, y) is (x, y+1). 
");
            Exec<PlateauDefinitionStage>();
            while (true) {
                Exec<RoverDefinitionStage>();
                Exec<RoversListStage>();
                Exec<RoverControlStage>();
                Exec<RoversListStage>();
            }
        }

        private void Exec<T>() where T: IStage, new() {
            new T().Execute();
        }

        void Exit() {
            Environment.Exit(0);
        }
    }
}
