using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWPF
{
    class Course
    {
        private string courseName;
        private int courseNumber;
        private int creditHours;
        private double courseGPA;

        public string CourseName
        {
            get
            {
                return courseName;
            }
            set
            {
                courseName = value;
            }
        }
        public int CourseNumber
        {
            get
            {
                return courseNumber;
            }
            set
            {
                courseNumber = value;
            }
        }
        public int CreditHours
        {
            get
            {
                return creditHours;
            }
            set
            {
                creditHours = value;
            }
        }
        public double CourseGPA
        {
            get
            {
                return courseGPA;
            }
            set
            {
                courseGPA = value;
            }
        }
    }
}
