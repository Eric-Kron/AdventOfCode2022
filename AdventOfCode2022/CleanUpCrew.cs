using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class CleanUpCrew
    {
        int a = 0;
        int b = 0;
        int c = 0;
        int d = 0;
        int howManyPairsContainsTheOther = 0;


        public void cleanString(string input) {

            var firstpart = input.Substring(0, input.IndexOf(','));
            var secondpart = input.Substring(input.IndexOf(",")+1);
            
            var a = int.Parse(firstpart.Substring(0, firstpart.IndexOf('-')));
            var b = int.Parse(firstpart.Substring(firstpart.IndexOf('-') + 1));
            var c = int.Parse(secondpart.Substring(0, secondpart.IndexOf('-')));
            var d = int.Parse(secondpart.Substring(secondpart.IndexOf('-')+1));

            sectionsInsideRange(a, b, c, d);

        }


        public bool sectionsInsideRange(int a, int b, int c, int d)
        {

            if (c > b) {
                Console.WriteLine("#" + a + ',' + b + ',' + c + ',' + d);
                return false;
             
            }
            else if (d<a)
            {
                Console.WriteLine("#" + a + ',' + b + ',' + c + ',' + d);
                return false;
            }
           
            else if (a <= c && b >= d || c <= a && d >= b || a <= c && d >= b || c <= a && b >= d)
            {
                howManyPairsContainsTheOther++;
                return true;
            }
            else { 

                return false; 
            }

        }

        public int gethowManyPairsContainsTheOther()
        {
            return howManyPairsContainsTheOther;
        }




    }
}
