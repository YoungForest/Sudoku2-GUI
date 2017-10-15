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
using Core;

namespace Sudoku2_GUI
{
    /// <summary>
    /// Interaction logic for Start.xaml
    /// </summary>
    public partial class Start : Page
    {
        public static int[][,] GUIpuzzle = new int[1][,];
        public static int[,] solvedPuzzle = new int[9,9];
        public static int mode;
       
        public Start()
        {
            InitializeComponent();
            

            EasyComboBoxItem.IsSelected = true;
            mode = 1;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EasyComboBoxItem.IsSelected)
            {
                mode = 1;
            }
            if (MediumComboBoxItem.IsSelected)
            {
                mode = 2;
            }
            if (HardComboBoxItem.IsSelected)
            {
                mode = 3;
            }
        }

        private void BeginGameButton_Click(object sender, RoutedEventArgs e)
        {
            if (EasyComboBoxItem.IsSelected)
            {
                mode = 1;
            }
            if (MediumComboBoxItem.IsSelected)
            {
                mode = 2;
            }
            if (HardComboBoxItem.IsSelected)
            {
                mode = 3;
            }

            SudokuFounctionLibrary.generate(1, mode, ref GUIpuzzle);

            NavigationWindow window = new NavigationWindow();

            window.Source = new Uri("Gaming.xaml", UriKind.Relative);
            window.Height = 750;
            window.Width = 600;
            window.Show();


        }

        private void BestRecordButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationWindow windowR = new NavigationWindow();

            windowR.Source = new Uri("BestRecord.xaml", UriKind.Relative);
            windowR.Height = 300;
            windowR.Width = 300;
            windowR.Show();
        }
    }
}
