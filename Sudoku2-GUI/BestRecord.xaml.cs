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

namespace Sudoku2_GUI
{
    /// <summary>
    /// Interaction logic for BestRecord.xaml
    /// </summary>
    public partial class BestRecord : Page
    {
        public BestRecord()
        {
            InitializeComponent();

            int BestRecordEasy = Properties.Settings.Default.BestRecordEasy;
            int BestRecordMedium = Properties.Settings.Default.BestRecordMedium;
            int BestRecordHard = Properties.Settings.Default.BestRecordHard;
            if (BestRecordEasy == Int32.MaxValue)
            {
                EazyRecord.Text = "暂无";
            }
            else
            {
                EazyRecord.Text = BestRecordEasy.ToString() + "s";
            }
            if (BestRecordMedium == Int32.MaxValue)
            {
                MediumRecord.Text = "暂无";
            }
            else
            {
                MediumRecord.Text = BestRecordMedium.ToString() + "s";
            }
            if (BestRecordHard == Int32.MaxValue)
            {
                HardRecord.Text = "暂无";
            }
            else
            {
                HardRecord.Text = BestRecordHard.ToString() + "s";
            }
            
            
        }
    }
}
