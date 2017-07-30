using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHS_CSS_APP
{
    class Subject
    {
        private string subjID;
        private string description;
        private double unit;
        private double hourPerWeek;

        public string SubjID
        {
            get { return subjID; }
            set { subjID = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public double Unit
        {
            get { return unit; }
            set { unit = value; }
        }

        public double HourPerWeek
        {
            get { return hourPerWeek; }
            set { hourPerWeek = value; }
        }

        public void PrintSubjectInfo()
        {
            Console.WriteLine("Subj ID: " + SubjID + "\n" + 
                              "Description : " + Description + "\n" + 
                              "Unit: " + Unit + "\n" +
                              "Hrs Per Week: " + HourPerWeek);
        }
        
        
    }
}
