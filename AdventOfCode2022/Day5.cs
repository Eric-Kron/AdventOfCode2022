using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day5
    {
        Stack <string> first = new Stack<string>(new [] { "Q", "M", "G", "C", "L" });
        Stack<string> second = new Stack<string>(new[] { "R", "D", "L", "C", "T", "F", "H", "G"});
        Stack<string> third = new Stack<string>(new[] { "V", "J", "F", "N", "M", "T", "W", "R"});
        Stack<string> fourth = new Stack<string>(new[] { "J", "F", "D", "V", "Q", "P" });
        Stack<string> fifth = new Stack<string>(new[] { "N", "F", "M", "S", "L", "B", "T" });
        Stack<string> sixth = new Stack<string>(new[] { "R", "N", "V", "H", "C", "D", "P" });
        Stack<string> seventh = new Stack<string>(new[] { "H", "C", "T" });
        Stack<string> eight = new Stack<string>(new[] { "G", "S", "J", "V", "Z", "N", "H", "P" });
        Stack<string> ninth = new Stack<string>(new[] { "Z", "F", "H", "G" });

        int counter = 0;
        int externalCounter = 0;


        Dictionary<int, Stack<string>> keyValuePairs= new Dictionary<int, Stack<string>>();
        
        public void setup()
        {
            keyValuePairs.Add(1, first);
            keyValuePairs.Add(2, second);
            keyValuePairs.Add(3, third);
            keyValuePairs.Add(4, fourth);
            keyValuePairs.Add(5, fifth);
            keyValuePairs.Add(6, sixth);
            keyValuePairs.Add(7, seventh);
            keyValuePairs.Add(8, eight);
            keyValuePairs.Add(9, ninth);
        }
        public void sorterOfAll(int amount, int from, int to)
        {
            int internalcounter = 1;

            var fromStack = keyValuePairs[from];
            var toStack = keyValuePairs[to];

            List<string> list = new List<string>(); 
         
            while (internalcounter <= amount)
            {
                var t = fromStack.Pop();
                list.Add(t);
                internalcounter++;
            }

            while(list.Count > 0)
            {
                toStack.Push(list.Last());
                list.RemoveAt(list.Count- 1);
            }
        
        }

        public void getStarted(int amount, int from, int to)
        {
           
            while (counter == 0)
            {
                setup();
                counter++;
            }
            sorterOfAll(amount, from, to);
        }

        public void stringCleanUp(string line)
        {
            //int amount = 0;
            //int from = 0;
            //int to = 0;

            var stringArray = line.Split(' ', ' ');

            var amount = int.Parse(stringArray[1]);
            var from = int.Parse(stringArray[3]);
            var to = int.Parse(stringArray[5]);



            //    IEnumerator enumerator = line.GetEnumerator();

            //    while (enumerator.MoveNext())
            //    {

            //        char a = (char)enumerator.Current;
            //        bool b = Char.IsDigit(a);

            //        //int a = int.TryParse(enumerator.Current.ToString().ToCharArray().ElementAtOrDefault(0));

            //       if (b) {
            //            int c = int.Parse(a.ToString());
            //            if (amount == 0)
            //            {
            //                amount = c;

            //            }
            //            else if (from == 0)
            //            {
            //                from = c;

            //            }
            //            else if (to == 0)
            //            {
            //                to = c;

            //            }
            //        }

            //    }
               getStarted(amount, from, to);
            //}
        }

        public string outPut()
        {
            string outString = null;
            string stringOne = null;
            string stringTwo = null;
            foreach (var item in keyValuePairs)
            {
                stringOne = item.Key.ToString();
                stringTwo = item.Value.Pop();
               
                outString +="#" + stringOne + " " + stringTwo + "\n";
            }
            return outString;
        }


    }
}
