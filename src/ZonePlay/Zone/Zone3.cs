using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZonePlay.Zone
{
    /// <summary>
    /// 递归分割
    /// </summary>
    public class Zone3 : BaseZone
    {
        /*就是把空间用十字分成四个子空间，然后在三面墙上挖洞（为了确保连通），
         * 之后对每个子空间继续做这件事直到空间不足以继续分割为止
         */

        public Zone3(int width, int height)
            : base(width, height)
        {
            CreateZone();
        }

        protected override void CreateZone()
        {
            Cross(1, zWidth, 1, zHeight);
        }

        private void Cross(int xST, int xEd, int yST, int yEd)
        {
            // 在一定的空间内，划一个十字墙，然后四条边上，选三个随机挖一个洞
            int xC = -1;

            int yC = -1;
            if (xEd - xST > 1 && yEd - yST > 1)
            {
                // 十字墙
                xC = RandGetWall(xST, xEd);
                yC = RandGetWall(yST, yEd);
                for (int y = yST; y < yEd; y++)
                {
                    ZoneArr[xC, y] = 1;
                }
                for (int x = xST; x < xEd; x++)
                {
                    ZoneArr[x, yC] = 1;
                }

                // 4面墙，各随机选一个点（空的位置）
                var x1 = RandGetKong(xST, xC);
                var x2 = RandGetKong(xC, xEd);
                var y1 = RandGetKong(yST, yC);
                var y2 = RandGetKong(yC, yEd);
                // 随机选3个来挖墙
                var r1 = rand.Next(0, 4);
                switch (r1)
                {
                    case 0:
                        {
                            ZoneArr[x2, yC] = 0;
                            ZoneArr[xC, y1] = 0;
                            ZoneArr[xC, y2] = 0;
                            break;
                        }
                    case 1:
                        {
                            ZoneArr[x1, yC] = 0;
                            ZoneArr[xC, y1] = 0;
                            ZoneArr[xC, y2] = 0;
                            break;
                        }
                    case 2:
                        {
                            ZoneArr[x1, yC] = 0;
                            ZoneArr[x2, yC] = 0;
                            ZoneArr[xC, y2] = 0;
                            break;
                        }
                    case 3:
                        {
                            ZoneArr[x1, yC] = 0;
                            ZoneArr[x2, yC] = 0;
                            ZoneArr[xC, y1] = 0;
                            break;
                        }
                    default:
                        break;
                }

                Cross(xST, xC-1, yST, yC-1);
                Cross(xST, xC-1, yC+1, yEd);
                Cross(xC+1, xEd, yST, yC-1);
                Cross(xC+1, xEd, yC+1, yEd);
            }
        }

        private int RandGetWall(int start, int end)
        {
            if (end - start > 1)
            {
                var rd = rand.Next(start, end);
                if (rd % 2 == 1)
                {
                    rd += 1;
                }
                if (rd >= end)
                    rd -= 2;

                return rd;
            }
            return -1;
        }

        private int RandGetKong(int start, int end)
        {
            var rd = (start + end) / 2;
            if (rd % 2 == 0)
            {
                rd += 1;
            }
            if (rd >= end)
                rd -= 2;

            return rd;
        }
    }
}
