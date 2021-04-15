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
    /// Логика взаимодействия для WinListTourOperator.xaml
    /// </summary>
    public partial class WinListTourOperator : Window
    {
        SqlConnection sqlConnection =
          new SqlConnection(App.ConnectionString());
        SqlCommand sqlCommand;
        ClassFolder.ClassDG classDG;
        public WinListTourOperator()
        {
            InitializeComponent();
            classDG = new ClassFolder.ClassDG(dgListTourOperator);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            classDG.LoadDB("Select * from dbo.ViewTourOperator");
        }

        private void dgListTourOperator_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ClassFolder.TableFolder.ClassTourOperator.IdTourOperator = Int32.Parse(classDG.SelectId());
            if(ClassFolder.TableFolder.ClassTourOperator.IdTourOperator<1)
            {
                ClassFolder.ClassMB.MBInformation("Выберите строку");
            }
            else
            {
                WindowsEdit.WinEditTourOperator winEditTourOperator =
                new WindowsEdit.WinEditTourOperator();
                winEditTourOperator.ShowDialog();
                classDG.LoadDB("Select * from dbo.ViewTourOperator");
            }            
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlConnection.Open();

                sqlCommand = new SqlCommand($"Delete TourOperator " +
                    $"where IdTourOperator='{classDG.SelectId()}'", sqlConnection);
                sqlCommand.ExecuteNonQuery();

                ClassFolder.ClassMB.MBInformation("Клиент удален");

                classDG.LoadDB("Select * from dbo.ViewTourOperator");
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

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbSearch.Text))
            {
                classDG.LoadDB("Select * from dbo.ViewTourOperator");
            }
            else
            {
                classDG.LoadDB($"Select * from dbo.ViewTourOperator " +
               $"where FullNameTourOperator like '%{tbSearch}%'");
            }
        }
    }
}
