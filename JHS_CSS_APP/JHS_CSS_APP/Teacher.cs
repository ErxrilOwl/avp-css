using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHS_CSS_APP
{
    class Teacher : Person
    {
        private string teacherID;

        public string TeacherID
        {
            get { return teacherID; }
            set { teacherID = value; }
        }

        public Teacher(string teacherID, string lastname, string middlename, string firstname, DateTime birthdate, char gender) : base(lastname, middlename, firstname, birthdate, gender)
        {
            TeacherID = teacherID;
        }

        public void PrintTeacherInfo()
        {
            Console.WriteLine("Teacher ID: " + TeacherID + "\n" +
                   "Name: " + FirstName + " " + MiddleName + " " + LastName);
        }
    }
}
