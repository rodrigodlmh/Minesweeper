using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballScenario
{
    /// <summary>
    /// The class used to represent a kicker.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not taught.")]
    public class Kicker
    {
        /// <summary>
        /// The kicker's leg strength.
        /// </summary>
        public int LegStrength;

        /// <summary>
        /// The kicker's name.
        /// </summary>
        public string Name;

        /// <summary>
        /// The kicker's number.
        /// </summary>
        public int Number;

        /// <summary>
        /// The kicker's salary.
        /// </summary>
        public decimal Salary;

        /// <summary>
        /// The kicker's skill level.
        /// </summary>
        public int SkillLevel;

        /// <summary>
        /// Attempts to kick a field goal.
        /// </summary>
        /// <param name="fieldPosition">The team's current field position.</param>
        /// <returns>An indicator of whether or not the field goal was successful.</returns>
        public bool KickFieldGoal(double fieldPosition)
        {
            bool result = false;

            double accuracy = this.AimKick();

            result = this.Kick(fieldPosition, accuracy);

            return result;
        }

        /// <summary>
        /// Perform the kicking action.
        /// </summary>
        /// <param name="fieldPosition">The team's field position.</param>
        /// <param name="accuracy">The accuracy of the aim.</param>
        /// <returns>An indicator of whether or not the field goal was successful.</returns>
        private bool Kick(double fieldPosition, double accuracy)
        {
            bool result = false;

            // TODO: Determine whether or not the field goal was successful.

            // determine if kick was successful based on accuracy, field position, legstrength, and skill level.
            return result;
        }

        /// <summary>
        /// Aims the kick.
        /// </summary>
        /// <returns>The accuracy of the kick.</returns>
        private double AimKick()
        {
            double result = 0;

            // TODO : Determine accuracy based on the player's skill level.

            // Return the accuracy of the kick.
            return result;
        }
    }
}