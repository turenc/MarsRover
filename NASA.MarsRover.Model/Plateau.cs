using System;
using System.Collections.Generic;
using System.Text;

namespace NASA.MarsRover.Model {
    public class Plateau {

        const int minX = 0;
        const int minY = 0;

        public Plateau(Coordinate upperRightCorner) {
            PlateauCode = Guid.NewGuid();
            this.upperRightCorner = upperRightCorner;
            Rovers = new List<Rover>();
        }

        public Guid PlateauCode { get; }

        public List<Rover> Rovers { get; set; }

        public Rover SelectedRover { get; set; }

        readonly Coordinate upperRightCorner;

        public int MaxX
        {
            get
            {
                return upperRightCorner.X;
            }
        }

        public int MaxY
        {
            get
            {
                return upperRightCorner.Y;
            }
        }

        public int MinX
        {
            get
            {
                return minX;
            }
        }

        public int MinY
        {
            get
            {
                return minY;
            }
        }
    }
}
