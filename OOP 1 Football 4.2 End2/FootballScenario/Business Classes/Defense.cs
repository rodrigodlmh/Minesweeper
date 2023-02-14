using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballScenario
{
    /// <summary>
    /// The class that represents a football team's defense.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not taught.")]
    public class Defense
    {
        /// <summary>
        /// The type of coverage the defense will employ.
        /// </summary>
        public string CoverageType;

        /// <summary>
        /// The formation that the defense lines up in.
        /// </summary>
        public string Formation;

        /// <summary>
        /// The Defense's personnel grouping.
        /// </summary>
        public string PersonnelGrouping;

        /// <summary>
        /// The skill level of the defense (1-10).
        /// </summary>
        public int SkillLevel;

        /// <summary>
        /// The name of the football team that is on defense.
        /// </summary>
        public string TeamName;

        /// <summary>
        /// Readies the defensive players for the snap of the ball.
        /// </summary>
        public void ReadyForSnap()
        {
            // Sends the defensive players into formation.
        }

        /// <summary>
        /// Responds to the offense's hard count.
        /// </summary>
        public void RespondToHardCount()
        {
            // Respond to the quarterback's hard count.
        }

        /// <summary>
        /// Sends the defensive players onto the field.
        /// </summary>
        public void TakeTheField()
        {
            // Sends the defensive players onto the field.
        }
    }
}