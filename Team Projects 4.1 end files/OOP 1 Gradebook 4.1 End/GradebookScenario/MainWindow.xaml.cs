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

namespace GradebookScenario
{
    /// <summary>
    /// Contains interaction logic for MainWindow.xaml.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The school's Blackboard system.
        /// </summary>
        public Gradebook Blackboard;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Calculates a student's cumulative grade point average.
        /// </summary>
        /// <param name="student">The student for which to calculate the GPA.</param>
        /// <returns>The student's GPA.</returns>
        public double CalculateStudentGpa(Student student)
        {
            // Define a result variable to hold the student's GPA.
            double result;

            // Define and initialize an accumulator variable to hold the sum
            // of all of the student's grade point values.
            double gradePointTotal = 0;

            // Loop through the list of grade records.
            foreach (GradeRecord g in student.Transcript.Grades)
            {
                // Add the current record's grade point value to the accumulator variable.
                gradePointTotal += g.GradePointValue;
            }

            // Calculate the student's average GPA.
            result = gradePointTotal / student.Transcript.Grades.Count;

            // Return result.
            return result;
        }

        /// <summary>
        /// Finds a grade record from the specified student's transcript's list of grades.
        /// </summary>
        /// <param name="courseName">The name of the course to find within the student's transcript's grades list.</param>
        /// <param name="student">The student for which the grade record should be found.</param>
        /// <returns>The first grade record matching the specified courseName.</returns>
        public GradeRecord FindGradeRecord(string courseName, Student student)
        {
            // Define and initialize a result variable.
            GradeRecord result = null;

            // Loop through all grade records of the passed-in student.
            foreach (GradeRecord gr in student.Transcript.Grades)
            {
                // If the current grade record's course name matches the specified course name...
                if (gr.CourseName == courseName)
                {
                    // Set the result variable to the current grade record.
                    result = gr;

                    // Break out of the loop.
                    break;
                }
            }

            // Return the resulting grade record.
            return result;
        }

        /// <summary>
        /// Adds 1 to the percentage grade of the current student's OOP 1 grade record.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void add1ToOop1PercentageGradeButton_Click(object sender, RoutedEventArgs e)
        {
            // Define and set a variable to hold the desired grade record once it is found.
            GradeRecord gradeRecord = this.FindGradeRecord("OOP 1", this.Blackboard.CurrentStudent);

            // If the OOP 1 course was found...
            if (gradeRecord != null)
            {
                // Retrieve the grade record's letter grade and store it in a variable.
                gradeRecord.PercentageGrade += 1;
            }
        }

        /// <summary>
        /// Calculates the student's cumulative grade point average.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void calculateCurrentStudentGpaButton_Click(object sender, RoutedEventArgs e)
        {
            // Calculate the current student's GPA.
            double gpa = this.CalculateStudentGpa(this.Blackboard.CurrentStudent);

            // Set the current student's GPA.
            this.Blackboard.CurrentStudent.Transcript.CumulativeGpa = gpa;
        }

        /// <summary>
        /// Retrieves the student's letter grade for the course "Object-Oriented Programming 1".
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void findOop1LetterGradeButton_Click(object sender, RoutedEventArgs e)
        {
            // Define and set a variable to hold the desired grade record once it is found.
            GradeRecord gradeRecord = this.FindGradeRecord("OOP 1", this.Blackboard.CurrentStudent);

            // If the OOP 1 course was found...
            if (gradeRecord != null)
            {
                // Retrieve the grade record's letter grade and store it in a variable.
                string letterGrade = gradeRecord.LetterGrade;
            }
        }

        /// <summary>
        /// Creates a gradebook and related objects.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void newGradebookButton_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the Gradebook class.
            this.Blackboard = new Gradebook();

            // Set field values of Blackboard (except for current student).
            this.Blackboard.Courses = new List<Course>();
            this.Blackboard.IsOnline = false;
            this.Blackboard.MyTheme = new Theme();
            this.Blackboard.StudentCalendar = new Calendar();
            this.Blackboard.Version = "42.37.1.1";

            // Define a temporary course variable.
            Course course;

            // Create an instance of the Course class (OOP 1).
            course = new Course();

            // Set field values of the OOP 1 course.
            course.EnrollmentCapacity = 18;
            course.IsFull = true;
            course.Name = "OOP 1";
            course.Number = "10-152-311";

            // Add the OOP 1 course to the gradebook.
            this.Blackboard.Courses.Add(course);

            // Create an instance of the Course class (OOP 2).
            course = new Course();

            // Set field values of the OOP 2 course.
            course.EnrollmentCapacity = 24;
            course.IsFull = false;
            course.Name = "OOP 2";
            course.Number = "10-152-312";
            course.Roster = new List<Student>();

            // Define a temporary student variable.
            Student student;

            // Create an instance of the Student class (Arthur).
            student = new Student();

            // Set field values of Arthur.
            student.Advisor = new Instructor();
            student.Id = 123456789;
            student.IsOnProbation = true;
            student.Name = "Arthur";
            student.ProgramName = "Computer Science";
            student.Transcript = new ReportCard();

            // Set field values of the advisor.
            student.Advisor.Assistant = new TeachingAssistant();
            student.Advisor.EmployeeNumber = 987654321;
            student.Advisor.Name = "Plato";
            student.Advisor.ProgramName = "Computer Science";

            // Set field values of the assistant.
            student.Advisor.Assistant.IsSleeping = true;
            student.Advisor.Assistant.Name = "Leon";
            student.Advisor.Assistant.Salary = 10500m;

            // Set field values of Arthur's transcript.
            student.Transcript.CumulativeGpa = 3.5;
            student.Transcript.Grades = new List<GradeRecord>();
            student.Transcript.Term = "2013-Fall";

            // Define a temporary grade record variable.
            GradeRecord gradeRecord;

            // Create an instance of the GradeRecord class (Database Concepts).
            gradeRecord = new GradeRecord();

            // Set field values of the Database Concepts grade record.
            gradeRecord.CourseName = "Database Concepts";
            gradeRecord.GradePointValue = 4.0;
            gradeRecord.LetterGrade = "A";
            gradeRecord.PercentageGrade = 0.94;

            // Add the Database Concepts grade record to the transcript's list of grades.
            student.Transcript.Grades.Add(gradeRecord);

            // Create an instance of the GradeRecord class (Web Design 1).
            gradeRecord = new GradeRecord();

            // Set field values of the Web Design 1 grade record.
            gradeRecord.CourseName = "Web Design 1";
            gradeRecord.GradePointValue = 3.0;
            gradeRecord.LetterGrade = "B";
            gradeRecord.PercentageGrade = 0.82;

            // Add the Web Design 1 grade record to the transcript's list of grades.
            student.Transcript.Grades.Add(gradeRecord);

            // Create an instance of the GradeRecord class (OOP 1).
            gradeRecord = new GradeRecord();

            // Set field values of the OOP 1 grade record.
            gradeRecord.CourseName = "OOP 1";
            gradeRecord.GradePointValue = 3.0;
            gradeRecord.LetterGrade = "B";
            gradeRecord.PercentageGrade = 0.85;

            // Add the OOP 1 grade record to the transcript's list of grades.
            student.Transcript.Grades.Add(gradeRecord);

            // Set Arthur to be the current student.
            this.Blackboard.CurrentStudent = student;

            // Add Arthur to the OOP 2 roster.
            course.Roster.Add(student);

            // Create an instance of the Student class (Pete).
            student = new Student();

            // Set field values of Pete.
            student.Id = 543219876;
            student.IsOnProbation = false;
            student.Name = "Pete";
            student.ProgramName = "Computer Science";
            student.Transcript = new ReportCard();

            // Set field values of Pete's transcript.
            student.Transcript.CumulativeGpa = 4;
            student.Transcript.Term = "2013-Fall";

            // Add Pete to the Roster.
            course.Roster.Add(student);

            // Create an instance of the Student class (Gwen).
            student = new Student();

            // Set field values of Gwen.
            student.Id = 987612345;
            student.IsOnProbation = true;
            student.Name = "Gwen";
            student.ProgramName = "Computer Science";
            student.Transcript = new ReportCard();

            // Set field values of Gwen's transcript.
            student.Transcript.CumulativeGpa = 2.67;
            student.Transcript.Term = "2013-Fall";

            // Add Gwen to the Roster.
            course.Roster.Add(student);

            // Add the OOP 2 course to the gradebook.
            this.Blackboard.Courses.Add(course);

            // Set field values of my theme.
            this.Blackboard.MyTheme.BackgroundColor = "White";
            this.Blackboard.MyTheme.FontColor = "Blue";
            this.Blackboard.MyTheme.FontIsBold = true;
            this.Blackboard.MyTheme.FontIsItalic = false;
            this.Blackboard.MyTheme.FontName = "Arial";
            this.Blackboard.MyTheme.FontSize = 10.5;
            this.Blackboard.MyTheme.IsHighContrast = false;
            this.Blackboard.MyTheme.Name = "NTC Default";

            // Set field values of the student calendar.
            this.Blackboard.StudentCalendar.CurrentDayName = "Monday";
            this.Blackboard.StudentCalendar.CurrentDayNumber = 26;
            this.Blackboard.StudentCalendar.CurrentMonth = "August";
            this.Blackboard.StudentCalendar.CurrentYear = 2042;
            this.Blackboard.StudentCalendar.ViewStyle = "Month";
        }
    }
}