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
    /// Interaction logic for WinAdddDirector.xaml
    /// </summary>
    public partial class WinAdddDirector : Window
    {
        SqlConnection sqlConnection =
           new SqlConnection(App.ConnectionString());
        ClassFolder.ClassAdd classAdd;
        public WinAdddDirector()
        {
            InitializeComponent();
            classAdd = new ClassFolder.ClassAdd();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(tbDirectorLastName.Text))
            {
                ClassFolder.ClassMB.MBError("Введите фамилию директора");
                tbDirectorLastName.Focus();
            }
            else if(string.IsNullOrEmpty(tbDirectorFirstName.Text))
            {
                ClassFolder.ClassMB.MBError("Введите имя директора");
                tbDirectorFirstName.Focus();
            }
            else if(string.IsNullOrEmpty(tbDirectorNumberPhone.Text))
            {
                ClassFolder.ClassMB.MBError("Введите номер телефона директора");
                tbDirectorNumberPhone.Focus();
            }
            else if(string.IsNullOrEmpty(tbDirectorEmail.Text))
            {
                ClassFolder.ClassMB.MBError("Введите электронную почту директора");
                tbDirectorEmail.Focus();
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    classAdd.AddDirector(tbDirectorLastName, tbDirectorFirstName, tbDirectorMiddletName,
                        tbDirectorNumberPhone, tbDirectorEmail);
                    ClassFolder.ClassMB.MBInformation("Директор добавлен");
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
