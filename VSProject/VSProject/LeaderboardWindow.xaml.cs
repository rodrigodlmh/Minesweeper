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
            StreamReader streamreader = new StreamReader("leaderboard.txt");

            while (!streamreader.EndOfStream)
            {
                string line = streamreader.ReadLine();
                string[] split = line.Split('\t');

                Leaderboard leaderboard1 = new Leaderboard();
                if (float.TryParse(split[0], out leaderboard1.score))
                {

                }
                leaderboard1.initials = split[1];

                leaderboards.Add(leaderboard1);
            }
            streamreader.Close();
        }

        private void WriteFile()
        {
            List<Leaderboard> highscores = new List<Leaderboard>();
            LeaderboardLB.Items.Add("Name\t" + "Score\t");
            foreach (Leaderboard lb in leaderboards)
            {
                if (highscores.Count >= 5)
                {
                    int validCount = 0;
                    int lowestScoreIndex = 0;
                    int lowestScore = 1000000000;
                    for (int i = 0; i < highscores.Count; i++)
                    {
                        if (highscores[i].score < lowestScore)
                        {
                            lowestScoreIndex = i;
                        }

                        if (lb.score > highscores[i].score)
                        {
                            validCount++;
                        }
                    }

                    if (validCount == highscores.Count)
                    {
                        highscores[lowestScoreIndex] = lb;
                    }
                }
                else
                {
                    highscores.Add(lb);
                }
            }

            foreach(Leaderboard lb in highscores)
            {
                LeaderboardLB.Items.Add(lb.initials + '\t' + lb.score);
            }
        }
    }
}
