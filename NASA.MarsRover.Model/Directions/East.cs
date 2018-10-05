using System;
using System.Collections.Generic;
using System.Text;

namespace NASA.MarsRover.Model.Directions {
    public class East : Direction {

        protected override char DirectionAbbreviation => 'E';

        public override string Text => "East";
        
        public override Direction Left => new North();

        public override Direction Right => new South();
    }
}
