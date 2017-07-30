using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHS_CSS_APP
{
    class Students : CollectionBase
    {
        public Student this[int index]
        {
            get {
                return (Student)List[index];
            }
            set {
                List[index] = value;
            }
        }

        public void Add(Student s)
        {
            List.Add(s);
        }

        public void Remove(Student s)
        {
            List.Remove(s);
        }

        public Student GetStudentByID(string studentID) 
        {
            foreach (Student student in List) {
                if (student.StudentNo == studentID) return student;
            }
            return null;
        }

    }
}
