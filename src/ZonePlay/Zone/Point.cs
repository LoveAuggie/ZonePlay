using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZonePlay.Zone
{
    public struct Point
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        internal Point GetNextPoint(Dir dir)
        {
            switch (dir)
            {
                case Dir.Shang:
                    return new Point(this.X, this.Y - 1);
                case Dir.Xia:
                    return new Point(this.X, this.Y + 1);
                case Dir.Zuo:
                    return new Point(this.X - 1, this.Y);
                case Dir.You:
                    return new Point(this.X + 1, this.Y);
                default:
                    return this;
            }
        }
    }
}
