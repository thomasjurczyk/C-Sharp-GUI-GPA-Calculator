using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWPF
{
    class GraduateStudent : Person
    {
        public GraduateStudent()
        {
            isGraduate = true;
        }
        public bool addCourse(Course courseToAdd)
        {
            if (courseToAdd.CourseNumber >= 5000)
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
