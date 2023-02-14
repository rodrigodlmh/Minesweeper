//----------------------------------------------------------------------
// <copyright file="Movie.cs" company="DO">
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
    /// The class which is used to represent a movie
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not taught.")]
    public class Movie
    {
        /// <summary>
        /// whether the movie supports 3d or not. 
        /// </summary>
        public bool Is3d;

        /// <summary>
        /// the rating of the movie
        /// </summary>
        public string Rating;

        /// <summary>
        /// how long is the movie in minutes
        /// </summary>
        public int Runtime;

        /// <summary>
        /// title of the movie
        /// </summary>
        public string Title;
    }
}
