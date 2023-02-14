using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradebookScenario
{
    /// <summary>
    /// The class which is used to represent a student.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class Student
    {
        /// <summary>
        /// The student's advisor.
        /// </summary>
        public Instructor Advisor;

        /// <summary>
        /// The student's ID number.
        /// </summary>
        public int Id;

        /// <summary>
        /// An indicator of whether or not the student is on probation.
        /// </summary>
        public bool IsOnProbation;

        /// <summary>
        /// The student's name.
        /// </summary>
        public string Name;

        /// <summary>
        /// The name of the program that the student is enrolled in.
        /// </summary>
        public string ProgramName;

        /// <summary>
        /// The student's transcript.
        /// </summary>
        public ReportCard Transcript;
    }
}