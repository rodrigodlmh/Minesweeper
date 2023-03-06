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
                string[] split = line.Split(' ');
                if (split.Length <= 1)
                {
                    return;
                }
                Leaderboard leaderboard1 = new Leaderboard();
                leaderboard1.initials = split[0];
                if(float.TryParse(split[1], out leaderboard1.score))
                {

                }

                leaderboards.Add(leaderboard1);
            }
            streamreader.Close();
        }

        private void WriteFile()
        {
            LeaderboardLB.Items.Add("Highscores");
            LeaderboardLB.Items.Add("Name\t" + "Score");
            LoserboardLB.Items.Add("Low scores");
            LoserboardLB.Items.Add("Name\t" + "Score");

            leaderboards.Sort((x, y) => x.score.CompareTo(y.score));

            int length = leaderboards.Count();
            if (length > 5)
            {
                length = 5;
            }

            for (int i = leaderboards.Count() - 1; i >= leaderboards.Count() - length; i--)
            {
                LeaderboardLB.Items.Add(leaderboards[i].initials + '\t' + leaderboards[i].score);
            }

            for (int j = 0; j < length; j++)
            {
                LoserboardLB.Items.Add(leaderboards[j].initials + '\t' + leaderboards[j].score);
            }
        }
    }
}
