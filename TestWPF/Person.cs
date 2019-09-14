using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWPF
{
    abstract class Person
    {
        private string firstName;
        private string lastName;
        /// <summary>
        /// 0 for male
        /// 1 for female
        /// 2 for other
        /// </summary>
        private int gender;
        private int age;
        private int studentID;
        protected List<Course> courses = new List<Course>();
        protected bool isGraduate;

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        public int Gender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }
        public int StudentID
        {
            get
            {
                return studentID;
            }
            set
            {
                studentID = value;
            }
        }
        public bool IsGraduate
        {
            get
            {
                return isGraduate;
            }
        }
        public List<Course> AddCourse
        {
            get
            {
                return courses;
            }
        }
        public double calculateGPA()
        {
            double addedUpGPA=0;
            double addedUpCreditHours = 0;
            foreach(var currentCourse in courses)
            {
                addedUpGPA += currentCourse.CourseGPA * currentCourse.CreditHours;
                addedUpCreditHours += currentCourse.CreditHours;
            }
            return addedUpGPA / addedUpCreditHours;
        }
    }
}
