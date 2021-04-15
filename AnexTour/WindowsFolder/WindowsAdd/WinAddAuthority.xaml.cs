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
    /// Логика взаимодействия для WinAddAuthority.xaml
    /// </summary>
    public partial class WinAddAuthority : Window
    {
        SqlConnection sqlConnection =
            new SqlConnection(App.ConnectionString());
        SqlCommand sqlCommand;
        public WinAddAuthority()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAddAuthority_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbAddAuthority.Text))
            {
                ClassFolder.ClassMB.MBError("Введите город");
                tbAddAuthority.Focus();
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("Insert into " +
                        "dbo.TheAuthorityThatIssuedThePassport " +
                        "(NameAuthority) " +
                        "Values (@NameAuthority)", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("NameAuthority", tbAddAuthority.Text);
                    sqlCommand.ExecuteNonQuery();
                    ClassFolder.ClassMB.MBInformation("Орган добавлена");
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
