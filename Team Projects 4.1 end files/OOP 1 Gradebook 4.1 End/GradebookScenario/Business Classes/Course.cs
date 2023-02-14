using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradebookScenario
{
    /// <summary>
    /// The class which is used to represent a course.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class Course
    {
        /// <summary>
        /// The maximum number of students that can be enrolled in the course.
        /// </summary>
        public int EnrollmentCapacity;

        /// <summary>
        /// An indicator of whether or not the course is full.
        /// </summary>
        public bool IsFull;

        /// <summary>
        /// The name of the course.
        /// </summary>
        public string Name;

        /// <summary>
        /// The catalog number of the course.
        /// </summary>
        public string Number;

        /// <summary>
        /// A list of all students currently enrolled in the course.
        /// </summary>
        public List<Student> Roster;
    }
}