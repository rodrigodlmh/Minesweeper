using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradebookScenario
{
    /// <summary>
    /// The class which is used to represent a calendar.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not yet taught.")]
    public class Calendar
    {
        /// <summary>
        /// The name of the calendar's current day.
        /// </summary>
        public string CurrentDayName;

        /// <summary>
        /// The number of the calendar's current day.
        /// </summary>
        public int CurrentDayNumber;

        /// <summary>
        /// The name of the calendar's current month.
        /// </summary>
        public string CurrentMonth;

        /// <summary>
        /// The number of the calendar's current year.
        /// </summary>
        public int CurrentYear;

        /// <summary>
        /// The calendar's viewing style.
        /// </summary>
        public string ViewStyle;
    }
}