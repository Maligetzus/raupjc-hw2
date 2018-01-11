using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad4
{
    public class HomeworkLinqQueries
    {
        public static string[] Linq1(int[] intArray)
        {
            int i = 0;
            var result = intArray.GroupBy(p => p);

            result = result.OrderBy(p => p.Key);
            string[] output = new string[result.Count()];

            foreach (var r in result)
            {
                output[i] = $"Broj {r.Key} ponavlja se {r.Count()} puta";
                i++;
            }

            return output;
        }

        //Men only universities
        public static University[] Linq2_1(University[] universityArray)
        {
            return universityArray.Where(p => (p.Students.Where(q => q.Gender == Gender.Female)).Count() == 0).ToArray();
        }

        //Universities with bellow average number of students
        public static University[] Linq2_2(University[] universityArray)
        {
            return universityArray.Where(p => p.Students.Length < (universityArray.SelectMany(u => u.Students).ToArray().Length)/(universityArray.Length)).ToArray();
        }

        //All the students in Croatia
        public static Student[] Linq2_3(University[] universityArray)
        {
            return universityArray.SelectMany(p => p.Students).Distinct().ToArray();
        }

        //All students that study in a one-gender university
        public static Student[] Linq2_4(University[] universityArray)
        {
            return universityArray.Where(p => (p.Students.Count(q => q.Gender == Gender.Female) == 0) || (p.Students.Count(q => q.Gender == Gender.Male) == 0)).SelectMany(r => r.Students).Distinct().ToArray();
        }

        //Students that study on 2 or more universities
        public static Student[] Linq2_5(University[] universityArray)
        {
            return universityArray.SelectMany(p => p.Students).GroupBy(q => q.Jmbag).Where(p => p.Count() > 1).SelectMany(q => q).Distinct().ToArray();
        }
    }
}