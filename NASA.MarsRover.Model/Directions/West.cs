using System;
using System.Collections.Generic;
using System.Text;

namespace NASA.MarsRover.Model.Directions {
    public class West : Direction {

        protected override char DirectionAbbreviation => 'W';

        public override string Text => "West";

        public override Direction Left => new South();

        public override Direction Right => new North();
    }
}
