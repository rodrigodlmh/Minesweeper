using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradebookScenario
{
    /// <summary>
    /// The class which is used to represent a gradebook.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class Gradebook
    {
        /// <summary>
        /// The gradebook's list of courses.
        /// </summary>
        public List<Course> Courses;

        /// <summary>
        /// The gradebook's current student.
        /// </summary>
        public Student CurrentStudent;

        /// <summary>
        /// An indicator of whether or not the gradebook system is online and available for use.
        /// </summary>
        public bool IsOnline;

        /// <summary>
        /// The gradebook's theme.
        /// </summary>
        public Theme MyTheme;

        /// <summary>
        /// The gradebook's student calendar.
        /// </summary>
        public Calendar StudentCalendar;

        /// <summary>
        /// The current version of the gradebook.
        /// </summary>
        public string Version;
    }
}