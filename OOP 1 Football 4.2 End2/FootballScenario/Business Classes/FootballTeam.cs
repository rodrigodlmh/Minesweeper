using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballScenario
{
    /// <summary>
    /// The class used to represent a football team.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not taught.")]
    public class FootballTeam
    {
        /// <summary>
        /// The football team's stadium.
        /// </summary>
        public Stadium CityStadium;

        /// <summary>
        /// The team's field position.
        /// </summary>
        public int FieldPosition;

        /// <summary>
        /// The football team's head coach.
        /// </summary>
        public Coach HeadCoach;

        /// <summary>
        /// The location of the stadium.
        /// </summary>
        public string Location;

        /// <summary>
        /// The team's mascot.
        /// </summary>
        public Person Mascot;

        /// <summary>
        /// The name of the stadium.
        /// </summary>
        public string Name;

        /// <summary>
        /// The team's next play.
        /// </summary>
        public Play NextPlay;

        /// <summary>
        /// The skill level of the team's offense.
        /// </summary>
        public double OffenseSkillLevel;

        /// <summary>
        /// The opposing team.
        /// </summary>
        public Defense Opponent;

        /// <summary>
        /// The team's owner.
        /// </summary>
        public Person Owner;

        /// <summary>
        /// Kick a field goal.
        /// </summary>
        /// <returns>An indicator of whether or not the field goal kick was successful.</returns>
        public bool KickFieldGoal()
        {
            bool result = this.HeadCoach.CallFieldGoalPlay(this.FieldPosition);

            return result;
        }

        /// <summary>
        /// Reads the defense.
        /// </summary>
        public void ReadDefense()
        {
            this.HeadCoach.ReadDefense(this.Opponent);
        }
    }
}