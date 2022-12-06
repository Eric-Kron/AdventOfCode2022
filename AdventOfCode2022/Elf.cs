using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Elf
    {
        int numberOfElf;
        int sumCalories;

        public Elf(int numberOfElf) {
            this.numberOfElf = numberOfElf;
            sumCalories = 0;
        }

        public Elf getElf()
        {
            return this;
        }
        public int getNumberOfElf()
        {
                return numberOfElf;
        }

        public int getCalories() {
            return sumCalories;
        }

        public void setCalories (int input) {
            sumCalories += input;
         }
    }
}
