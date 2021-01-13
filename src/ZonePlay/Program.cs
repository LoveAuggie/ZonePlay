using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZonePlay.Zone;

namespace ZonePlay
{
    class Program
    {
        static void Main(string[] args)
        {
            var zone = new Zone1(21, 21);

            Print(zone);

            PlayZone(zone);

            Console.ReadKey();
        }

        static void PlayZone(BaseZone zone)
        {
            var cp = new Point(0, 1);

            Dir dir = Dir.You;
            List<Point> list = new List<Point>();
            while (cp.X != zone.zWidth || cp.Y != zone.zHeight)
            {
                System.Threading.Thread.Sleep(20);
                DrawStep(cp, dir);

                var cd = dir.GetYouDir();
                Point next = cp.GetNextPoint(cd);
                do
                {
                    if (zone.CheckPoint(next, 0))
                    {
                        cp = next;
                        dir = cd;
                        break;
                    }
                    else
                    {
                        cd = cd.GetZuoDir();
                        next = cp.GetNextPoint(cd);
                    }
                } while (true);
            }  
            Console.SetCursorPosition(cp.X * 2, cp.Y);
            Console.Write("→");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(cp.X * 2 +2, cp.Y);
            Console.Write("★");
        }

        private static void DrawStep(Point cp, Dir dir)
        {
            Console.SetCursorPosition(cp.X*2, cp.Y);
            switch (dir)
            {
                case Dir.Shang:
                    Console.Write("↑");
                    break;
                case Dir.Xia:
                    Console.Write("↓");
                    break;
                case Dir.Zuo:
                    Console.Write("←");
                    break;
                case Dir.You:
                    Console.Write("→");
                    break;
                default:
                    break;
            }
        }

        static void Print(BaseZone zone)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            for (int j = 0; j < zone.zHeight + 2; j++)
            {
                for (int i = 0; i < zone.zWidth + 2; i++)
                {
                    var value = zone.ZoneArr[i, j];
                    if (value == 0)
                    {
                        Console.Write("  ");
                    }
                    else if (value == 1)
                    {
                        Console.Write("█");
                    }
                    else
                    {
                        Console.Write("??");
                    }
                }
                Console.WriteLine("");
            }
        }
    }

    public enum Dir
    {
        Shang,
        Xia,
        Zuo,
        You
    }

    public static class DirExtend
    {
        public static Dir GetYouDir(this Dir dir)
        {
            switch (dir)
            {
                case Dir.Shang:
                    return Dir.You;
                case Dir.Xia:
                    return Dir.Zuo;
                case Dir.Zuo:
                    return Dir.Shang;
                case Dir.You:
                    return Dir.Xia;
                default:
                    return dir;
            }
        }


        public static Dir GetZuoDir(this Dir dir)
        {
            switch (dir)
            {
                case Dir.Shang:
                    return Dir.Zuo;
                case Dir.Xia:
                    return Dir.You;
                case Dir.Zuo:
                    return Dir.Xia;
                case Dir.You:
                    return Dir.Shang;
                default:
                    return dir;
            }
        }
    }
}
