using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballScenario
{
    /// <summary>
    /// The class that represents a football team's playbook.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not taught.")]
    public class Playbook
    {
        /// <summary>
        /// The number of pages in the playbook.
        /// </summary>
        public int PageCount;

        /// <summary>
        /// The playbook's list of plays.
        /// </summary>
        public List<Play> Plays;

        /// <summary>
        /// The type of playbook.
        /// </summary>
        public string Type;
    }
}