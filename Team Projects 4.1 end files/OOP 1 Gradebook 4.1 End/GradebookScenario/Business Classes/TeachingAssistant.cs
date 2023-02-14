using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradebookScenario
{
    /// <summary>
    /// The class which is used to represent a teaching assistant.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class TeachingAssistant
    {
        /// <summary>
        /// The indicator of whether or not the teaching assistant is sleeping.
        /// </summary>
        public bool IsSleeping;

        /// <summary>
        /// The teaching assistant's name.
        /// </summary>
        public string Name;

        /// <summary>
        /// The teaching assistant's salary.
        /// </summary>
        public decimal Salary;
    }
}