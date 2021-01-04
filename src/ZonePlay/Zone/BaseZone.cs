using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZonePlay.Zone
{
    public abstract class BaseZone
    {
        public int zWidth { get; private set; }
        public int zHeight { get; private set; }

        protected Random rand = new Random(Guid.NewGuid().GetHashCode());

        public BaseZone(int width, int height)
        {
            zWidth = width;
            zHeight = height;

            // 设置大一些，包括外层的墙
            ZoneArr = new int[width + 2, height + 2];

            // 四周围墙
            for (int i = 0; i < width + 2; i++)
            {
                ZoneArr[i, 0] = 1;
                ZoneArr[i, height + 1] = 1;
            }
            for (int j = 0; j < height + 2; j++)
            {
                ZoneArr[0, j] = 1;
                ZoneArr[width + 1, j] = 1; 
            }
            // 开口，迷宫的入口和出口
            ZoneArr[0, 1] = 0;
            ZoneArr[width + 1, height] = 0;
        }

        /// <summary>
        /// 迷宫单元， 1标识为墙 0 标志为路，其他用于算法中的标志
        /// </summary>
        public int[,] ZoneArr;

        protected abstract void CreateZone();

        
        protected bool CheckPoint(Point p, int value)
        {
            if (p.X >= 1 && p.Y >= 1 && p.X < zWidth + 1 && p.Y < zHeight + 1)
            {
                return ZoneArr[p.X, p.Y] == value;
            }
            return false;
        }
    }
}
