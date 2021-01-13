using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZonePlay.Zone
{
    /// <summary>
    /// 深度优先算法
    /// </summary>
    public class Zone1 : BaseZone
    {
        /* 1.将起点作为当前迷宫单元并标记为已访问
         * 2.当还存在未标记的迷宫单元，进行循环
	     *   2.1.如果当前迷宫单元有未被访问过的的相邻的迷宫单元
		 *     2.1.1.随机选择一个未访问的相邻迷宫单元
		 *     2.1.2.将当前迷宫单元入栈
		 *     2.1.3.移除当前迷宫单元与相邻迷宫单元的墙
		 *     2.1.4.标记相邻迷宫单元并用它作为当前迷宫单元
	     *  2.2.如果当前迷宫单元不存在未访问的相邻迷宫单元，并且栈不空
		 *     2.2.1.栈顶的迷宫单元出栈
		 *     2.2.2.令其成为当前迷宫单元
         */

        /// <summary>
        /// 构造迷宫
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Zone1(int width, int height)
            :base(width,height)
        {
            // 将迷宫使用十字的墙隔开
            for (int i = 1; i <= width; i ++)
            {
                for (int j = 1; j <= height; j++)
                {
                    if (i % 2 == 0 || j % 2 == 0)
                        ZoneArr[i, j] = 1; 
                    else
                        ZoneArr[i, j] = 2;
                }
            }

            CreateZone();
        }

        Queue<Point> pQueue = new Queue<Point>();
        protected override void CreateZone()
        {
            Point start = new Point(1, 1);
            while (true)
            {
                ZoneArr[start.X, start.Y] = 0;   // 当前点标记为已访问
                var next = GetNextPoint(start);  // 获取相邻点
                if (next.X >= 0)
                {
                    pQueue.Enqueue(start);
                    RemoveWall(start, next); // 移除二者之间的墙
                    start = next; // 使用
                }
                else
                {
                    if (pQueue.Count > 0)
                        start = pQueue.Dequeue();
                    else
                        break;
                }
            }
        }

        private Point GetNextPoint(Point p)
        {
            List<Point> list = new List<Point>();

            var sp = new Point(p.X, p.Y - 2);
            if (CheckPoint(sp, 2))
                list.Add(sp);

            sp = new Point(p.X, p.Y + 2);
            if (CheckPoint(sp, 2))
                list.Add(sp);

            sp = new Point(p.X - 2, p.Y);
            if (CheckPoint(sp, 2))
                list.Add(sp);

            sp = new Point(p.X + 2, p.Y);
            if (CheckPoint(sp, 2))
                list.Add(sp);

            if (list.Count > 0)
                return list[rand.Next(list.Count)];

            return new Point(-1, -1); 
        }

        private void RemoveWall(Point start, Point next)
        {
            var wx = (start.X + next.X) / 2;
            var wy = (start.Y + next.Y) / 2;
            ZoneArr[wx, wy] = 0;
        }
    }
}
