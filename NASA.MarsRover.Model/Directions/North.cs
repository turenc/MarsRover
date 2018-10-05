using System;
using System.Collections.Generic;
using System.Text;

namespace NASA.MarsRover.Model.Directions {
    public class North : Direction {

        protected override char DirectionAbbreviation => 'N';

        public override string Text => "North";

        public override Direction Left => new West();

        public override Direction Right => new East();
    }
}
