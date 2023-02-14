using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballScenario
{
    /// <summary>
    /// The class used to represent a coach.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not taught.")]
    public class Quarterback
    {
        /// <summary>
        /// The quarterback's arm strength (on a scale from 0 to 100).
        /// </summary>
        public int ArmStrength;

        /// <summary>
        /// The quarterback's name.
        /// </summary>
        public string Name;

        /// <summary>
        /// The quarterback's jersey number.
        /// </summary>
        public int Number;

        /// <summary>
        /// The quarterback's list of teammates.
        /// </summary>
        public List<Player> OffensiveTeammates;

        /// <summary>
        /// The quarterback's annual salary.
        /// </summary>
        public decimal Salary;

        /// <summary>
        /// The quarterback's skill level (on a scale from 0 to 100).
        /// </summary>
        public int SkillLevel;

        /// <summary>
        /// The quarterback's target.
        /// </summary>
        public Player Target;

        /// <summary>
        /// The quarterback's weight (in pounds).
        /// </summary>
        public double Weight;

        /// <summary>
        /// Breaks the offensive huddle.
        /// </summary>
        /// <param name="defense">The defensive team.</param>
        public void BreakHuddle(Defense defense)
        {
            // Breaks the huddle and prepares to run the play by lining up, prompting the defense
            // to prepare for the snap. This reveals the defense's formation.
            defense.ReadyForSnap();

            // Initiate a hard count.
            this.HardCount(defense);
        }

        /// <summary>
        /// Initiate a hard-count.
        /// </summary>
        /// <param name="defense">The defensive team.</param>
        public void HardCount(Defense defense)
        {
            // Executes a hard count to get the defense to indicate their coverage.
            defense.RespondToHardCount();
        }
    }
}