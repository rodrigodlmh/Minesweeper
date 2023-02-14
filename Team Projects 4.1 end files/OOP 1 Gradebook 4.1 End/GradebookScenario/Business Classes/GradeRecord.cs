using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradebookScenario
{
    /// <summary>
    /// The class which is used to represent a grade record.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class GradeRecord
    {
        /// <summary>
        /// The grade record's course name.
        /// </summary>
        public string CourseName;

        /// <summary>
        /// The grade point value of the grade record.
        /// </summary>
        public double GradePointValue;

        /// <summary>
        /// The letter grade of the grade record.
        /// </summary>
        public string LetterGrade;

        /// <summary>
        /// The percentage grade of the grade record.
        /// </summary>
        public double PercentageGrade;
    }
}