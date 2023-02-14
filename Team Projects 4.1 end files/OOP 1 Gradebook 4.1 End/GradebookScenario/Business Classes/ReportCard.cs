using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradebookScenario
{
    /// <summary>
    /// The class which is used to represent a report card.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class ReportCard
    {
        /// <summary>
        /// The report card's cumulative grade point average.
        /// </summary>
        public double CumulativeGpa;

        /// <summary>
        /// The report card's list of grade records.
        /// </summary>
        public List<GradeRecord> Grades;

        /// <summary>
        /// The term of the report card.
        /// </summary>
        public string Term;
    }
}