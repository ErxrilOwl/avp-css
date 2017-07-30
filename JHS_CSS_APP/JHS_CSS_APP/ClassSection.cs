using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHS_CSS_APP
{
    class ClassSection : SubjectInterface
    {
        private string sectionID;
        private ArrayList subjectList;
        private ArrayList studentList;
        private Teacher adviser;

        public ClassSection()
        {
            sectionID = "";
            InitializeList();
        }

        public ClassSection(string sectionID) 
        {
            SectionID = sectionID;
            InitializeList();
        }

        private void InitializeList() 
        {
            this.subjectList = new ArrayList();
            this.studentList = new ArrayList();
        }

        public string SectionID
        {
            get { return sectionID; }
            set { sectionID = value; }
        }

        public Teacher Adviser
        {
            get { return adviser; }
            set { adviser = value; }
        }

        public void PrintAllSubjectList() 
        { 
            Console.WriteLine("Section " + SectionID + " Subject List : \n");
            foreach(Subject subj in subjectList)
            {
                subj.PrintSubjectInfo();
                Console.WriteLine();
            }
        }

        public void PrintAllStudentInfo()
        {
            Console.WriteLine("Section " + SectionID + " Student List : \n");
            foreach (Student stud in studentList)
            {
                stud.PrintStudentInfo();
                Console.WriteLine();
            }
        }

        public void AddSubject(Subject subj)
        {
            this.subjectList.Add(subj);
        }

        public void AddStudent(Student stud)
        {
            this.studentList.Add(stud);
        }

        public void RemoveSubject(Subject subj)
        {
            this.subjectList.Remove(subj);   
        }

        public void RemoveStudent(Student stud)
        {
            this.studentList.Remove(stud);
        }

        public ArrayList GetAllStudents()
        {
            return this.studentList;
        }

        public int GetTotalStudent() {
            return studentList.ToArray().Length;
        }

        public int GetTotalSubject()
        {
            return subjectList.ToArray().Length;
        }
    }
}
