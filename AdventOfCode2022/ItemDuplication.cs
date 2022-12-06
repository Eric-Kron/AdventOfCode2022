using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Itemduplication
    {

        Dictionary<char, int> keyValuePairs= new Dictionary<char, int>();

        List <string> groupHolder = new List<string>(); 

        int sumOfTheItemsFound = 0;

        char[]? alphabet;

        int counter = 0;
        public int getsumOfTheItemsFound()
        {
            return sumOfTheItemsFound;
        }
        public void Input(string input)

        {     
            counter++;
            if(alphabet is null)
            {
                setupThing();
            }
            if(counter == 3) {
                groupHolder.Add(input);
                readString(groupHolder);
                groupHolder.Clear();
                counter = 0;
            }
            else
            {
                groupHolder.Add(input);
            }
        }

        public void setupThing()
        {
            alphabet = Enumerable.Range('a', 'Z').Select(i => (Char)i).ToArray();

            for (int i = 0; i < alphabet.Length; i++)
            {
                keyValuePairs.Add(alphabet[i], i+1);
            }

        }

        public Boolean readString(List <string> groupholder)
        {
          
            var stringOne = groupHolder.ElementAt(0).ToList();
            var stringTwo = groupHolder.ElementAt(1).ToList();
            var stringThree = groupHolder.ElementAt(2).ToList();


            // var middle = (input.Length/2);
            //var firstCompartment = input.Substring(0, middle).ToList();
            //var secondCompartment = input.Substring(middle).ToList();


            foreach (char a in stringOne)
            {
                foreach (char b in stringTwo)
                {
                    if (a.ToString().Equals(b.ToString(), StringComparison.InvariantCulture))
                    {
                        foreach (char c in stringThree)
                        {
                            if (b.ToString().Equals(c.ToString(), StringComparison.InvariantCulture))
                            {
                                getValueOfTheThings(a);
                                return true;
                            }
                        } 
                    }
                }
            }
            OutputService outputService = new OutputService();
            outputService.output("Items: "+ sumOfTheItemsFound);
            return false;

        }
        public void getValueOfTheThings(char a)
        {
            var localSum = 0;
            localSum += keyValuePairs.GetValueOrDefault(a);
            if(localSum == 0)
            {
                char b = char.ToLower(a);
                localSum += keyValuePairs.GetValueOrDefault(b)+26;
            }
            sumOfTheItemsFound += localSum;

        }

        
    }
}
