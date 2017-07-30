using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHS_CSS_APP
{
    class SubjectSched
    {
        private int schedID;
        private Teacher instructor;
        private Subject subject;
        private string time;
        private string days;

        public int SchedID
        {
            get { return schedID; }
            set { schedID = value; }
        }

        public Teacher Instructor
        {
            get { return instructor; }
            set { instructor = value; }
        }

        public Subject SchedSubject
        {
            get { return subject; }
            set { subject = value; }
        }

        public string Time
        {
            get { return time; }
            set { time = value; }
        }

        public string Days
        {
            get { return days; }
            set { days = value; }
        }

        public void PrintSubjectSched() 
        {
            Console.WriteLine("Sched ID: " + SchedID + "\n" +
                              "Instructor: " + Instructor + "\n" +
                              "Time: " + Time + "\n" +
                              "Days: " + Days);
            this.subject.PrintSubjectInfo();
        }
        
    }
}
