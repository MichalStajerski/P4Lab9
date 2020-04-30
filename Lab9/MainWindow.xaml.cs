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

namespace Lab9
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml 
    /// </summary>
    public partial class MainWindow : Window
    {
        private int votesCount = 0;
        Dictionary<string, int> options = new Dictionary<string,int>
        {
            {"A",0 },
            {"B",0 },
            {"C",0 },
            {"D",0 }
        };


        public MainWindow()
        {
            InitializeComponent();
            TextBlock.Text = "Wolisz litere A, B, C czy D?";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var choice = button.Content.ToString();
            options[choice]++;
            votesCount++;

            var canvasHeight = Canvas.ActualHeight;
            
            var scoreA = (double)options["A"] / votesCount;
            var scoreB = (double)options["B"] / votesCount;
            var scoreC = (double)options["C"] / votesCount;
            var scoreD = (double)options["D"] / votesCount;


            RA.Height = canvasHeight = scoreA;
            RB.Height = canvasHeight = scoreB;
            RC.Height = canvasHeight = scoreC;
            RD.Height = canvasHeight = scoreD;

            Canvas.SetBottom(LA, canvasHeight = scoreA);
            Canvas.SetBottom(LB, canvasHeight = scoreB);
            Canvas.SetBottom(LC, canvasHeight = scoreC);
            Canvas.SetBottom(LD, canvasHeight = scoreD);

            LA.Content = (scoreA *100).ToString("F2")+ "%";
            LB.Content = (scoreB * 100).ToString("F2") + "%";
            LC.Content = (scoreC * 100).ToString("F2") + "%";
            LD.Content = (scoreD * 100).ToString("F2") + "%";




            allVotesTextBox.Text = votesCount.ToString();
            maxVotes.Text = options.Max(x=>x.Value).ToString();
            
        }

        
    }
}
