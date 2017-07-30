using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHS_CSS_APP
{
    class Student : Person
    {
        private string studentNo;
        private int yearLevel;

        public string StudentNo
        {
            get { return studentNo; }
            set { studentNo = value; }
        }

        public int YearLevel
        {
            get { return yearLevel; }
            set { yearLevel = value; }
        }

        public Student(string studentNo, int yearLevel, string lastname, string middlename, string firstname, DateTime birthdate, char gender) : 
            base(lastname, middlename, firstname, birthdate, gender)
        {
            StudentNo = studentNo;
            YearLevel = yearLevel;
        }

        public void PrintStudentInfo() {
            Console.WriteLine("Student No: " + StudentNo + "\n" +
                   "Name: " + FirstName + " " + MiddleName + " " + LastName + "\n" +
                   "Year Lvl: " + YearLevel);
        }
    }
}
