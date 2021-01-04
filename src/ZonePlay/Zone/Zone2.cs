using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZonePlay.Zone
{
    /// <summary>
    /// 随机Prim
    /// </summary>
    public class Zone2 : BaseZone
    {
        /*1.让迷宫全是墙.
         *2.选一个单元格作为迷宫的通路，然后把它的邻墙放入列表
         *3.当列表里还有墙时
         *	1.从列表里随机选一个墙，如果这面墙分隔的两个单元格只有一个单元格被访问过
         *		1.那就从列表里移除这面墙，即把墙打通，让未访问的单元格成为迷宫的通路
         *		2.把这个格子的墙加入列表
         *	2.如果墙两面的单元格都已经被访问过，那就从列表里移除这面墙
         */

        public Zone2(int width, int height)
            : base(width, height)
        {
            // 将迷宫全部设置为墙
            for (int i = 1; i <= width; i++)
            {
                for (int j = 1; j <= height; j++)
                {
                    ZoneArr[i, j] = 1;
                }
            }
            CreateZone();
        }

        protected override void CreateZone()
        {
            var start = new Point(1, 1);
            List<Point> wList = new List<Point>();
            ZoneArr[start.X, start.Y] = 0;
            var list = GetNexWall(start);
            wList.AddRange(list);
            while (wList.Count > 0)
            {
                // 随机选一个墙
                var wall = wList[rand.Next(wList.Count)];

                // 分隔的单元格？上下左右都计算一下吧
                int s = ZoneArr[wall.X, wall.Y - 1];
                int x = ZoneArr[wall.X, wall.Y + 1];
                int z = ZoneArr[wall.X - 1, wall.Y];
                int y = ZoneArr[wall.X + 1, wall.Y];

                wList.Remove(wall); // 先移除，再判断是否需要掏空
                if (s + x == 1)
                {
                    ZoneArr[wall.X, wall.Y] = 0; // 先掏空墙，再掏空对面的点
                    if (s == 1)
                    {
                        ZoneArr[wall.X, wall.Y - 1] = 0;
                        wList.AddRange(GetNexWall(new Point(wall.X, wall.Y - 1)));
                    }
                    else
                    {
                        ZoneArr[wall.X, wall.Y + 1] = 0;
                        wList.AddRange(GetNexWall(new Point(wall.X, wall.Y + 1)));
                    }
                }
                else if (z + y == 1)
                {
                    ZoneArr[wall.X, wall.Y] = 0;
                    if (z == 1)
                    {
                        ZoneArr[wall.X - 1, wall.Y] = 0;
                        wList.AddRange(GetNexWall(new Point(wall.X - 1, wall.Y)));
                    }
                    else
                    {
                        ZoneArr[wall.X + 1, wall.Y] = 0;
                        wList.AddRange(GetNexWall(new Point(wall.X + 1, wall.Y)));
                    }
                }
            }
        }

        private List<Point> GetNexWall(Point p)
        {
            List<Point> list = new List<Point>();

            var sp = new Point(p.X, p.Y - 1);
            if (CheckPoint(sp, 1))
                list.Add(sp);

            sp = new Point(p.X, p.Y + 1);
            if (CheckPoint(sp, 1))
                list.Add(sp);

            sp = new Point(p.X - 1, p.Y);
            if (CheckPoint(sp, 1))
                list.Add(sp);

            sp = new Point(p.X + 1, p.Y);
            if (CheckPoint(sp, 1))
                list.Add(sp);
            
            return list;
        }
    }
}
