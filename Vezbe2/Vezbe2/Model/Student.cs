using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vezbe2.Model
{
    [Serializable]
    public class Student
    {
        public String Name { get; set; }
        public String Surname { get; set; }
        public char Gender { get; set; }
        public String Department { get; set; }

        public Student()
        {

        }

        public Student(string name, string surname, char gender, string department)
        {
            Name = name;
            Surname = surname;
            Gender = gender;
            Department = department;
        }
    }
}
