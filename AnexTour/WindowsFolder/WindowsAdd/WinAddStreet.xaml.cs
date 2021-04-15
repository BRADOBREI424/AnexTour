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
    /// Логика взаимодействия для WinAddStreet.xaml
    /// </summary>
    public partial class WinAddStreet : Window
    {
        SqlConnection sqlConnection =
           new SqlConnection(App.ConnectionString());
        SqlCommand sqlCommand;
        public WinAddStreet()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAddStreet_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbAddStreet.Text))
            {
                ClassFolder.ClassMB.MBError("Введите улицу");
                tbAddStreet.Focus();
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("Insert into dbo.Street " +
                        "(NameStreet) " +
                        "Values (@NameStreet)", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("NameStreet", tbAddStreet.Text);
                    sqlCommand.ExecuteNonQuery();
                    ClassFolder.ClassMB.MBInformation("Улица добавлена");
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
