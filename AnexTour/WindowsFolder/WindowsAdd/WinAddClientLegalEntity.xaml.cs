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
    /// Логика взаимодействия для WinClientLegalEntity.xaml
    /// </summary>
    public partial class WinClientLegalEntity : Window
    {
        SqlConnection sqlConnection =
            new SqlConnection(App.ConnectionString());
        ClassFolder.ClassCB classCB;
        ClassFolder.ClassAdd classAdd;
        ClassFolder.ClassRead classRead;
        public WinClientLegalEntity()
        {
            InitializeComponent();
            classCB = new ClassFolder.ClassCB();
            classAdd = new ClassFolder.ClassAdd();
            classRead = new ClassFolder.ClassRead();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            classCB.LoadAddress(cbAddressRegistration);
            classCB.LoadAddress(cbAddressLocation);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAddCityRegistration_Click(object sender, RoutedEventArgs e)
        {
            WinAddCity winAddCity = new WinAddCity();
            winAddCity.ShowDialog();
        }

        private void btnAddCityLocation_Click(object sender, RoutedEventArgs e)
        {
            WinAddCity winAddCity = new WinAddCity();
            winAddCity.ShowDialog();
        }

        private void btnAddStreetLocation_Click(object sender, RoutedEventArgs e)
        {
            WinAddStreet winAddStreet = new WinAddStreet();
            winAddStreet.ShowDialog();
        }

        private void btnAddStreetRegistration_Click(object sender, RoutedEventArgs e)
        {
            WinAddStreet winAddStreet = new WinAddStreet();
            winAddStreet.ShowDialog();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(tbFullName.Text))
            {
                ClassFolder.ClassMB.MBError("Введите наименование");
                tbFullName.Focus();
            }
            else if(string.IsNullOrEmpty(tbNumberPhone.Text))
            {
                ClassFolder.ClassMB.MBError("Введите номер телефона организации");
                tbNumberPhone.Focus();
            }
            else if(string.IsNullOrEmpty(tbEmail.Text))
            {
                ClassFolder.ClassMB.MBError("Введите электронную почту организации");
                tbEmail.Focus();
            }
            else if(string.IsNullOrEmpty(tbINN.Text))
            {
                ClassFolder.ClassMB.MBError("Введите ИНН");
                tbINN.Focus();
            }
            else if(string.IsNullOrEmpty(tbOKPO.Text))
            {
                ClassFolder.ClassMB.MBError("Введите ОКПО");
                tbOKPO.Focus();
            }
            
            else if(string.IsNullOrEmpty(tbDirectorLastName.Text))
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
                    classRead.ReadAddressRegistration(cbAddressRegistration);
                    classRead.ReadAddressLocation(cbAddressLocation);
                    classAdd.AddDirector(tbDirectorLastName, tbDirectorFirstName, tbDirectorMiddletName,
                        tbDirectorNumberPhone, tbDirectorEmail);
                    classRead.ReadDirector(tbDirectorLastName, tbDirectorFirstName, tbDirectorMiddletName,
                        tbDirectorNumberPhone, tbDirectorEmail);
                    
                    classAdd.AddClientLegalentity(tbFullName, tbNumberPhone, tbEmail, tbINN, tbOKPO);
                    ClassFolder.ClassMB.MBInformation("Клиент добавлен");
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

        private void btnAddAddressRegistration_Click(object sender, RoutedEventArgs e)
        {
            WinAddAddress winAddAddress = new WinAddAddress();
            winAddAddress.ShowDialog();
        }

        private void btnAddAddressLocation_Click(object sender, RoutedEventArgs e)
        {
            WinAddAddress winAddAddress = new WinAddAddress();
            winAddAddress.ShowDialog();
        }
    }
}
