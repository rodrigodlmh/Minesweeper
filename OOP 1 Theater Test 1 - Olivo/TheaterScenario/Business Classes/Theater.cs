//----------------------------------------------------------------------
// <copyright file="Theater.cs" company="DO">
//     Company copyright tag.
// </copyright>
//----------------------------------------------------------------------
namespace TheaterScenario
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The class which is used to represent a theater.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not taught.")]
    public class Theater
    {
        /// <summary>
        /// The name of the theater.
        /// </summary>
        public string Name;

        /// <summary>
        /// average movie run time at theater
        /// </summary>
        public double AverageMovieRunTime;

        /// <summary>
        /// List of movies in theater
        /// </summary>
        public List<Movie> Movies;

        /// <summary>
        /// te current movie in screening room
        /// </summary>
        public ScreeningRoom screeningRoom;
    }
}