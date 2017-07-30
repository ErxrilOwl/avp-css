using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHS_CSS_APP
{
    class Person : Entity
    {
        //private variables
        private string lastname;
        private string firstname;
        private string middlename;
        private DateTime birthDate;
        private char gender;


        //Constructor
        public Person(string lastname, string middlename, string firstname, DateTime birthdate, char gender)
        {
            this.lastname = lastname;
            this.firstname = firstname;
            this.middlename = middlename;
            this.gender = gender;
            this.birthDate = birthdate;
        }

        //Properties (Setter & Getter)
        public string LastName
        {
            get { return lastname; }
            set { lastname = value; }
        }

        public string FirstName
        {
            get { return firstname; }
            set { firstname = value; }
        }

        public string MiddleName
        {
            get { return middlename; }
            set { middlename = value; }
        }
        public int Age
        {
            get { return DateTime.Now.Year - birthDate.Year; }
        }

        public Char Gender {
            get { return gender; }
            set {gender = value; }
        }

        //Methods
        private string GetCompleteName()
        {
            return this.firstname + " " + this.middlename + " " + this.lastname;
        }

        public void Greet()
        {
            Console.WriteLine("Hi, I am " + GetCompleteName());
            Console.WriteLine("I am " + Age + " year(s) old");
        }

        public override void PrintInfo() {
            Console.WriteLine("Name : " + GetCompleteName());
            Console.WriteLine("Birthdate : " + birthDate.ToShortDateString());
            Console.WriteLine("Age : " + Age);
        }
    }
}
