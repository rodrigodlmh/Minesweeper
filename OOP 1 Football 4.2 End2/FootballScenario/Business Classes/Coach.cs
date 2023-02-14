using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballScenario
{
    /// <summary>
    /// The class used to represent a coach.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not taught.")]
    public class Coach
    {
        /// <summary>
        /// The team's primary quarterback.
        /// </summary>
        public Quarterback JoeCool;

        /// <summary>
        /// The coach's kicker.
        /// </summary>
        public Kicker Kicker;

        /// <summary>
        /// The coach's name.
        /// </summary>
        public string Name;

        /// <summary>
        /// The playbook containing plays for the team's offense.
        /// </summary>
        public Playbook OffensivePlaybook;

        /// <summary>
        /// The coach's annual salary.
        /// </summary>
        public decimal Salary;

        /// <summary>
        /// Sends the kicker to the field to attempt a field goal.
        /// </summary>
        /// <param name="fieldPosition">The team's field position.</param>
        /// <returns>An indicator of whether or not the field goal attempt was successful.</returns>
        public bool CallFieldGoalPlay(int fieldPosition)
        {
            // Request that the kicker kick a field goal.
            bool result = this.Kicker.KickFieldGoal(fieldPosition);

            // Return an indicator of whether or not the field goal was successful.
            return result;
        }

        /// <summary>
        /// Reads the defense personnel grouping and requests that the quarterback break the huddle.
        /// </summary>
        /// <param name="defense">The opposing, defensive team.</param>
        public void ReadDefense(Defense defense)
        {
            // Read defense's personel grouping by sending our players onto the field.
            this.TakeTheField(defense);

            // TODO : Senlect a play (chosen based on the defenses personel grouping to the quarterback.

            // Have the quarterback break the huddle to line up to run the play.
            this.JoeCool.BreakHuddle(defense);
        }

        /// <summary>
        /// Takes the football field.
        /// </summary>
        /// <param name="defense">The defensive team.</param>
        private void TakeTheField(Defense defense)
        {
            // Send the offensive players onto the field.

            // This prompts the defense to take the field, revealing their personel grouping.
            defense.TakeTheField();
        }
    }
}