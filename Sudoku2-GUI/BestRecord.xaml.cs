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
            if (App.BestRecordEasy == -1)
            {
                EazyRecord.Text = "暂无";
            }
            else
            {
                EazyRecord.Text = App.BestRecordEasy.ToString() + "s";
            }
            if (App.BestRecordMedium == -1)
            {
                MediumRecord.Text = "暂无";
            }
            else
            {
                MediumRecord.Text = App.BestRecordMedium.ToString() + "s";
            }
            if (App.BestRecordHard == -1)
            {
                HardRecord.Text = "暂无";
            }
            else
            {
                HardRecord.Text = App.BestRecordHard.ToString() + "s";
            }
            
            
        }
    }
}
