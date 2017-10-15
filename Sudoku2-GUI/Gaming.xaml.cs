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
using System.Windows.Threading;

namespace Sudoku2_GUI
{
    /// <summary>
    /// Gaming.xaml 的交互逻辑
    /// </summary>
    public partial class Gaming : Page
    {
        public const double B = 2;
        public const double S = 0.5;
        public const double FB = 25;
        public const double FS = 20;
        public const double FSS = 16;
        public SolidColorBrush startColor = new SolidColorBrush(Color.FromRgb(220, 220, 220));
        public SolidColorBrush chooseColor = new SolidColorBrush(Color.FromRgb(255, 255, 0));
        public SolidColorBrush noChangeColor = new SolidColorBrush(Color.FromRgb(190, 190, 190));
        public SolidColorBrush helpColor = new SolidColorBrush(Color.FromRgb(255, 0, 0));
        public SolidColorBrush Black = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        String lastChoice;
        int count = 0;
        int seconds = 0;
        int[,] noChange = new int[9, 9];
        public Gaming()
        {
            InitializeComponent();

            seconds = 0;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += TimeTick; //你的事件
            timer.Start();

            int i, j;
            String s;
            //设置边界
            for (i = 0; i < 9; i++)
            {
                for (j = 0; j < 9; j++)
                {
                    s = ("B" + i) + j;
                    //(this.FindName(s) as Button).Content = (s);
                    if (i % 3 == 0)
                    {
                        if (j % 3 == 0)
                            (this.FindName(s) as Button).BorderThickness = new Thickness(B, B, S, S);
                        else if (j % 3 == 2)
                            (this.FindName(s) as Button).BorderThickness = new Thickness(S, B, B, S);
                        else
                            (this.FindName(s) as Button).BorderThickness = new Thickness(S, B, S, S);
                    }
                    else if (i % 3 == 2)
                    {
                        if (j % 3 == 0)
                            (this.FindName(s) as Button).BorderThickness = new Thickness(B, S, S, B);
                        else if (j % 3 == 2)
                            (this.FindName(s) as Button).BorderThickness = new Thickness(S, S, B, B);
                        else
                            (this.FindName(s) as Button).BorderThickness = new Thickness(S, S, S, B);
                    }
                    else
                    {
                        if (j % 3 == 0)
                            (this.FindName(s) as Button).BorderThickness = new Thickness(B, S, S, S);
                        else if (j % 3 == 2)
                            (this.FindName(s) as Button).BorderThickness = new Thickness(S, S, B, S);
                        else
                            (this.FindName(s) as Button).BorderThickness = new Thickness(S, S, S, S);
                    }
                }
            }

            //显示数独

            for (i = 0; i < 9; i++)
            {
                for (j = 0; j < 9; j++)
                {
                    s = ("B" + i) + j;
                    if (Start.GUIpuzzle[0][i, j] != 0)
                    {
                        (this.FindName(s) as Button).Content = (Start.GUIpuzzle[0][i, j]);
                        (this.FindName(s) as Button).FontSize = FB;
                        (this.FindName(s) as Button).FontWeight = FontWeights.Bold;
                        (this.FindName(s) as Button).Background = noChangeColor;
                        noChange[i, j] = 1;
                    }
                    else
                    {
                        (this.FindName(s) as Button).Content = (" ");
                        count++;
                        if (count == 1)
                        {
                            lastChoice = s;
                        }

                        noChange[i, j] = 0;
                    }
                }
            }
            if (lastChoice == null)
            {
                lastChoice = "B00";
            }
            (this.FindName(lastChoice) as Button).Background = chooseColor;
            
            Core.SudokuFounctionLibrary.solve(Start.GUIpuzzle[0], ref Start.solvedPuzzle);

        }

        void TimeTick(object sender, EventArgs e)
        {
            textBox.Text = "Difficulty: " + Start.mode + "; Time: " + seconds.ToString() + " s";
            seconds++;
        }

        void choose(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            char c1 = button.Name[1];
            char c2 = button.Name[2];
            if (noChange[c1 - '0', c2 - '0'] == 0)
            {
                (this.FindName(lastChoice) as Button).Background = startColor;
                lastChoice = button.Name;

                (this.FindName(lastChoice) as Button).Background = chooseColor;

            }
        }

        void fill(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            char c = button.Name[1];
            char c1 = lastChoice[1];
            char c2 = lastChoice[2];
            if (noChange[c1 - '0', c2 - '0'] == 0)
            {
                if (c == 'C')
                {
                    (this.FindName(lastChoice) as Button).Content = (" ");
                }
                else if (c == 'H')
                {
                    (this.FindName(lastChoice) as Button).Content = Start.solvedPuzzle[lastChoice[1] - '0', lastChoice[2] - '0'];
                    (this.FindName(lastChoice) as Button).FontSize = FSS;
                    (this.FindName(lastChoice) as Button).FontStyle = FontStyles.Italic;
                    (this.FindName(lastChoice) as Button).Foreground = helpColor;
                }
                else
                {
                    (this.FindName(lastChoice) as Button).Content = c;
                    (this.FindName(lastChoice) as Button).FontSize = FS;
                    (this.FindName(lastChoice) as Button).FontStyle = FontStyles.Normal;
                    (this.FindName(lastChoice) as Button).Foreground = Black;
                }
            }
        }

        private void BS_Click(object sender, RoutedEventArgs e)
        {
            int i, j;
            for (i = 0; i < 9; i++)
            {
                for (j = 0; j < 9; j++)
                {
                    var s = ("B" + i) + j;
                    try
                    {
                        var n = Int32.Parse((this.FindName(s) as Button).Content.ToString());
                        if (n != Start.solvedPuzzle[i, j])
                        {
                            MessageBox.Show(String.Format("Not a right answer; check mistake at ({0}, {1}). Your time spent: {2} s", i + 1, j + 1, seconds));
                            return;
                        }
                    }
                    catch(FormatException)
                    {
                        MessageBox.Show(String.Format("Not a right answer; check mistake at ({0}, {1}). Your time spent: {2} s", i + 1, j + 1, seconds));
                        return;
                    }
                }
            }
            MessageBox.Show(String.Format("Congradulations! Your time spent: {0} s", seconds));

            switch (Start.mode)
            {
                case 1:
                    if (seconds < Properties.Settings.Default.BestRecordEasy)
                        Properties.Settings.Default.BestRecordEasy = seconds;
                    break;
                case 2:
                    if (seconds < Properties.Settings.Default.BestRecordMedium)
                        Properties.Settings.Default.BestRecordMedium = seconds;
                    break;
                case 3:
                    if (seconds < Properties.Settings.Default.BestRecordHard)
                        Properties.Settings.Default.BestRecordHard = seconds;
                    break;
                default:
                    break;
            }
            Properties.Settings.Default.Save();
        }
    }
}
