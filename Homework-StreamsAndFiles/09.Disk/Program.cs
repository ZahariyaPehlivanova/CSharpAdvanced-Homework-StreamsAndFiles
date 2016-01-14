using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write field and radius");
            int field = int.Parse(Console.ReadLine());
            int radius = int.Parse(Console.ReadLine());


            int x = field / 2;
            int y = field / 2;

            for (int i = 0; i < field; i++)
            {
                for (int j = 0; j < field; j++)
                {
                    int distanceToX = Math.Abs(y-i);
                    int distanceToY = Math.Abs(x - j);
                    double distanceToCenter = Math.Sqrt(distanceToX * distanceToX + distanceToY * distanceToY);

                    if (distanceToCenter <= radius)
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write('.');
                    }
                   
                }
                Console.WriteLine();
            }
        }
    }
}
            

