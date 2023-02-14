using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradebookScenario
{
    /// <summary>
    /// The class which is used to represent an instructor.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class Instructor
    {
        /// <summary>
        /// The instructor's assistant.
        /// </summary>
        public TeachingAssistant Assistant;

        /// <summary>
        /// The instructor's employee number.
        /// </summary>
        public int EmployeeNumber;

        /// <summary>
        /// The instructor's name.
        /// </summary>
        public string Name;

        /// <summary>
        /// The program area in which the instructor primarily teaches.
        /// </summary>
        public string ProgramName;
    }
}