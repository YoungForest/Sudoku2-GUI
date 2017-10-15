using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Sudoku2_GUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static int BestRecordEasy = Int32.MaxValue;
        public static int BestRecordMedium = Int32.MaxValue;
        public static int BestRecordHard = Int32.MaxValue;
        public static Frame f;
    }
}
