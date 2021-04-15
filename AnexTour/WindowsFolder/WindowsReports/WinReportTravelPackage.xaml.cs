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

namespace AnexTour.WindowsFolder.WindowsReports
{
    /// <summary>
    /// Interaction logic for WinReportTravelPackage.xaml
    /// </summary>
    public partial class WinReportTravelPackage : Window
    {
        ClassFolder.ClassDG classDG;
        public WinReportTravelPackage()
        {
            InitializeComponent();
            classDG = new ClassFolder.ClassDG(dgReportTravelPackage);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            classDG.LoadDB("select * from dbo.ViewTravelPackageReports");
        }
    }
}
