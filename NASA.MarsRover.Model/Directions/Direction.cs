using System;
using System.Collections.Generic;
using System.Text;

namespace NASA.MarsRover.Model.Directions {
    public abstract class Direction {
        public abstract Direction Left { get; }
        public abstract Direction Right { get; }
        protected abstract char DirectionAbbreviation { get; }
        public abstract string Text { get; }

        public static implicit operator char(Direction direction) {
            return direction.DirectionAbbreviation;
        }
    }
}
