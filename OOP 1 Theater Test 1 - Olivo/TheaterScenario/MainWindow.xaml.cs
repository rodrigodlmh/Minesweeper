//----------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="DO">
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
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;

    /// <summary>
    /// Contains interaction logic for MainWindow.xaml.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not taught.")]
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The Marcus Theater.
        /// </summary>
        public Theater MarcusTheater;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Performs the initialization tasks outlined in Test 1.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void newTheaterButton_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the Theater class.
            MarcusTheater = new Theater();

            // Set the field values of the theater.
            MarcusTheater.Movies = new List<Movie>();
            MarcusTheater.Name = "Marcus Theater";
            MarcusTheater.screeningRoom = new ScreeningRoom();

            // Define a temporary movie variable.
            Movie movie = new Movie();

            // Create an instance of the Movie class.
            movie = new Movie();

            // Set field values of the movie.
            movie.Is3d = true;
            movie.Rating = "PG";
            movie.Runtime = 95;
            movie.Title = "Despicable Me";

            // Add the movie to the theater's list of movies.
            MarcusTheater.Movies.Add(movie);

            // Create an instance of the Movie class.
            movie = null;
            movie = new Movie();

            // Set field values of the movie.
            movie.Rating = "R";
            movie.Runtime = 175;
            movie.Title = "The Godfather";

            // Add the movie to the theater's list of movies.
            MarcusTheater.Movies.Add(movie);

            // Create an instance of the Movie class.
            movie = null;
            movie = new Movie();

            // Set field values of the movie.
            movie.Rating = "PG";
            movie.Runtime = 114;
            movie.Title = "August Rush";

            // Add the movie to the theater's list of movies.
            MarcusTheater.Movies.Add(movie);

            // Set field values of the screening room.
            MarcusTheater.screeningRoom.Is3dCapable = true;
            MarcusTheater.screeningRoom.nowShowing = MarcusTheater.Movies[2];
            MarcusTheater.screeningRoom.SeatingCapacity = 78;
        }

        /// <summary>
        /// Finds the rating of the movie "The Godfather" as outlined in Test 1.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void findGodfatherRatingButton_Click(object sender, RoutedEventArgs e)
        {
            // Define and initialize a local variable to store the movie.
            Movie GodfatherMovie = null;

            // Define a local variable to store the rating of the movie.
            string GodfatherRating;

            // Loop through the list of movies.
            for (int index = 0; index < MarcusTheater.Movies.Count(); index++)
            {
                // If The Godfather was found...
                if (MarcusTheater.Movies[index].Title == "The Godfather")
                {
                    // Store the current movie into the temporary variable.
                    GodfatherMovie = MarcusTheater.Movies[index];

                    // Break out of the loop.
                    break;
                }
            }

            // If The Godfather was found..
            if (GodfatherMovie != null)
            {
                // set a local variable to the rating of the movie.
                 GodfatherRating = GodfatherMovie.Rating;
            }
        }

        /// <summary>
        /// Calculates the average movie runtime as outlined in Test 1.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void calculateAverageRuntimeButton_Click(object sender, RoutedEventArgs e)
        {
            // Define and initialize an accumulator variable to hold the total of all movie runtimes.
            int TotaMovieRuntime = 0;

            // Loop through the list of movies.
            for (int index = 0; index < MarcusTheater.Movies.Count(); index++)
            {
                // Add the current movie's runtime to the total.
                TotaMovieRuntime += MarcusTheater.Movies[index].Runtime;
            }

            // Calculate the average runtime and assign it to the movie theater's corresponding field.
            MarcusTheater.AverageMovieRunTime = TotaMovieRuntime / MarcusTheater.Movies.Count();
        }
    }
}