using System;

namespace Zad4
{
    public class Student
    {
        public string Name { get; set; }
        public string Jmbag { get; set; }
        public Gender Gender { get; set; }
        public Student(string name, string jmbag)
        {
            Name = name;
            Jmbag = jmbag;
        }

        public static bool operator ==(Student student1, Student student2)
        {
            if (student1.Jmbag == student2.Jmbag) return true;
            return false;
        }

        public static bool operator !=(Student student1, Student student2)
        {
            if (student1.Jmbag == student2.Jmbag) return false;
            return true;
        }

        public override bool Equals(Object student)
        {
            Student pom = (Student)student;
            if (student is Student && pom.Jmbag == this.Jmbag) return true;
            return false;
        }

        public override int GetHashCode()
        {
            return this.Jmbag.GetHashCode() * 29 + Name.GetHashCode() * 99 + Gender.GetHashCode() * 57;
        }
    }

    public enum Gender
    {
        Male, Female
    }
}