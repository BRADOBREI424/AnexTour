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

namespace AnexTour.WindowsFolder
{
    /// <summary>
    /// Логика взаимодействия для WinTourAgent.xaml
    /// </summary>
    public partial class WinTourAgent : Window
    {
        public WinTourAgent()
        {
            InitializeComponent();
        }

        private void mniAddClientIndividual_Click(object sender, RoutedEventArgs e)
        {
           WinAddClientIndividual winAddClientIndividual =
                new WinAddClientIndividual();
            winAddClientIndividual.ShowDialog();
        }

        private void mniBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();            
        }

        private void mniAddClientLegalEntity_Click(object sender, RoutedEventArgs e)
        {
            WinClientLegalEntity winClientLegalEntity =
                new WinClientLegalEntity();
            winClientLegalEntity.ShowDialog();
        }       

        private void mniAddTourOperator_Click(object sender, RoutedEventArgs e)
        {
            WinAddTourOperator winAddTourOperator =
               new WinAddTourOperator();
            winAddTourOperator.ShowDialog();
        }

        private void mniListClientIndividual_Click(object sender, RoutedEventArgs e)
        {
            WindowsList.WinListClientIndividual winListClientIndividual =
                new WindowsList.WinListClientIndividual();
            winListClientIndividual.ShowDialog();
        }

        private void mniListClientLegalEntity_Click(object sender, RoutedEventArgs e)
        {
            WindowsList.WinListClientLegalEntity winListClientLegalEntity =
                new WindowsList.WinListClientLegalEntity();
            winListClientLegalEntity.ShowDialog();
        }

        private void mniListTourOperator_Click(object sender, RoutedEventArgs e)
        {
            WindowsList.WinListTourOperator winListTourOperator =
                new WindowsList.WinListTourOperator();
            winListTourOperator.ShowDialog();
        }

        private void mniVouchers_Click(object sender, RoutedEventArgs e)
        {
            WindowsReports.WinReportTravelPackage winReportTravelPackage =
                new WindowsReports.WinReportTravelPackage();
            winReportTravelPackage.ShowDialog();
        }

        private void mniTourOperator_Click(object sender, RoutedEventArgs e)
        {
            WindowsReports.WinReportTourOperator winReportTourOperator =
                new WindowsReports.WinReportTourOperator();
            winReportTourOperator.ShowDialog();
        }

        private void mniClientIndividual_Click(object sender, RoutedEventArgs e)
        {
            WindowsTravelPackage.WinTravelPackageClientIndividual
                winTravelPackageClientIndividual =
                new WindowsTravelPackage.WinTravelPackageClientIndividual();
            winTravelPackageClientIndividual.ShowDialog();
        }

        private void mniClientLegalEntity_Click(object sender, RoutedEventArgs e)
        {
            WindowsTravelPackage.WinTravelPackageClientLegalEntity
                winTravelPackageClientLegal =
                new WindowsTravelPackage.WinTravelPackageClientLegalEntity();
            winTravelPackageClientLegal.ShowDialog();
        }
    }
}
