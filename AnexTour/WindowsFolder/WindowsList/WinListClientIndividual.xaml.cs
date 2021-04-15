using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace AnexTour.WindowsFolder.WindowsList
{
    /// <summary>
    /// Логика взаимодействия для WinListClientIndividual.xaml
    /// </summary>
    public partial class WinListClientIndividual : Window
    {
        SqlConnection sqlConnection =
           new SqlConnection(App.ConnectionString());
        SqlCommand sqlCommand;
        ClassFolder.ClassDG classDG;
        public WinListClientIndividual()
        {
            InitializeComponent();
            classDG = new ClassFolder.ClassDG(dgListClientIndividual);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            classDG.LoadDB("Select * from dbo.ViewClientIndividual");
        }

        private void dgListClientIndividual_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ClassFolder.TableFolder.ClassClient.IdClientIndividual = Int32.Parse(classDG.SelectId());
            if(ClassFolder.TableFolder.ClassClient.IdClientIndividual<1)
            {
                ClassFolder.ClassMB.MBInformation("Выберите строку");
            }
            else
            {
                WindowsEdit.WinEditClientIndividual winEditClientIndividual =
                new WindowsEdit.WinEditClientIndividual();
                winEditClientIndividual.ShowDialog();
                classDG.LoadDB("Select * from dbo.ViewClientIndividual");
            }                     
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(string.IsNullOrEmpty(tbSearch.Text))
            {
                classDG.LoadDB("Select * from dbo.ViewClientIndividual");
            }
            else
            {
                classDG.LoadDB($"Select * from dbo.ViewClientIndividual " +
               $"where Surname like '%{tbSearch}%'");
            }                      
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlConnection.Open();

                sqlCommand = new SqlCommand($"Delete ClientIndividual where Id='{classDG.SelectId()}'",sqlConnection);
                sqlCommand.ExecuteNonQuery();

                ClassFolder.ClassMB.MBInformation("Клиент удален");

                classDG.LoadDB("Select * from dbo.ViewClientIndividual");
            }
            catch (Exception ex)
            {
                ClassFolder.ClassMB.MBError(ex);                
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
