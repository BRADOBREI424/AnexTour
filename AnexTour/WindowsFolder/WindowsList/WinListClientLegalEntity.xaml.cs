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
    /// Логика взаимодействия для WinListClientLegalEntity.xaml
    /// </summary>
    public partial class WinListClientLegalEntity : Window
    {
        SqlConnection sqlConnection =
           new SqlConnection(App.ConnectionString());
        SqlCommand sqlCommand;
        ClassFolder.ClassDG classDG;
        public WinListClientLegalEntity()
        {
            InitializeComponent();
            classDG = new ClassFolder.ClassDG(dgListClientLegalEntity);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            classDG.LoadDB("Select * from dbo.ViewClientLegalEntity");
        }

        private void dgListClientLegalEntity_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ClassFolder.TableFolder.ClassClient.IdClientLegalEntity = Int32.Parse(classDG.SelectId());
            if(ClassFolder.TableFolder.ClassClient.IdClientLegalEntity<1)
            {
                ClassFolder.ClassMB.MBInformation("Выберите строку");
            }
            else
            {
                WindowsEdit.WinEditClientLegalEntity winEditClientLegalEntity =
                new WindowsEdit.WinEditClientLegalEntity();
                winEditClientLegalEntity.ShowDialog();
                classDG.LoadDB("Select * from dbo.ViewClientLegalEntity");
            }            
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlConnection.Open();

                sqlCommand = new SqlCommand($"Delete ClientLegalEntity " +
                    $"where IdClientLegalEntity='{classDG.SelectId()}'", sqlConnection);
                sqlCommand.ExecuteNonQuery();

                ClassFolder.ClassMB.MBInformation("Клиент удален");

                classDG.LoadDB("Select * from dbo.ViewClientLegalEntity");
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
                classDG.LoadDB("Select * from dbo.ViewClientLegalEntity");
            }
            else
            {
                classDG.LoadDB($"Select * from dbo.ViewClientLegalEntity " +
               $"where FullName like '%{tbSearch}%'");
            }
        }
    }
}
