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
            Cross(0, zWidth, 0, zHeight);
        }

        private void Cross(int xST, int xEd, int yST, int yEd)
        {
            // 在一定的空间内，划一个十字墙，然后四条边上，随机挖一个洞
            throw new NotImplementedException();
        }
    }
}
