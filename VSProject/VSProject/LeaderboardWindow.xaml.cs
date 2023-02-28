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
using System.IO;

namespace VSProject
{
    /// <summary>
    /// Interaction logic for LeaderboardWindow.xaml
    /// </summary>
    public partial class LeaderboardWindow : Window
    {
        List<Leaderboard> leaderboards;
        public LeaderboardWindow()
        {
            InitializeComponent();
            leaderboards = new List<Leaderboard>();
            ReadFile();
            WriteFile();
        }

        private void ReadFile()
        {
            StreamReader streamreader = new StreamReader("Leaderboard.txt");

            while (!streamreader.EndOfStream)
            {
                string line = streamreader.ReadLine();
                string[] split = line.Split(' ');

                Leaderboard leaderboard1 = new Leaderboard();
                leaderboard1.time = split[0];
                leaderboard1.initials = split[1];
                leaderboard1.revealedSquares = split[2];
                leaderboard1.gridsize = split[3];
                leaderboard1.score = split[4];
               
                leaderboards.Add(leaderboard1);
            }
        }

        private void WriteFile()
        {
            LeaderboardLB.Items.Add("Score\t" + "Grid size\t" + "Initials\t" + "Time\t" + "Revealed Squares");
            foreach (Leaderboard lb in leaderboards)
            {
                LeaderboardLB.Items.Add(lb.score + lb.gridsize + lb.initials + lb.time + lb.revealedSquares);

            }
        }
    }
}
