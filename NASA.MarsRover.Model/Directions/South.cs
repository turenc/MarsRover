using System;
using System.Collections.Generic;
using System.Text;

namespace NASA.MarsRover.Model.Directions {
    public class South : Direction {

        protected override char DirectionAbbreviation => 'S';

        public override string Text => "South";

        public override Direction Left => new East();

        public override Direction Right => new West();
    }
}
