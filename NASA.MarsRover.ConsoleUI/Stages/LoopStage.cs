using System;
using System.Collections.Generic;
using System.Text;
using NASA.MarsRover.Model;
using NASA.MarsRover.Service;

namespace NASA.MarsRover.ConsoleUI.Stages {

    public abstract class LoopStage : IStage {

        protected PlateauService plateauService = new PlateauService();
        protected RoverService roverService = new RoverService();

        protected string command = "";
        private bool continueLoop = true;

        protected void ExitLoop() {
            continueLoop = false;
        }

        public void Execute() {
            BeforeExecute();
            Message.Warning("Enter 'Q' to quit");
            while (continueLoop && command.ToUpper() != "Q" && LoopCondition()) {
                ExecuteLoop();
            }
            AfterLoop();
            AfterExecute();
        }

        protected virtual bool LoopCondition() {
            return true;
        }

        protected virtual void BeforeExecute() {

        }

        protected abstract void ExecuteLoop();

        private void AfterLoop() {
            if (command.Trim().ToUpper() == "Q") {
                Environment.Exit(0);
            }
        }

        protected virtual void AfterExecute() {

        }
    }
}
