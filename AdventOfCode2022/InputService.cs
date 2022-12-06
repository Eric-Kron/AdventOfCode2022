using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class InputService
    {

        Dictionary <int, int> _ElfCollection = new Dictionary<int, int>();
        List<Elf> _ElfList = new List<Elf>();
        Elf? _Elf;
        OutputService outputService = new OutputService();
        int points = 0; 
        int counter = 0;

        Itemduplication itemduplication = new Itemduplication();
        CleanUpCrew cleanUpCrew= new CleanUpCrew();
        Day5 Day5 = new Day5();

       



        public void StringReaderToChar()
        {


            foreach (string line in File.ReadLines(@"C:\Users\ekron\Input-part-5.txt"))
            {
                //cleanUpCrew.cleanString(line);

                Day5.stringCleanUp(line);
            }

            //foreach (string line in File.ReadLines(@"C:\Users\ekron\Input-part-3.txt"))
            //{
            //    itemduplication.Input(line);
            //}

            //OutputService outputService = new OutputService();
            //outputService.output("Items: " + cleanUpCrew.gethowManyPairsContainsTheOther().ToString());

            OutputService outputService = new OutputService();
            outputService.output(Day5.outPut());
                
                //.getsumOfTheItemsFound().ToString());
            //    var CharArray  = line.Substring(0,line.Length).ToCharArray();
            //    var first =  CharArray.Last();
            //    var second = CharArray.First();

            //    charSwitch(first, second);
            //    /// charSwitch();
            //    /// 
            //    counter++;
            //    outputService.output("#"+ counter + "  " +first+second+ " Points:" + points.ToString());

            //}

            //outputService.output(points.ToString());

        }

        public void charSwitch(char first, char second)
        {

            switch (first)
            {
                case'X':
                    charX(second);
                    break;
                case 'Y':
                    charY(second);
                    break;
                case 'Z': 
                    charZ(second);
                    break;

            }

        }

        //  x = rock Me --> a oppo
        //  Y = papper Me --> b oppo
        //  z = scissor Me --> c oppo

        // x = lose
        // y == draw 
        // z == win 

        public void charX(char first)
        {
            if (first == 'A')
            {
                points += 3;
            }
            else if (first == 'B')
            {
                points += 1;

            }
            else
            {
                points += 2;
            }
        } 
        public void charY(char first) {
           
            
            if (first == 'A')
            {
                points += 1;
                points += 3;
            }
            else if (first == 'B')
            {
                points += 2;
                points += 3;
            }
            else
            {
                points += 3;
                points += 3;
            }



        }
        public void charZ(char first) {
           
            if (first == 'A')
            {
                points += 2;
                points += 6;
            }
            else if (first == 'B')
            {
                points += 3;
                points += 6;
            }
            else
            {
                points += 1;
                points += 6;
            }


        }
        public void charA(char second)
        {
           
            if (second == 'X')
            {
                points += 1;
                points += 3;
                // do nothing
            }
            else if (second == 'Y')
            {
                points += 2;
                points += 6;
            }
            else
            {
                points += 3;
            }
        }
        public void charB(char second)
        {

            if (second == 'X')
            {
                points += 1;
            }
            else if (second == 'Y')
            {
                points += 2;
                points += 3;
            }
            else
            {
                points += 3;
                points += 6;
            }
        }
            public void charC(char second)
             {
  
            if (second == 'X')
            {
                points += 1;
                points += 6;
            }
            else if (second == 'Y')
            {
                points += 2;
            }
            else
            {
                points += 3;
                points += 3;
            }

             }

        public void StringReaderToInt() {

            int counter = 1;
            var calories = 0;
            int counterOfLines = 1;
            createElf(counter);

            foreach (string line in File.ReadLines(@"C:\Users\ekron\Input-part-1.txt"))
            {
                counterOfLines = counterOfLines++;
                if (!line.Equals("")) {
                    calories = int.Parse(line);
                    
                    addToElfCalories(counter, calories);
                
                }
                else
                {
                    addElfToCollection(counter);
                    counter++;
                    createElf(counter);
                }
            }
            getTheElf();
            getTopThree();
        }

        private void createElf(int numberOfElf)
        {
            _Elf = new Elf(numberOfElf);
            _ElfList.Add(_Elf);
        }

        private void addToElfCalories(int getNumberofElf ,int calories)
        {
            _Elf = _ElfList[getNumberofElf-1];
            _Elf.setCalories(calories);
        }

        private void addElfToCollection(int numberOfElf)
        {
            _Elf = _ElfList[numberOfElf-1];
            var elfNumber = _Elf.getNumberOfElf();
            var sumCalories = _Elf.getCalories();
            _ElfCollection.Add(elfNumber, sumCalories);
        }

        private void getTheElf()
        {
            var carryElf = _ElfCollection.OrderByDescending(number => number.Value).ToList();
            foreach (var item in carryElf)
            {
                outputService.output(item.Value.ToString());
                outputService.output("#" + item.Key.ToString() + " : " + item.Value.ToString());
            }
        }


        private void getTopThree()
        {
            var carryElf = _ElfCollection.OrderByDescending(number => number.Value).ToList();
            int calorieSum = 0;

            for (int i = 0; i < 3; i++)
            {
                calorieSum += carryElf[i].Value;
            }
            outputService.output("Top Three elfs carry: " + calorieSum.ToString());
        }
    }
}
