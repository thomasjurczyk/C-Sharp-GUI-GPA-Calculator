using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWPF
{
    class UndergraduateStudent : Person
    {
        public UndergraduateStudent()
        {
            isGraduate = false;
        }
        public bool addCourse(Course courseToAdd)
        {
            if(courseToAdd.CourseNumber>=5000)
            {
                return false;
            }
            else
            {
                courses.Add(courseToAdd);
                return true;
            }
        }
    }
}
