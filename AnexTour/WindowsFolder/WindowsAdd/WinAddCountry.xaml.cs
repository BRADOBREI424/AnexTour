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

namespace AnexTour.WindowsFolder.WindowsAdd
{
    /// <summary>
    /// Interaction logic for WinAddCountry.xaml
    /// </summary>
    public partial class WinAddCountry : Window
    {
        SqlConnection sqlConnection =
            new SqlConnection(App.ConnectionString());
        SqlCommand sqlCommand;
        public WinAddCountry()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAddCity_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbAddCountry.Text))
            {
                ClassFolder.ClassMB.MBError("Введите город");
                tbAddCountry.Focus();
            }
            else if(string.IsNullOrEmpty(tbAddVisaPrice.Text))
            {
                ClassFolder.ClassMB.MBError("Введите стоимость визы");
                tbAddVisaPrice.Focus();
            }            
            else
            {
                try
                {

                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("Insert into dbo.Country " +
                        "(CountryName, VisaPrice) " +
                        "Values (@CountryName, @VisaPrice)", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("CountryName", tbAddCountry.Text);
                    sqlCommand.Parameters.AddWithValue("VisaPrice", tbAddVisaPrice.Text);
                    sqlCommand.ExecuteNonQuery();
                    ClassFolder.ClassMB.MBInformation("Страна добавлена");
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
}
