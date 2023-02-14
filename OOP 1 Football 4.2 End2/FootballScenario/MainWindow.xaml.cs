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
using System.Windows.Shapes;

namespace FootballScenario
{
    /// <summary>
    /// Contains interaction logic for MainWindow.xaml.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Encapsulation not taught.")]
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The application's football team.
        /// </summary>
        public FootballTeam WuvLuvs;

        /// <summary>
        /// The application's second football team.
        /// </summary>
        public FootballTeam Legomen;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Finds the first play in the team's playbook matching a given formation.
        /// </summary>
        /// <param name="formation">The formation of the play to be found.</param>
        /// <returns>The found play.</returns>
        public Play FindPlay(string formation)
        {
            // Define and initialize a result variable.
            Play result = null;

            // Loop through all of the plays in the playbook.
            foreach (Play o in this.Legomen.HeadCoach.OffensivePlaybook.Plays)
            {
                // If a play of the desired formation was found.
                if (o.Formation == formation)
                {
                    // Set the temporary variable to the current play.
                    result = o;

                    break;
                }
            }

            // Return the result.
            return result;
        }

        /// <summary>
        /// Finds the player with the passed in name.
        /// </summary>
        /// <param name="name">The name of the player to be returned.</param>
        /// <returns>The first player in quarterback's teammates list with the passed in name.</returns>
        public Player FindPlayer(string name)
        {
            // Define a result variable.
            Player result = null;

            // Loop through all of the quarterback's offensive team-mates.
            foreach (Player p in this.Legomen.HeadCoach.JoeCool.OffensiveTeammates)
            {
                // If a player with the desired name was found.
                if (p.Name == name)
                {
                    // Set the temporary variable to the current player.
                    result = p;
                }
            }

            // Return result.
            return result;
        }

        /// <summary>
        /// Performs the tasks outlined in assignment 1.2.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void assignment12Button_Click(object sender, RoutedEventArgs e)
        {
            // 1) Define variable    3) Assign new object to variable    2) Create football team object
            // FootballTeam wuvLuvs  =                                   new FootballTeam();

            // Create an instance of the FootballTeam class.
            FootballTeam wuvLuvs = new FootballTeam();

            // Set field values of the football team.
            wuvLuvs.CityStadium = new Stadium();
            wuvLuvs.HeadCoach = new Coach();
            wuvLuvs.Location = "Wausau";
            wuvLuvs.Name = "Wausau Wuv Luv's";

            // Set field values of the city stadium.
            wuvLuvs.CityStadium.Capacity = 7650;
            wuvLuvs.CityStadium.ConcessionStand = new Stand();
            wuvLuvs.CityStadium.Name = "City Stadium";
            wuvLuvs.CityStadium.SouvenirStand = new Stand();

            // Set field values of the concession stand.
            wuvLuvs.CityStadium.ConcessionStand.MoneyBalance = 350;
            wuvLuvs.CityStadium.ConcessionStand.QuantityOnHand = 500;
            wuvLuvs.CityStadium.ConcessionStand.QuantitySold = 0;
            wuvLuvs.CityStadium.ConcessionStand.Type = "Pizza";

            // Set field values of the souvenir stand.
            wuvLuvs.CityStadium.SouvenirStand.MoneyBalance = 420.5m;
            wuvLuvs.CityStadium.SouvenirStand.QuantityOnHand = 150;
            wuvLuvs.CityStadium.SouvenirStand.QuantitySold = 0;
            wuvLuvs.CityStadium.SouvenirStand.Type = "Foam Beak";

            // Set field values of the coach.
            wuvLuvs.HeadCoach.Name = "Bart";
            wuvLuvs.HeadCoach.Salary = 325000;
        }

        /// <summary>
        /// Performs the tasks outlined in assignment 2.1.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void assignment21Button_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the FootballTeam class.
            this.WuvLuvs = new FootballTeam();

            // Set field values of the Wuv Luvs team.
            this.WuvLuvs.CityStadium = new Stadium();
            this.WuvLuvs.HeadCoach = new Coach();
            this.WuvLuvs.Location = "Wausau";
            this.WuvLuvs.Mascot = new Person();
            this.WuvLuvs.Name = "Wausau Wuv Luvs";
            this.WuvLuvs.Owner = new Person();

            // Set field values of City Stadium.
            this.WuvLuvs.CityStadium.Capacity = 13500;
            this.WuvLuvs.CityStadium.ConcessionStand = new Stand();
            this.WuvLuvs.CityStadium.Name = "City Stadium";
            this.WuvLuvs.CityStadium.SouvenirStand = new Stand();

            // Set field values of the concession stand.
            this.WuvLuvs.CityStadium.ConcessionStand.MoneyBalance = 550m;
            this.WuvLuvs.CityStadium.ConcessionStand.QuantityOnHand = 490;
            this.WuvLuvs.CityStadium.ConcessionStand.QuantitySold = 10;
            this.WuvLuvs.CityStadium.ConcessionStand.Type = "Pizza";

            // Set field values of the souvenir stand.
            this.WuvLuvs.CityStadium.SouvenirStand.MoneyBalance = 720.5m;
            this.WuvLuvs.CityStadium.SouvenirStand.QuantityOnHand = 130;
            this.WuvLuvs.CityStadium.SouvenirStand.QuantitySold = 20;
            this.WuvLuvs.CityStadium.SouvenirStand.Type = "Foam Beak";

            // Set field values of the head coach.
            this.WuvLuvs.HeadCoach.JoeCool = new Quarterback();
            this.WuvLuvs.HeadCoach.Name = "Bart";
            this.WuvLuvs.HeadCoach.Salary = 352100m;

            // Set field values of Joe Cool.
            this.WuvLuvs.HeadCoach.JoeCool.ArmStrength = 86;
            this.WuvLuvs.HeadCoach.JoeCool.Name = "Joe Cool";
            this.WuvLuvs.HeadCoach.JoeCool.Number = 16;
            this.WuvLuvs.HeadCoach.JoeCool.Salary = 21500680m;
            this.WuvLuvs.HeadCoach.JoeCool.SkillLevel = 93;
            this.WuvLuvs.HeadCoach.JoeCool.Weight = 220.3;

            // Set field values of the mascot.
            this.WuvLuvs.Mascot.IsInCostume = true;
            this.WuvLuvs.Mascot.Name = "Svanhilde";

            // Set field values of the owner.
            this.WuvLuvs.Owner.IsInCostume = false;
            this.WuvLuvs.Owner.Name = "Dominic";
        }

        /// <summary>
        /// Performs the tasks outlined in assignment 2.2.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void assignment22Button_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the FootballTeam class.
            this.WuvLuvs = new FootballTeam();

            // Set field values of the Wuv Luvs team.
            this.WuvLuvs.HeadCoach = new Coach();
            this.WuvLuvs.Location = "Wausau";
            this.WuvLuvs.Mascot = new Person();
            this.WuvLuvs.Name = "Wausau Wuv Luvs";
            this.WuvLuvs.Opponent = new Defense();
            this.WuvLuvs.Owner = new Person();

            // Set field values of the head coach.
            this.WuvLuvs.HeadCoach.JoeCool = new Quarterback();
            this.WuvLuvs.HeadCoach.Name = "Bart";
            this.WuvLuvs.HeadCoach.OffensivePlaybook = new Playbook();
            this.WuvLuvs.HeadCoach.Salary = 352100m;

            // Set field values of Joe Cool.
            this.WuvLuvs.HeadCoach.JoeCool.ArmStrength = 92;
            this.WuvLuvs.HeadCoach.JoeCool.Name = "Joe Cool";
            this.WuvLuvs.HeadCoach.JoeCool.Number = 16;
            this.WuvLuvs.HeadCoach.JoeCool.Salary = 21500680m;
            this.WuvLuvs.HeadCoach.JoeCool.SkillLevel = 93;
            this.WuvLuvs.HeadCoach.JoeCool.Weight = 224.7;

            // Set field values of the playbook.
            this.WuvLuvs.HeadCoach.OffensivePlaybook.PageCount = 315;
            this.WuvLuvs.HeadCoach.OffensivePlaybook.Type = "Offense";

            // Set field values of the mascot.
            this.WuvLuvs.Mascot.IsInCostume = false;
            this.WuvLuvs.Mascot.Name = "Svanhilde";

            // Set field values of the opponent.
            this.WuvLuvs.Opponent.CoverageType = "Man";
            this.WuvLuvs.Opponent.Formation = "3-4";
            this.WuvLuvs.Opponent.SkillLevel = 8;
            this.WuvLuvs.Opponent.TeamName = "Brookfield Beanie Babies";

            // Set field values of the owner.
            this.WuvLuvs.Owner.IsInCostume = false;
            this.WuvLuvs.Owner.Name = "Dominic";
        }

        /// <summary>
        /// Performs the initialization tasks outlined in assignment 3.1.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void assignment31NewFootballTeamButton_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the FootballTeam class.
            this.WuvLuvs = new FootballTeam();

            // Set field values of the WuvLuvs.
            this.WuvLuvs.HeadCoach = new Coach();
            this.WuvLuvs.Location = "Wausau";
            this.WuvLuvs.Name = "Wausau Wuv Luvs";
            this.WuvLuvs.Opponent = new Defense();

            // Set field values of the opponent.
            this.WuvLuvs.Opponent.CoverageType = "Man";
            this.WuvLuvs.Opponent.Formation = "3-4";
            this.WuvLuvs.Opponent.SkillLevel = 8;
            this.WuvLuvs.Opponent.TeamName = "LaCrosse Legomen";

            // Set field values of the head coach.
            this.WuvLuvs.HeadCoach.JoeCool = new Quarterback();
            this.WuvLuvs.HeadCoach.Name = "Bart";
            this.WuvLuvs.HeadCoach.OffensivePlaybook = new Playbook();
            this.WuvLuvs.HeadCoach.Salary = 325100m;

            // Set field values of JoeCool.
            this.WuvLuvs.HeadCoach.JoeCool.ArmStrength = 92;
            this.WuvLuvs.HeadCoach.JoeCool.Name = "Joe Cool";
            this.WuvLuvs.HeadCoach.JoeCool.Number = 16;
            this.WuvLuvs.HeadCoach.JoeCool.OffensiveTeammates = new List<Player>();
            this.WuvLuvs.HeadCoach.JoeCool.Salary = 12500680m;
            this.WuvLuvs.HeadCoach.JoeCool.SkillLevel = 93;
            this.WuvLuvs.HeadCoach.JoeCool.Weight = 224.7;

            // Define a temporary player variable.
            Player player;

            // Create an instance of the player class.
            player = new Player();

            // Set field values of the player.
            player.IsEligibleReceiver = true;
            player.Name = "Jordy Nelson";
            player.Number = 87;
            player.Salary = 3750264m;
            player.SkillLevel = 96;
            player.Weight = 217.3;

            // Add the player to JoeCool's offensive teammates list.
            this.WuvLuvs.HeadCoach.JoeCool.OffensiveTeammates.Add(player);

            // Create an instance of the player class.
            player = new Player();

            // Set field values of the player.
            player.IsEligibleReceiver = true;
            player.Name = "Randall Cobb";
            player.Number = 18;
            player.Salary = 875297m;
            player.SkillLevel = 93;
            player.Weight = 191.8;

            // Add the player to JoeCool's offensive teammates list.
            this.WuvLuvs.HeadCoach.JoeCool.OffensiveTeammates.Add(player);

            // Create an instance of the player class.
            player = new Player();

            // Set field values of the player.
            player.IsEligibleReceiver = true;
            player.Name = "Jermichael Finley";
            player.Number = 88;
            player.Salary = 8751882m;
            player.SkillLevel = 91;
            player.Weight = 247;

            // Add the player to JoeCool's offensive teammates list.
            this.WuvLuvs.HeadCoach.JoeCool.OffensiveTeammates.Add(player);

            // Create an instance of the player class.
            player = new Player();

            // Set field values of the player.
            player.IsEligibleReceiver = false;
            player.Name = "Evan Dietrich-Smith";
            player.Number = 62;
            player.Salary = 1323442m;
            player.SkillLevel = 74;
            player.Weight = 308.1;

            // Add the player to JoeCool's offensive teammates list.
            this.WuvLuvs.HeadCoach.JoeCool.OffensiveTeammates.Add(player);

            // Create an instance of the player class.
            player = new Player();

            // Set field values of the player.
            player.IsEligibleReceiver = true;
            player.Name = "Eddie Lacy";
            player.Number = 27;
            player.Salary = 616802m;
            player.SkillLevel = 85;
            player.Weight = 229.8;

            // Add the player to JoeCool's offensive teammates list.
            this.WuvLuvs.HeadCoach.JoeCool.OffensiveTeammates.Add(player);

            // Set field values of the playbook.
            this.WuvLuvs.HeadCoach.OffensivePlaybook.PageCount = 315;
            this.WuvLuvs.HeadCoach.OffensivePlaybook.Plays = new List<Play>();
            this.WuvLuvs.HeadCoach.OffensivePlaybook.Type = "Offense";

            // Create a temporary play variable.
            Play play;

            // Create an instance of the play class.
            play = new Play();

            // Set field values of the play.
            play.Formation = "Spread";
            play.MaxGain = 99;
            play.MinGain = 60;
            play.Name = "Hail Mary";
            play.SuccessRate = 0.25;

            // Add the play to the playbook.
            this.WuvLuvs.HeadCoach.OffensivePlaybook.Plays.Add(play);

            // Create an instance of the play class.
            play = new Play();

            // Set field values of the play.
            play.Formation = "Offset I";
            play.MaxGain = 30;
            play.MinGain = 4;
            play.Name = "Sweep";
            play.SuccessRate = 0.65;

            // Add the play to the playbook.
            this.WuvLuvs.HeadCoach.OffensivePlaybook.Plays.Add(play);

            // Create an instance of the play class.
            play = new Play();

            // Set field values of the play.
            play.Formation = "Pro Set";
            play.MaxGain = 20;
            play.MinGain = 2;
            play.Name = "Dive";
            play.SuccessRate = 0.75;

            // Add the play to the playbook.
            this.WuvLuvs.HeadCoach.OffensivePlaybook.Plays.Add(play);

            // Create an instance of the play class.
            play = new Play();

            // Set field values of the play.
            play.Formation = "Pro Set";
            play.MaxGain = 40;
            play.MinGain = 1;
            play.Name = "Screen";
            play.SuccessRate = 0.50;

            // Add the play to the playbook.
            this.WuvLuvs.HeadCoach.OffensivePlaybook.Plays.Add(play);
        }

        /// <summary>
        /// Finds the first "pro set" play in the playbook as outlined in assignment 3.1.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void assignment31FindFirstProSetPlayButton_Click(object sender, RoutedEventArgs e)
        {
            // Define a temporary variable.
            Play play = null;

            // Loop through the football team's playbook.
            foreach (Play p in this.WuvLuvs.HeadCoach.OffensivePlaybook.Plays)
            {
                // If "Pro Set" play found.
                if (p.Formation == "Pro Set")
                {
                    // Set the temporary variable to the current play.
                    play = p;

                    // Break out of the loop.
                    break;
                }
            }

            // If play was found.
            if (play != null)
            {
                // Set the play as the team's next play.
                this.WuvLuvs.NextPlay = play;
            }
        }

        /// <summary>
        /// Calculates the offense's average skill level as outlined in assignment 3.1.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void assignment31CalculateOffenseSkillLevelButton_Click(object sender, RoutedEventArgs e)
        {
            // Define a temporary variable to accumulate the skill levels and initialize it with the
            // Joe Cool skill level.
            int skillLevelTotal = this.WuvLuvs.HeadCoach.JoeCool.SkillLevel;

            // Loop through the list of players.
            foreach (Player p in this.WuvLuvs.HeadCoach.JoeCool.OffensiveTeammates)
            {
                skillLevelTotal += p.SkillLevel;
            }

            // Calculate the average skill level and set the team's offense skill level.
            this.WuvLuvs.OffenseSkillLevel = skillLevelTotal / (this.WuvLuvs.HeadCoach.JoeCool.OffensiveTeammates.Count + 1);
        }

        /// <summary>
        /// Performs the initialization tasks outlined in assignment 4.1.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void assignment41NewFootballTeamButton_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the FootballTeam class.
            this.Legomen = new FootballTeam();

            // Set field values of the Legomen.
            this.Legomen.HeadCoach = new Coach();
            this.Legomen.Location = "La Crosse";
            this.Legomen.Name = "La Crosse Legomen";
            this.Legomen.Opponent = new Defense();

            // Set field values of the opponent.
            this.Legomen.Opponent.CoverageType = "Man";
            this.Legomen.Opponent.Formation = "3-4";
            this.Legomen.Opponent.SkillLevel = 8;
            this.Legomen.Opponent.TeamName = "Brookfield Beanie Babies";

            // Set field values of the head coach.
            this.Legomen.HeadCoach.JoeCool = new Quarterback();
            this.Legomen.HeadCoach.Name = "Vince";
            this.Legomen.HeadCoach.OffensivePlaybook = new Playbook();
            this.Legomen.HeadCoach.Salary = 3200m;

            // Set field values of JoeCool.
            this.Legomen.HeadCoach.JoeCool.ArmStrength = 92;
            this.Legomen.HeadCoach.JoeCool.Name = "Joe Cool";
            this.Legomen.HeadCoach.JoeCool.Number = 16;
            this.Legomen.HeadCoach.JoeCool.OffensiveTeammates = new List<Player>();
            this.Legomen.HeadCoach.JoeCool.Salary = 12500860m;
            this.Legomen.HeadCoach.JoeCool.SkillLevel = 93;
            this.Legomen.HeadCoach.JoeCool.Weight = 224.7;

            // Define a temporary player variable.
            Player player;

            // Create an instance of the player class.
            player = new Player();

            // Set field values of the player.
            player.IsEligibleReceiver = true;
            player.Name = "Lloyd";
            player.Number = 78;
            player.Salary = 3764m;
            player.SkillLevel = 87;
            player.Weight = 0.0044;

            // Add the player to JoeCool's offensive teammates list.
            this.Legomen.HeadCoach.JoeCool.OffensiveTeammates.Add(player);

            // Create an instance of the player class.
            player = new Player();

            // Set field values of the player.
            player.IsEligibleReceiver = true;
            player.Name = "Randall Cobb";
            player.Number = 81;
            player.Salary = 875297m;
            player.SkillLevel = 93;
            player.Weight = 191.8;

            // Add the player to JoeCool's offensive teammates list.
            this.Legomen.HeadCoach.JoeCool.OffensiveTeammates.Add(player);

            // Create an instance of the player class.
            player = new Player();

            // Set field values of the player.
            player.IsEligibleReceiver = true;
            player.Name = "Kai";
            player.Number = 88;
            player.Salary = 8782m;
            player.SkillLevel = 30;
            player.Weight = 0.0043;

            // Add the player to JoeCool's offensive teammates list.
            this.Legomen.HeadCoach.JoeCool.OffensiveTeammates.Add(player);

            // Create an instance of the player class.
            player = new Player();

            // Set field values of the player.
            player.IsEligibleReceiver = false;
            player.Name = "Garmadon";
            player.Number = 65;
            player.Salary = 1342m;
            player.SkillLevel = 56;
            player.Weight = 0.0062;

            // Add the player to JoeCool's offensive teammates list.
            this.Legomen.HeadCoach.JoeCool.OffensiveTeammates.Add(player);

            // Create an instance of the player class.
            player = new Player();

            // Set field values of the player.
            player.IsEligibleReceiver = true;
            player.Name = "Darreth";
            player.Number = 23;
            player.Salary = 612m;
            player.SkillLevel = 67;
            player.Weight = 0.0051;

            // Add the player to JoeCool's offensive teammates list.
            this.Legomen.HeadCoach.JoeCool.OffensiveTeammates.Add(player);

            // Set field values of the playbook.
            this.Legomen.HeadCoach.OffensivePlaybook.PageCount = 513;
            this.Legomen.HeadCoach.OffensivePlaybook.Plays = new List<Play>();
            this.Legomen.HeadCoach.OffensivePlaybook.Type = "Offense";

            // Create a temporary play variable.
            Play play;

            // Create an instance of the play class.
            play = new Play();

            // Set field values of the play.
            play.Formation = "Spread";
            play.MaxGain = 74;
            play.MinGain = 16;
            play.Name = "Long Pass";
            play.SuccessRate = 0.33;

            // Add the play to the playbook.
            this.Legomen.HeadCoach.OffensivePlaybook.Plays.Add(play);

            // Create an instance of the play class.
            play = new Play();

            // Set field values of the play.
            play.Formation = "Offset I";
            play.MaxGain = 30;
            play.MinGain = 4;
            play.Name = "Sweep";
            play.SuccessRate = 0.65;

            // Add the play to the playbook.
            this.Legomen.HeadCoach.OffensivePlaybook.Plays.Add(play);

            // Create an instance of the play class.
            play = new Play();

            // Set field values of the play.
            play.Formation = "Pro Set";
            play.MaxGain = 20;
            play.MinGain = 2;
            play.Name = "Counter";
            play.SuccessRate = 0.70;

            // Add the play to the playbook.
            this.Legomen.HeadCoach.OffensivePlaybook.Plays.Add(play);

            // Create an instance of the play class.
            play = new Play();

            // Set field values of the play.
            play.Formation = "Pro Set";
            play.MaxGain = 50;
            play.MinGain = 1;
            play.Name = "Wide-Receiver Screen";
            play.SuccessRate = 0.47;

            // Add the play to the playbook.
            this.Legomen.HeadCoach.OffensivePlaybook.Plays.Add(play);
        }

        /// <summary>
        /// Sets the first "Pro Set" play as the next play as outlined in assignment 4.1.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void assignment41CallProSetPlayNextButton_Click(object sender, RoutedEventArgs e)
        {
            // Define a temporary variable.
            Play play;

            // Find the first "Pro Set" play.
            play = this.FindPlay("Pro Set");

            // Set the next play to be the play that was found (null is acceptable).
            this.Legomen.NextPlay = play;
        }

        /// <summary>
        /// Sets Randall Cobb as the quarterback's target as outlined in assignment 4.1.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void assignment41SetRandallCobbAsTargetButton_Click(object sender, RoutedEventArgs e)
        {
            // Define a temporary variable.
            Player player;

            // Find the player Randall Cobb.
            player = this.FindPlayer("Randall Cobb");

            // If a player was found.
            if (player != null)
            {
                // Set the found player to be the quarterback's target.
                this.Legomen.HeadCoach.JoeCool.Target = player;
            }
        }

        /// <summary>
        /// Performs the initialization tasks outlined in assignment 4.2.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void assignment42NewFootballTeamButton_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the FootballTeam class.
            this.WuvLuvs = new FootballTeam();

            // Set field values of the WuvLuvs.
            this.WuvLuvs.HeadCoach = new Coach();
            this.WuvLuvs.Location = "Wausau";
            this.WuvLuvs.Name = "Wausau Wuv Luvs";
            this.WuvLuvs.Opponent = new Defense();

            // Set field values of the opponent.
            this.WuvLuvs.Opponent.CoverageType = "Man";
            this.WuvLuvs.Opponent.Formation = "3-4";
            this.WuvLuvs.Opponent.SkillLevel = 8;
            this.WuvLuvs.Opponent.TeamName = "LaCrosse Legomen";

            // Set field values of the head coach.
            this.WuvLuvs.HeadCoach.JoeCool = new Quarterback();
            this.WuvLuvs.HeadCoach.Kicker = new Kicker();
            this.WuvLuvs.HeadCoach.Name = "Bart";
            this.WuvLuvs.HeadCoach.OffensivePlaybook = new Playbook();
            this.WuvLuvs.HeadCoach.Salary = 325100m;

            // Set field values of Joe Cool.
            this.WuvLuvs.HeadCoach.JoeCool.ArmStrength = 92;
            this.WuvLuvs.HeadCoach.JoeCool.Name = "Joe Cool";
            this.WuvLuvs.HeadCoach.JoeCool.Number = 16;
            this.WuvLuvs.HeadCoach.JoeCool.OffensiveTeammates = new List<Player>();
            this.WuvLuvs.HeadCoach.JoeCool.Salary = 12500680m;
            this.WuvLuvs.HeadCoach.JoeCool.SkillLevel = 93;
            this.WuvLuvs.HeadCoach.JoeCool.Weight = 224.7;

            // Set field values of the kicker.
            this.WuvLuvs.HeadCoach.Kicker.LegStrength = 55;
            this.WuvLuvs.HeadCoach.Kicker.Name = "Kickalicious";
            this.WuvLuvs.HeadCoach.Kicker.Number = 17;
            this.WuvLuvs.HeadCoach.Kicker.Salary = 550000m;
            this.WuvLuvs.HeadCoach.Kicker.SkillLevel = 76;

            // Define a temporary player variable.
            Player player;

            // Create an instance of the player class.
            player = new Player();

            // Set field values of the player.
            player.IsEligibleReceiver = true;
            player.Name = "Jordy Nelson";
            player.Number = 87;
            player.Salary = 3750264m;
            player.SkillLevel = 96;
            player.Weight = 217.3;

            // Add the player to JoeCool's offensive teammates list.
            this.WuvLuvs.HeadCoach.JoeCool.OffensiveTeammates.Add(player);

            // Create an instance of the player class.
            player = new Player();

            // Set field values of the player.
            player.IsEligibleReceiver = true;
            player.Name = "Randall Cobb";
            player.Number = 18;
            player.Salary = 875297m;
            player.SkillLevel = 93;
            player.Weight = 191.8;

            // Add the player to JoeCool's offensive teammates list.
            this.WuvLuvs.HeadCoach.JoeCool.OffensiveTeammates.Add(player);

            // Create an instance of the player class.
            player = new Player();

            // Set field values of the player.
            player.IsEligibleReceiver = true;
            player.Name = "Jermichael Finley";
            player.Number = 88;
            player.Salary = 8751882m;
            player.SkillLevel = 91;
            player.Weight = 247;

            // Add the player to JoeCool's offensive teammates list.
            this.WuvLuvs.HeadCoach.JoeCool.OffensiveTeammates.Add(player);

            // Create an instance of the player class.
            player = new Player();

            // Set field values of the player.
            player.IsEligibleReceiver = false;
            player.Name = "Evan Dietrich-Smith";
            player.Number = 62;
            player.Salary = 1323442m;
            player.SkillLevel = 74;
            player.Weight = 308.1;

            // Add the player to JoeCool's offensive teammates list.
            this.WuvLuvs.HeadCoach.JoeCool.OffensiveTeammates.Add(player);

            // Create an instance of the player class.
            player = new Player();

            // Set field values of the player.
            player.IsEligibleReceiver = true;
            player.Name = "Eddie Lacy";
            player.Number = 27;
            player.Salary = 616802m;
            player.SkillLevel = 85;
            player.Weight = 229.8;

            // Add the player to JoeCool's offensive teammates list.
            this.WuvLuvs.HeadCoach.JoeCool.OffensiveTeammates.Add(player);

            // Set field values of the playbook.
            this.WuvLuvs.HeadCoach.OffensivePlaybook.PageCount = 315;
            this.WuvLuvs.HeadCoach.OffensivePlaybook.Plays = new List<Play>();
            this.WuvLuvs.HeadCoach.OffensivePlaybook.Type = "Offense";

            // Create a temporary play variable.
            Play play;

            // Create an instance of the play class.
            play = new Play();

            // Set field values of the play.
            play.Formation = "Spread";
            play.MaxGain = 99;
            play.MinGain = 60;
            play.Name = "Hail Mary";
            play.SuccessRate = 0.25;

            // Add the play to the playbook.
            this.WuvLuvs.HeadCoach.OffensivePlaybook.Plays.Add(play);

            // Create an instance of the play class.
            play = new Play();

            // Set field values of the play.
            play.Formation = "Offset I";
            play.MaxGain = 30;
            play.MinGain = 4;
            play.Name = "Sweep";
            play.SuccessRate = 0.65;

            // Add the play to the playbook.
            this.WuvLuvs.HeadCoach.OffensivePlaybook.Plays.Add(play);

            // Create an instance of the play class.
            play = new Play();

            // Set field values of the play.
            play.Formation = "Pro Set";
            play.MaxGain = 20;
            play.MinGain = 2;
            play.Name = "Dive";
            play.SuccessRate = 0.75;

            // Add the play to the playbook.
            this.WuvLuvs.HeadCoach.OffensivePlaybook.Plays.Add(play);

            // Create an instance of the play class.
            play = new Play();

            // Set field values of the play.
            play.Formation = "Pro Set";
            play.MaxGain = 40;
            play.MinGain = 1;
            play.Name = "Screen";
            play.SuccessRate = 0.50;

            // Add the play to the playbook.
            this.WuvLuvs.HeadCoach.OffensivePlaybook.Plays.Add(play);
        }

        /// <summary>
        /// Kicks a field goal as outlined in assignment 4.2.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void assignment42KickFieldGoalButton_Click(object sender, RoutedEventArgs e)
        {
            this.WuvLuvs.KickFieldGoal();
        }

        /// <summary>
        /// Reads the opposing defense as outlined in assignment 4.2.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void assignment42ReadDefenseButton_Click(object sender, RoutedEventArgs e)
        {
            this.WuvLuvs.ReadDefense();
        }
    }
}