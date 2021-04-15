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

namespace AnexTour.WindowsFolder
{
    /// <summary>
    /// Логика взаимодействия для WinAddCity.xaml
    /// </summary>
    public partial class WinAddCity : Window
    {
        SqlConnection sqlConnection =
            new SqlConnection(App.ConnectionString());
        SqlCommand sqlCommand;
        ClassFolder.ClassCB classCB;
        public WinAddCity()
        {
            InitializeComponent();
            classCB = new ClassFolder.ClassCB();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAddCity_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbAddCity.Text))
            {
                ClassFolder.ClassMB.MBError("Введите город");
                tbAddCity.Focus();
            }
            else
            {
                try
                {

                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("Insert into dbo.City " +
                        "(NameCity, IdRegion) " +
                        "Values (@NameCity, @IdRegion)", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("NameCity", tbAddCity.Text);
                    sqlCommand.Parameters.AddWithValue("Idregion", Int32.Parse(cbRegion.SelectedValue.ToString()));
                    sqlCommand.ExecuteNonQuery();
                    ClassFolder.ClassMB.MBInformation("Город добавлен");
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            classCB.LoadRegion(cbRegion);
        }
    }
}
