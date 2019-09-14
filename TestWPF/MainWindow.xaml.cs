using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace TestWPF
{
    /// <summary>
    /// MainWindow.xaml 
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Person> students = new List<Person>();
        bool isPersonChanging = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddStudentButton_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem studentListBoxItem = new ListBoxItem();
            studentListBoxItem.Content = LastNameTextBox.Text + " " + FirstNameTextBox.Text;
            StudentsListBox.Items.Add(studentListBoxItem);
            if(LevelBox.Text=="Undergraduate")
            {
                UndergraduateStudent tempStudent = new UndergraduateStudent();
                tempStudent.Age = Convert.ToInt32(AgeTextBox.Text);
                tempStudent.FirstName = FirstNameTextBox.Text;
                tempStudent.LastName = LastNameTextBox.Text;
                tempStudent.Gender = GenderBox.SelectedIndex;
                tempStudent.StudentID = Convert.ToInt32(StudentIDTextBox.Text);
                students.Add(tempStudent);
            }
            else
            {
                GraduateStudent tempStudent = new GraduateStudent();
                tempStudent.Age = Convert.ToInt32(AgeTextBox.Text);
                tempStudent.FirstName = FirstNameTextBox.Text;
                tempStudent.LastName = LastNameTextBox.Text;
                tempStudent.Gender = GenderBox.SelectedIndex;
                tempStudent.StudentID = Convert.ToInt32(StudentIDTextBox.Text);
                students.Add(tempStudent);
            }
            StudentsListBox.SelectedItem = StudentsListBox.Items.GetItemAt(StudentsListBox.Items.Count - 1);
        }
        private void StudentsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int studentIndex = StudentsListBox.SelectedIndex;
            FirstNameTextBox.Text = students[studentIndex].FirstName;
            LastNameTextBox.Text = students[studentIndex].LastName;
            StudentIDTextBox.Text = students[studentIndex].StudentID.ToString();
            GenderBox.SelectedIndex = students[studentIndex].Gender;
            AgeTextBox.Text = students[studentIndex].Age.ToString();
            if(students[studentIndex].IsGraduate==false)
            {
                LevelBox.SelectedIndex = 0;
            }
            else
            {
                LevelBox.SelectedIndex = 1;
            }
            isPersonChanging = true;
            CoursessListBox.Items.Clear();
            CourseNameTextBox.Text = "";
            CourseNumberTextBox.Text = "";
            CreditHoursTextBox.Text = "";
            GPATextBox.Text = "";
            foreach(var currentCourse in students[studentIndex].AddCourse)
            {
                ListBoxItem tempCourse = new ListBoxItem();
                tempCourse.Content = currentCourse.CourseName;
                CoursessListBox.Items.Add(tempCourse);
            }
            isPersonChanging = false;
        }
        private void CourseNumberTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void AddCourseButton_Click(object sender, RoutedEventArgs e)
        {
            if (StudentsListBox.Items.Count!=0)
            {
                int currentStudent = StudentsListBox.SelectedIndex;
                if (Convert.ToInt32(CourseNumberTextBox.Text) >= 5000)
                {
                    if (students[currentStudent].IsGraduate == false)
                    {
                        MessageBox.Show("Undergraduate Student cannot add graduate course!");
                    }
                    else
                    {
                        Course tempCourse = new Course();
                        tempCourse.CourseGPA = Convert.ToDouble(GPATextBox.Text);
                        tempCourse.CourseName = CourseNameTextBox.Text;
                        tempCourse.CourseNumber = Convert.ToInt32(CourseNumberTextBox.Text);
                        tempCourse.CreditHours = Convert.ToInt32(CreditHoursTextBox.Text);
                        students[currentStudent].AddCourse.Add(tempCourse);
                        ListBoxItem courseListboxItem = new ListBoxItem();
                        courseListboxItem.Content = tempCourse.CourseName;
                        CoursessListBox.Items.Add(courseListboxItem);
                        TotalGPATextBox.Text = students[currentStudent].calculateGPA().ToString();
                    }
                }
                else
                {
                    if (students[currentStudent].IsGraduate != false)
                    {
                        MessageBox.Show("Graduate Student cannot add undergraduate course!");
                    }
                    else
                    {
                        Course tempCourse = new Course();
                        tempCourse.CourseGPA = Convert.ToDouble(GPATextBox.Text);
                        tempCourse.CourseName = CourseNameTextBox.Text;
                        tempCourse.CourseNumber = Convert.ToInt32(CourseNumberTextBox.Text);
                        tempCourse.CreditHours = Convert.ToInt32(CreditHoursTextBox.Text);
                        students[currentStudent].AddCourse.Add(tempCourse);
                        ListBoxItem courseListboxItem = new ListBoxItem();
                        courseListboxItem.Content = tempCourse.CourseName;
                        CoursessListBox.Items.Add(courseListboxItem);
                        TotalGPATextBox.Text = students[currentStudent].calculateGPA().ToString();
                    }
                }
            }
        }

        private void CoursessListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isPersonChanging == false)
            {
                Course selectedCourse = students[StudentsListBox.SelectedIndex].AddCourse[CoursessListBox.SelectedIndex];
                CourseNameTextBox.Text = selectedCourse.CourseName;
                CourseNumberTextBox.Text = selectedCourse.CourseNumber.ToString();
                CreditHoursTextBox.Text = selectedCourse.CreditHours.ToString();
                GPATextBox.Text = selectedCourse.CourseGPA.ToString();
            }
        }
    }
}
