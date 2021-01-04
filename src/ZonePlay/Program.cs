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
            var zone = new Zone2(25,25);
            Print(zone);

            Console.ReadKey();
        }

        static void Print(BaseZone zone)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            for (int j = 0; j < zone.zHeight +2; j++)
            {
                for (int i = 0; i < zone.zWidth+2; i++)
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
}
