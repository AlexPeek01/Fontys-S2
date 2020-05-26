using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managers
{
    public class Program
    {
        private readonly ScientistManager scientistmanager = new ScientistManager();
        public int[] Run()
        {
            List<Scientist> scientistList = scientistmanager.SeperateScientists();
            int lowest = GetLowestYear(scientistList);
            int highest = GetHighestYear(scientistList);
            return GetMostAliveInYear(scientistList, lowest, highest);
        }
        public int[] GetMostAliveInYear(List<Scientist> scientists, int lowest, int highest)
        {
            int year = 0;
            int count = 0;
            for (int i = lowest; i < highest; i++)
            {
                int tempcount = 0;
                foreach (Scientist scientist in scientists)
                {
                    if (scientist.birth < i && scientist.death >= i)
                        tempcount++;
                }
                if (tempcount > count)
                {
                    count = tempcount;
                    year = i;
                }
            }
            int[] data = new int[2];
            data[0] = year;
            data[1] = count;
            return data;
        }
        public int GetLowestYear(List<Scientist> scientistList)
        {
            int year = scientistList[0].birth;
            foreach (Scientist s in scientistList)
            {
                if (s.birth < year)
                    year = s.birth;
            }
            return year;
        }
        public int GetHighestYear(List<Scientist> scientistList)
        {
            int year = scientistList[0].death;
            foreach (Scientist s in scientistList)
            {
                if (s.death > year)
                    year = s.death;
            }
            return year;
        }
    }
}
