using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weboo.Examen
{
    public class Program
    {
        public static void Main()
        {
            bool T = true;
            bool F = false;

            // 0  1  2  3  4  5
            bool[,] dungeons1 = {{F, F, T, F, F, F },    //0
                /*  0  1  */     {F, F, F, T, F, F },    //1
                /*  |  |  */     {T, F, F, T, T, F },    //2
                /*  2--3  */     {F, T, T, F, F, T },    //3
                /*  |  |  */     {F, F, T, F, F, F },    //4
                /*  4  5  */     {F, F, F, T, F, F }};   //5

            //                   // 0  1  2  3  4
            bool[,] dungeons2 = {{F, F, T, F, F},    //0
              /*     0     */    {F, F, T, F, F},    //1
              /*     |     */    {T, T, F, T, T},    //2 
              /*  1--2--3  */    {F, F, T, F, F},    //3
              /*     |     */    {F, F, T, F, F}};   //4
            /*     4     */

            Console.WriteLine(string.Join(" ", ProblemaAntorchas.AsignaAntorchas(dungeons1)));
            // [2, 3]

            Console.WriteLine(string.Join(" ", ProblemaAntorchas.AsignaAntorchas(dungeons2)));
            // [2]
        }
    }
}
